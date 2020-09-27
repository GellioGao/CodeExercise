using System;
using System.Runtime.Serialization;

namespace ParseTheParcel.Exceptions
{
    [Serializable]
    public class UnexpectedPackageException : Exception
    {
        public UnexpectedPackageException() { }
        public UnexpectedPackageException(string message) : base(message) { }
        public UnexpectedPackageException(string message, Exception inner) : base(message, inner) { }
        protected UnexpectedPackageException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}