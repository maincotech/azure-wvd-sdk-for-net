using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public partial class SessionHostOperations : CRUDOperations<SessionHost>
    {
        internal SessionHostOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<SessionHost> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            return new SessionHostRestOperations(clientDiagnostics, pipeline, endpoint);
        }

        [Obsolete("This operation is not supported", true)]
        public override Response<SessionHost> Create(SessionHost model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<SessionHost>> CreateAsync(SessionHost model, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}