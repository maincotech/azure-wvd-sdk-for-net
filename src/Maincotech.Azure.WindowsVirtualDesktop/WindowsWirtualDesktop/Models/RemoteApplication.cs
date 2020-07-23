using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class RemoteApplication : SerializableResource<RemoteApplication>
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

        [JsonPropertyName("remoteAppName")]
        [CRUDRequired(CRUDOperationsTypes.WithoutList)]
        public string RemoteAppName { get; set; }

        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }

        [JsonPropertyName("appAlias")]
        public string AppAlias { get; set; }

        [JsonPropertyName("commandLineSetting")]
        public CommandLineSetting? CommandLineSetting { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("iconIndex")]
        public int? IconIndex { get; set; }

        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }

        [JsonPropertyName("requiredCommandLine")]
        public string RequiredCommandLine { get; set; }

        [JsonPropertyName("showInWebFeed")]
        public bool? ShowInWebFeed { get; set; }

        public RemoteApplication()
        {
            TenantGroupName = RDInfraStringConstants.DefaultTenantGroupName;
        }

        public RemoteApplication(ApplicationGroup applicationGroup):this(null,applicationGroup.AppGroupName,applicationGroup.HostPoolName, applicationGroup.TenantName,applicationGroup.TenantGroupName)
        {

        }

        public RemoteApplication(string remoteAppName, string appGroupName, string hostPoolName, string tenantName, string tenantGroupName)
        {
            RemoteAppName = remoteAppName;
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

    public enum CommandLineSetting
    {
        DoNotAllow,
        Allow,
        Require,
    }
}