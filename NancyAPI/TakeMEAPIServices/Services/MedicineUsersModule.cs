using System.Linq;

using Nancy;
using Nancy.ModelBinding;
using System.Data.Entity;

using TakeMEAPIServices.Interfaces;
using System;

namespace TakeMEAPIServices.Services
{
    public class MedicineUsersModule : Nancy.NancyModule
    {
        public MedicineUsersModule(IMyContext ctx):base("/MedicineUsers")
        {
            Get["/hello"] = _ => "Hello World!";

            Get["/"] = x =>
            {
                    try { 
                    ctx.Medicine.Add(new Models.MedicineUser()
                    {
                        Comments = "testing",
                        Name = "name",
                        UserId = 1,
                        Enable =true
                    });
                    ctx.SaveChanges();
                    }
                    catch (Exception ex) {
                        throw ex;
                    }
                return Response.AsJson<object>(ctx.Medicine.Select(q=>q.Enable==true).ToArray()); 
            };

            Post["/"] = _ =>
            {
                using (var context = new MyContext())
                {
                    context.Medicine.Add(new Models.MedicineUser()
                    {
                        Comments = "testing",
                        Name = "name",
                        UserId = 1
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