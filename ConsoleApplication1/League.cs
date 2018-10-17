using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class League
    {
        public string Name { get; set; }
        private List<Team> Teams { get; set; }
        public League()
        {
            Teams = new List<Team>();
        }



        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }
        public Team GetTeam(string name)
        {
            var result = Teams.Find(p => p.Name == name);
            return result;
        }

        public void Print()
        {
            Console.WriteLine(string.Format("联赛名称：{0}", this.Name));
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("球队名称\t球队攻击力\t球队防御力\t球队稳定性\t综合评分");

            foreach (var item in Teams)
            {
                Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", item.Name,item.GetTeamAttackPower(),item.GetTeamDefendPower(),item.GetTeamStability(),item.GetRate()));
            }
            Console.WriteLine("----------------------------------------");

            Console.ReadKey();


        }
    }
}
