using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public  static class DataInit
    {
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="league"></param>
        public static void InitData(League league)
        {
            #region team1
            var team1 = new Team();
            team1.Name = "皇马";
            team1.AddCoach(new Coach()
            {
                Gender = Gender.Male,
                Name = "佩吉特",
                Id = "HM000",
                PersonalPower = 60,
                TacticsPower = 88,
                Position = Position.Coach,
                Salary = 8
            });
            team1.AddPlayer(new Player
            {
                Id = "HM001",
                Name = "本泽马",
                Position = Position.Forward,
                Gender = Gender.Male,
                AttackPower = 88,
                DefendPower = 10,
                Stability = 78,
                Salary = 7
            });
            team1.AddPlayer(new Player
            {
                Id = "HM002",
                Name = "莫德里奇",
                Position = Position.MidFeild,
                Gender = Gender.Male,
                AttackPower = 80,
                DefendPower = 80,
                Stability = 90,
                Salary = 8
            });
            team1.AddPlayer(new Player
            {
                Id = "HM003",
                Name = "拉莫斯",
                Position = Position.Defender,
                Gender = Gender.Male,
                AttackPower = 70,
                DefendPower = 89,
                Stability = 70,
                Salary = 8
            });
            team1.AddPlayer(new Player
            {
                Id = "HM004",
                Name = "纳瓦斯",
                Position = Position.GoalKeeper,
                Gender = Gender.Male,
                AttackPower = 0,
                DefendPower = 88,
                Stability = 90,
                Salary = 7
            });
            #endregion
            #region team2
            var team2 = new Team();
            team2.Name = "巴萨";
            team2.AddCoach(new Coach()
            {
                Gender = Gender.Male,
                Name = "巴尔韦德",
                Id = "BS000",
                PersonalPower = 60,
                TacticsPower = 80,
                Position = Position.Coach,
                Salary = 7
            });
            team2.AddPlayer(new Player
            {
                Id = "BS001",
                Name = "梅西",
                Position = Position.Forward,
                Gender = Gender.Male,
                AttackPower = 99,
                DefendPower = 30,
                Stability = 90,
                Salary = 10
            });
            team2.AddPlayer(new Player
            {
                Id = "BS002",
                Name = "伊涅斯塔",
                Position = Position.MidFeild,
                Gender = Gender.Male,
                AttackPower = 90,
                DefendPower = 78,
                Stability = 90,
                Salary = 8
            });
            team2.AddPlayer(new Player
            {
                Id = "BS003",
                Name = "皮克",
                Position = Position.Defender,
                Gender = Gender.Male,
                AttackPower = 50,
                DefendPower = 85,
                Stability = 77,
                Salary = 7
            });
            team2.AddPlayer(new Player
            {
                Id = "BS004",
                Name = "特尔施特根",
                Position = Position.GoalKeeper,
                Gender = Gender.Male,
                AttackPower = 0,
                DefendPower = 90,
                Stability = 90,
                Salary = 7
            });
            #endregion
            #region team3
            var team3 = new Team();
            team3.Name = "中国";
            team3.AddCoach(new Coach()
            {
                Gender = Gender.Male,
                Name = "高洪波",
                Id = "ZG000",
                PersonalPower = 40,
                TacticsPower = 60,
                Position = Position.Coach,
                Salary = 7
            });
            team3.AddPlayer(new Player
            {
                Id = "ZG001",
                Name = "李毅",
                Position = Position.Forward,
                Gender = Gender.Male,
                AttackPower = 60,
                DefendPower = 10,
                Stability = 60,
                Salary = 10
            });
            team3.AddPlayer(new Player
            {
                Id = "ZG002",
                Name = "郑智",
                Position = Position.MidFeild,
                Gender = Gender.Male,
                AttackPower = 55,
                DefendPower = 50,
                Stability = 70,
                Salary = 8
            });
            team3.AddPlayer(new Player
            {
                Id = "ZG003",
                Name = "张三",
                Position = Position.Defender,
                Gender = Gender.Male,
                AttackPower = 30,
                DefendPower = 75,
                Stability = 66,
                Salary = 7
            });
            team3.AddPlayer(new Player
            {
                Id = "ZG004",
                Name = "李四",
                Position = Position.GoalKeeper,
                Gender = Gender.Male,
                AttackPower = 0,
                DefendPower = 70,
                Stability = 80,
                Salary = 7
            });
            #endregion
            league.Teams.Clear();
            league.AddTeam(team1);
            league.AddTeam(team2);
            league.AddTeam(team3);
        }
        /// <summary>
        /// 使用文件，初始化数据
        /// </summary>
        /// <param name="league"></param>
        /// <param name="filePath"></param>
        public static void InitData(League league, string filePath)
        {

        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="league"></param>
        /// <param name="saveFilePath"></param>
        public static void SaveData(League league, string saveFilePath)
        {

        }
        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="league"></param>
        /// <param name="loadFilePath"></param>
        public static void LoadData(League league, string loadFilePath)
        {

        }
    }
}
