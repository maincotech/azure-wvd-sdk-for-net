using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public class ApplicationGroupOperations : CRUDOperations<ApplicationGroup>
    {
        private ApplicationGroupRestOperations _Operations;

        internal ApplicationGroupOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<ApplicationGroup> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            if (_Operations == null)
            {
                _Operations = new ApplicationGroupRestOperations(clientDiagnostics, pipeline, endpoint);
            }
            return _Operations;
        }

        public Response<List<StartMenuItem>> GetStartMemuApps(ApplicationGroup model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return _Operations.GetStartMemuApps(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<List<StartMenuItem>>> GetStartMemuAppsAsync(ApplicationGroup model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return await _Operations.GetStartMemuAppsAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}