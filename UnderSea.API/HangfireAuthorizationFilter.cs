using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.API
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            //return context.GetHttpContext().User.Identity.IsAuthenticated;
            return true; // TODO ezt kiszedni, nem biztonságos..
        }
    }
}
