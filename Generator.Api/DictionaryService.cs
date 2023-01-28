using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Generator.Api
{
    public class DictionaryService :IDictionaryService
    {
        private const string RequestUri = "all";
        private readonly HttpClient _client;

        public DictionaryService(HttpClient client)
        {
            var productValue = new ProductInfoHeaderValue("GravatarBot", "1.0");
            client.BaseAddress = new Uri("https://random-word-api.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.UserAgent.Add(productValue);


            _client = client;
        }

        public async Task<IEnumerable<string>> GetAllWords()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(RequestUri);
                if (!response.IsSuccessStatusCode) return new List<string>();
                
                var responseJson = await response.Content.ReadAsStringAsync();
                var wordsList = JsonConvert.DeserializeObject<IEnumerable<string>>(responseJson)!;
   
                return SqueezeList(wordsList);
            }
            catch (TaskCanceledException ex)
            {
                return new  List<string>();
            }
        }

        private List<string> SqueezeList(IEnumerable<string> wordsList)
        {
            var words = new List<string>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                words.AddRange(wordsList.Where(cw => cw.StartsWith(c)).Take(10));

            }
            return words;
        }
    }
}