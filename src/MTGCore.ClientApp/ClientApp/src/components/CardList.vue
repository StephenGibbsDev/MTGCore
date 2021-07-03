<template>
  <div class="list-group card-table">
    <div v-for="item in card" v-bind:Key="item.id" class="card-container">
      <div class="card-image-container">
        <img :src="item.imageUrl" width="140" />
      </div>

      <div class="card-information-container">
        <div class="block-text card-container-header">
          <h6 class="card-container-heading-text">{{ item.name }}</h6>
          <div style="display: flex;">
            <ManaCost :size="14" :manaSymbols="item.manaSymbols" />
          </div>
        </div>

        <div class="card-information-subtext">
          <span class="card-subtext">{{ item.type }}</span>
        </div>

        <div class="card-actions" @click="addToDeck(item.id)">
          <i class="fas fa-plus fa-3x"></i>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ManaCost from "./ManaCost.vue";

export default {
  props: ["card"],
  components: {
    ManaCost,
  },
  methods: {
    addToDeck(id) {
      this.$emit("addCardToDeck", id);
    },
  },
};
</script>

<style scoped>
.card-table {
  background-color: var(--light-grey);
  height: 100%;
}

.card-container {
  background-color: var(--light-grey);
  border-bottom: 2px solid #efefef;
  display: flex;
  flex-direction: row;
}

.card-container:hover {
  background-color: white;
}

.card-container:hover .card-actions {
  border-color: white;
}

.card-container .card-image-container {
  display: flex;
  padding: 10px;
  justify-content: center;
}

.card-container .card-container-header {
  display: flex;
  align-items: center;
}

.card-container .card-container-heading-text {
  margin: 0;
  flex-grow: 1;
  font-size: 14px;
}

.block-text {
  padding: 5px;
  background-color: #efefef;
}

.card-container .card-information-subtext {
  margin: 2px 0 10px 0;
  display: block;
  border-left: 2px solid #efefef;
}

.card-container .card-subtext {
  font-size: 10px;
  text-align: center;
  padding: 5px;
  font-style: italic;
}

.card-container .card-actions {
  transition: all 0.3s ease;
  display: flex;
  flex-grow: 1;
  justify-content: center;
  align-items: center;
  border-radius: 3px;
  cursor: pointer;
  color: #efefef;
  border: 1px solid var(--light-grey);
}

.card-container .card-actions:hover {
  color: var(--primary);
  border-color: var(--primary);
}

.card-information-container {
  width: 100%;
  padding: 10px 10px 10px 0;
  display: flex;
  flex-direction: column;
}
</style>
