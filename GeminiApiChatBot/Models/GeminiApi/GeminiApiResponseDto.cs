namespace GeminiApiChatBot.Models.GeminiApi
{
    public class GeminiApiResponseDto
    {
        public List<Candidate> candidates { get; set; }
        public UsageMetadata usageMetadata { get; set; }
    }
}
