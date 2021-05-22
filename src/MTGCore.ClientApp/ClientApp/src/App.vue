<template>
  <div id="app">
    <nav id="nav" class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">MTG</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <router-link to="/">Home</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/decks">Decks</router-link>
          </li>
        </ul>
        <form class="form-inline my-2 my-lg-0">
          <a class="nav-item-right">Login</a>
          <a class="nav-item-right">Register</a>
        </form>
      </div>
    </nav>
    <router-view/>
  </div>
</template>

<style scoped>
* {
  --primary: #42b983;
  --gray: #2c3e50;
  --light-grey: #f8f9fa;
}
</style>

<script>
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import './assets/css/Main.css';

export default {
  name: "app"
}
</script>