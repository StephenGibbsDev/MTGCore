<template>
    <div>
        <span v-for="(mana, index) in manaArray" v-bind:key="`${mana}[${index}]`">
            <img :src="require(`../assets/images/${mana}.svg`)" width="20" height="20" />
        </span>
    </div>
</template>

<script>
    import "bootstrap";
    import "bootstrap/dist/css/bootstrap.min.css";
    
    export default {

        props: ['manaCost'],
        computed: {
            manaArray: function () {
                return this.manaCost.split(/{(\w+)}/).filter(m => m);
            }
        }
    };
</script>