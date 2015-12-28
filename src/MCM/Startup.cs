using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCM.Startup))]

namespace MCM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
