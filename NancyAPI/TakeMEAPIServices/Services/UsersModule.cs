using System.Linq;

using Nancy;
using Nancy.ModelBinding;
using System.Data.Entity;

using TakeMEAPIServices.Interfaces;
using System;

namespace TakeMEAPIServices.Services
{
    public class UsersModule : Nancy.NancyModule
    {
        public UsersModule(IMyContext ctx):base("/Users")
        {
            Get["/hello"] = _ => "Hello World!";

            Get["/"] = x =>
            {
                try
                {
                    ctx.User.Add(new Models.User()
                    {
                        UserName = "Oyuky",
                        Password = "hola",
                        UID = "asda",
                        Type = 1
                    });
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Response.AsJson<object>(ctx.User.ToArray());
            };

            Get["/username/{username}/password/{password}"] = parameters =>
            {
                try
                {
                    string username = parameters.username;
                    string password = parameters.password;
                    return Response.AsJson<object>(ctx.User.Select(x => x.UserName == username && x.Password == password));
                }
                catch (Exception ex)
                {
                    return Response.AsJson<object>(ex.Message);
                }
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