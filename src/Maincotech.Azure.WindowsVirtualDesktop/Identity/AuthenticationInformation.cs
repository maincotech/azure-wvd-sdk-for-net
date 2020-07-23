namespace Azure.Identity
{
    public class AuthenticationInformation
    {
        public string Resource { get; set; }
        public string DeploymentUrl { get; set; }
        public string Authority { get; set; }
        public string RedirectUrl { get; set; }
        public string ClientId { get; set; }
    }
}