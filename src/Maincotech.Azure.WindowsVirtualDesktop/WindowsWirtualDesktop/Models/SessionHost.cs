using System;
using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class SessionHost : SerializableResource<SessionHost>
    {
        [JsonPropertyName("sessionHostName")]
        [CRUDRequired(CRUDOperationsTypes.WithoutList)]
        public string SessionHostName { get; set; }

        [JsonPropertyName("tenantName")]
        [CRUDRequired]
        public string TenantName { get; set; }

        [JsonPropertyName("tenantGroupName")]
        [CRUDRequired]
        public string TenantGroupName { get; set; }

        [JsonPropertyName("hostPoolName")]
        [CRUDRequired]
        public string HostPoolName { get; set; }

        [JsonPropertyName("allowNewSession")]
        public bool AllowNewSession { get; set; }

        [JsonPropertyName("azureVmId")]
        public string AzureVmId { get; set; }

        [JsonPropertyName("azureResourceId")]
        public string AzureResourceId { get; set; }

        [JsonPropertyName("sessions")]
        public int Sessions { get; set; }

        [JsonPropertyName("lastHeartBeat")]
        public DateTime LastHeartBeat { get; set; }

        [JsonPropertyName("agentVersion")]
        public string AgentVersion { get; set; }

        [JsonPropertyName("assignedUser")]
        public string AssignedUser { get; set; }

        [JsonPropertyName("osVersion")]
        public string OsVersion { get; set; }

        [JsonPropertyName("sxSStackVersion")]
        public string SxSStackVersion { get; set; }

        [JsonPropertyName("status")]
        public SessionHostStatus Status { get; set; } = SessionHostStatus.Unavailable;

        [JsonPropertyName("sessionHostHealthCheckResult")]
        public string SessionHostHealthCheckResult { get; set; }

        [JsonPropertyName("updateState")]
        public UpgradeState UpdateState { get; set; }

        [JsonPropertyName("lastUpdateTime")]
        public DateTime? LastUpdateTime { get; set; }

        [JsonPropertyName("updateErrorMessage")]
        public string UpdateErrorMessage { get; set; }

        public SessionHost(string hostPoolName, string tenantName, string tenantGroupName = RDInfraStringConstants.DefaultTenantGroupName) : this(null, hostPoolName, tenantName, tenantGroupName)
        {
        }

        public SessionHost()
        {
            TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public SessionHost(string sessionHostName, string hostPoolName, string tenantName, string tenantGroupName)
        {
            SessionHostName = sessionHostName;
            HostPoolName = hostPoolName;
            TenantName = tenantName;
            TenantGroupName = tenantGroupName;
        }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }

    public enum SessionHostStatus
    {
        Available,
        Unavailable,
        Shutdown,
        Disconnected,
        Upgrading,
        UpgradeFailed,
        NoHeartbeat,
        NotJoinedToDomain,
        DomainTrustRelationshipLost,
        SxSStackListenerNotReady,
        FSLogixNotHealthy,
        NeedsAssistance,
    }

    public enum UpgradeState
    {
        Initial,
        Pending,
        Started,
        Succeeded,
        Failed,
        FailedHostRename,
    }
}