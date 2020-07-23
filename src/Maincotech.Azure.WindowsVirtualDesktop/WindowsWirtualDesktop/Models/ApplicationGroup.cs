using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class ApplicationGroup : SerializableResource<ApplicationGroup>
    {
        public ApplicationGroup()
        {
            TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public ApplicationGroup(string hostPoolName, string tenantName, string tenantGroupName = RDInfraStringConstants.DefaultTenantGroupName) : this(null, hostPoolName, tenantName, tenantGroupName)
        {
        }

        public ApplicationGroup(string appGroupName, string hostPoolName, string tenantName, string tenantGroupName)
        {
            AppGroupName = appGroupName;
            HostPoolName = hostPoolName;
            TenantName = tenantName;
            TenantGroupName = tenantGroupName;
        }

        [CRUDRequired]
        [JsonPropertyName("tenantGroupName")]
        public string TenantGroupName { get; set; }

        [CRUDRequired]
        [JsonPropertyName("tenantName")]
        public string TenantName { get; set; }

        [CRUDRequired]
        [JsonPropertyName("hostPoolName")]
        public string HostPoolName { get; set; }

        [JsonPropertyName("appGroupName")]
        [CRUDRequired(CRUDOperationsTypes.WithoutList)]
        public string AppGroupName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("resourceType")]
        [CRUDRequired(CRUDOperationsTypes.Create)]
        public AppGroupResource? ResourceType { get; set; }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }

    public enum AppGroupResource
    {
        RemoteApp,
        Desktop,
    }
}