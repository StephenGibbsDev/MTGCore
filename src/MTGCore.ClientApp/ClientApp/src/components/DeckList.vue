<template>
    <div>
        <div class="form-group row" style="margin-bottom:0px">
            <div class="input-group">
                <div class="input-group-prepend float-right">
                    <button @click="openmodal" type="button" class="btn btn-default input-group-text">Add New Deck</button>
                </div>
                <select class="form-control float-right col-lg-9" @change="onchange" v-model="selectedOption">
                    <option v-for="item in deckList" v-bind:Key="item.id" v-bind:value="item.id">{{item.title}}</option>
                </select>
            </div>
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