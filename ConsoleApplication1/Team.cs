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
        /// <summary>
        /// 增加教练
        /// </summary>
        /// <param name="coach"></param>
        public void AddCoach(Coach coach)
        {
            this.coach = coach;
        }
        /// <summary>
        /// 增加球员
        /// </summary>
        /// <param name="player"></param>
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
        /// <summary>
        /// 解雇球员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                int count = 0;
                foreach (var item in players)
                {
                    if (item.Position == Position.Forward || item.Position == Position.MidFeild)
                    {
                        result += item.AttackPower;
                        count++;
                    }                    
                }
                if (count>0)
                {
                    result = result / count;
                }
                

            }
            return result;
        }
        public double GetTeamDefendPower()
        {
            double result = 0.0;
            if (players != null)
            {
                int count = 0;
                foreach (var item in players)
                {
                    if (item.Position == Position.MidFeild || item.Position == Position.Defender || item.Position == Position.GoalKeeper)
                    {
                        result += item.DefendPower;
                        count++;
                    }
                }
                if (count > 0)
                {
                    result = result / count;
                }


            }
            return result;
        }
        public double GetTeamStability()
        {
            double NotStability = 0.0;
            if (players != null)
            {
                foreach (var item in players)
                {
                    NotStability += (100-item.Stability);
                }
                NotStability = (NotStability / players.Count) * (1.5-coach.GetRate()/100.0 );

            }
            return 100- NotStability;
        }
        public double GetRate()
        {
            return (GetTeamAttackPower() + GetTeamDefendPower() + GetTeamStability()) / 3.0;
        }
    }
}
