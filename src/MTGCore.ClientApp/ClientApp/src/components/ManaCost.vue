  <template>
      <span>{{convertedManaCost}}</span>
  </template>
  
<script>
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
export default {
    
props: ['manaCost'],
methods:{
    convertMana: function(manaCost){
        //implement mana conversion here
        var convertedManaCost = manaCost.replace(/{(\w)}/g, "~/MTGCore/wwwroot/images/${match[0]}.svg");
        //console.log("${ manaCost } ${ t1 }");
        return convertedManaCost;
    }
},
      created: function(){
        this.convertMana()
      }
};
</script>