using System.Linq;

using Nancy;
using Nancy.ModelBinding;
using System.Data.Entity;

using TakeMEAPIServices.Interfaces;

namespace TakeMEAPIServices.Services
{
    public class MedicineUsersModule : Nancy.NancyModule
    {
        public MedicineUsersModule(IMyContext ctx):base("/MedicineUsers")
        {
            Get["/hello"] = _ => "Hello World!";

            Get["/"] = x =>
            {
                using (var context = new MyContext())
                {
                    context.Medicine.Add(new Models.MedicineUsers()
                    {
                        Comments = "testing",
                        Name = "name",
                        UserId = 1
                    });
                    ctx.SaveChanges();
                }
                return Response.AsJson<object>(ctx.Medicine.ToArray()); 
            };

            Post["/"] = _ =>
            {
                return HttpStatusCode.NotImplemented;
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