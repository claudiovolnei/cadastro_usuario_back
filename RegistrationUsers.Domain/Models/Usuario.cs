namespace RegistrationUsers.Domain.Models
{
    public class Usuario : Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public int HistoricoEscolarId { get; set; }
        public virtual HistoricoEscolar HistoricoEscolar { get; set; }

    }
}
