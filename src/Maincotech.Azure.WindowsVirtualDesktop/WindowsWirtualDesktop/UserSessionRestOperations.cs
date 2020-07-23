using Azure.Core;
using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    internal partial class UserSessionRestOperations : CRUDRestOperations<UserSession>
    {
        public UserSessionRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(UserSession model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/SessionHosts/{model.SessionHostName}/Sessions/{model.SessionId}/";
        }

        public override string GetResourcesRelativeUrl(UserSession model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/Sessions/";
        }

        public Response Disconnect(UserSession model, CancellationToken cancellationToken = default)
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
            using var message = CreateDisconnectRequest(model);
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

        public async Task<Response> DisconnectAsync(UserSession model, CancellationToken cancellationToken = default)
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
            using var message = CreateDisconnectRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;

                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public Response Logoff(UserSession model, bool force = false, CancellationToken cancellationToken = default)
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
            using var message = CreateLogoffRequest(model, force);
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

        public async Task<Response> LogoffAsync(UserSession model, bool force = false, CancellationToken cancellationToken = default)
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
            using var message = CreateLogoffRequest(model, force);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;

                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        public Response SendMessage(UserSession model, string messageTitle, string messageBody, CancellationToken cancellationToken = default)
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
            if (messageTitle == null)
            {
                throw new ArgumentNullException(nameof(messageTitle));
            }
            if (messageBody == null)
            {
                throw new ArgumentNullException(nameof(messageBody));
            }
            using var message = CreateSendMessageRequest(model, messageTitle, messageBody);
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

        public async Task<Response> SendMessageAsync(UserSession model, string messageTitle, string messageBody, CancellationToken cancellationToken = default)
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
            if (messageTitle == null)
            {
                throw new ArgumentNullException(nameof(messageTitle));
            }
            if (messageBody == null)
            {
                throw new ArgumentNullException(nameof(messageBody));
            }
            using var message = CreateSendMessageRequest(model, messageTitle, messageBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;

                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        protected virtual HttpMessage CreateDisconnectRequest(UserSession model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            //POST https://rdbroker.wvd.microsoft.com/RdsManagement/V1/TenantGroups/Default%20Tenant%20Group/Tenants/maincotech.onmicrosoft.com/HostPools/ITHostpool/SessionHosts/wvh-1.maincotech.com/Sessions/2/actions/disconnect-user HTTP/1.1
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}actions/disconnect-user", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");

            var content = new Utf8JsonRequestContent();
            WriteHeadersJson(content.JsonWriter);

            request.Content = content;
            return message;
        }

        protected virtual HttpMessage CreateLogoffRequest(UserSession model, bool force)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            //POST https://rdbroker.wvd.microsoft.com/RdsManagement/V1/TenantGroups/Default%20Tenant%20Group/Tenants/maincotech.onmicrosoft.com/HostPools/ITHostpool/SessionHosts/wvh-1.maincotech.com/Sessions/2/actions/disconnect-user HTTP/1.1
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}actions/logoff-user", false);
            uri.AppendQuery("force", force);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");

            var content = new Utf8JsonRequestContent();
            WriteHeadersJson(content.JsonWriter);

            request.Content = content;
            return message;
        }

        private void WriteHeadersJson(Utf8JsonWriter writer)
        {
            // {"Headers":[{"Key":"Content-Type","Value":["text/plain; charset=utf-8"]}]}
            writer.WriteStartObject();
            writer.WritePropertyName("Headers");
            writer.WriteStartArray();
            writer.WriteStartObject();
            writer.WritePropertyName("Key");
            writer.WriteStringValue("Content-Type");

            writer.WritePropertyName("Value");
            writer.WriteStartArray();
            writer.WriteStringValue("text/plain; charset=utf-8");
            writer.WriteEndArray();
            writer.WriteEndObject();

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        protected virtual HttpMessage CreateSendMessageRequest(UserSession model, string messageTitle, string messageBody)
        {
            //      stringBuilder.Append(this.GetFormatBase("TenantGroups/{tenantGroupName}/Tenants/{tenantName}/HostPools/{hostPoolName}/SessionHosts/{sessionHostName}/Sessions/{sessionId}/actions/send-message-user", (object) this.CurrentTenantGroup, (object) this.TenantName, (object) this.HostPoolName, (object) this.SessionHostName, (object) this.SessionId));
            // stringBuilder.Append("?");
            // stringBuilder.Append("MessageTitle").Append("=").Append(Uri.EscapeDataString(this.MessageTitle.ToString((IFormatProvider)CultureInfo.InvariantCulture)));
            //  stringBuilder.Append("&");
            //  stringBuilder.Append("MessageBody").Append("=").Append(Uri.EscapeDataString(this.MessageBody.ToString((IFormatProvider)CultureInfo.InvariantCulture)));

            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            //POST https://rdbroker.wvd.microsoft.com/RdsManagement/V1/TenantGroups/Default%20Tenant%20Group/Tenants/maincotech.onmicrosoft.com/HostPools/ITHostpool/SessionHosts/wvh-1.maincotech.com/Sessions/2/actions/disconnect-user HTTP/1.1
            uri.AppendPath($"/RdsManagement/V1/{GetResourceRelativeUrl(model)}actions/send-message-user", false);
            uri.AppendQuery("MessageTitle", Uri.EscapeDataString(messageTitle.ToString((IFormatProvider)CultureInfo.InvariantCulture)));
            uri.AppendQuery("MessageBody", Uri.EscapeDataString(messageBody.ToString((IFormatProvider)CultureInfo.InvariantCulture)));
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");

            var content = new Utf8JsonRequestContent();
            WriteHeadersJson(content.JsonWriter);
            request.Content = content;
            return message;
        }
    }
}