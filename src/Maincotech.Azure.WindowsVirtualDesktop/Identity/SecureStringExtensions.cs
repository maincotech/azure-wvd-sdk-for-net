using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Azure.Identity
{
    internal static class SecureStringExtensions
    {
        public static string ToClearText(this SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}