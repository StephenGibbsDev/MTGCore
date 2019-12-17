  <template>
  <table class="table">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Card</th>
        <th scope="col">Mana</th>
        <th scope="col">Type</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in post" v-bind:Key="item.multiverseid">
        <th scope="row">{{item.multiverseid}}</th>
        <td>{{item.name}}</td>
        <td>
          <ManaCost :manaCost="item.manaCost"/>
        </td>
        <td>{{item.type}}</td>
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
  }
};
</script>