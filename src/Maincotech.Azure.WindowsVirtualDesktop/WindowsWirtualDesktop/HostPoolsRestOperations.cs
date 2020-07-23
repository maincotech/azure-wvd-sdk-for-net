using Azure.Core;
using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    internal class HostPoolsRestOperations : CRUDRestOperations<HostPool>
    {
        public HostPoolsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(HostPool model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/";
        }

        public override string GetResourcesRelativeUrl(HostPool model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/";
        }

        public Response<RegistrationInfo> CreateRegistration(HostPool model, int expirationHours = 24, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Update);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateCreateRegistrationRequest(model, expirationHours);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = SerializableResource<RegistrationInfo>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public async Task<Response<RegistrationInfo>> CreateRegistrationAsync(HostPool model, int expirationHours = 24, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Update);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateCreateRegistrationRequest(model, expirationHours);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = await SerializableResource<RegistrationInfo>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public Response<RegistrationInfo> ExportRegistration(HostPool model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Get);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateExportRegistrationRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = SerializableResource<RegistrationInfo>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public async Task<Response<RegistrationInfo>> ExportRegistrationAsync(HostPool model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Update);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateExportRegistrationRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = await SerializableResource<RegistrationInfo>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public Response DeleteRegistration(HostPool model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Delete);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateDeleteRegistrationRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        return message.Response;
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public async Task<Response> DeleteRegistrationAsync(HostPool model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Delete);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateDeleteRegistrationRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        return message.Response;
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        private HttpMessage CreateCreateRegistrationRequest(HostPool model, int expirationHours)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}RegistrationInfos/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            var regInfo = new RegistrationInfo(model) { ExpirationTime = DateTime.UtcNow.AddHours(expirationHours) };
            content.JsonWriter.WriteObjectValue(regInfo);
            request.Content = content;
            return message;
        }

        private HttpMessage CreateExportRegistrationRequest(HostPool model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}RegistrationInfos/actions/export/", false);
            request.Uri = uri;
            return message;
        }

        private HttpMessage CreateDeleteRegistrationRequest(HostPool model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}RegistrationInfos/", false);
            request.Uri = uri;
            return message;
        }
    }
}