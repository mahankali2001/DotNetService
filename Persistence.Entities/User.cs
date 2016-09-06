using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
   [Table("User")]
    public class User
    {
        [Key]
        public int uid { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        //public string VendorName { get; set; }
        //public DealVendorAttributes VendorAttributes { get; set; }
    }
}
