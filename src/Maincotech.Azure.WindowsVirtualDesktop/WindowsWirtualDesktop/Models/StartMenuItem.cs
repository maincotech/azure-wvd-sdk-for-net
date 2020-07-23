using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class StartMenuItem : SerializableResource<StartMenuItem>
    {
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

        [JsonPropertyName("appAlias")]
        public string AppAlias { get; set; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }

        [JsonPropertyName("commandLineArguments")]
        public string CommandLineArguments { get; set; }

        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }

        [JsonPropertyName("iconIndex")]
        public int IconIndex { get; set; }

        public StartMenuItem()
        {
        }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}