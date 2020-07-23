using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;

namespace Azure.WindowsWirtualDesktop
{
    public partial class TenantOperations : CRUDOperations<Tenant>
    {
        internal TenantOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<Tenant> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            return new TenantRestOperations(clientDiagnostics, pipeline, endpoint);
        }
    }
}