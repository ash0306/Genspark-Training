using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoEmployeesFoundException : Exception
    {
        string msg;
        public NoEmployeesFoundException()
        {
            msg = "No Employees Found";
        }
        public override string Message => msg;
        public NoEmployeesFoundException(string? message) : base(message)
        {
        }
    }
}