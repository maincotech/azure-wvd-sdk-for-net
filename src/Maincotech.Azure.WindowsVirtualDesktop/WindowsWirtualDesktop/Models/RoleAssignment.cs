using System;
using System.Text.Json.Serialization;

namespace Azure.WindowsWirtualDesktop.Models
{
    public class RoleAssignment : SerializableResource<RoleAssignment>
    {
        private string _TenantGroupName;

        public string TenantGroupName
        {
            get
            {
                if (string.IsNullOrEmpty(_TenantGroupName))
                {
                    _TenantGroupName = ManagementObjectScope.GetObjectName(this.Scope, ManagementObjectScope.Type.TenantGroup);
                }

                return _TenantGroupName;
            }
            set
            {
                _TenantGroupName = value;
            }
        }

        private string _TenantName;

        public string TenantName
        {
            get
            {
                if (string.IsNullOrEmpty(_TenantName))
                {
                    _TenantName = ManagementObjectScope.GetObjectName(this.Scope, ManagementObjectScope.Type.Tenant);
                }
                return _TenantName;
            }
            set
            {
                _TenantName = value;
            }
        }

        private string _HostPoolName;

        public string HostPoolName
        {
            get
            {
                if (string.IsNullOrEmpty(_HostPoolName))
                {
                    _HostPoolName = ManagementObjectScope.GetObjectName(this.Scope, ManagementObjectScope.Type.HostPool);
                }
                return _HostPoolName;
            }
            set
            {
                _HostPoolName = value;
            }
        }

        private string _AppGroupName;

        public string AppGroupName
        {
            get
            {
                if (string.IsNullOrEmpty(_AppGroupName))
                {
                    _AppGroupName = ManagementObjectScope.GetObjectName(this.Scope, ManagementObjectScope.Type.AppGroup);
                }
                return _AppGroupName;
            }
            set
            {
                _AppGroupName = value;
            }
        }

        [JsonPropertyName("roleAssignmentId")]
        public Guid RoleAssignmentId { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("signInName")]
        public string SignInName { get; set; }

        [JsonPropertyName("groupObjectId")]
        public string GroupObjectId { get; set; }

        [JsonPropertyName("aadTenantId")]
        public string AadTenantId { get; set; }

        [JsonPropertyName("appId")]
        public string AppId { get; set; }

        [JsonPropertyName("roleDefinitionName")]
        [CRUDRequired(CRUDOperationsTypes.Create | CRUDOperationsTypes.Delete)]
        public string RoleDefinitionName { get; set; }

        [JsonPropertyName("roleDefinitionId")]
        [CRUDRequired(CRUDOperationsTypes.Create)]
        public Guid RoleDefinitionId { get; set; }

        [JsonPropertyName("objectId")]
        public Guid ObjectId { get; set; }

        [JsonPropertyName("objectType")]
        public string ObjectType { get; set; }

        public RoleAssignment()
        {
        }

        public RoleAssignment(string roleDefinitionName, string signInName, Tenant scope, bool isServicePrincipal = false)
        {
            RoleDefinitionName = roleDefinitionName;
            if (isServicePrincipal)
            {
                AppId = signInName;
            }
            else
            {
                SignInName = signInName;
            }

            TenantGroupName = scope.TenantGroupName;
            TenantName = scope.TenantName;
        }

        public RoleAssignment(string roleDefinitionName, string signInName, HostPool scope, bool isServicePrincipal = false)
        {
            RoleDefinitionName = roleDefinitionName;
            if (isServicePrincipal)
            {
                AppId = signInName;
            }
            else
            {
                SignInName = signInName;
            }

            TenantGroupName = scope.TenantGroupName;
            TenantName = scope.TenantName;
            HostPoolName = scope.HostPoolName;
        }

        public RoleAssignment(string roleDefinitionName, string signInName, ApplicationGroup scope, bool isServicePrincipal = false)
        {
            RoleDefinitionName = roleDefinitionName;
            if (isServicePrincipal)
            {
                AppId = signInName;
            }
            else
            {
                SignInName = signInName;
            }

            TenantGroupName = scope.TenantGroupName;
            TenantName = scope.TenantName;
            HostPoolName = scope.HostPoolName;
            AppGroupName = scope.AppGroupName;
        }

        protected override string Serialize()
        {
            return Serialize(this);
        }
    }
}