using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class AuthenticationHelper
    {
        internal static async Task<AuthenticationInformation> GetAuthenticationInformation(string deploymentUrl = RDInfraStringConstants.DefaultDeploymentUrl, HttpMessageHandler testHandler = null)
        {
            var result = new AuthenticationInformation { DeploymentUrl = deploymentUrl };
            using (HttpClient client = testHandler != null ? new HttpClient(testHandler) : new HttpClient())
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{deploymentUrl.TrimEnd('/')}/RdsManagement/V1");
                try
                {
                    using HttpResponseMessage httpResponseMessage = await client.SendAsync(request).ConfigureAwait(false);
                    if (httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized)
                        throw new HttpRequestException(string.Format("{0}:{1}", deploymentUrl, httpResponseMessage.StatusCode.ToString()));
                    var authString = httpResponseMessage.Headers.WwwAuthenticate.ToString();
                    string[] strArray = authString.Split(';');
                    if (strArray == null || strArray.Length != 5)
                        throw new NotSupportedException($"{authString} is not supported");
                    result.Authority = strArray[0].Replace("MS-WARA-CLAIMS hint=\"Authority=", string.Empty).Trim();
                    result.ClientId = strArray[1].Replace("Client=", string.Empty).Trim();
                    result.RedirectUrl = strArray[2].Replace("Redirect=", string.Empty).Trim();
                    result.Resource = strArray[3].Replace("Resource=", string.Empty).Trim();
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    while (exception.InnerException != null)
                        exception = exception.InnerException;
                    throw exception;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resouce"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="scope"></param>
        /// <param name="testHandler"></param>
        /// <returns></returns>
        internal static async Task<Token> GetTokenAsync(string resouce, string clientId, string clientSecret, string username, SecureString password, string scope = "openid", HttpMessageHandler testHandler = null)
        {
            string tokenEndpoint = "https://login.microsoftonline.com/common/oauth2/token";
            //resource=https%3A%2F%2Fmrs-prod.ame.gbl%2Fmrs-RDInfra-prod&client_id=fa4345a4-a730-4230-84a8-7d9651b86739&client_info=1&grant_type=password&username=trior%40maincotech.onmicrosoft.com&password=aiPOCO1013%21%40&scope=openid
            var body = $"resource={resouce}&client_id={clientId}&client_secret={clientSecret}&grant_type=password&username={username}&password={password.ToClearText()}&scope={scope}";
            var stringContent = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

            using (HttpClient client = testHandler != null ? new HttpClient(testHandler) : new HttpClient())
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint) { Content = stringContent };
                try
                {
                    using HttpResponseMessage httpResponseMessage = await client.SendAsync(request).ConfigureAwait(false);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var token = await httpResponseMessage.Content.ReadAsStringAsync().ContinueWith<Token>(stream =>
                        {
                            return Token.Deserialize(stream.Result);
                        });
                        return token;
                    }
                    else
                    {
                        var errorDetails = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                        try
                        {
                            var errorObject = JsonDocument.Parse(errorDetails).RootElement;
                            if (errorObject.GetProperty("error").ValueEquals("invalid_grant"))
                            {
                                throw new InteractiveAuthorizationRequiredException(errorObject.GetProperty("error_description").GetString());
                                //var authResult = await authenticationContext.AcquireTokenAsync(resouce, clientId, new Uri("msal3bbbabc7-0fd8-458b-9254-c73f08dd9060://auth"), new PlatformParameters(PromptBehavior.Auto));
                                //return new Token() { AccessToken = authResult.AccessToken, ExpiresOn = authResult.ExpiresOn.ToUnixTimeSeconds() };
                            }
                        }
                        catch (JsonException e)
                        {
                        }
                        throw new Exception(errorDetails);
                    }
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    while (exception.InnerException != null)
                        exception = exception.InnerException;
                    throw exception;
                }
            }
        }
    }
}