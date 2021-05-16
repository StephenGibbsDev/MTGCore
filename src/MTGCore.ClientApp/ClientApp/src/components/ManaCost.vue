<template>
    <div>
        <span v-for="(symbol, index) in manaSymbols" :key="index">
            <img :src="loadImage(symbol.imageName)" width="20" height="20" alt="Mana Symbol" />
        </span>
    </div>
</template>

<script>
    import "bootstrap";
    import "bootstrap/dist/css/bootstrap.min.css";

    export default {
      props: {
        manaSymbols: []
      },
      methods: {
        loadImage(imageName) {
          return require(`../assets/images/mana-symbols/${imageName}`);
        }
      }
    };
</script>