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
                <ResultsTable v-for="post in posts" v-bind:key="post.id" v-bind:post="post"/>
              </form>
            </div>
          </div>
        </div>
        <div class="col-lg-6">decks ting</div>
      </div>
    </div>
  </div>
</template>

<script>
import ResultsTable from "./components/ResultsTable.vue";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";

export default {
  name: "app",
  props: ['post'],
  data: function() {
    return {
      Name: ""
    };
  },
  components: {
    ResultsTable
    // HelloWorld
  },
  methods: {
    SubmitForm() {
      axios({
        method: "post",
        url: "https://localhost:44305/api/Search/",
        data: this.$data
      })
        .then(res => {
          alert("Successfully submitted feedback form");
          this.post = res.data;
        })
        .catch(err => {
          alert(`There was an error submitting your form. See details: ${err}`);
        });
    }
  }
};
</script>

<style>
/* .row > div {
  background: lightgrey;
  border: 1px solid grey;
} */
</style>
