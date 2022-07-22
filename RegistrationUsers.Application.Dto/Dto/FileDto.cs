namespace RegistrationUsers.Application.Dto.Dto
{
    public  class FileDto
    {
        public MemoryStream MemoryStream { get; set; }
        public string Path { get; set; }
        public Func<string, string> MimeType { get; set; }
    }
}
