using DotnetGeminiSDK.Client;
using DotnetGeminiSDK.Config;
using GeminiApiChatBot.Models.GeminiApi;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GeminiApiChatBot.Service
{
    public class GeminiService : IGeminiService
    {
        private readonly GeminiClient _geminiClient;
        private readonly HttpClient _httpClient;
        public GeminiService(HttpClient httpClient)
        {
            _geminiClient = new GeminiClient(new GoogleGeminiConfig()
            {
                ApiKey = "Google-Api-Key"
            });
            _httpClient = httpClient;
        }

        public async Task<string> GeminiSdk(string text)
        {
            var response = await _geminiClient.TextPrompt(text);
            if (response != null)
            {
                return response.Candidates[0].Content.Parts[0].Text.ToString();
            }
            else
            {
                return $"Error: Gemini api is not responding.";
            }

        }

        public async Task<string> GeminiApi(string question)
        {

            string apiKey = "Google-Api-Key";
            string url = $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={apiKey}";
            var requestData = new RequestData
            {
                contents = new List<Content>
                {
                     new Content
                     {
                         role = "user",
                         parts = new List<Part>
                         {
                             new Part()
                             {
                                 text = question
                             }
                         }
                     }
                }

            };

            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, jsonContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<GeminiApiResponseDto>(responseContent);

            if (response.IsSuccessStatusCode)
            {
                if (responseObject != null && responseObject.candidates[0].content != null )
                {
                    return responseObject.candidates[0].content.parts[0].text;
                }
                else
                {
                    if (responseObject != null && responseObject.candidates[0].finishReason == "SAFETY")
                    {
                        return "Do not use sentences that may contain sex, hate or harassment.";
                    }
                    return "Error: Response object is null or missing expected data.";
                }
            }
            else
            {
                return $"Error: {response.StatusCode} - {responseContent}";
            }
        }
    }
}
