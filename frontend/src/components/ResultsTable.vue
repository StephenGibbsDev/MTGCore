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
      <tr>
        <th scope="row">1</th>
        <td>Shock</td>
        <td>{R}{1}</td>
        <td>instant</td>
      </tr>
      <tr>
        <th scope="row">2</th>
        <td>Naturize</td>
        <td>{G}{2}</td>
        <td>Sorcery</td>
      </tr>
      <tr>
        <th scope="row">3</th>
        <td>Ajani's Pridemate</td>
        <td>{W}{1}</td>
        <td>Cat-Soldier</td>
      </tr>
    </tbody>
    
    <ul id="example-1">
      <li v-for="item in items" v-bind:key="item.Key">{{ item.Name }}</li>
    </ul>
  </table>
</template>

<script>
export default {
  el: "#example-1",
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