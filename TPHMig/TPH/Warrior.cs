using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.TPH
{
    public class Warrior : Person
    {
        public double Attack { get; set; }

        public double Armor { get; set; }

        public Warrior()
        {

        }

        public Warrior(string name, double damage, double armor, double hp = 200, double stamina = 100): base(name, hp, stamina)
        {
            Attack = damage;

            Armor = armor;
        }
    }
}
