using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public partial class AuthorizationOperations : CRUDOperations<RoleAssignment>
    {
        private AuthorizationRestOperations _Operations;

        internal AuthorizationOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<RoleAssignment> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            if (_Operations == null)
            {
                _Operations = new AuthorizationRestOperations(clientDiagnostics, pipeline, endpoint);
            }
            return _Operations;
        }

        #region Hide unsupported CRUD opertaions

        [Obsolete("This operation is not supported", true)]
        public override Response<RoleAssignment> Get(RoleAssignment model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<RoleAssignment>> GetAsync(RoleAssignment model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Response<RoleAssignment> Update(RoleAssignment model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<RoleAssignment>> UpdateAsync(RoleAssignment model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        #endregion Hide unsupported CRUD opertaions

        public Response<List<RoleDefinition>> GetRoleDefinitions(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.GetRoleDefinitions(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<List<RoleDefinition>>> GetRoleDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.GetRoleDefinitionsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}