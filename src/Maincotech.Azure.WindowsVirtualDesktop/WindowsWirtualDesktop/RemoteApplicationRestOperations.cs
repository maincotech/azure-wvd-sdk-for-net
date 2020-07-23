using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    internal class RemoteApplicationRestOperations : CRUDRestOperations<RemoteApplication>
    {
        public RemoteApplicationRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(RemoteApplication model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/{model.AppGroupName}/RemoteApps/{model.RemoteAppName}/";
        }

        public override string GetResourcesRelativeUrl(RemoteApplication model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/{model.AppGroupName}/RemoteApps/";
        }

        public override Response<RemoteApplication> Create(RemoteApplication model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.FilePath == null && model.AppAlias == null)
            {
                throw new ArgumentNullException("Either of FilePath or AppAlias must be specified.");
            }
            return base.Create(model, cancellationToken);
        }

        public override Task<Response<RemoteApplication>> CreateAsync(RemoteApplication model, CancellationToken cancellationToken)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.FilePath == null && model.AppAlias == null)
            {
                throw new ArgumentNullException("Either of FilePath or AppAlias must be specified.");
            }
            return base.CreateAsync(model, cancellationToken);
        }
    }
}