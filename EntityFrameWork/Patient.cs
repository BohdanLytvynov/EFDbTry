using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    public class Patient : Person
    {
        #region properties
       

        public string Diagnosis { get; set; }

        public List<Patient_Doctor> Patient_Doctors { get; set; }

        #endregion

        #region Ctor

        public Patient(Guid id, string name, string surename, int age, Adress actualAdress, List<AddInfo> adinfo, 
            string diagnosis):
            base(id, name, surename, age, actualAdress, adinfo)
        {
            Diagnosis = diagnosis;

            Patient_Doctors = new List<Patient_Doctor>();            
        }

        public Patient()
        {

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            var t = base.ToString();

            t += $"\n\nDiagnosis: {Diagnosis} \n\n Physicians: \n";
            int i = 1;
            foreach (var item in Patient_Doctors)
            {
                t += $"#{i} {item.Doctor.GetBriefInfo()}";
                i++;
            }

            return t;
        }

        public override string GetBriefInfo()
        {
            return base.GetBriefInfo() + $" Diagnosis: {Diagnosis}";
        }

        #endregion
    }
}
