using System;
using System.Threading.Tasks;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces.Employee;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(chat.Pool.Startup))]

namespace chat.Pool
{
    public class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
