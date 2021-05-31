<template>
        <div class="form-group" style="margin-bottom: 0">
            <div class="input-group">
                <div class="input-group-prepend">
                    <button @click="openModal" type="button" class="btn btn-default input-group-text">New Deck</button>
                </div>
                <select class="form-control" @change="onchange" v-model="selectedOption">
                    <option v-for="item in deckList" v-bind:Key="item.id" v-bind:value="item.id">{{item.title}}</option>
                </select>
            </div>
          <DeckNewModal ref="NewDeckRef" v-on:addDeckClick="addNewDeck"></DeckNewModal>
        </div>
</template> 

<script>
    import DeckNewModal from "./DeckNewModal.vue";

    export default {  
        props: {
            deckList: Array,
            selectedOption: String
        },
        components: {
            DeckNewModal
        },
        methods: {
            openModal: function () {
                this.$refs.NewDeckRef.open()
            },
            onchange: function () {
                this.$emit("triggerChange", this.selectedOption);
            },
            addNewDeck: function (data) {
                this.$emit("addDeck", data);
            },
            resetNewDeckName: function () {
                this.$refs.NewDeckRef.deckname = '';
            }
        }
    };
</script>