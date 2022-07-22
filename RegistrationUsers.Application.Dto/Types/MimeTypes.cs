namespace RegistrationUsers.Application.Dto.Types
{
    public static class MimeTypes
    {
        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".doc", "application/msword"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".pdf", "application/pdf"}
            };
        }
    }
}
