<template>
  <ul v-if="deckCards.cards">
    <li v-for="item in deckCards.cards" v-bind:Key="item.card.multiverseid">{{item.amount}} X {{item.card.name}}</li>
  </ul>
</template>

<script>
export default {
  props: ["deckCards"],
  components: {}
};
</script>