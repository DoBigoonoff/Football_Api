using System.Net.Http.Headers;
using Newtonsoft.Json;
using TranslatorModels;

namespace Clients;
public class TranslatorClient
{
	public async Task<Translator> TranslateAsync(string text, string source, string target)
	{
		string main = "{ \"text\": \"" + text + "\", \"source\": \"" + source + "\", \"target\": \"" + target + "\"}";

        var client = new HttpClient();
		var request = new HttpRequestMessage
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri("https://deepl-translator.p.rapidapi.com/translate"),
			Headers =
	{
		{ "X-RapidAPI-Key", "8955d23492msh82a78f9451adc20p1c7889jsn06e2be356e7b" },
		{ "X-RapidAPI-Host", "deepl-translator.p.rapidapi.com" },
	},
			Content = new StringContent(main)
			{
				Headers =
		{
			ContentType = new MediaTypeHeaderValue("application/json")
		}
			}
		};
		using (var response = await client.SendAsync(request))
		{
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Translator>(content);
			return result;
		}
	}
}
