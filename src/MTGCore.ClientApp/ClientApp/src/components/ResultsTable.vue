  <template>
  <table class="table">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Card</th>
        <th scope="col">Mana</th>
        <th scope="col">Type</th>
        <th scope="col">Add to Deck</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in post" v-bind:Key="item.id">
        <th scope="row">{{item.multiverseid}}</th>
        <td>{{item.name}}</td>
        <td>
          <ManaCost :manaSymbols="item.manaSymbols" />
        </td>
        <td>{{item.type}}</td>
        <td>
          <button @click="addToDeck(item.id)" type="button" class="btn btn-success">Add</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import ManaCost from "./ManaCost.vue";

export default {
  props: ["post"],
  components: {
    ManaCost
  },
  methods: {
    addToDeck(id) {
      this.$emit("addCardToDeck", id);
    }
  }
};
</script>