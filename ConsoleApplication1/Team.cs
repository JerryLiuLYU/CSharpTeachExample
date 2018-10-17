using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Team
    {
        const int MaxNumOfPlayer = 11;
        private string name;
        /// <summary>
        /// 球队名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 球队包含球员列表
        /// </summary>
        private List<Player> players;
        private Coach coach;

        public Team()
        {
            players = new List<Player>();
        }
        public void AddCoach(Coach coach)
        {
            this.coach = coach;
        }
        public void AddPlayer(Player player)
        {
            if (players.Count <  MaxNumOfPlayer)
            {
                players.Add(player);              
            }
            else
            {
                throw new Exception("超出人数限制");
            }
        }
        public Player KickPlayer(string id)
        {
            int kickPlayerIndex = players.FindIndex(p => p.Id == id);
            Player kickPlayer = players[kickPlayerIndex];
            players.RemoveAt(kickPlayerIndex);
            return kickPlayer;
        }

        public void Print()
        {
            Console.WriteLine(string.Format("球队名称:{0}", this.Name));
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("姓名\t身份证号\t位置\t攻击指数\t防守指数\t稳定性\t综合评分\t年薪");
            foreach (var stu in players)
            {
                Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                    stu.Name, 
                    stu.Id, 
                    stu.Position,
                    stu.AttackPower,
                    stu.DefendPower,
                    stu.Stability,
                    stu.GetRate(),
                    stu.Salary));
            }
            Console.WriteLine("----------------------------------------");
            Console.ReadKey();
        }
        public double GetTeamAttackPower()
        {
            double result = 0.0;
            if (players != null)
            {
                foreach (var item in players)
                {
                    result += item.AttackPower;
                }
                result = result / players.Count;

            }
            return result;
        }
        public double GetTeamDefendPower()
        {
            double result = 0.0;
            if (players != null)
            {
                foreach (var item in players)
                {
                    result += item.DefendPower;
                }
                result = result / players.Count;

            }
            return result;
        }
        public double GetTeamStability()
        {
            double result = 0.0;
            if (players != null)
            {
                foreach (var item in players)
                {
                    result += item.Stability;
                }
                result = (result / players.Count) * (coach.GetRate()/100);

            }
            return result;
        }
        public double GetRate()
        {
            return (GetTeamAttackPower() + GetTeamDefendPower() + GetTeamStability()) / 3;
        }
    }
}
