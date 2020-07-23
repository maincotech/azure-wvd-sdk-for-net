using Azure.Core;
using System;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class WVDUsernamePasswordCredential : WVDTokenCredential
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _username;
        private readonly SecureString _password;

        public WVDUsernamePasswordCredential(string username, string password, string clientId, string clientSecreet, string deploymentUrl = RDInfraStringConstants.DefaultDeploymentUrl) : base(deploymentUrl)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));
            _password = (password != null) ? password.ToSecureString() : throw new ArgumentNullException(nameof(password));
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _clientSecret = clientSecreet ?? throw new ArgumentNullException(nameof(clientSecreet));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var token = AuthenticationHelper.GetTokenAsync(AuthenticationInformation.Resource, _clientId, _clientSecret, _username, _password).GetAwaiter().GetResult();
            return new AccessToken(token.AccessToken, DateTimeOffset.FromUnixTimeSeconds(token.ExpiresOn));
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var token = await AuthenticationHelper.GetTokenAsync(AuthenticationInformation.Resource, _clientId, _clientSecret, _username, _password);
            return new AccessToken(token.AccessToken, DateTimeOffset.FromUnixTimeSeconds(token.ExpiresOn));
        }
    }
}