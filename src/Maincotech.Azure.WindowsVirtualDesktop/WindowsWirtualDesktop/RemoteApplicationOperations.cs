using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;

namespace Azure.WindowsWirtualDesktop
{
    public partial class RemoteApplicationOperations : CRUDOperations<RemoteApplication>
    {
        internal RemoteApplicationOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<RemoteApplication> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            return new RemoteApplicationRestOperations(clientDiagnostics, pipeline, endpoint);
        }
    }
}