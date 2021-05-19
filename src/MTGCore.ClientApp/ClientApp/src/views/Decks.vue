<template>
  <div id="deck-container" class="fill-height">
    <div style="display: flex; height: 100%;">
      <div style="border-right: 1px solid #dee2e6; flex-basis: 600px; overflow-x: hidden">
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
          <ResultsTable v-on:addCardToDeck="addToDeck" v-bind:post="searchedCards"/>
        </form>
        <div v-if="searchInProgress" style="width: 100%; text-align: center; padding: 20px;">
          <div class="spinner-border" role="status">
            <span class="sr-only">Loading...</span>
          </div>
        </div>
        <div class="alert alert-danger" role="alert" v-if="searchedCardsLoadingError">{{
            searchedCardsLoadingError
          }}
        </div>
      </div>
      <div style="flex-grow: 1;">
        <div style="padding: 10px;">
          <h3>Cards in Deck</h3>
          <div>
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

<script>
import DeckCardList from '@/components/DeckCardList.vue'
import ResultsTable from "@/components/ResultsTable.vue";
import DeckList from "@/components/DeckList.vue";
import axios from "axios";

import '../assets/css/Decks.css';

export default {
  name: 'Decks',
  components: {
    ResultsTable,
    DeckCardList,
    DeckList
  },
  data: function () {
    return {
      Name: "",
      searchedCards: null,
      searchedCardsLoadingError: "",
      searchInProgress: false,
      deckCards: null,
      deckList: null,
      selectedDeck: null
    };
  },
  methods: {
    addNewDeck(title) {
      const params = new URLSearchParams();
      params.append('title', title);

      axios({
        method: "post",
        url: `https://localhost:44305/api/Deck/New`,
        data: params
      })
          .then(res => {
            this.updateDeckCardList(res.data);
            this.updateDeckList();
            // Set selected dropdown value to new deck ID
            this.selectedDeck = res.data;
            // Set textbox val back to empty string
            this.$refs.deckListRef.resetNewDeckName();
          })
          .catch(err => {
            alert(`There was an error submitting your form. See details: ${err}`);
          });
    },
    addToDeck(id) {
      axios({
        method: "post",
        url: `https://localhost:44305/api/Deck/Add/${this.selectedDeck}/${id}`,
        data: this.$data
      })
          .then(() => {
            this.updateDeckCardList(this.selectedDeck);
          })
          .catch(err => {
            alert(`There was an error submitting your form. See details: ${err}`);
          });
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
    updateDeckCardList(id) {
      this.selectedDeck = id;
      axios({
        method: "get",
        //todo: make this call based on the selected dropdown ID
        url: `https://localhost:44305/api/Deck/${id}`,
        data: this.$data
      })
          .then(res => {
            this.deckCards = res.data;
          })
          .catch(err => {
            alert(`There was an error submitting your form. See details: ${err}`);
          });
    },
    updateDeckList() {
      axios({
        method: "get",
        url: "https://localhost:44305/api/Deck",
        data: this.$data
      })
          .then(res => {
            this.deckList = res.data;
          })
          .catch(err => {
            alert(`There was an error submitting your form. See details: ${err}`);
          });
    }
  },
  mounted() {
    // this.updateDeckCardList(this.selectedDeck);
    // this.updateDeckList();
  }
}
</script>