using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class RoleDefinition : SerializableResource<RoleDefinition>
    {
        [JsonPropertyName("roleDefinitionName")]
        public string RoleDefinitionName { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("isCustom")]
        public bool IsCustom { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("actions")]
        public List<string> Actions { get; set; }

        [JsonPropertyName("assignableScopes")]
        public List<string> AssignableScopes { get; set; }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}