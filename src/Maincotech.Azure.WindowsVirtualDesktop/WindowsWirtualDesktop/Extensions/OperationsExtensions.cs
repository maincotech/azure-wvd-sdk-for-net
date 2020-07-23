using Azure.WindowsWirtualDesktop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop
{
    public static class OperationsExtensions
    {
        public static Response DeleteForce(this WindowsWirtualDesktopManagementClient client, SessionHost sessionHost)
        {
            var userSessions = client.UserSessionOperations.List(new UserSession(sessionHost.HostPoolName, sessionHost.TenantName, sessionHost.TenantGroupName)).Value.Where(x => x.SessionHostName == sessionHost.SessionHostName);
            if (userSessions.Any())
            {
                foreach (var userSession in userSessions)
                {
                    client.UserSessionOperations.Logoff(userSession, true);
                }
            }

            return client.SessionHostOperations.Delete(sessionHost);
        }

        public static async Task<Response> DeleteForceAsync(this WindowsWirtualDesktopManagementClient client, SessionHost sessionHost)
        {
            var result = await client.UserSessionOperations.ListAsync(new UserSession(sessionHost.HostPoolName, sessionHost.TenantName, sessionHost.TenantGroupName)).ConfigureAwait(false);
            var userSessions = result.Value.Where(x => x.SessionHostName == sessionHost.SessionHostName);
            if (userSessions.Any())
            {
                foreach (var userSession in userSessions)
                {
                    await client.UserSessionOperations.LogoffAsync(userSession, true).ConfigureAwait(false);
                }
            }

            return await client.SessionHostOperations.DeleteAsync(sessionHost).ConfigureAwait(false);
        }

        public static Response DeleteForce(this WindowsWirtualDesktopManagementClient client, HostPool hostPool)
        {
            var appGroups = client.ApplicationGroupOperations.List(new ApplicationGroup(hostPool.HostPoolName, hostPool.TenantName, hostPool.TenantGroupName));
            foreach (var appGroup in appGroups.Value)
            {
                client.ApplicationGroupOperations.Delete(appGroup);
            }
            return client.HostPoolsOperations.Delete(hostPool);
        }

        public static async Task<Response> DeleteForceAysnc(this WindowsWirtualDesktopManagementClient client, HostPool hostPool)
        {
            var appGroups = await client.ApplicationGroupOperations.ListAsync(new ApplicationGroup(hostPool.HostPoolName, hostPool.TenantName, hostPool.TenantGroupName)).ConfigureAwait(false);
            foreach (var appGroup in appGroups.Value)
            {
                await client.ApplicationGroupOperations.DeleteAsync(appGroup).ConfigureAwait(false);
            }
            return await client.HostPoolsOperations.DeleteAsync(hostPool).ConfigureAwait(false);
        }
    }
}