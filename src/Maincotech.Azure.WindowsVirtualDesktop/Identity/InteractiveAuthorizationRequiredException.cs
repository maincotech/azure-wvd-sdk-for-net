using System;

namespace Azure.Identity
{
    [Serializable]
    public class InteractiveAuthorizationRequiredException : Exception
    {
        public InteractiveAuthorizationRequiredException()
        {
        }

        public InteractiveAuthorizationRequiredException(string message) : base(message)
        {
        }

        public InteractiveAuthorizationRequiredException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InteractiveAuthorizationRequiredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}