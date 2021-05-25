<template>
  <div v-if="visible" :class="backgroundClass">
    <div class="spinner-border" role="status">
      <span class="sr-only">Loading...</span>
    </div>
  </div>
</template>

<script>
const classMap = {
  dark: "Dark",
  transparent: "Transparent"
};

export default {
  name: "Loader",
  props: {
    visible: {
      type: Boolean,
      required: true
    },
    background: {
      type: String,
      default: "transparent",
      required: false
    }
  },
  computed: {
    backgroundClass: function() {
      // Default to transparent class
      const backgroundClass = classMap[this.background] || 'Transparent';
      return `Loader ${backgroundClass}`;
    }
  }
}
</script>

<style scoped>
.Loader {
  position: absolute;
  width: 100%;
  padding: 20px;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 2;
}

.Loader.Dark {
  background-color: rgba(120, 120, 120, 0.5);
}
</style>