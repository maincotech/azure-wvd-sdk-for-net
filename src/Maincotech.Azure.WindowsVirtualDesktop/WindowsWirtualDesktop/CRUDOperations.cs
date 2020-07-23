using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public abstract class CRUDOperations<TModel> where TModel : SerializableResource<TModel>
    {
        internal readonly ClientDiagnostics _clientDiagnostics;

        internal abstract CRUDRestOperations<TModel> GetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint);

        /// <summary> Initializes a new instance of ApplicationGroupsOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal CRUDOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = GetRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary> Initializes a new instance of ApplicationGroupsOperations for mocking. </summary>
        protected CRUDOperations()
        {
        }

        internal CRUDRestOperations<TModel> RestClient { get; }

        public virtual Response<TModel> Create(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            scope.Start();
            try
            {
                return RestClient.Create(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TModel>> CreateAsync(TModel model, CancellationToken cancellationToken)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return await RestClient.CreateAsync(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response Delete(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return RestClient.Delete(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<TModel> Get(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return RestClient.Get(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TModel>> GetAsync(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return await RestClient.GetAsync(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<List<TModel>> List(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return RestClient.List(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<List<TModel>>> ListAsync(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return await RestClient.ListAsync(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<TModel> Update(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return RestClient.Update(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TModel>> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            scope.Start();
            try
            {
                return await RestClient.UpdateAsync(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}