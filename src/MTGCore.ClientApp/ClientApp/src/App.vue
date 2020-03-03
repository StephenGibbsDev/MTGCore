<template>
  <div id="app">
    <!-- <HelloWorld msg="this test is amazing"/> -->
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-6">
          <div class="card">
            <div class="card-header">Featured</div>
            <div class="card-body">
              <form id="form">
                <div class="form-group">
                  <label for="exampleInputEmail1">Search for card</label>
                  <div class="input-group mb-3">
                    <input
                      v-model="Name"
                      type="text"
                      class="form-control"
                      placeholder="Search"
                      aria-label="Card Name"
                      aria-describedby="basic-addon2"
                    />
                    <div class="input-group-append">
                      <button
                        class="btn btn-outline-secondary"
                        type="button"
                        v-on:click="SubmitForm"
                      >Button</button>
                    </div>
                  </div>
                  <small id="emailHelp" class="form-text text-muted">Lorem Ipsum Dolar set ammet</small>
                </div>
                <ResultsTable v-on:addCardToDeck="addToDeck" v-bind:post="post" />
              </form>
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
                    v-on:triggerChange="updateDeckCardList"
                    v-bind:deckList="deckList"
                  />
                </div>
              </div>
            </div>
            <div class="card-body">
              <DeckCardList v-bind:deckCards="deckCards" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ResultsTable from "./components/ResultsTable.vue";
import DeckCardList from "./components/DeckCardList.vue";
import DeckList from "./components/DeckList.vue";

import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";

export default {
  name: "app",
  computed: {
    ListofCards() {
      return this.post;
    }
  },
  data: function() {
    return {
      Name: "",
      post: null,
      deckCards: null,
      deckList: null,
      selectedDeck: null
    };
  },
  components: {
    ResultsTable,
    DeckCardList,
    DeckList
  },
  methods: {
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
      axios({
        method: "post",
        url: "https://localhost:44305/api/Search/",
        data: this.$data
      })
        .then(res => {
          this.post = res.data;
        })
        .catch(err => {
          alert(`There was an error submitting your form. See details: ${err}`);
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
    this.updateDeckCardList(this.selectedDeck);
    this.updateDeckList();
  }
};
</script>