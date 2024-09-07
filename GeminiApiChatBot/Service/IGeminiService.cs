namespace GeminiApiChatBot.Service
{
    public interface IGeminiService
    {
        Task<string> GeminiSdk(string text);
        Task<string> GeminiApi(string question);
    }
}