namespace IS.Api.Exceptions
{
    [Serializable]
    public class DepartmentException : Exception
    {
        public DepartmentException() { }
        public DepartmentException(string message) : base(message) { }
    }
}
