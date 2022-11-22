using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.TPH
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Hp { get; set; }

        public double Stamina { get; set; }

        public Person()
        {

        }

        public Person(string name, double hp = 100, double stamina = 50)
        {
            Id = Guid.NewGuid();

            Name = name;

            Stamina = stamina;

            Hp = hp;
        }
    }




}
