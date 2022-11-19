using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    public class AddInfo
    {
        #region Properties

        [Key]
        [Required]
        public Guid PrimKey { get; set; }

        public string Value { get; set; }

        #region Nav Properties

        public Guid PersonId { get; set; }// Foreign Key

        public Person Person { get; set; }

        #endregion

        #endregion

        #region Ctor
        public AddInfo(Guid id, string value)
        {
            PrimKey = id;

            Value = value;
        }

        public AddInfo()
        {

        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Note: {Value}";
        }

        #endregion
    }
}
