using Azure.Core;
using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    internal class AuthorizationRestOperations : CRUDRestOperations<RoleAssignment>
    {
        public AuthorizationRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override Response<RoleAssignment> Create(RoleAssignment model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.SignInName) && string.IsNullOrEmpty(model.AppId))
            {
                throw new ArgumentNullException("Either SignInName or AppId must be specified.");
            }
            if (!string.IsNullOrEmpty(model.SignInName) && !string.IsNullOrEmpty(model.AppId))
            {
                throw new ArgumentException("SignInName and AppId can't be specified together.");
            }

            return base.Create(model, cancellationToken);
        }

        public override string GetResourceRelativeUrl(RoleAssignment model)
        {
            var scope = new ManagementObjectScope() { AppGroupName = model.AppGroupName, HostPoolName = model.HostPoolName, TenantName = model.TenantName, TenantGroupName = model.TenantGroupName };
            var relativeUrlBuilder = new StringBuilder($"{scope.AsUrlPath().TrimStart('/')}/Rds.Authorization/roleAssignments/{model.RoleDefinitionName}/Users/");
            if (string.IsNullOrEmpty(model.SignInName) == false)
            {
                relativeUrlBuilder.Append($"UPN/{model.SignInName}/");
            }
            else
            {
                relativeUrlBuilder.Append($"appid/{model.AppId}/");
            }
            return relativeUrlBuilder.ToString();
        }

        public override string GetResourcesRelativeUrl(RoleAssignment model)
        {
            var relativeUrlBuilder = new StringBuilder($"Rds.Authorization/roleAssignments");
            bool firstQueryFlag = true;
            if (!string.IsNullOrEmpty(model.SignInName))
            {
                if (firstQueryFlag)
                {
                    relativeUrlBuilder.Append("?");
                    firstQueryFlag = false;
                }
                relativeUrlBuilder.Append($"unp={model.SignInName}");
            }

            return relativeUrlBuilder.ToString();
        }

        public Response<List<RoleDefinition>> GetRoleDefinitions(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRolePermissionsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        List<RoleDefinition> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            // value = ApplicationGroupList.DeserializeApplicationGroupList(document.RootElement);
                            value = new List<RoleDefinition>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    value.Add(null);
                                }
                                else
                                {
                                    value.Add(SerializableResource<RoleDefinition>.Deserialize(item.GetRawText()));
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public async Task<Response<List<RoleDefinition>>> GetRoleDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRolePermissionsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        List<RoleDefinition> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            // value = ApplicationGroupList.DeserializeApplicationGroupList(document.RootElement);
                            value = new List<RoleDefinition>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    value.Add(null);
                                }
                                else
                                {
                                    value.Add(SerializableResource<RoleDefinition>.Deserialize(item.GetRawText()));
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        protected override HttpMessage CreateCreateRequest(RoleAssignment model)
        {
            var message = base.CreateCreateRequest(model);
            message.Request.Method = RequestMethod.Put;
            return message;
        }

        private HttpMessage CreateGetRolePermissionsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath($"/RdsManagement/V1/Rds.Authorization/roleDefinitions/", false);
            request.Uri = uri;
            return message;
        }
    }
}