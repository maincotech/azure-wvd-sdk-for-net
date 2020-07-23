using System;
using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class RegistrationInfo : SerializableResource<RegistrationInfo>
    {
        [JsonPropertyName("tenantName")]
        public string TenantName { get; set; }

        [JsonPropertyName("tenantGroupName")]
        public string TenantGroupName { get; set; }

        [JsonPropertyName("hostPoolName")]
        public string HostPoolName { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("expirationTime")]
        public DateTime ExpirationTime { get; set; }

        public RegistrationInfo()
        {
        }

        public RegistrationInfo(HostPool hostPool)
        {
            TenantGroupName = hostPool.TenantGroupName;
            TenantName = hostPool.TenantName;
            HostPoolName = hostPool.HostPoolName;
        }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}