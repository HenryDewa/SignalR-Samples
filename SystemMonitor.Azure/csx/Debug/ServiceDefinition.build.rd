<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="SystemMonitor.Azure" generation="1" functional="0" release="0" Id="3b58c846-3d19-4582-abd5-22e1dd349195" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="SystemMonitor.AzureGroup" generation="1" functional="0" release="0">
      <settings>
        <aCS name="SystemMonitor.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/SystemMonitor.Azure/SystemMonitor.AzureGroup/MapSystemMonitor.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="SystemMonitor.WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/SystemMonitor.Azure/SystemMonitor.AzureGroup/MapSystemMonitor.WorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <maps>
        <map name="MapSystemMonitor.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/SystemMonitor.Azure/SystemMonitor.AzureGroup/SystemMonitor.WorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapSystemMonitor.WorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/SystemMonitor.Azure/SystemMonitor.AzureGroup/SystemMonitor.WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="SystemMonitor.WorkerRole" generation="1" functional="0" release="0" software="C:\Users\bradyg\SkyDrive\Sources\SignalR-Samples\SystemMonitor.Azure\csx\Debug\roles\SystemMonitor.WorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;SystemMonitor.WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;SystemMonitor.WorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/SystemMonitor.Azure/SystemMonitor.AzureGroup/SystemMonitor.WorkerRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/SystemMonitor.Azure/SystemMonitor.AzureGroup/SystemMonitor.WorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="SystemMonitor.WorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="SystemMonitor.WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
</serviceModel>