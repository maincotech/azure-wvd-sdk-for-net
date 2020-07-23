using Azure.Core;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class WVDClientSecretCredential : WVDTokenCredential
    {
        private readonly ClientCredential _clientCredential;

        public WVDClientSecretCredential(string clientId, string clientSecret, string deploymentUrl = RDInfraStringConstants.DefaultDeploymentUrl) : base(deploymentUrl)
        {
            _clientCredential = new ClientCredential(clientId, clientSecret);
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var result = AuthenticationContext.AcquireTokenAsync(AuthenticationInformation.Resource, _clientCredential).GetAwaiter().GetResult();
            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var result = await AuthenticationContext.AcquireTokenAsync(AuthenticationInformation.Resource, _clientCredential).ConfigureAwait(false);
            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }
    }
}