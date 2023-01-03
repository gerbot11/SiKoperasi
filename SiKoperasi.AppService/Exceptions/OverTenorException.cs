namespace SiKoperasi.AppService.Exceptions
{
    public class OverTenorException : Exception
    {
        public OverTenorException()
        {
        }

        public OverTenorException(string? message) : base(string.Format("Jumlah angusran melebihi Skema Pinjaman : {0}", message))
        {
        }
    }
}
