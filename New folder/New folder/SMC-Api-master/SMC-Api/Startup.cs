using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SMC_Api.Mappings;

[assembly: OwinStartup(typeof(SMC_Api.Startup))]

namespace SMC_Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
            AutoMapperConfiguration.Configure();
        }
    }
}
