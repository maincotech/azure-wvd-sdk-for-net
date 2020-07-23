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
    internal class ApplicationGroupRestOperations : CRUDRestOperations<ApplicationGroup>
    {
        public ApplicationGroupRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(ApplicationGroup model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/{model.AppGroupName}/";
        }

        public override string GetResourcesRelativeUrl(ApplicationGroup model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/";
        }

        public Response<List<StartMenuItem>> GetStartMemuApps(ApplicationGroup model, CancellationToken cancellationToken = default)
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

            using var message = CreateStartMemuAppsRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        List<StartMenuItem> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            // value = ApplicationGroupList.DeserializeApplicationGroupList(document.RootElement);
                            value = new List<StartMenuItem>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    value.Add(null);
                                }
                                else
                                {
                                    value.Add(SerializableResource<StartMenuItem>.Deserialize(item.GetRawText()));
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public async Task<Response<List<StartMenuItem>>> GetStartMemuAppsAsync(ApplicationGroup model, CancellationToken cancellationToken = default)
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

            using var message = CreateStartMemuAppsRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        List<StartMenuItem> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            // value = ApplicationGroupList.DeserializeApplicationGroupList(document.RootElement);
                            value = new List<StartMenuItem>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    value.Add(null);
                                }
                                else
                                {
                                    value.Add(SerializableResource<StartMenuItem>.Deserialize(item.GetRawText()));
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        protected virtual HttpMessage CreateStartMemuAppsRequest(ApplicationGroup model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}StartMenuApps", false);
            request.Uri = uri;
            return message;
        }
    }
}