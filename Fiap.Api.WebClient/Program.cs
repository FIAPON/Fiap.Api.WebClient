using System.Text;
using Fiap.Api.WebClient.Models;
using Newtonsoft.Json;

namespace Fiap.Api.WebClient;
class Program
{

    private static readonly string urlEndPoint = "http://localhost:5179/api/cliente/";

    static void Main(string[] args)
    {
        post();
        Console.Read();
    }

    static void get()
    {
        // Criando um objeto Cliente para conectar com o recurso.
        HttpClient client = new HttpClient();

        // Execute o método Get passando a url da API e salvando o resultado.
        // em um objeto do tipo HttpResponseMessage
        HttpResponseMessage resposta = client.GetAsync(urlEndPoint).Result;

        // Verifica se o Status Code é 200.
        if (resposta.IsSuccessStatusCode)
        {
            // Recupera o conteúdo JSON retornado pela API
            string conteudo = resposta.Content.ReadAsStringAsync().Result;

            // Convertendo o conteúdo em uma lista de Cliente
            List<ClienteModel> lista =
                JsonConvert.DeserializeObject<List<ClienteModel>>(conteudo);

            // Imprime o conteúdo na janela Console
            foreach (var item in lista)
            {
                Console.WriteLine("Nome:" + item.Nome);
                Console.WriteLine("Nascimento:" + item.DataNascimento);
                Console.WriteLine(" ========== ");
                Console.WriteLine("");
            }

        }
        else
        {
            Console.WriteLine("Erro:" + resposta.StatusCode + " - " + resposta.Content);
        }

    }

    static void post()
    {
        // Criando um objeto Cliente para conectar com o recurso.
        HttpClient client = new HttpClient();

        ClienteModel clienteModel = new ClienteModel();
        clienteModel.Nome = "Fátima Silva";
        clienteModel.RepresentanteId = 2;
        clienteModel.DataNascimento = new DateTime();
        clienteModel.Observacao = "Obs Obs";

        // Conteudo do Cliente em JSON
        var json = JsonConvert.SerializeObject(clienteModel);

        // Convertendo texto para JSON StringContent 
        StringContent conteudo = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

        // Execute o método POST passando a url da API 
        // e envia o conteúdo do tipo StringContent.
        HttpResponseMessage resposta = client.PostAsync(urlEndPoint, conteudo).Result;

        // Verifica que o POST foi executado com sucesso
        if (resposta.IsSuccessStatusCode)
        {
            Console.WriteLine("Cliente criado com sucesso");
            Console.Write("Link para consulta: " + resposta.Headers.Location);
        } else
        {
            Console.WriteLine("Erro:" + resposta.StatusCode + " - " + resposta.Content);
        }
    }


    
}