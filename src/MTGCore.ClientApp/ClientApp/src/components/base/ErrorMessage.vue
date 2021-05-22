<template>
  <div class="alert-container" v-if="visible">
    <div class="alert alert-danger" role="alert">
      {{
        message
      }}
    </div>
  </div>
</template>

<script>
export default {
  name: "ErrorMessage",
  props: {
    message: {
      type: String,
      required: false
    },
    visible: {
      type: Boolean,
      required: true
    }
  }
}
</script>

<style scoped>
.alert-container {
  position: absolute;
  width: 100%;
  height: 100%;
  padding: 10px;
  z-index: 2;
}
</style>