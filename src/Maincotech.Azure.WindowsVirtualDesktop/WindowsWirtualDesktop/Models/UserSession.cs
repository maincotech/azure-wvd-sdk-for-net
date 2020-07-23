using System;
using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class UserSession : SerializableResource<UserSession>
    {
        [JsonPropertyName("tenantGroupName")]
        [CRUDRequired]
        public string TenantGroupName { get; set; }

        [JsonPropertyName("tenantName")]
        [CRUDRequired]
        public string TenantName { get; set; }

        [JsonPropertyName("hostPoolName")]
        [CRUDRequired]
        public string HostPoolName { get; set; }

        [JsonPropertyName("sessionHostName")]
        [CRUDRequired(CRUDOperationsTypes.WithoutList)]
        public string SessionHostName { get; set; }

        [JsonPropertyName("userPrincipalName")]
        public string UserPrincipalName { get; set; }

        [JsonPropertyName("adUserName")]
        public string AdUserName { get; set; }

        [JsonPropertyName("createTime")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("sessionId")]
        [CRUDRequired(CRUDOperationsTypes.WithoutList)]
        public int SessionId { get; set; }

        [JsonPropertyName("applicationType")]
        public string ApplicationType { get; set; }

        [JsonPropertyName("sessionState")]
        public string SessionState { get; set; }

        public UserSession()
        {
            TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public UserSession(string hostPoolName, string tenantName, string tenantGroupName = RDInfraStringConstants.DefaultTenantGroupName)
        {
            HostPoolName = hostPoolName;
            TenantName = tenantName;
            TenantGroupName = tenantGroupName;
        }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}