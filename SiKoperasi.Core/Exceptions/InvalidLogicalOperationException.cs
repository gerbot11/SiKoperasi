namespace SiKoperasi.Core.Exceptions
{
    public class InvalidLogicalOperationException : Exception
    {
        private static readonly string msg = "Unable to process logical operator for filter!";

        public InvalidLogicalOperationException() : base(msg)
        {
        }
    }
}
