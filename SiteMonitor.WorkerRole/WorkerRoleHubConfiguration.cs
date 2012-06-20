using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace SiteMonitor.WorkerRole
{
    public class WorkerRoleHubConfiguration : IHubConfiguration
    {
        public string GetHubContainingSiteUrl()
        {
            return RoleEnvironment.GetConfigurationSettingValue("GUI_URL");
        }
    }
}
