<template>
    <div class="modal" id="TitleModal" v-if="ShowModal" style="display: block; background-color: rgba(0, 0, 0, 0.5);">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add a new deck</h4>
                    <button @click="close" type="button" id="btnCloseTitleModal" class="close pull-right">&times;</button>
                </div>
                <div class="modal-body">
                    Title
                    <input type="text" class="form-control" v-model="deckname" />
                </div>
                <div class="modal-footer">
                    <button @click="adddeckclick" type="button" class="btn btn-primary">Add</button>
                    <button @click="close" type="button" class="btn btn-primary">Close</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import "bootstrap";
    import "bootstrap/dist/css/bootstrap.min.css";
    
    export default {
        data: function () {
            return {
                ShowModal: false,
                deckname: ''
            };
        },
        methods: {
            adddeckclick: function () {
                // Not sure about emitting the event here, by emitting, it could lead to duplicate code
                // in each page where this component is used. To abide by the principle of DRY, is 
                // making the API call in this component better?
                this.close();
                this.$emit("addDeckClick", this.deckname);
            },
            open: function(){
                this.ShowModal = true;
            },
            close: function(){
                this.ShowModal = false;
            }
        }
    };
</script>