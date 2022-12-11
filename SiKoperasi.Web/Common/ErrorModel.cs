namespace SiKoperasi.Web.Common
{
    public class ErrorModel
    {
        public string Title { get; } = "An Error Occurred While Proccessing Request";
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
