<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="SiteMonitor.Azure" generation="1" functional="0" release="0" Id="b0bc4987-fe84-4f7e-9fb6-43b95a9aba40" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="SiteMonitor.AzureGroup" generation="1" functional="0" release="0">
      <settings>
        <aCS name="SiteMonitor.WorkerRole:GUI_URL" defaultValue="">
          <maps>
            <mapMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/MapSiteMonitor.WorkerRole:GUI_URL" />
          </maps>
        </aCS>
        <aCS name="SiteMonitor.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/MapSiteMonitor.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="SiteMonitor.WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/MapSiteMonitor.WorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <maps>
        <map name="MapSiteMonitor.WorkerRole:GUI_URL" kind="Identity">
          <setting>
            <aCSMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/SiteMonitor.WorkerRole/GUI_URL" />
          </setting>
        </map>
        <map name="MapSiteMonitor.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/SiteMonitor.WorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapSiteMonitor.WorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/SiteMonitor.WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="SiteMonitor.WorkerRole" generation="1" functional="0" release="0" software="C:\Users\bradyg\Dropbox\Presentations\AZ-Groups-Gu-Day-2012\AZ-Group-SignalR\SiteMonitor.Azure\csx\Release\roles\SiteMonitor.WorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="GUI_URL" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;SiteMonitor.WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;SiteMonitor.WorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/SiteMonitor.WorkerRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/SiteMonitor.Azure/SiteMonitor.AzureGroup/SiteMonitor.WorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="SiteMonitor.WorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="SiteMonitor.WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
</serviceModel>