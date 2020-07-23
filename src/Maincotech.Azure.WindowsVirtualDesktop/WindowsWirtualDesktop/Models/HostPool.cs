using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class HostPool : SerializableResource<HostPool>
    {
        public HostPool() : this(null, null, RDInfraStringConstants.DefaultTenantGroupName)
        {
        }

        public HostPool(string tenantName) : this(null, tenantName, RDInfraStringConstants.DefaultTenantGroupName)
        {
        }

        public HostPool(string hostPoolName, string tenantName) : this(hostPoolName, tenantName, RDInfraStringConstants.DefaultTenantGroupName)
        {
        }

        public HostPool(string hostPoolName, string tenantName, string tenantGroupName)
        {
            HostPoolName = hostPoolName;
            TenantName = tenantName;
            TenantGroupName = tenantGroupName;
        }

        [JsonPropertyName("tenantName")]
        [CRUDRequired()]
        public string TenantName { get; set; }

        [CRUDRequired()]
        [JsonPropertyName("tenantGroupName")]
        public string TenantGroupName { get; set; }

        [CRUDRequired(CRUDOperationsTypes.Create | CRUDOperationsTypes.Update | CRUDOperationsTypes.Delete | CRUDOperationsTypes.Get)]
        [JsonPropertyName("hostPoolName")]
        public string HostPoolName { get; set; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("persistent")]
        public bool Persistent { get; set; }

        [JsonPropertyName("customRdpProperty")]
        public string CustomRdpProperty { get; set; }

        [JsonPropertyName("maxSessionLimit")]
        public int? MaxSessionLimit { get; set; }

        [JsonPropertyName("loadBalancerType")]
        public SessionHostLoadBalancingAlgorithm LoadBalancerType { get; set; }

        [JsonPropertyName("validationEnv")]
        public bool? ValidationEnv { get; set; }

        [JsonPropertyName("ring")]
        public int? Ring { get; set; }

        [JsonPropertyName("assignmentType")]
        public PersonalDesktopAssignmentType? AssignmentType { get; set; }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}