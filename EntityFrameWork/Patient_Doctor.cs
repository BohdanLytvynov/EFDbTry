using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    [Table("Patient_Physician")]
    public class Patient_Doctor
    {
        #region Properties

        [Key]
        public int Id { get; set; } //Primary Key

        #endregion

        #region Nav Properties

        public Guid PatientId { get; set; } // Foreign key

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public Guid DoctorId { get; set; } // Foreign Key

        #endregion

        #region Ctor

        public Patient_Doctor(Guid PId, Patient p, Guid dId, Doctor d)
        {
            PatientId = PId;

            Patient = p;

            DoctorId = dId;

            Doctor = d;
        }

        public Patient_Doctor()
        {

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Patient: \n{Patient}  \n\n Physician: \n{Doctor}";
        }

        #endregion

    }
}
