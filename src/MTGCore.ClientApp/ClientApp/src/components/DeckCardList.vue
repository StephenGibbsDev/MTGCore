<template>
  <div v-if="visible">
    <div class="grid-container">
      <div
        class="grid-item"
        v-for="item in visibleCards"
        v-bind:Key="item.card.id"
      >
        <div class="tilt-container" v-tilt>
          <img :src="item.card.imageUrl" height="310" />
          <div class="tilt-container-actions">
            <span @click="removeCard(item)" class="icon fa-stack" title="Remove card from deck" >
              <i class="fas fa-square fa-stack-2x"></i>
              <i class="fas fa-times fa-stack-1x fa-inverse"></i>
            </span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vue from "vue";
import VueTilt from "vue-tilt.js";
Vue.use(VueTilt);

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

      let cards = [];
      cardList.cards.forEach(function (card) {
        for (let i = 0; i < card.quantity; i++) {
          cards.push({ card: card, deletionRequestSent: false });
        }
      });
      return cards;
    },
  }
};
</script>

<style scoped>
.grid-container {
  display: grid;
  grid-template-columns: auto auto auto auto;
  background: #eee;
}

.grid-item {
  background: #eee;
  text-align: center;
  border: 1px solid #e9e9e9;
}

.tilt-container {
  padding: 30px 0;
  transform-style: preserve-3d;
}

.grid-item:hover {
  background: #e9e9e9;
}

.tilt-container-actions {
  position: absolute;
  display: none;
  transform: translateZ(20px);
  width: 100%;
}

.grid-item:hover .tilt-container-actions {
  display: block;
}

.icon {
  cursor: pointer;
}
</style>