<template>
  <div class="form-group row" style="margin-bottom:0px">
    <label class="col-lg-3">Deck</label>
    <select class="form-control float-right col-lg-9" @change="onchange" v-model="selectedOption">
      <option v-for="item in deckList" v-bind:Key="item.id" v-bind:value="item.id">{{item.title}}</option>
    </select>
  </div>
</template> 

<script>
export default {
  data: function() {
    return {
      selectedOption: undefined
    };
  },
  props: ["deckList"],
  components: {},
  methods: {
    onchange: function() {
      this.$emit("triggerChange", this.selectedOption);
    }
  },
  events: {
    triggerChange: function(event) {
      alert("DETECTED CHANGE " + event);
    }
  }
};
</script>