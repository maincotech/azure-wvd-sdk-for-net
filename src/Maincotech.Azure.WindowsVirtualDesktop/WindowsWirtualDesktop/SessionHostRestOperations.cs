using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;

namespace Azure.WindowsWirtualDesktop
{
    partial class SessionHostRestOperations : CRUDRestOperations<SessionHost>
    {
        public SessionHostRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(SessionHost model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/SessionHosts/{model.SessionHostName}/";
        }

        public override string GetResourcesRelativeUrl(SessionHost model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/SessionHosts/";
        }
    }
}