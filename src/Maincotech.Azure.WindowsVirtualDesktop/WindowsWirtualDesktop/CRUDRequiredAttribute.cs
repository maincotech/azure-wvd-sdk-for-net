using System;

namespace Azure
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    internal sealed class CRUDRequiredAttribute : Attribute
    {
        public CRUDOperationsTypes Value { get; private set; }

        public CRUDRequiredAttribute(CRUDOperationsTypes operations = CRUDOperationsTypes.All)
        {
            Value = operations;
        }
    }

    [Flags]
    internal enum CRUDOperationsTypes : short
    {
        Create = 1,
        Delete = 2,
        Update = 4,
        Get = 8,
        List = 16,
        WithoutList = Create | Delete | Update | Get,
        All = Create | Delete | Update | Get | List
    }
}