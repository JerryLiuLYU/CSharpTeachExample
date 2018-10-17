using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly string END_OPTION = "0";
        private static readonly string[] MENUS = new  string[] {
            "退出系统",
            "添加球队",
            "查看球队",
            "联赛信息",
            "开始比赛"
            };
        static void Main(string[] args)
        {
            League league = new League();
            league.Name = "西甲联赛";
            DataInit.InitData(league);
            ShowWelcome();
            string strInput = Console.ReadLine().ToUpper();
            while(strInput!=END_OPTION)
            {
                PrintMenu();
                strInput = Console.ReadLine().ToUpper();
                switch (strInput)
                {
                    case "0":
                        ShowByebye();
                        break;
                    case "1":
                        AddTeam(league);
                        break;
                    case "2":
                        PrintTeam(league);
                        break;
                    case "3":
                        PrintLeague(league);
                        break;
                    default:
                        Console.WriteLine("输入有误，请重新选择");
                        break;
                }               
            }

        }

        private static void PrintTeam(League league)
        {
            Console.WriteLine("请输入查看的球队名称：");
            string name = Console.ReadLine();
            Team team = league.GetTeam(name);
            team.Print();

        }

        private static void PrintLeague(League league)
        {
            league.Print();
        }

        private static void ShowByebye()
        {
            Console.WriteLine("--------ByeBye(按任意键退出)----------");
            Console.ReadKey();
        }

        private static void PrintMenu()
        {
            Console.WriteLine(new string('-',30));
            Console.WriteLine("请选择一下操作：");
            for (int i = 0; i < MENUS.Length; i++)
            {
                Console.WriteLine(string.Format("{0}.{1}", i, MENUS[i]));
            }
            Console.WriteLine(new string('-',30));
        }

        private static void ShowWelcome()
        {
            Console.WriteLine("欢迎进入足球联赛,按任意键开始。。。");
        }

        static void AddTeam(League league)
        {
            var newTeam = new Team();
            Console.WriteLine("球队名称：");
            newTeam.Name = Console.ReadLine();
            Console.WriteLine("添加球员（Y or N）");
            string strInput = Console.ReadLine().ToUpper();
            while (strInput == "Y")
            {
                AddPlayer(newTeam);
                Console.WriteLine("添加球员（Y or N）");
                strInput = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("添加教练");
            AddCoach(newTeam);
            league.AddTeam(newTeam);

        }

        private static void AddCoach(Team newTeam)
        {
            var newCoach = new Coach();
            Console.WriteLine("教练姓名：");
            newCoach.Name = Console.ReadLine();
            Console.WriteLine("教练身份证号：");
            newCoach.Id = Console.ReadLine();
            newCoach.Position = Position.Coach;
            Console.WriteLine("教练战术指数：");
            newCoach.TacticsPower = int.Parse(Console.ReadLine());
            Console.WriteLine("教练人格魅力指数：");
            newCoach.PersonalPower = int.Parse(Console.ReadLine());          
            Console.WriteLine("工资：");
            newCoach.Salary = decimal.Parse(Console.ReadLine());
            newTeam.AddCoach(newCoach);
        }

        static void AddPlayer(Team team)
        {
            var newPlayer = new Player();
            Console.WriteLine("球员名称：");
            newPlayer.Name = Console.ReadLine();
            Console.WriteLine("球员身份证号：");
            newPlayer.Id = Console.ReadLine();
            Console.WriteLine("球员位置：(0-前锋;1-中场;2-后卫;3-门将)");
            newPlayer.Position = (Position)(int.Parse(Console.ReadLine()));
            Console.WriteLine("球员攻击指数：");
            newPlayer.AttackPower = int.Parse(Console.ReadLine());
            Console.WriteLine("球员防守指数：");
            newPlayer.DefendPower = int.Parse(Console.ReadLine());
            Console.WriteLine("球员稳定性：");
            newPlayer.Stability = int.Parse(Console.ReadLine());
            Console.WriteLine("球员工资：");
            newPlayer.Salary = decimal.Parse(Console.ReadLine());
            team.AddPlayer(newPlayer);

        }

       

    }
}
