<template>
  <transition name="modal" v-if="ShowModal">
    <div
      class="modal"
      id="TitleModal"
      style="display: block; background-color: rgba(0, 0, 0, 0.5); transition: opacity 0.3s ease"
    >
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h4 class="modal-title">Search filtering options</h4>
            <button @click="close" type="button" id="btnCloseTitleModal" class="close pull-right">&times;</button>
          </div>

          <div class="modal-body">
            <div class="row form-group">
              <div class="col-lg-2">Type:</div>
              <div class="col-lg-10">
                <input v-model="form.type" type="text" class="form-control" />
              </div>
            </div>
            <hr />
            <div class="row form-group">
              <div class="col-lg-2">Colours:</div>
              <div class="col-lg-10">
                <select
                  v-model="form.coloursOption"
                  class="form-control form-select form-select-lg"
                  aria-label="Are exactly"
                >
                  <option value="Exactly">Are exactly</option>
                </select>
              </div>
            </div>

            <div class="row form-group">
              <div class="form-check form-inline col-md-2">
                <input v-model="form.colours" class="form-check-input" type="checkbox" value="W" id="chkWhite" />
                <label class="form-check-label" for="chkWhite">W</label>
              </div>
              <div class="form-check form-inline col-md-2">
                <input v-model="form.colours" class="form-check-input" type="checkbox" value="U" id="chkBlue" />
                <label class="form-check-label" for="chkBlue">U</label>
              </div>
              <div class="form-check form-inline col-md-2">
                <input v-model="form.colours" class="form-check-input" type="checkbox" value="B" id="chkBlack" />
                <label class="form-check-label" for="chkBlack">B</label>
              </div>
              <div class="form-check form-inline col-md-2">
                <input v-model="form.colours" class="form-check-input" type="checkbox" value="R" id="chkRed" />
                <label class="form-check-label" for="chkRed">R</label>
              </div>
              <div class="form-check form-inline col-md-2">
                <input v-model="form.colours" class="form-check-input" type="checkbox" value="G" id="chkGreen" />
                <label class="form-check-label" for="chkGreen">G</label>
              </div>
              <div class="form-check form-inline col-md-2">
                <input v-model="form.colours" class="form-check-input" type="checkbox" value="C" id="chkColourless" />
                <label class="form-check-label" for="chkColourless">C</label>
              </div>
            </div>

            <hr />

            <div class="row form-group">
              <div class="col-lg-2">Rarity:</div>
              <div class="col-lg-10">
                <select v-model="form.rarity" class="form-control form-select form-select-lg">
                  <option selected value="Uncommon">Uncommon</option>
                  <option value="Uncommon">Common</option>
                  <option value="Uncommon">Mythic Rare</option>
                  <option value="Uncommon">Rare</option>
                </select>
              </div>
            </div>

            <div class="row form-group">
              <div class="col-lg-2">Set:</div>
              <div class="col-lg-10">
                <input v-model="form.set" type="text" class="form-control" />
              </div>
            </div>

            <div class="row form-group">
              <div class="col-lg-2">Price:</div>
              <div class="col-lg-10">
                <input v-model="form.price" type="text" class="form-control" />
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-warning">Clear</button>
            <button v-on:click="submitFilter" type="button" class="btn btn-primary">Submit</button>
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
      form: {
        type: '',
        coloursOption: '',
        colours: [],
        rarity: '',
        set: '',
        price: '',
      },
    };
  },
  methods: {
    open: function () {
      this.ShowModal = true;
    },
    close: function () {
      this.ShowModal = false;
    },
    submitFilter: function () {
      this.$emit('submitFilter', this.form)
    },
  },
};
</script>