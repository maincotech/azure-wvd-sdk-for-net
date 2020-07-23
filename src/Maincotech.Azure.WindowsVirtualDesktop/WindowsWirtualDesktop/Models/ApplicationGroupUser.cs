using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class ApplicationGroupUser : SerializableResource<ApplicationGroupUser>
    {
        [JsonPropertyName("userPrincipalName")]
        [CRUDRequired(CRUDOperationsTypes.WithoutList)]
        public string UserPrincipalName { get; set; }

        [JsonPropertyName("tenantName")]
        [CRUDRequired]
        public string TenantName { get; set; }

        [JsonPropertyName("tenantGroupName")]
        [CRUDRequired]
        public string TenantGroupName { get; set; }

        [JsonPropertyName("hostPoolName")]
        [CRUDRequired]
        public string HostPoolName { get; set; }

        [JsonPropertyName("appGroupName")]
        [CRUDRequired]
        public string AppGroupName { get; set; }

        public ApplicationGroupUser()
        {
            TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public ApplicationGroupUser(string appGroupName, string hostPoolName, string tenantName, string tenantGroupName) : this(null, appGroupName, hostPoolName, tenantName, tenantGroupName)
        {
        }

        public ApplicationGroupUser(string userPrincipalName, string appGroupName, string hostPoolName, string tenantName, string tenantGroupName)
        {
            UserPrincipalName = userPrincipalName;
            AppGroupName = appGroupName;
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