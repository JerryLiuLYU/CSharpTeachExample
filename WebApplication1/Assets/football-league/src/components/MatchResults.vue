<template>
<div>
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
</div>

</template>


<script>
export default {
  name: 'MatchResults',
  props: {
    results: {}
  },
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
          if (posts.Details == null) {
              posts={
                  HomeTeamGoal: 0,
                  AwayTeamGoal: 0,
                  Details: [0],
              }
          }
          return posts;
        },
    },
     methods: {
        matching(obj) {
            let clearInt = setInterval(function () {
                if(obj.matchInfo)
                {
                console.log(obj)
                let numOfmatchInfoLasttime = Math.round((obj.proBar-1) / 10) - 1
                let numOfmatchInfo = Math.round(obj.proBar / 10) - 1
                let text = numOfmatchInfo==-1? '' : obj.matchInfo.Details[numOfmatchInfo];
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
                }
            }, 200)
        },
        test() {
            console.log("父组件调用子组件函数")
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>    