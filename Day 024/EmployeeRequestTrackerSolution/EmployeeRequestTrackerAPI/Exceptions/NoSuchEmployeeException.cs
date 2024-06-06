using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoSuchEmployeeException : Exception
    {
        string msg;
        public NoSuchEmployeeException()
        {
            msg = "No such employee";
        }
        public override string Message => msg;
        public NoSuchEmployeeException(string? message) : base(message)
        {
        }
    }
}