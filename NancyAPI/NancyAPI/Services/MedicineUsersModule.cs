using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyAPI.Services
{
    public class MedicineUsersModule : Nancy.NancyModule
    {
        public MedicineUsersModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
    
}
