<template>
  <div v-if="visible">
    <ul class="list-group">
      <li
        class="list-group-item d-flex justify-content-between align-items-center"
        v-for="item in visibleCards"
        v-bind:Key="item.card.id"
      >
        {{ item.card.name }}
        <span
          @click="removeCard(item)"
          class="btn btn-primary"
          >Remove</span
        >
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  props: ["deck"],
  data() {
    return {
      cardList: this.calculateCards(this.deck),
    };
  },
  computed: {
    visible: function () {
      return this.cardList;
    },
    visibleCards: function () {
      return this.cardList.filter((x) => x.deletionRequestSent === false);
    },
  },
  watch: {
    deck: function (newVal) {
      this.cardList = this.calculateCards(newVal);
    },
  },
  methods: {
    removeCard: function (card) {
      card.deletionRequestSent = true;
      this.$emit("cardRemoved", card.card.id);
    },
    calculateCards: function (cardList) {
      if (!cardList) {
        return;
      }
      
      var cards = [];
      cardList.cards.forEach(function (card) {
        for (let i = 0; i < card.quantity; i++) {
          cards.push({ card: card, deletionRequestSent: false });
        }
      });
      return cards;
    },
  },
};
</script>