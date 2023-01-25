
using System.Text;

namespace Fiap.Api.WebClient;
class Program
{

    private static readonly string urlEndPoint = "http://localhost:5179/api/cliente/";

    static void Main(string[] args)
    {
        post();
        Console.Read();
    }

    static void post()
    {
        // Criando um objeto Cliente para conectar com o recurso.
        HttpClient client = new HttpClient();

        // Conteúdo do tipo de produto em JSON.
        string json = "{ \"nome\": \"Cauani Sanches\" , \"dataNascimento\": \"1990-03-01T00:00:00\" , \"observacao\": \"Texto de Observação\" , \"representanteId\": 1}";

        // Convertendo texto para JSON StringContent. 
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

            // Imprime o conteúdo na janela Console.
            Console.Write(conteudo.ToString());
        }

    }
}