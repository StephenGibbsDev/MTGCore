<template>
  <div id="app">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-6">
          <div class="card">
            <div class="card-header">Featured</div>
            <div class="card-body">
              <form id="form" v-on:submit.prevent="">
                <div class="form-group">
                  <label id="card-search-title" for="card-search">Search for card</label>
                  <div class="input-group mb-3">
                    <input
                      v-model="Name"
                      v-on:keyup.enter="SubmitForm"
                      id="card-search"
                      type="text"
                      class="form-control"
                      placeholder="Search"
                      aria-label="Card Search"
                      aria-labelledby="card-search-title"
                    />
                    <div class="input-group-append">
                      <button class="btn btn-outline-secondary" type="button" @click="openmodal">Filter</button>
                      <button class="btn btn-outline-secondary" type="button" v-on:click="SubmitForm">Button</button>
                    </div>
                  </div>
                </div>
                <ResultsTable v-on:addCardToDeck="addToDeck" v-bind:post="searchedCards" />
              </form>
              <div v-if="searchInProgress" style="width: 100%; text-align: center; padding: 20px">
                <div class="spinner-border" role="status">
                  <span class="sr-only">Loading...</span>
                </div>
              </div>
              <div class="alert alert-danger" role="alert" v-if="searchedCardsLoadingError">
                {{ searchedCardsLoadingError }}
              </div>
            </div>
          </div>
        </div>
        <div class="col-lg-6">
          <div class="card">
            <div class="card-header">
              <div class="row">
                <div class="col-lg-6">Cards in Deck</div>
                <div class="col-lg-6">
                  <DeckList
                    ref="deckListRef"
                    v-on:triggerChange="updateDeckCardList"
                    v-on:addDeck="addNewDeck"
                    v-bind:deckList="deckList"
                    v-bind:selectedOption="selectedDeck"
                  />
                </div>
              </div>
            </div>
            <div class="card-body">
              <DeckCardList v-bind:deckCards="deckCards" />
            </div>
          </div>
        </div>
        <SearchFilterModal v-on:submitFilter="SetSearchFilter" ref="SearchFilterRef"></SearchFilterModal>
      </div>
    </div>
  </div>
</template>

<script>
import ResultsTable from './components/ResultsTable.vue';
import DeckCardList from './components/DeckCardList.vue';
import DeckList from './components/DeckList.vue';
import SearchFilterModal from './components/SearchFilterModal.vue';
import './assets/css/Main.css';

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';

export default {
  name: 'app',
  data: function () {
    return {
      Name: '',
      searchedCards: null,
      searchedCardsLoadingError: '',
      searchInProgress: false,
      deckCards: null,
      deckList: null,
      selectedDeck: null,
      searchFilter: null,
    };
  },
  components: {
    ResultsTable,
    DeckCardList,
    DeckList,
    SearchFilterModal,
  },
  methods: {
    SetSearchFilter(value) {
      this.searchFilter = value;
    },
    openmodal: function () {
      this.$refs.SearchFilterRef.open();
    },
    addNewDeck(title) {
      var params = new URLSearchParams();
      params.append('title', title);

      axios({
        method: 'post',
        url: `https://localhost:44305/api/Deck/New`,
        data: params,
      })
        .then((res) => {
          this.updateDeckCardList(res.data);
          this.updateDeckList();
          // Set selected dropdown value to new deck ID
          this.selectedDeck = res.data;
          // Set textbox val back to empty string
          this.$refs.deckListRef.resetNewDeckName();
        })
        .catch((err) => {
          alert(`There was an error submitting your form. See details: ${err}`);
        });
    },
    addToDeck(id) {
      axios({
        method: 'post',
        url: `https://localhost:44305/api/Deck/Add/${this.selectedDeck}/${id}`,
        data: this.$data,
      })
        .then(() => {
          this.updateDeckCardList(this.selectedDeck);
        })
        .catch((err) => {
          alert(`There was an error submitting your form. See details: ${err}`);
        });
    },
    SubmitForm() {
      this.searchInProgress = true;
      this.searchedCards = null;
      this.searchedCardsLoadingError = null;


      var filter = {}
      filter["SearchFilter"] = this.searchFilter;
      filter["SearchFilter"].Name = this.Name;

      axios({
        method: 'post',
        url: 'https://localhost:44305/api/Search/',
        data: filter,
      })
        .then((res) => {
          this.searchedCards = res.data;
        })
        .catch((err) => {
          this.searchedCardsLoadingError = `Something went wrong: ${err}`;
        })
        .finally(() => {
          this.searchInProgress = false;
        });
    },
    updateDeckCardList(id) {
      this.selectedDeck = id;
      axios({
        method: 'get',
        //todo: make this call based on the selected dropdown ID
        url: `https://localhost:44305/api/Deck/${id}`,
        data: this.$data,
      })
        .then((res) => {
          this.deckCards = res.data;
        })
        .catch((err) => {
          alert(`There was an error submitting your form. See details: ${err}`);
        });
    },
    updateDeckList() {
      axios({
        method: 'get',
        url: 'https://localhost:44305/api/Deck',
        data: this.$data,
      })
        .then((res) => {
          this.deckList = res.data;
        })
        .catch((err) => {
          alert(`There was an error submitting your form. See details: ${err}`);
        });
    },
  },
  mounted() {
    this.updateDeckCardList(this.selectedDeck);
    this.updateDeckList();
  },
};
</script>