namespace SiKoperasi.Core.Exceptions
{
    public class InvalidExpressionOprException : Exception
    {
        public InvalidExpressionOprException(string? message) : base($"Invalid Logical Expression Operator: {message}")
        {
        }
    }
}
