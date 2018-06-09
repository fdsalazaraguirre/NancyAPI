using System.Linq;

using Nancy;
using Nancy.ModelBinding;
using System.Data.Entity;

using TakeMEAPIServices.Interfaces;
using System;
using TakeMEAPIServices.Models;

namespace TakeMEAPIServices.Services
{
    public class UsersModule : Nancy.NancyModule
    {
        public UsersModule(IMyContext ctx):base("/Users")
        {
            Get["/hello"] = _ => "Hello World!";

            Get["/"] = x =>
            {
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
                try
                {
                    var user = this.Bind<User>();
                    ctx.User.Add(user);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
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