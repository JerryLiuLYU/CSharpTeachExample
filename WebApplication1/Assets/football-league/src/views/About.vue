<template>
<div>
   <h3 class="text-center">{{title}}</h3>    
    <div class="row-fluid"></div>
    <div class="row-fluid">
                <div class="span6 text-center">
                        主队
                        <select v-model="homeTeam">
                            <option v-for="team in teams" :value="team">{{ team.Name }}</option>
                        </select>
                </div>
                <div class="span6 text-center">
                        客场
                        <select v-model="awayTeam">
                            <option v-for="team in teams" :value="team">{{ team.Name }}</option>
                        </select>
                </div>
    </div>
    <div class="row-fluid text-center">
            <button  @click="beginMatch()" class="btn btn-large btn-primary" type="button">开始比赛</button>
    </div>

    <div v-if="loading" class="loader text-center"><img src="img/loader-large.gif" alt="loader"></div>
    <MatchResults ref="blogpost" v-show="isShowMatch" :results="matchResults"></MatchResults>
    </div>
</template>
<script>
// @ is an alias to /src
import MatchResults from "@/components/HelloWorld.vue"

export default {
  name: 'about',
  data: {
    teams: [], // create an array of the sections
    homeTeam: void 0, // set default section to 'home'
    awayTeam: void 0, // set default section to 'home'
    matchResults: [],
      loading: false,
      isShowMatch: false,
    title: ''
  },
  mounted () {
    this.getLeague();
    this.getTeams();
    },
  methods: {
        getLeague() {
            console.log("getteams")
            let url = buildUrl('league/getLeague')
            console.log(url)
            axios.get(url).then((response) => {
                console.log(response)
                this.title = response.data.Name;
              }).catch((error) => { console.log(error); });
    
          },
      getTeams() {
        console.log("getteams")
        let url = buildUrl('league/getTeams')
        console.log(url)
        axios.get(url).then((response) => {
            console.log(response)
            this.teams = response.data;
          }).catch((error) => { console.log(error); });

      },
      beginMatch() {
          this.loading = true;
          this.isShowMatch = false;
          console.log("beginMatch")
          let url = buildUrl('league/beginMatch')
          console.log(url)
          console.log(this.homeTeam.Name)
          axios.post(url, { //请求参数
                HomeTeamName: this.homeTeam.Name,
                AwayTeamName: this.awayTeam.Name,
            }
          ).then((response) => {
              console.log(response)
              this.matchResults = response.data;
              setTimeout(function () {
                  vm.isShowMatch = true
                  vm.loading =false
                vm.$refs.blogpost.proBar = 0
                vm.$refs.blogpost.inTimeGoalHomeTeam = 0
                vm.$refs.blogpost.inTimeGoalAwayTeam = 0
                vm.$refs.blogpost.matching(vm.$refs.blogpost)
              }, 1000);
              
              
              
          }).catch((error) => { console.log(error); });
    }
    },
  components: {
    MatchResults
  }
}
</script>