using System;
using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class Tenant : SerializableResource<Tenant>
    {
        [CRUDRequired()]
        [JsonPropertyName("tenantGroupName")]
        public string TenantGroupName { get; set; }

        [CRUDRequired(CRUDOperationsTypes.Create)]
        [JsonPropertyName("aadTenantId")]
        public string AadTenantId { get; set; }

        [CRUDRequired(CRUDOperationsTypes.Create | CRUDOperationsTypes.Update | CRUDOperationsTypes.Get)]
        [JsonPropertyName("tenantName")]
        public string TenantName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("ssoAdfsAuthority")]
        public string SsoAdfsAuthority { get; set; }

        [JsonPropertyName("ssoClientId")]
        public string SsoClientId { get; set; }

        [JsonPropertyName("ssoClientSecret")]
        public string SsoClientSecret { get; set; }

        [CRUDRequired(CRUDOperationsTypes.Create)]
        [JsonPropertyName("azureSubscriptionId")]
        public Guid? AzureSubscriptionId { get; set; }

        [JsonPropertyName("logAnalyticsWorkspaceId")]
        public string LogAnalyticsWorkspaceId { get; set; }

        [JsonPropertyName("logAnalyticsPrimaryKey")]
        public string LogAnalyticsPrimaryKey { get; set; }

        public Tenant()
        {
            this.TenantName = null;
            this.TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public Tenant(string name)
        {
            this.TenantName = name;
            this.TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        [JsonPropertyName("ssoSecretType")]
        public SecretType? SsoClientSecretType { get; set; }

        public enum SecretType
        {
            SharedKey,
            Certificate,
        }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}