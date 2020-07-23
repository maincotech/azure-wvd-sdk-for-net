using Azure.Core.Pipeline;
using Azure.WindowsWirtualDesktop.Models;
using System;

namespace Azure.WindowsWirtualDesktop
{
    partial class ApplicationGroupUserRestOperations : CRUDRestOperations<ApplicationGroupUser>
    {
        public ApplicationGroupUserRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null) : base(clientDiagnostics, pipeline, endpoint)
        {
        }

        public override string GetResourceRelativeUrl(ApplicationGroupUser model)
        {
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/{model.AppGroupName}/AssignedUsers/{model.UserPrincipalName}/";
        }

        public override string GetResourcesRelativeUrl(ApplicationGroupUser model)
        {
            //GET https://rdbroker.wvd.microsoft.com/RdsManagement/V1/TenantGroups/Default%20Tenant%20Group/Tenants/maincotech.onmicrosoft.com/HostPools/ITHostpool/AppGroups/Basic%20app%20group/AssignedUsers?PageSize=1000&LastEntry=&SortField=UserPrincipalName&IsDescending=False&InitialSkip=0 HTTP/1.1
            return $"TenantGroups/{model.TenantGroupName}/Tenants/{model.TenantName}/HostPools/{model.HostPoolName}/AppGroups/{model.AppGroupName}/AssignedUsers/";
        }
    }
}