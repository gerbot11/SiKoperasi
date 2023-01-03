namespace SiKoperasi.Core.Exceptions
{
    public class InvalidFilterFieldException : Exception
    {
        public InvalidFilterFieldException(string? message) : base($"Invalid Filter Field: {message}")
        {
        }
    }
}
