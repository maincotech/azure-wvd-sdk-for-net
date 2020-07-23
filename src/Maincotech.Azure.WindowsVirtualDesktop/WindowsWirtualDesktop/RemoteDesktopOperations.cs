using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public partial class RemoteDesktopOperations : CRUDOperations<RemoteDesktop>
    {
        internal RemoteDesktopOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<RemoteDesktop> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            return new RemoteDesktopRestOperations(clientDiagnostics, pipeline, endpoint);
        }

        [Obsolete("This operation is not supported", true)]
        public override Response<RemoteDesktop> Create(RemoteDesktop model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<RemoteDesktop>> CreateAsync(RemoteDesktop model, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Response Delete(RemoteDesktop model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response> DeleteAsync(RemoteDesktop model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Response<List<RemoteDesktop>> List(RemoteDesktop model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<List<RemoteDesktop>>> ListAsync(RemoteDesktop model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}