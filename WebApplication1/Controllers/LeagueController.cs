using ConsoleApplication1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LeagueController : ApiController
    {
 
        static League currentLeague = new League();

        /// <summary>
        /// 初始化联赛
        /// </summary>
        /// <param name="l"></param>
        [HttpPost]
        public void InitLeague(League l)
        {
            currentLeague.Id = l.Id;
            currentLeague.Name = l.Name;
            DataInit.InitData(currentLeague);
        }
        public League GetLeague()
        {
            return currentLeague;
        }
        [HttpPost]
        public void AddTeam(Team team)
        {
            currentLeague.Teams.Add(team);
            currentLeague.AddTeam(team);
        }
        public IEnumerable<Team> GetTeams()
        {
            return currentLeague.Teams;
        }

 
    }
}
