namespace Fiap.Api.WebClient.Models
{

    public class RepresentanteModel
    {
        public int RepresentanteId { get; set; }

        public string? NomeRepresentante { get; set; }

        public string? Cpf { get; set; }

        public string? Token { get; set; }

        public RepresentanteModel()
        {

        }

        public RepresentanteModel(int representanteId, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }

        public RepresentanteModel(int representanteId, string cpf, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            Cpf = cpf;
            NomeRepresentante = nomeRepresentante;
        }
    }
}
