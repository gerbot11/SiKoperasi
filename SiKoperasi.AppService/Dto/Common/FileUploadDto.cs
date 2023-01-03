namespace SiKoperasi.AppService.Dto.Common
{
    public record FileUploadDto
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Status { get; set; }
    }
}
