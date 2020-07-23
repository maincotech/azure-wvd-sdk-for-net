using Azure.Core;
using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    internal abstract class CRUDRestOperations<TModel> where TModel : SerializableResource<TModel>
    {
        protected ClientDiagnostics _clientDiagnostics;
        protected HttpPipeline _pipeline;
        protected Uri _endpoint;

        public abstract string GetResourceRelativeUrl(TModel model);

        public abstract string GetResourcesRelativeUrl(TModel model);

        protected CRUDRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            endpoint ??= new Uri("https://rdbroker.wvd.microsoft.com");
            _endpoint = endpoint;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        public virtual Response<TModel> Create(TModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Create);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateCreateRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        try
                        {
                            var value = SerializableResource<TModel>.DeserializeAsync(message.Response.ContentStream).GetAwaiter().GetResult();
                            return Response.FromValue(value, message.Response);
                        }
                        catch (Exception)
                        {
                            return Response.FromValue(model, message.Response);
                        }
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public virtual async Task<Response<TModel>> CreateAsync(TModel model, CancellationToken cancellationToken)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.Create);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateCreateRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = await SerializableResource<TModel>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public virtual Response Delete(TModel model, CancellationToken cancellationToken = default)
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

            using var message = CreateDeleteRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;

                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public virtual async Task<Response> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
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
            using var message = CreateDeleteRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;

                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        public virtual Response<TModel> Get(TModel model, CancellationToken cancellationToken = default)
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

            using var message = CreateGetRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = SerializableResource<TModel>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    {
                        return Response.FromValue<TModel>(default, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public virtual async Task<Response<TModel>> GetAsync(TModel model, CancellationToken cancellationToken = default)
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

            using var message = CreateGetRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = await SerializableResource<TModel>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        public virtual Response<List<TModel>> List(TModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.List);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateListRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        List<TModel> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            // value = ApplicationGroupList.DeserializeApplicationGroupList(document.RootElement);
                            value = new List<TModel>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    value.Add(null);
                                }
                                else
                                {
                                    value.Add(SerializableResource<TModel>.Deserialize(item.GetRawText()));
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public virtual async Task<Response<List<TModel>>> ListAsync(TModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var properties = model.GetRequiredProperties(CRUDOperationsTypes.List);
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    throw new ArgumentNullException(property.Name);
                }
            }

            using var message = CreateListRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        List<TModel> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            // value = ApplicationGroupList.DeserializeApplicationGroupList(document.RootElement);
                            value = new List<TModel>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    value.Add(null);
                                }
                                else
                                {
                                    value.Add(SerializableResource<TModel>.Deserialize(item.GetRawText()));
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        public virtual Response<TModel> Update(TModel model, CancellationToken cancellationToken = default)
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

            using var message = CreateUpdateRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = SerializableResource<TModel>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public virtual async Task<Response<TModel>> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
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

            using var message = CreateUpdateRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        var value = await SerializableResource<TModel>.DeserializeAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        protected virtual HttpMessage CreateCreateRequest(TModel model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        protected virtual HttpMessage CreateDeleteRequest(TModel model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}", false);
            request.Uri = uri;
            return message;
        }

        protected virtual HttpMessage CreateGetRequest(TModel model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}", false);
            //GET https://rdbroker.wvd.microsoft.com/RdsManagement/V1/TenantGroups/Default%20Tenant%20Group/Tenants/maincotech.onmicrosoft.com HTTP/1.1
            request.Uri = uri;
            return message;
        }

        protected virtual HttpMessage CreateListRequest(TModel model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourcesRelativeUrl(model)}", false);
            // uri.AppendQuery("api-version", apiVersion, true);
            //GET https://rdbroker.wvd.microsoft.com/RdsManagement/V1/TenantGroups/Default%20Tenant%20Group/Tenants?PageSize=1000&LastEntry=&SortField=TenantName&IsDescending=False&InitialSkip=0 HTTP/1.1
            request.Uri = uri;
            return message;
        }

        protected virtual HttpMessage CreateUpdateRequest(TModel model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }
    }
}