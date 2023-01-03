namespace SiKoperasi.ExternalService.Contract
{
    public interface IWhatsUpService
    {
        Task SendInitialMessageAsync(string phonenumber);
    }
}
