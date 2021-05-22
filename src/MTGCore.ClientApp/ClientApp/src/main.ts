import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import CardService from "./services/card";
import DeckService from "./services/deck";

Vue.config.productionTip = false

const baseUrl = process.env.VUE_APP_API_BASE_URL;
if (!baseUrl) throw new Error('Base url is not set-up');
    
CardService.init(baseUrl);
DeckService.init(baseUrl);

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
