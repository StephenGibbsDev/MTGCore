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
        <td>{{item.manaCost}}</td>
        <td>{{item.type}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  props:['post']
//   data: function() {
//     return {
//       items: [
//         { Key: 1, Name: "Shock", ManaCost: "{R}{1}", Type: "Instant" },
//         { Key: 2, Name: "Naturize", ManaCost: "{G}{2}", Type: "Sorcery" },
//         {
//           Key: 3,
//           Name: "Ajani's Pridemate",
//           ManaCost: "{W}{1}",
//           Type: "Cat-Soldier"
//         }
//       ]
//     };
//   }
};
</script>