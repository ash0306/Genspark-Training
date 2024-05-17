using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class UnableToAddRequestException : Exception
    {
        public UnableToAddRequestException()
        {
        }

        public UnableToAddRequestException(string? message) : base(message)
        {
        }

        public UnableToAddRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToAddRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}