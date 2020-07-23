using Azure.Core;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Azure.Identity
{
    public abstract class WVDTokenCredential : TokenCredential
    {
        private AuthenticationInformation _authenticationInformation;

        protected AuthenticationInformation AuthenticationInformation
        {
            get
            {
                if (_authenticationInformation == null)
                {
                    _authenticationInformation = AuthenticationHelper.GetAuthenticationInformation(_deploymentUrl).GetAwaiter().GetResult();
                }
                return _authenticationInformation;
            }
        }

        private readonly string _deploymentUrl;
        private AuthenticationContext _authContext;

        protected AuthenticationContext AuthenticationContext
        {
            get
            {
                if (_authContext == null)
                {
                    _authContext = new AuthenticationContext(AuthenticationInformation.Authority);
                }
                return _authContext;
            }
        }

        public WVDTokenCredential(string deploymentUrl = RDInfraStringConstants.DefaultDeploymentUrl)
        {
            _deploymentUrl = deploymentUrl;
        }
    }
}