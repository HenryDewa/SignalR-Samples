<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="TimeServer.Azure" generation="1" functional="0" release="0" Id="c528127c-5a2e-4425-b5d5-c57c8e3ae361" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="TimeServer.AzureGroup" generation="1" functional="0" release="0">
      <settings>
        <aCS name="TimeServer.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/TimeServer.Azure/TimeServer.AzureGroup/MapTimeServer.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="TimeServer.WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/TimeServer.Azure/TimeServer.AzureGroup/MapTimeServer.WorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <maps>
        <map name="MapTimeServer.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/TimeServer.Azure/TimeServer.AzureGroup/TimeServer.WorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapTimeServer.WorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/TimeServer.Azure/TimeServer.AzureGroup/TimeServer.WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="TimeServer.WorkerRole" generation="1" functional="0" release="0" software="C:\Users\bradyg\SkyDrive\Sources\SignalR-Samples\TimeServer.Azure\csx\Debug\roles\TimeServer.WorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;TimeServer.WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;TimeServer.WorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/TimeServer.Azure/TimeServer.AzureGroup/TimeServer.WorkerRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/TimeServer.Azure/TimeServer.AzureGroup/TimeServer.WorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="TimeServer.WorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="TimeServer.WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
</serviceModel>