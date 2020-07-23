using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;

using System;

namespace Azure.WindowsWirtualDesktop
{
    internal partial class TenantRestOperations : CRUDRestOperations<Tenant>
    {
        public TenantRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(Tenant model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/";
        }

        public override string GetResourcesRelativeUrl(Tenant model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/";
        }
    }
}