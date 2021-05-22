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
          <Loader :visible="searchInProgress" :background="'Dark'" />
          <ErrorMessage :visible="!!searchedCardsLoadingError" :message="searchedCardsLoadingError" />
          <CardList v-on:addCardToDeck="addToDeck" v-bind:card="searchedCards"/>
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
                      v-bind:deckList="deckList"
                      v-bind:selectedOption="selectedDeck"/>
          </div>
        </div>
        <div class="card-body">
          <DeckCardList v-bind:deckCards="deckCards"/>
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

export default {
  name: 'Decks',
  components: {
    CardList,
    DeckCardList,
    DeckList,
    Loader,
    ErrorMessage
  },
  data: function () {
    return {
      Name: "",
      searchedCards: null,
      searchedCardsLoadingError: null,
      searchInProgress: false,
      deckCards: null,
      deckList: null,
      selectedDeck: null
    };
  },
  methods: {
    async addNewDeck(title) {
      const newDeckId = await DeckService.createDeck(title);
      this.updateDeckCardList(newDeckId);
      this.updateDeckList();
      // Set textbox val back to empty string
      this.$refs.deckListRef.resetNewDeckName();
    },
    async addToDeck(cardId) {
      await DeckService.addCardToDeck(this.selectedDeck, cardId);
      this.updateDeckCardList(this.selectedDeck);
    },
    SubmitForm() {
      this.searchInProgress = true;
      this.searchedCards = null;
      this.searchedCardsLoadingError = null;
      axios({
        method: "post",
        url: "https://localhost:44305/api/Search/",
        data: this.$data
      })
          .then(res => {
            this.searchedCards = res.data;
          })
          .catch(err => {
            this.searchedCardsLoadingError = `Something went wrong: ${err}`;
          })
          .finally(() => {
            this.searchInProgress = false;
          });
    },
    async updateDeckCardList(id) {
      this.deckCards = await DeckService.getDeckById(id);
      this.selectedDeck = id;
    },
    async updateDeckList() {
      this.deckList = await DeckService.getDecks();
    }
  },
  mounted() {
    this.updateDeckList();
    if (this.deckList && this.deckList.length > 0) {
      alert('Hit');
      this.updateDeckCardList(this.selectedDeck);
    }
  }
}
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