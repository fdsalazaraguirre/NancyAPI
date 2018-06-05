using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeMEAPIServices.Models
{
    public class MedicineUsers
    {
        public int MedicineId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }

    }
}