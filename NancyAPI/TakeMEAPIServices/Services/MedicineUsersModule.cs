using System.Linq;

using Nancy;
using Nancy.ModelBinding;
using System.Data.Entity;

using TakeMEAPIServices.Interfaces;
using System;
using TakeMEAPIServices.Models;
using System.Collections.Generic;

namespace TakeMEAPIServices.Services
{
    public class MedicineUsersModule : Nancy.NancyModule
    {
        public MedicineUsersModule(IMyContext ctx):base("/MedicineUsers")
        {
            Get["/hello"] = _ => "Hello World!";

            Get["/"] = x =>
            {
                return Response.AsJson<List<MedicineUser>>(ctx.Medicine.Where(q=>q.Enable==true).ToList()); 
            };

            Post["/"] = _ =>
            {
                using (var context = new MyContext())
                {
                    context.Medicine.Add(new Models.MedicineUser()
                    {
                        Comments = "testing",
                        Name = "name",
                        UserId = 1,
                        Enable = true
                    });
                    ctx.SaveChanges();
                }
                return 1;
            };

            Put["/{id:int}"] = parameters =>
            {
                return HttpStatusCode.NotImplemented;
            };

            Delete["/{id:int}"] = x =>
            {
                return HttpStatusCode.NotImplemented;
            };
        }
    }
}