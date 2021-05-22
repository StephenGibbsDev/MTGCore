<template>
  <div id="deck-container" class="fill-height overflow-y-hidden">
    <div style="display: flex; height: 100%;">
      <div style="border-right: 1px solid #dee2e6; flex-basis: 400px; overflow: hidden; display: flex; flex-direction: column;">
        <div>
          <form id="form" v-on:submit.prevent="">
            <div class="form-group search-container md">
              <div class="input-group">
                <input v-model="Name"
                       v-on:keyup.enter="SubmitForm"
                       id="card-search"
                       type="text"
                       class="form-control"
                       placeholder="Search for a card"
                       aria-label="Card Search"
                       aria-labelledby="card-search-title"/>
                <div class="input-group-append">
                  <button class="btn btn-default input-group-text"
                          type="button"
                          v-on:click="SubmitForm">
                    Search
                  </button>
                </div>
              </div>
            </div>
          </form>
        </div>
        <div class="overflow-y-auto" style="height: 100%; position: relative;">
          <Loader :visible="SearchInProgress" :background="'Dark'" />
          <ErrorMessage :visible="!!SearchedCardsLoadingError" :message="SearchedCardsLoadingError" />
          <CardList v-on:addCardToDeck="addToDeck" v-bind:card="SearchedCards"/>
        </div>
      </div>
      <div style="flex-grow: 1;">
        <div class="form-group search-container md" style="display: flex;">
          <div style="flex-grow: 1;">
            
          </div>
          <div style="width: 300px;">
            <DeckList ref="deckListRef"
                      v-on:triggerChange="updateDeckCardList"
                      v-on:addDeck="addNewDeck"
                      v-bind:deckList="Decks"
                      v-bind:selectedOption="SelectedDeck"/>
          </div>
        </div>
        <div class="card-body">
          <DeckCardList v-bind:deckCards="CardsInDeck"/>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import DeckCardList from '../components/DeckCardList.vue'
import CardList from "../components/CardList.vue";
import DeckList from "../components/DeckList.vue";
import Loader from "../components/base/Loader.vue";
import ErrorMessage from "../components/base/ErrorMessage.vue";
import DeckService from "../services/deck";
import axios from 'axios';
import Vue from "vue";

interface Data {
  Name: string,
  SearchedCards: any,
  SearchedCardsLoadingError: string | null,
  SearchInProgress: boolean,
  CardsInDeck: any,
  Decks: any,
  SelectedDeck: number | null
}

export default Vue.extend({
  name: 'Decks',
  components: {
    CardList,
    DeckCardList,
    DeckList,
    Loader,
    ErrorMessage
  },
  data(): Data {
    return {
      Name: '',
      SearchedCards: null,
      SearchedCardsLoadingError: '',
      SearchInProgress: false,
      CardsInDeck: null,
      Decks: null,
      SelectedDeck: null
    };
  },
  methods: {
    async addNewDeck(title: string) {
      const newDeckId = await DeckService.createDeck(title);
      await this.updateDeckCardList(newDeckId);
      await this.updateDeckList();
      // Set textbox val back to empty string
      (this.$refs.deckListRef as any).resetNewDeckName();
    },
    async addToDeck(cardId: string) {
      if (!this.SelectedDeck) {
        throw new Error("No deck is selected!");
      }
      
      await DeckService.addCardToDeck(this.SelectedDeck, cardId);
      await this.updateDeckCardList(this.SelectedDeck);
    },
    SubmitForm() {
      this.SearchInProgress = true;
      this.SearchedCards = null;
      this.SearchedCardsLoadingError = null;
      axios({
        method: "post",
        url: "https://localhost:44305/api/Search/",
        data: this.$data
      })
          .then(res => {
            this.SearchedCards = res.data;
          })
          .catch(err => {
            this.SearchedCardsLoadingError = `Something went wrong: ${err}`;
          })
          .finally(() => {
            this.SearchInProgress = false;
          });
    },
    async updateDeckCardList(id: number) {
      this.CardsInDeck = await DeckService.getDeckById(id);
      this.SelectedDeck = id;
    },
    async updateDeckList() {
      this.Decks = await DeckService.getDecks();
    }
  },
  mounted() {
    this.updateDeckList();
    if (this.Decks && this.Decks.length > 0) {
      // TODO(CD): Can probably set their selected deck to the most recently viewed one?
      // Storing it in the local memory may be simplest or in the DB
      // this.updateDeckCardList(this.SelectedDeck);
    }
  }
})
</script>

<style scoped>
.search-container.md {
  margin: 0;
  padding: 10px;
  box-shadow: 0px 3px 1px 0px rgb(222, 226, 230);
  position: relative;
  z-index: 1;
}
</style>