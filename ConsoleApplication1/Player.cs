using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Player : TeamMember
    {
        public int AttackPower { get; set; }
        public int DefendPower { get; set; }
        public int Stability { get; set; }
        public override double GetRate()
        {
            double rate = 0.0;
            switch (Position)
            {
                case Position.Forward:
                    rate = AttackPower * 0.7 + DefendPower * 0.1 + Stability * 0.2;
                    break;
                case Position.MidFeild:
                    rate = AttackPower * 0.4 + DefendPower * 0.4 + Stability * 0.2;
                    break;
                case Position.Defender:
                    rate = AttackPower * 0.1 + DefendPower * 0.5 + Stability * 0.4;

                    break;
                case Position.GoalKeeper:
                    rate = AttackPower * 0.0 + DefendPower * 0.6 + Stability * 0.4;
                    break;
                
                default:
                    break;
            }
            return rate;
        }


    }
}
