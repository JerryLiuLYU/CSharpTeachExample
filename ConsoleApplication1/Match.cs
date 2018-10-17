using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public struct MatchInfo
    {
        public int HomeTeamGoal { get; set; }
        public string HomeTeamName { get; set; }
        public int AwayTeamGoal { get; set; }
        public string AwayTeamName { get; set; }

    }
    public class Match
    {
        private Team _homeTeam;
        private Team _awayTeam;
        public Match(Team homeTeam, Team awayTeam)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;

        }

        public MatchInfo Run()
        {
            MatchInfo matchResult = new MatchInfo();
            matchResult.AwayTeamGoal = 0;
            matchResult.AwayTeamName = _awayTeam.Name;
            matchResult.HomeTeamGoal = 0;
            matchResult.HomeTeamName = _homeTeam.Name;
            //todo: 模拟比赛过程，计算进球，赋给matchResult

            return matchResult;
        }
        /// <summary>
        /// 根据概论判断是否为true
        /// </summary>
        /// <param name="propValue">概论值，必须在0-1之间</param>
        /// <returns></returns>
        private bool IsTtueByProb(double propValue)
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            if (rnd.Next(0,1)<=propValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
