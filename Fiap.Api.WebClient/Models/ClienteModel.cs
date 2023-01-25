namespace Fiap.Api.WebClient.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        public string? Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? Observacao { get; set; }

        public int RepresentanteId { get; set; }

        public RepresentanteModel? Representante { get; set; }

    }
}
