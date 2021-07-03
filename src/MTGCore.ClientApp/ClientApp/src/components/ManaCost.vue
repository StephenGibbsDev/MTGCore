<template>
    <div class="mana-symbol-container">
        <span v-for="(symbol, index) in manaSymbols" :key="index">
            <img :src="loadImage(symbol.imageName)" v-bind:width="size" v-bind:height="size" alt="Mana Symbol" />
        </span>
    </div>
</template>

<script>
    import "bootstrap";
    import "bootstrap/dist/css/bootstrap.min.css";

    export default {
      props: {
        manaSymbols: Array,
        size: {
          type: Number,
          required: false,
          default: 20
        }
      },
      methods: {
        loadImage(imageName) {
          return require(`../assets/images/mana-symbols/${imageName}`);
        }
      }
    };
</script>

<style scoped>
.mana-symbol-container {
  display: flex;
}
</style>