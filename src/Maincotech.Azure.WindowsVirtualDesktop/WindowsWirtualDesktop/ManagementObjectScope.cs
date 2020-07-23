using System;
using System.Text;

namespace Azure.WindowsWirtualDesktop
{
    public class ManagementObjectScope
    {
        private static ManagementObjectScope FromUrlPath(string scope)
        {
            ManagementObjectScope rdMgmtObjectScope = new ManagementObjectScope();
            if (string.IsNullOrWhiteSpace(scope))
                return rdMgmtObjectScope;
            string[] s = scope.Split('/');
            if (s.Length <= 2 && !string.IsNullOrWhiteSpace(s[0]) && !string.IsNullOrWhiteSpace(s[0]))
                throw new ArgumentException("Invalid scope format in RdMgmtObjectScope '" + scope + "'");
            rdMgmtObjectScope.TenantGroupName = rdMgmtObjectScope.GetObjectName(s, ManagementObjectScope.Type.TenantGroup, scope);
            rdMgmtObjectScope.TenantName = rdMgmtObjectScope.GetObjectName(s, ManagementObjectScope.Type.Tenant, scope);
            rdMgmtObjectScope.HostPoolName = rdMgmtObjectScope.GetObjectName(s, ManagementObjectScope.Type.HostPool, scope);
            rdMgmtObjectScope.AppGroupName = rdMgmtObjectScope.GetObjectName(s, ManagementObjectScope.Type.AppGroup, scope);
            if (s.Length >= 10)
                throw new ArgumentException("Extra scope format in RdMgmtObjectScope '" + scope + "'");
            return rdMgmtObjectScope;
        }

        private string GetObjectName(string[] s, ManagementObjectScope.Type scopeType, string scope)
        {
            int index = (int)(scopeType + 1) * 2;
            if (s.Length >= index + 1 && !s[index - 1].Equals(ManagementObjectScope.ObjectSegmentNames[(int)scopeType], StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Invalid " + ManagementObjectScope.ObjectNames[(int)scopeType] + " scope format in RdMgmtObjectScope '" + scope + "'");
            return s.Length < index + 1 ? (string)null : s[index];
        }

        public static string GetObjectName(string scope, ManagementObjectScope.Type scopeType)
        {
            if (string.IsNullOrWhiteSpace(scope))
                return (string)null;
            string[] strArray = scope.Split('/');
            if (strArray.Length != 0 && !string.IsNullOrWhiteSpace(strArray[0]))
                return (string)null;
            int index = (int)(scopeType + 1);
            return strArray.Length < index + 1 || string.IsNullOrWhiteSpace(strArray[index]) ? (string)null : strArray[index];
        }

        public bool IsValid()
        {
            bool flag = string.IsNullOrEmpty(this.TenantGroupName) && string.IsNullOrEmpty(this.TenantName) && string.IsNullOrEmpty(this.HostPoolName) && string.IsNullOrEmpty(this.AppGroupName);
            if (!flag)
                flag = !string.IsNullOrEmpty(this.TenantGroupName) && !string.IsNullOrEmpty(this.TenantName) && !string.IsNullOrEmpty(this.HostPoolName) && !string.IsNullOrEmpty(this.AppGroupName);
            if (!flag)
                flag = !string.IsNullOrEmpty(this.TenantGroupName) && !string.IsNullOrEmpty(this.TenantName) && !string.IsNullOrEmpty(this.HostPoolName) && string.IsNullOrEmpty(this.AppGroupName);
            if (!flag)
                flag = !string.IsNullOrEmpty(this.TenantGroupName) && !string.IsNullOrEmpty(this.TenantName) && string.IsNullOrEmpty(this.HostPoolName) && string.IsNullOrEmpty(this.AppGroupName);
            if (!flag)
                flag = !string.IsNullOrEmpty(this.TenantGroupName) && string.IsNullOrEmpty(this.TenantName) && string.IsNullOrEmpty(this.HostPoolName) && string.IsNullOrEmpty(this.AppGroupName);
            return flag;
        }

        public string Scope
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (this.TenantGroupName != null)
                    stringBuilder.Append("/" + this.TenantGroupName);
                if (this.TenantName != null)
                    stringBuilder.Append("/" + this.TenantName);
                if (this.HostPoolName != null)
                    stringBuilder.Append("/" + this.HostPoolName);
                if (this.AppGroupName != null)
                    stringBuilder.Append("/" + this.AppGroupName);
                if (stringBuilder.Length == 0)
                    stringBuilder.Append("/");
                return stringBuilder.ToString();
            }
        }

        public string AsUrlPath()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.TenantGroupName != null)
            {
                stringBuilder.Append("/" + ManagementObjectScope.ObjectSegmentNames[0]);
                if (!string.IsNullOrWhiteSpace(this.TenantGroupName))
                    stringBuilder.Append("/" + this.TenantGroupName);
            }
            if (this.TenantName != null)
            {
                stringBuilder.Append("/" + ManagementObjectScope.ObjectSegmentNames[1]);
                if (!string.IsNullOrWhiteSpace(this.TenantName))
                    stringBuilder.Append("/" + this.TenantName);
            }
            if (this.HostPoolName != null)
            {
                stringBuilder.Append("/" + ManagementObjectScope.ObjectSegmentNames[2]);
                if (!string.IsNullOrWhiteSpace(this.HostPoolName))
                    stringBuilder.Append("/" + this.HostPoolName);
            }
            if (this.AppGroupName != null)
            {
                stringBuilder.Append("/" + ManagementObjectScope.ObjectSegmentNames[3]);
                if (!string.IsNullOrWhiteSpace(this.AppGroupName))
                    stringBuilder.Append("/" + this.AppGroupName);
            }
            if (stringBuilder.Length == 0)
                stringBuilder.Append("/");
            return stringBuilder.ToString();
        }

        public string TenantGroupName { get; set; }

        public string TenantName { get; set; }

        public string HostPoolName { get; set; }

        public string AppGroupName { get; set; }

        public static string[] ObjectSegmentNames { get; } = new string[4]
        {
      "TenantGroups",
      "Tenants",
      "HostPools",
      "AppGroups"
        };

        public static string[] ObjectNames { get; } = new string[4]
        {
      "Tenant Group",
      "Tenant",
      "Host Pool",
      "Application Group"
        };

        public enum Type
        {
            TenantGroup,
            Tenant,
            HostPool,
            AppGroup,
        }
    }
}