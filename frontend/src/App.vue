<template>
  <div id="app">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-6">
          <div class="card">
            <div class="card-header">Featured</div>
            <div class="card-body">
              <form>
                <div class="form-group">
                  <label for="exampleInputEmail1">Email address</label>
                  <input
                    type="email"
                    class="form-control"
                    id="exampleInputEmail1"
                    aria-describedby="emailHelp"
                    placeholder="Enter email"
                  />
                  <small
                    id="emailHelp"
                    class="form-text text-muted"
                  >We'll never share your email with anyone else.</small>
                </div>
                <table class="table">
                  <thead>
                    <tr>
                      <th scope="col">#</th>
                      <th scope="col">Card</th>
                      <th scope="col">Mana</th>
                      <th scope="col">Type</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <th scope="row">1</th>
                      <td>Shock</td>
                      <td>{R}{1}</td>
                      <td>instant</td>
                    </tr>
                    <tr>
                      <th scope="row">2</th>
                      <td>Naturize</td>
                      <td>{G}{2}</td>
                      <td>Sorcery</td>
                    </tr>
                    <tr>
                      <th scope="row">3</th>
                      <td>Ajani's Pridemate</td>
                      <td>{W}{1}</td>
                      <td>Cat-Soldier</td>
                    </tr>
                  </tbody>
                </table>
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
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

export default {
  name: "app",
  components: {
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
