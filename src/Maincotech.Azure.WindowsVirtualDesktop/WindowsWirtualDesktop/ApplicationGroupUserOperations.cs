using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public partial class ApplicationGroupUserOperations : CRUDOperations<ApplicationGroupUser>
    {
        internal ApplicationGroupUserOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<ApplicationGroupUser> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            return new ApplicationGroupUserRestOperations(clientDiagnostics, pipeline, endpoint);
        }

        [Obsolete("This is not supported in this class.", true)]
        public override Response<ApplicationGroupUser> Update(ApplicationGroupUser model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This is not supported in this class.", true)]
        public override Task<Response<ApplicationGroupUser>> UpdateAsync(ApplicationGroupUser model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}