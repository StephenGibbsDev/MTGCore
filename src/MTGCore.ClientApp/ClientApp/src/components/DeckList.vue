<template>
  <div class="form-group row" style="margin-bottom:0px">
    <label class="col-lg-3">Deck</label>
    <select class="form-control float-right col-lg-9">
      <option v-for="item in deckList" v-bind:Key="item.id">{{item.title}}</option>
    </select>
  </div>
</template> 

<script>
export default {
  props: ["deckList"],
  components: {}
};
</script>