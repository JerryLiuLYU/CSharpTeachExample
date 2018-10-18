const BaseUrl = "http://localhost:60962/api/";

function buildUrl (url) {
    return BaseUrl + url;
}


Vue.component('blog-post', {
    props: ['results'],
    template: `
        <div class="row">
        <h3 class="text-center">{{this.matchInfo.HomeTeamName}} {{this.inTimeGoalHomeTeam}} : {{this.inTimeGoalAwayTeam}} {{this.matchInfo.AwayTeamName}}</h3>
            <div class="progress progress-info">
                <div class="bar" :style="{width:proBar+'%',}">
            </div>
        </div>
        <div>
        {{this.proBar>=95?'比赛结束'+this.matchInfo.HomeTeamGoal+':'+this.matchInfo.AwayTeamGoal:this.matchInfo.Details[Math.round(proBar/10)-1]}}
        </div>
        </div>
    `,
    data: function () {
        return {
            proBar: 0,
            inTimeGoalHomeTeam: 0,
            inTimeGoalAwayTeam: 0,
        }
      },
    computed: {
        matchInfo() {
          let posts = this.results;
          return posts;
        },
    },
    methods: {
        matching(obj) {
            let clearInt = setInterval(function () {
                console.log(obj)
                let numOfmatchInfoLasttime = Math.round((obj.proBar-1) / 10) - 1
                let numOfmatchInfo = Math.round(obj.proBar / 10) - 1
                let text = obj.matchInfo.Details[numOfmatchInfo];
                if (text!=null && numOfmatchInfoLasttime!=numOfmatchInfo && text.indexOf("Goal")!=-1) {
                    console.log("进球了！！！")
                    if (text.indexOf(obj.matchInfo.HomeTeamName)!=-1) {
                        obj.inTimeGoalHomeTeam += 1
                    } else {
                        obj.inTimeGoalAwayTeam += 1
                    }

                }
                obj.proBar+=1;
                if (obj.proBar == 100) {
                    clearInterval(clearInt);
                }
            }, 200)
        },
        test() {
            console.log("父组件调用子组件函数")
        }
    }
  })

const vm = new Vue({
  el: '#app',
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
});
