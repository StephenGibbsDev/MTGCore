<template>
    <div>
        <div class="form-group row" style="margin-bottom:0px">
            <div class="input-group">
                <div class="input-group-prepend float-right">
                    <input type="button" class="btn btn-default input-group-text" value="Add New Deck" data-toggle="modal" data-target="#TitleModal">
                </div>
                <select class="form-control float-right col-lg-9" @change="onchange" v-model="selectedOption">
                    <option v-for="item in deckList" v-bind:Key="item.id" v-bind:value="item.id">{{item.title}}</option>
                </select>
            </div>
        </div>

        <!-- TODO: Consider installing Vue Bootstrap and using a VB modal -->
        <div class="modal fade" id="TitleModal" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add a new deck</h4>
                        <button type="button" id="btnCloseTitleModal" class="close pull-right" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        Title
                        <input type="text" class="form-control" v-model="deckname" />
                    </div>
                    <div class="modal-footer">
                        <button @click="adddeckclick" type="button" class="btn btn-primary">Add</button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template> 

<script>
    export default {
        data: function () {
            return {
                deckname: ''
            };
        },
        props: {
            deckList: Array,
            selectedOption: Number
        },
        components: {},
        methods: {
            onchange: function () {
                this.$emit("triggerChange", this.selectedOption);
            },
            adddeckclick: function () {
                document.getElementById('btnCloseTitleModal').click();
                this.$emit("addDeck", this.deckname);
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