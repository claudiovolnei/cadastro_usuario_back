namespace RegistrationUsers.Application.Dto.Dto
{
    public record struct SchoolRecordsDto
    {
        public int? Id { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
