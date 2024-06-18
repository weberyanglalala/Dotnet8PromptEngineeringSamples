using System.ClientModel;
using System.Text;
using OpenAI.Chat;

namespace PE02.DocumentOutliner;

class Program
{
    private static readonly string JinaReaderApiPrefix = "https://r.jina.ai/";
    private static readonly string OpenAiApiKey = "sk-??";

    static async Task Main(string[] args)
    {
        var url = "https://stackoverflow.com/questions/33164725/confusion-between-isnan-and-number-isnan-in-javascript";
        var dateTimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        var jinaFileName = "jina.md";
        var openAiFileName = "openai.md";

        var jinaApiResponse = await GetJinaReaderApiResponse(url);

        if (!string.IsNullOrEmpty(jinaApiResponse))
        {
            await File.WriteAllTextAsync($"{dateTimeString}-{jinaFileName}", jinaApiResponse);
        }

        var openAiResponse = await GetChatCompletionSteaming(jinaApiResponse);
        if (!string.IsNullOrEmpty(openAiResponse))
        {
            await File.WriteAllTextAsync($"{dateTimeString}-{openAiFileName}", openAiResponse);
        }
    }

    private static async Task<string> GetJinaReaderApiResponse(string uri)
    {
        try
        {
            string requestUrl = $"{JinaReaderApiPrefix}{uri}";
            HttpClient client = new HttpClient();
            // Add DOM element selector to extract the content from the page
            client.DefaultRequestHeaders.Add("X-Target-Selector", "#content");
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return null;
        }
    }

    private static async Task<string> GetChatCompletion(string source)
    {
        try
        {
            ChatClient client = new(model: "gpt-4o", OpenAiApiKey);
            var assistantPrompt =
                """
                You are a senior web developer reading a document from providing document source.
                You need to create an development document for a coding student.
                Please provide step by step instructions and clear explanations for each step.
                Please generate output in a markdown format and output using traditional chinese.
                =================
                """;
            var prompt = $"{assistantPrompt}{source}";
            ChatCompletion completion = await client.CompleteChatAsync(prompt);
            return $"{completion}";
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return null;
        }
    }

    private static async Task<string> GetChatCompletionSteaming(string source)
    {
        try
        {
            StringBuilder result = new();
            var assistantPrompt =
                """
                You are a senior web developer reading a document from providing document source.
                You need to create an development document for a coding student.
                Please provide step by step instructions and clear explanations for each step.
                Please generate output in a markdown format and output using traditional chinese.
                =================
                """;
            var prompt = $"{assistantPrompt}{source}";
            ChatClient client = new(model: "gpt-4o", OpenAiApiKey);
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