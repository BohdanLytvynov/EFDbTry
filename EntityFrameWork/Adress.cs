using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    public class Adress
    {
        #region Properties

        [Key]
        [Required]
        #region Prim Key
        public Guid Id { get; set; } // Prim Key
        #endregion

        #region Navigation Properties

        public Guid PersonId { get; set; } // Foreign key

        public Person Person { get; set; }

        #endregion

        public string Country { get; set; }

        public string City { get; set; }

        #endregion

        #region Ctor

        public Adress(Guid id, string country, string city)
        {
            Country = country;

            City = city;
        }

        #endregion

        public Adress()
        {

        }

        #region Methods

        public override string ToString()
        {
            return $"Country: {Country} \n\nCity: {City}";
        }

        #endregion
    }
}
