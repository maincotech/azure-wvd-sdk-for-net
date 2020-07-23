#nullable disable

using Azure.Core;
using Azure.Core.Pipeline;
using System;

namespace Azure.WindowsWirtualDesktop
{
    /// <summary> WindowsWirtualDesktop service management client. </summary>
    /// <see cref="https://docs.microsoft.com/en-us/rest/api/virtual-desktop/"/>
    public class WindowsWirtualDesktopManagementClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _subscriptionId;

        /// <summary> Initializes a new instance of WindowsWirtualDesktopManagementClient for mocking. </summary>
        protected WindowsWirtualDesktopManagementClient()
        {
        }

        /// <summary> Initializes a new instance of WindowsWirtualDesktopManagementClient. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="tokenCredential"> The OAuth token for making client requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public WindowsWirtualDesktopManagementClient(TokenCredential tokenCredential, WindowsWirtualDesktopManagementClientOptions options = null) : this(null, tokenCredential, options)
        {
        }

        /// <summary> Initializes a new instance of WindowsWirtualDesktopManagementClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="tokenCredential"> The OAuth token for making client requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> This occurs when one of the required arguments is null. </exception>
        public WindowsWirtualDesktopManagementClient(Uri endpoint, TokenCredential tokenCredential, WindowsWirtualDesktopManagementClientOptions options = null)
        {
            endpoint ??= new Uri("https://rdbroker.wvd.microsoft.com/");

            options ??= new WindowsWirtualDesktopManagementClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            //_pipeline = ManagementPipelineBuilder.Build(tokenCredential, endpoint, options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, "https://mrs-prod.ame.gbl/mrs-RDInfra-prod"));
            _endpoint = endpoint;
        }

        public virtual TenantOperations TenantOperations => new TenantOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual HostPoolsOperations HostPoolsOperations => new HostPoolsOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual ApplicationGroupOperations ApplicationGroupOperations => new ApplicationGroupOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual ApplicationGroupUserOperations ApplicationGroupUserOperations => new ApplicationGroupUserOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual SessionHostOperations SessionHostOperations => new SessionHostOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual UserSessionOperations UserSessionOperations => new UserSessionOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual RemoteApplicationOperations RemoteApplicationOperations => new RemoteApplicationOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual RemoteDesktopOperations RemoteDesktopOperations => new RemoteDesktopOperations(_clientDiagnostics, _pipeline, _endpoint);
        public virtual AuthorizationOperations AuthorizationOperations => new AuthorizationOperations(_clientDiagnostics, _pipeline, _endpoint);
    }
}