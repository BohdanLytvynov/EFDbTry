using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFrameWork
{

    [Table("Cheloveki")]
    public class Person
    {
        #region PrimaryKey

        [Required]
        public virtual Guid PrimKey { get; set; }
        #endregion

        [Column("PersonName")]
        [MinLength(1, ErrorMessage ="Field Name is Empty!!")]
        
        public string Name { get; set; }


        [MinLength(1, ErrorMessage = "Field Surename is Empty!!")]
        [Column("PersonSureName")]                
        public string Surename { get; set; }

        [Range(1, 90, ErrorMessage = "Age must be between 1 and 90")]
        
        public int Age { get; set; }

        public Adress ActualAdress { get; set; } // 1: 1

        public List<AddInfo> AddInfoList { get; set; }

        public Person(Guid id, string name, string surename, int age, Adress actualAdress, List<AddInfo> adinfo)
        {
            PrimKey = id;
            Name = name;
            Surename = surename;
            Age = age;
            AddInfoList = adinfo;

            ActualAdress = actualAdress;
        }

        public virtual string GetBriefInfo()
        {
            return $"Name: {Name} Surename:{Surename}";
        }

        public Person()
        {

        }

        public override string ToString()
        {
            string res = $"Id: {PrimKey} | Name: {Name} Surename: {Surename} | Age:{Age}\n\n"
                + $"{ActualAdress}\n\n";

            res += "Additional Info Collection:\n";

            for (int i = 0; i < AddInfoList.Count; i++)
            {
                res += $"\t {i + 1}) {AddInfoList[i].Value}\n";                    
            }

            return res;
        }
    }
}
