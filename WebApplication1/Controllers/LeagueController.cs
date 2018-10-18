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

        [HttpPost]
        public void SetLeagueName(League l)
        {
            currentLeague.Name = l.Name;
        }
        public HttpResponseMessage GetLeague()
        {
            return Request.CreateResponse(HttpStatusCode.Created,currentLeague);
        }
        public League GetLeague2()
        {
            return currentLeague;
        }
        [HttpPost]
        public void AddTeam(Team team)
        {
            //var newTeam = new Team();            
            //newTeam.Name = team.
            currentLeague.AddTeam(team);
        }

 
    }
}
