using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace FreeAI
{
    public class FreeGPT
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> ASK(string userMessage)
        {
            var response = await GetResponseFromNewAPI(userMessage);
            return response;
        }

        private static async Task<string> GetResponseFromNewAPI(string userMessage)
        {
            var requestBody = new
            {
                question = userMessage
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Origin", "https://www.pizzagpt.it");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/616.0.6350.196 Safari/537.36");
            client.DefaultRequestHeaders.Add("X-Secret", "Marinara");

            var response = await client.PostAsync("https://www.pizzagpt.it/api/chatx-completion", content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var jsonResponse = JsonConvert.DeserializeObject<FreeGPTResponseFormat>(responseBody);
            return jsonResponse.Answer.Content;
        }

        private class FreeGPTResponseFormat
        {
            public string? Description { get; set; }
            public FreeGPTAnswerFormat? Answer { get; set; }
        }

        private class FreeGPTAnswerFormat
        {
            public string? Role { get; set; }
            public string? Content { get; set; }
            public object? Refusal { get; set; }
        }
    }

    public class Pollinations
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> Generate(string userMessage, string model = "turbo", int? seed = null, int width = 1024, int height = 1024, bool nologo = false, bool nofeed = false, bool enhance = false, string folder="img")
        {
            var imageBytes = await GetResponseFromAPI(userMessage, model, seed, width, height, nologo, nofeed, enhance);
            string filePath = Path.Combine(folder, $"{Guid.NewGuid()}.png"); 
            await SaveImageToFile(imageBytes, filePath);
            return filePath;
        }

        private static async Task<byte[]> GetResponseFromAPI(string userMessage, string model, int? seed, int width, int height, bool nologo, bool nofeed, bool enhance)
        {
            var encodedMessage = Uri.EscapeDataString(userMessage);
            var requestUrl = $"https://image.pollinations.ai/prompt/{encodedMessage}?model={model}&width={width}&height={height}";
            if (seed.HasValue)
            {
                requestUrl += $"&seed={seed.Value}";
            }
            if (nologo)
            {
                requestUrl += "&nologo=true";
            }
            if (nofeed)
            {
                requestUrl += "&nofeed=true";
            }
            if (enhance)
            {
                requestUrl += "&enhance=true";
            }

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Origin", "https://image.pollinations.ai");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/616.0.6350.196 Safari/537.36");

            var response = await client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            // Читаем содержимое ответа как байтовый массив
            return await response.Content.ReadAsByteArrayAsync();
        }

        private static async Task SaveImageToFile(byte[] imageBytes, string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            await File.WriteAllBytesAsync(filePath, imageBytes);
        }
    }
}
