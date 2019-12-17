  <template>
  <span>{{manaCost}}</span>
  </template>
  
<script>
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";


export default {
    
props: ['manaCost'],
methods:{
    convertMana: function(manaCost){
        //implement mana conversion here

        
    }
},
      created: function(){
        this.convertMana(manaCost)
      }
};
</script>