<template>
        <div class="form-group" style="margin-bottom: 0">
            <div class="input-group">
                <div class="input-group-prepend">
                    <button @click="openmodal" type="button" class="btn btn-default input-group-text">New Deck</button>
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
            selectedOption: Number
        },
        components: {
            DeckNewModal
        },
        methods: {
            openmodal: function () {
                this.$refs.NewDeckRef.open()
            },
            onchange: function () {
                this.$emit("triggerChange", this.selectedOption);
            },
            addNewDeck: function (title) {
                this.$emit("addDeck", title);
            },
            resetNewDeckName: function () {
                this.$refs.NewDeckRef.deckname = '';
            }
        },
        events: {
            triggerChange: function (event) {
                alert("DETECTED CHANGE " + event);
            },
            addDeck: function (event) {
                alert("DECK ADDED " + event);
            }
        }
    };
</script>