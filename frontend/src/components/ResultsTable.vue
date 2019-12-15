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
      <tr v-for="item in items" v-bind:Key="item.Key">
        <th scope="row">{{item.Key}}</th>
        <td>{{item.Name}}</td>
        <td>{{item.ManaCost}}</td>
        <td>{{item.Type}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  data: function() {
    return {
      items: [
        { Key: 1, Name: "Shock", ManaCost: "{R}{1}", Type: "Instant" },
        { Key: 2, Name: "Naturize", ManaCost: "{G}{2}", Type: "Sorcery" },
        { Key: 3, Name: "Ajani's Pridemate", ManaCost: "{W}{1}", Type: "Cat-Soldier"}
      ]
    }
  }
};
</script>