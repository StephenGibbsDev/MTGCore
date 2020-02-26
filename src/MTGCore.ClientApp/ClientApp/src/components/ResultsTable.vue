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
          <ManaCost :manaCost="item.manaCost" />
        </td>
        <td>{{item.type}}</td>
        <td>
          <button
            v-on:click="addToDeck(item.id)"
            type="button"
            class="btn btn-success"
          >Add</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import ManaCost from "./ManaCost.vue";
import axios from "axios";

export default {
  props: ["post"],
  components: {
    ManaCost
  },
  methods: {
    addToDeck(id) {
      axios({
        method: "post",
        url: `https://localhost:44305/api/Deck/Add/3/${id}`,
        data: this.$data
      })
        .then(() => {
          this.someMethod();
        })
        .catch(err => {
          alert(`There was an error submitting your form. See details: ${err}`);
        });
    },
    someMethod(){
        this.$parent.updateDeckList();
    }
  }
};
</script>