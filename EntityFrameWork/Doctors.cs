using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    public class Doctor : Person
    {
        #region properties
        [Key]
        [Required]
        [Column("DocId")]
        public override Guid PrimKey { get; set; }

        public string Position { get; set; }

        public List<Patient_Doctor> Patient_Doctors { get; set; }

        #endregion

        #region Ctor

        public Doctor(Guid id, string name, string surename, int age, Adress actualAdress, List<AddInfo> adinfo,
            string position) :
            base(id, name, surename, age, actualAdress, adinfo)
        {
            Position = position;

            Patient_Doctors = new List<Patient_Doctor>();
        }

        public Doctor()
        {

        }

        public override string ToString()
        {
            var t = base.ToString();

            t += $"\n\nPosition: {Position} \n\n Patients:\n";

            foreach (var item in Patient_Doctors)
            {
                t += $"{item.Patient.GetBriefInfo()}";
            }

            return t;
        }

        public override string GetBriefInfo()
        {
            return base.GetBriefInfo() + $"Position: {Position}";
        }

        #endregion
    }
}
