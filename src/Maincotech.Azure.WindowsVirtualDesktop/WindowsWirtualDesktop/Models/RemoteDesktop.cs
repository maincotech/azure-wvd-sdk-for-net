using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class RemoteDesktop : SerializableResource<RemoteDesktop>
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

        [JsonPropertyName("appGroupName")]
        [CRUDRequired]
        public string AppGroupName { get; set; }

        [JsonPropertyName("remoteDesktopName")]
        public string RemoteDesktopName { get; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("showInWebFeed")]
        public bool? ShowInWebFeed { get; set; }

        public RemoteDesktop()
        {
            RemoteDesktopName = RDInfraStringConstants.DefaultRemoteDesktopName;
            TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public RemoteDesktop(ApplicationGroup applicationGroup) : this(null, applicationGroup.AppGroupName, applicationGroup.HostPoolName, applicationGroup.TenantName, applicationGroup.TenantGroupName)
        {
        }

        public RemoteDesktop(string remoteDesktopName, string appGroupName, string hostPoolName, string tenantName, string tenantGroupName)
        {
            RemoteDesktopName = remoteDesktopName;
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