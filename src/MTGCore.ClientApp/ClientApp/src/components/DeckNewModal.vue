<template>
  <transition name="modal" v-if="ShowModal">
    <div class="modal" id="TitleModal"
         style="display: block; background-color: rgba(0, 0, 0, 0.5); transition: opacity 0.3s ease;">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h4 class="modal-title">Add a new deck</h4>
            <button @click="close" type="button" id="btnCloseTitleModal" class="close pull-right">&times;</button>
          </div>
          <div class="modal-body">
            Title <span class="small" style="color: indianred;">*</span>
            <input type="text" class="form-control" v-model="deckName"/>
            Description
            <textarea class="form-control" v-model="description"/>
          </div>
          <div class="modal-footer">
            <button :disabled="!canSubmit" @click="addDeckClick" type="button" class="btn btn-primary">Add</button>
            <button @click="close" type="button" class="btn btn-primary">Close</button>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  data: function () {
    return {
      ShowModal: false,
      deckName: '',
      description: ''
    };
  },
  computed: {
    canSubmit: function() {
      return !!this.deckName;
    }
  },
  methods: {
    addDeckClick: function () {
      // Not sure about emitting the event here, by emitting, it could lead to duplicate code
      // in each page where this component is used. To abide by the principle of DRY, is 
      // making the API call in this component better?
      this.close();
      this.$emit("addDeckClick", { Title: this.deckName, Description: this.description});
    },
    open: function () {
      this.ShowModal = true;
    },
    close: function () {
      this.ShowModal = false;
    }
  }
};
</script>