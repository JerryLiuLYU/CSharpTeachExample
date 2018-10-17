using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum Gender { Male, Female}
    public enum Position { Forward, MidFeild, Defender, GoalKeeper, Coach }
    public class TeamMember
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }

        public virtual double GetRate()
        {
            throw new NotImplementedException();
        }

    }
}
