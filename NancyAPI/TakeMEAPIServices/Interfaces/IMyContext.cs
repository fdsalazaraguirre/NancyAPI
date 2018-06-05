using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TakeMEAPIServices.Models;

namespace TakeMEAPIServices.Interfaces
{
    public interface IMyContext
    {
        IDbSet<MedicineUsers> Medicine { get; set; }

        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}