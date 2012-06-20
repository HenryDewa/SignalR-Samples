<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ScalingSignalR" generation="1" functional="0" release="0" Id="c33b1494-42f1-465d-b2d7-46266fa0ca52" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="ScalingSignalRGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="ScalingSignalR.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/ScalingSignalR/ScalingSignalRGroup/LB:ScalingSignalR.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="ScalingSignalR.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ScalingSignalR/ScalingSignalRGroup/MapScalingSignalR.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="ScalingSignalR.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/ScalingSignalR/ScalingSignalRGroup/MapScalingSignalR.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:ScalingSignalR.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/ScalingSignalR/ScalingSignalRGroup/ScalingSignalR.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapScalingSignalR.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ScalingSignalR/ScalingSignalRGroup/ScalingSignalR.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapScalingSignalR.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/ScalingSignalR/ScalingSignalRGroup/ScalingSignalR.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="ScalingSignalR.Web" generation="1" functional="0" release="0" software="C:\Users\bradyg\Dropbox\Presentations\AZ-Groups-Gu-Day-2012\AZ-Group-SignalR\ScalingSignalR\csx\Release\roles\ScalingSignalR.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ScalingSignalR.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ScalingSignalR.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/ScalingSignalR/ScalingSignalRGroup/ScalingSignalR.WebInstances" />
            <sCSPolicyFaultDomainMoniker name="/ScalingSignalR/ScalingSignalRGroup/ScalingSignalR.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="ScalingSignalR.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="ScalingSignalR.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="eb6c9879-da3f-41dd-ad3d-a87dec05333a" ref="Microsoft.RedDog.Contract\ServiceContract\ScalingSignalRContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="a14a016a-c792-4ba4-98d4-4930ea371df8" ref="Microsoft.RedDog.Contract\Interface\ScalingSignalR.Web:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/ScalingSignalR/ScalingSignalRGroup/ScalingSignalR.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>