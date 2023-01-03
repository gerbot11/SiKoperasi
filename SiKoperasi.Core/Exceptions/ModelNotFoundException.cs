namespace SiKoperasi.Core.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException()
        {
        }

        public ModelNotFoundException(string? message) : base($"{message} Data Not Exist!")
        {
        }
    }
}
