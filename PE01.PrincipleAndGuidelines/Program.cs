using System.ClientModel;
using OpenAI.Chat;

namespace PE01.PrincipleAndGuidelines;

class Program
{
    private static readonly string _openApiKey = "sk-????";

    static async Task Main(string[] args)
    {
        var result = await GetCompletion("what is the capital of Japan?");
        Console.WriteLine(result);
    }

    static async Task<string> GetCompletion(string prompt, string model = "gpt-4o")
    {
        ChatClient client = new(model, _openApiKey);
        ChatCompletion chatCompletion = await client.CompleteChatAsync(prompt);
        return $"{chatCompletion}";
    }
    
    private static async Task GetChatCompletionSteaming(string source)
    {
        try
        {
            var prompt = $"{source}";
            ChatClient client = new(model: "gpt-4o", _openApiKey);
            AsyncResultCollection<StreamingChatCompletionUpdate> updates
                = client.CompleteChatStreamingAsync(prompt);
            await foreach (StreamingChatCompletionUpdate update in updates)
            {
                foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
                {
                    Console.Write(updatePart.Text);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}