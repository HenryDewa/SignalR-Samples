<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="RedisWindowsAzureHost" generation="1" functional="0" release="0" Id="34f4548f-f5f3-49b7-a6f6-bfbf3db19796" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="RedisWindowsAzureHostGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="RedisServerWorkerRole:Redis" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/LB:RedisServerWorkerRole:Redis" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="RedisServerWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/MapRedisServerWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="RedisServerWorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/MapRedisServerWorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:RedisServerWorkerRole:Redis">
          <toPorts>
            <inPortMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/RedisServerWorkerRole/Redis" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapRedisServerWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/RedisServerWorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapRedisServerWorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/RedisServerWorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="RedisServerWorkerRole" generation="1" functional="0" release="0" software="C:\Users\bradyg\SkyDrive\Sources\SignalR-Samples\RedisWindowsAzureHost\RedisWindowsAzureHost\csx\Debug\roles\RedisServerWorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Redis" protocol="tcp" portRanges="6379" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;RedisServerWorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;RedisServerWorkerRole&quot;&gt;&lt;e name=&quot;Redis&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/RedisServerWorkerRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/RedisServerWorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="RedisServerWorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="RedisServerWorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="72a2214c-0d6b-4668-8b32-0d7098f578e4" ref="Microsoft.RedDog.Contract\ServiceContract\RedisWindowsAzureHostContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="da1f4852-ef2a-479b-b1c5-f25b81a033af" ref="Microsoft.RedDog.Contract\Interface\RedisServerWorkerRole:Redis@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/RedisWindowsAzureHost/RedisWindowsAzureHostGroup/RedisServerWorkerRole:Redis" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>