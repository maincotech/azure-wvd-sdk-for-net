using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public partial class UserSessionOperations : CRUDOperations<UserSession>
    {
        private UserSessionRestOperations _Operations;

        internal UserSessionOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        internal override CRUDRestOperations<UserSession> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            if (_Operations == null)
            {
                _Operations = new UserSessionRestOperations(clientDiagnostics, pipeline, endpoint);
            }
            return _Operations;
        }

        [Obsolete("This operation is not supported", true)]
        public override Response<UserSession> Create(UserSession model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<UserSession>> CreateAsync(UserSession model, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Response<UserSession> Update(UserSession model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        [Obsolete("This operation is not supported", true)]
        public override Task<Response<UserSession>> UpdateAsync(UserSession model, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public Response Disconnect(UserSession model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.Disconnect(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response> DisconnectAysnc(UserSession model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.DisconnectAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response SendMessage(UserSession model, string messageTitle, string messageBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.SendMessage(model, messageTitle, messageBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response> SendMessageAysnc(UserSession model, string messageTitle, string messageBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.SendMessageAsync(model, messageTitle, messageBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response Logoff(UserSession model, bool force = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return _Operations.Logoff(model, force, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response> LogoffAsync(UserSession model, bool force = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return await _Operations.LogoffAsync(model, force, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}