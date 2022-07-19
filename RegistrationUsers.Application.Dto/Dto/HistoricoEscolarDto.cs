namespace RegistrationUsers.Application.Dto.Dto
{
    public record struct HistoricoEscolarDto
    {
        public int? Id { get; set; }
        public string Formato { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
    }
}
