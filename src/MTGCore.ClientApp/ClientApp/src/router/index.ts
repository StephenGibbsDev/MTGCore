import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Decks from '../views/Decks.vue'

Vue.use(VueRouter)

// TODO(CD): Investigate this
// https://router.vuejs.org/guide/advanced/lazy-loading.html
// const DeckComponent = import(/* webpackChunkName: "about" */ '../views/Decks.vue');

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/decks', name: 'Decks', component: Decks }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
