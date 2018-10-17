using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Coach : TeamMember
    {
        public int TacticsPower { get; set; }
        public int PersonalPower { get; set; }
        public Coach():base()
        {
            this.Position = Position.Coach;
        }
        public override double GetRate()
        {
            return TacticsPower * 0.7 + PersonalPower * 0.3;
        }
    }
}
