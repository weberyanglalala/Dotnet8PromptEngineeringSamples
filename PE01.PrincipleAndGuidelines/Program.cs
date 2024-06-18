using System.ClientModel;
using System.Text;
using OpenAI.Chat;

namespace PE01.PrincipleAndGuidelines;

class Program
{
    private static readonly string _openApiKey = "sk-????";

    static async Task Main(string[] args)
    {
        var result = await GetCompletion("what is the capital of Japan?");
        if (!string.IsNullOrEmpty(result))
        {
            await File.WriteAllTextAsync($"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-data.txt", result);
            Console.WriteLine(result);
        }
    }

    private static async Task<string> GetCompletion(string prompt, string model = "gpt-4o")
    {
        try
        {
            ChatClient client = new(model, _openApiKey);
            ChatCompletion chatCompletion = await client.CompleteChatAsync(prompt);
            return $"{chatCompletion}";
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return null;
        }
    }

    private static async Task<string> GetChatCompletionSteaming(string prompt)
    {
        try
        {
            var result = new StringBuilder();
            ChatClient client = new(model: "gpt-4o", _openApiKey);
            AsyncResultCollection<StreamingChatCompletionUpdate> updates
                = client.CompleteChatStreamingAsync(prompt);
            await foreach (StreamingChatCompletionUpdate update in updates)
            {
                foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
                {
                    Console.Write(updatePart.Text);
                    result.Append(updatePart.Text);
                }
            }

            return result.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return null;
        }
    }
}