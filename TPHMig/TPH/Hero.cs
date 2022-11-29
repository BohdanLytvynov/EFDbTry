using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.TPH
{
    public class Hero : Warrior
    {
        public double Mana { get; set; }

        public Hero()
        {

        }

        public Hero(string name, double damage, double armor, double mana): base(name, damage, armor, mana)
        {

        }
    }
}
