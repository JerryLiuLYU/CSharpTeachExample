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
        public List<string> Details { get; set; }
    }
    public class Match
    {
        private string[] descriptions = new string[] {
            "比赛沉闷至极",
            "精彩的射门，可惜被门框拒之门外",
            "两队你来我往，场面十分精彩，就差一个进球了",
            "两队你来我往，互有攻守",
            "两队你来我往",
            "门将发挥出色",
            "这球换我都能踢进，他在思考人生吗",
            "只能说运气没有站在他这一边",
            "太可惜了，他错失单刀！",
            "他把点球踢向了天空",
            "两队都没有进攻，球迷都睡着了" };
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
            matchResult.Details = new List<string>();
            matchResult.AwayTeamGoal = 0;
            matchResult.AwayTeamName = _awayTeam.Name;
            matchResult.HomeTeamGoal = 0;
            matchResult.HomeTeamName = _homeTeam.Name;
            //todo: 模拟比赛过程，计算进球，赋给matchResult
            //一共模拟9轮次，代表90分钟，每一轮次将会 进一球 或 不进球，如果有进球，则判断进球属于谁
            //进球的概率为（AB两队的球队综合能力的差值）/100+（5%-10%之内的随机数），注意若超过100%则按照100%计算。
            //todo 考虑进球的概率改为为（A队的进攻 - b队的防守）/100 +（B队进攻-A队防守）/100+（5%-10%之内的随机数）
            double homeTeamRateInMatch = _homeTeam.GetRate();
            double awayTeamRateInMatch = _awayTeam.GetRate();
            if (!IsTrueByProb(_homeTeam.GetTeamStability() / 100.0))
            {
                homeTeamRateInMatch = homeTeamRateInMatch * 0.9;
                Console.WriteLine(string.Format("{0}临场发挥欠佳", _homeTeam.Name));
            }
            if (!IsTrueByProb(_awayTeam.GetTeamStability() / 100.0))
            {
                awayTeamRateInMatch = awayTeamRateInMatch * 0.9;
                Console.WriteLine(string.Format("{0}临场发挥欠佳", _awayTeam.Name));
            }
            for (int i = 0; i < 9; i++)
            {
                

                Random rnd = new Random(Guid.NewGuid().GetHashCode()/(i+10));
                int t = rnd.Next(-5, 6);

                //double goalPorb = Math.Abs(homeTeamRateInMatch - awayTeamRateInMatch) / Math.Min(homeTeamRateInMatch,awayTeamRateInMatch) + t / 100.0;
                double goalPorb = Math.Abs(homeTeamRateInMatch - awayTeamRateInMatch) / 100 + Math.Abs(_homeTeam.GetTeamAttackPower()-_awayTeam.GetTeamDefendPower()) / 100 + Math.Abs(_homeTeam.GetTeamDefendPower() - _awayTeam.GetTeamAttackPower())/100+ t / 100.0;
                if (goalPorb > 1)
                {
                    goalPorb = 1;
                }
                bool isGoal = IsTrueByProb(goalPorb,i+1);
                if (isGoal)
                {
                    //如果某阶段判定为进球，那么该进球属于A队的概率为：
                    //A球队比赛时的能力值 /（A球队比赛时的能力值 + B球队比赛时的能力值）
                    //其中：球队比赛时的能力值 = 球队综合能力，但是会以（1 - 球队稳定性 / 100）的概率 变为90%）
                    //double diff = Math.Abs(homeTeamRateInMatch - awayTeamRateInMatch);
                    int temp = new Random(Guid.NewGuid().GetHashCode() / (i + 5)).Next(-5, 15);
                    double homeTeamGoalPorb = (homeTeamRateInMatch) / (homeTeamRateInMatch + awayTeamRateInMatch) + (homeTeamRateInMatch - awayTeamRateInMatch) / Math.Max(homeTeamRateInMatch,awayTeamRateInMatch) + temp / 100.0;
                    bool isHomeTeamGoal = IsTrueByProb(homeTeamGoalPorb,i+1);
                    if (isHomeTeamGoal)
                    {
                        matchResult.HomeTeamGoal += 1;
                        matchResult.Details.Add(string.Format("第{0}分钟，{1}进球，Goal~~~", (i + 1) * 10, _homeTeam.Name));
                    }
                    else
                    {
                        matchResult.AwayTeamGoal += 1;
                        matchResult.Details.Add(string.Format("第{0}分钟，{1}进球，Goal~~~", (i + 1) * 10, _awayTeam.Name));

                    }

                }
                else
                {
                    int d = new Random(Guid.NewGuid().GetHashCode()/(i+1)).Next(0, descriptions.Length);
                    matchResult.Details.Add(string.Format("第{0}分钟，{1}", (i + 1) * 10, descriptions[d]));

                }
            }

            return matchResult;
        }
        public static void DisplayMatch(MatchInfo matchResult)
        {
            Console.WriteLine(string.Format("{0}比赛开始{0}", new string('-', 10)));
            Console.WriteLine(string.Format("{0} vs {1}", matchResult.HomeTeamName,matchResult.AwayTeamName));
            foreach (var item in matchResult.Details)
            {
                Console.WriteLine(item);
                System.Threading.Thread.Sleep(1000); //毫秒
            }
            Console.WriteLine(string.Format("最终比分：{0}-{1} : {2}-{3}", matchResult.HomeTeamName,matchResult.HomeTeamGoal, matchResult.AwayTeamGoal, matchResult.AwayTeamName));
            Console.WriteLine(string.Format("{0}比赛结束{0}", new string('-', 10)));
        }
        /// <summary>
        /// 根据概论判断是否为true
        /// </summary>
        /// <param name="propValue">概论值，必须在0-1之间</param>
        /// <returns></returns>
        private bool IsTrueByProb(double propValue, int seed=1)
        {
            //if (propValue >1 || propValue <0)
            //{
            //    throw new Exception("概论值范围出错");
            //}
            if (propValue > 1)
            {
                propValue = 1;
            }
            if (propValue < 0)
            {
                propValue = 0;
            }

            double  randomValue = new Random(Guid.NewGuid().GetHashCode()/seed).NextDouble();
            if (randomValue <= propValue)
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
