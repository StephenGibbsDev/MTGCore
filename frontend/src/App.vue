<template>
  <div id="app">
    <!-- <HelloWorld msg="this test is amazing"/> -->
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-6">
          <div class="card">
            <div class="card-header">Featured</div>
            <div class="card-body">
              <form>
                <div class="form-group">
                  <label for="exampleInputEmail1">Search for card</label>
                  <div class="input-group mb-3">
                    <input
                      type="text"
                      class="form-control"
                      placeholder="Search"
                      aria-label="Card Name"
                      aria-describedby="basic-addon2"
                    />
                    <div class="input-group-append">
                      <button class="btn btn-outline-secondary" type="button">Button</button>
                    </div>
                  </div>
                  <small id="emailHelp" class="form-text text-muted">Lorem Ipsum Dolar set ammet</small>
                </div>
              <ResultsTable/>
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
// import HelloWorld from './components/HelloWorld.vue'
import ResultsTable from './components/ResultsTable.vue'
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

export default {
  name: "app",
  components: {
    ResultsTable
    // HelloWorld
  }
};
</script>

<style>
/* .row > div {
  background: lightgrey;
  border: 1px solid grey;
} */
</style>
