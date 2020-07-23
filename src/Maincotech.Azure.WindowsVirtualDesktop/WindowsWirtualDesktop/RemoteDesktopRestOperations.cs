using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;

namespace Azure.WindowsWirtualDesktop
{
    internal class RemoteDesktopRestOperations : CRUDRestOperations<RemoteDesktop>
    {
        public RemoteDesktopRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(RemoteDesktop model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/{model.AppGroupName}/Desktop/";
        }

        public override string GetResourcesRelativeUrl(RemoteDesktop model)
        {
            throw new NotImplementedException();
        }
    }
}