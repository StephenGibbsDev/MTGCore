<template>
  <div class="list-group card-table">
    <div v-for="item in card" v-bind:Key="item.id" class="card-container">
      <div class="card-image-container">
        <img :src="item.imageUrl" width="200"/>
      </div>
      
      <div class="block-text card-container-header">
        <h6 class="card-container-heading-text">{{ item.name }}</h6>
        <ManaCost :size="14" :manaSymbols="item.manaSymbols"/>
      </div>

      <div class="icon-bar">
        <span class="icon text">{{ item.type }}</span>
        <span class="icon-divider"></span>
        <span @click="addToDeck(item.id)" class="icon action">Add</span>
      </div>
    </div>
  </div>
</template>

<script>
import ManaCost from "./ManaCost.vue";

export default {
  props: ["card"],
  components: {
    ManaCost
  },
  methods: {
    addToDeck(id) {
      this.$emit("addCardToDeck", id);
    }
  }
};
</script>

<style scoped>
.card-table {
  background-color: var(--light-grey);
  height: 100%;
}

.card-container {
  background-color: var(--light-grey);
  padding: 10px;
  border-bottom: 2px solid #EFEFEF;
}

.card-container:hover {
  background-color: white;
}

.card-image-container {
  display: flex;
  padding: 10px;
  justify-content: center;
}

.card-container-header {
  display: flex;
  align-items: center;
}

.card-container-heading-text {
  margin: 0;
  flex-grow: 1;
  font-size: 14px;
}

.block-text {
  padding: 5px;
  background-color: #EFEFEF;
}

.icon-bar {
  margin-top: 2px;
  display: flex;
  border-left: 2px solid #EFEFEF;
}

.icon-bar .icon {
  font-size: 10px;
  text-align: center;
  padding: 5px;
}

.icon-bar .icon.text {
  font-style: italic;
}

.icon-bar .icon.action {
  transition: all 0.3s ease;
  background-color: #EFEFEF;
}

.icon-bar .icon.action:hover {
  background-color: var(--primary);
  cursor: pointer;
}

.icon-bar .icon-divider {
  flex-grow: 1;
}
</style>