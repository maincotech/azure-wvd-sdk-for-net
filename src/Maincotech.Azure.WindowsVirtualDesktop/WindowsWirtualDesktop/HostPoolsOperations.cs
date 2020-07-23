using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public class HostPoolsOperations : CRUDOperations<HostPool>
    {
        private HostPoolsRestOperations _Operations;

        internal HostPoolsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<HostPool> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            if (_Operations == null)
            {
                _Operations = new HostPoolsRestOperations(clientDiagnostics, pipeline, endpoint);
            }
            return _Operations;
        }

        public Response<RegistrationInfo> CreateRegistration(HostPool model, int expirationHours = 24, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.CreateRegistration(model,expirationHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<RegistrationInfo>> CreateRegistrationAsync(HostPool model, int expirationHours = 24, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.CreateRegistrationAsync(model, expirationHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<RegistrationInfo> ExportRegistration(HostPool model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.ExportRegistration(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<RegistrationInfo>> ExportRegistrationAsync(HostPool model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.ExportRegistrationAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response DeleteRegistration(HostPool model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.DeleteRegistration(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response> DeleteRegistrationAsync(HostPool model,  CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.DeleteRegistrationAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}