<template>
    <span v-html="convertedManaCost"></span> 
    <!-- <img src="../assets/images/1.svg" /> -->
</template>

<script>
    import "bootstrap";
    import "bootstrap/dist/css/bootstrap.min.css";
    export default {

        props: ['manaCost'],
        computed: {
            convertedManaCost: function () {
                /* TODO: Look at moving images to ClientApp assets to allow use of a relative URL https://localhost:44305/images/$1.svg */
                return this.manaCost.replace(/{(\w)}/g, '<img src="../assets/images/$1.svg" alt="Mana Symbol" height="20" width="20" />');
            }
        }
    };
</script>