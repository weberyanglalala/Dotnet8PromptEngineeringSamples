using System.ClientModel;
using System.Text;
using OpenAI.Chat;

namespace PE02.DocumentOutliner;

class Program
{
    private const string JinaReaderApiPrefix = "https://r.jina.ai/";
    private const string OpenAiApiKey = "sk-??";
    private const string SystemPrompt = """
                                        You are a senior web developer reading a document from providing document source.
                                        You need to create an development document for a coding student.
                                        Please provide step by step instructions and clear explanations for each step.
                                        Please generate output in a markdown format and output using traditional chinese.
                                        =================
                                        """;
    private const string Uri = "https://jina.ai/reader";
    private const string JinaFileName = "jina.md";
    private const string OpenAiFileName = "openai.md";

    static async Task Main(string[] args)
    {
        var dateTimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        var jinaApiResponse = await GetJinaReaderApiResponse(Uri);

        if (!string.IsNullOrEmpty(jinaApiResponse))
        {
            await File.WriteAllTextAsync($"{dateTimeString}-{JinaFileName}", jinaApiResponse);
        }

        var prompt = $"{SystemPrompt}{jinaApiResponse}";
        var openAiResponse = await GetChatCompletionStreaming(prompt);
        if (!string.IsNullOrEmpty(openAiResponse))
        {
            await File.WriteAllTextAsync($"{dateTimeString}-{OpenAiFileName}", openAiResponse);
        }
    }

    /// <summary>
    /// Get Jina Reader API response by URI
    /// </summary>
    /// <param name="uri">uri</param>
    /// <returns>Get a well-structured and LLM friendly content from Jina Reader API.</returns>
    private static async Task<string> GetJinaReaderApiResponse(string uri)
    {
        try
        {
            string requestUrl = $"{JinaReaderApiPrefix}{uri}";
            using HttpClient client = new HttpClient();
            // Add DOM element selector to extract the content from the page
            // client.DefaultRequestHeaders.Add("X-Target-Selector", "#content");
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

    /// <summary>
    /// Get Chat Completion from OpenAI API Using OpenAI .NET SDK.
    /// </summary>
    /// <param name="prompt">user prompt</param>
    /// <param name="model">model id</param>
    /// <returns>OpenAI chat completion api response message.</returns>
    private static async Task<string> GetChatCompletion(string prompt, string model = "gpt-4o")
    {
        try
        {
            ChatClient client = new(model, OpenAiApiKey);
            ChatCompletion completion = await client.CompleteChatAsync(prompt);
            return $"{completion}";
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return null;
        }
    }

    /// <summary>
    /// Get chat completion streaming result from OpenAI API using OpenAI .NET SDK.
    /// </summary>
    /// <param name="prompt">user prompt</param>
    /// <param name="model">model id</param>
    /// <returns>OpenAI chat completion api streaming response.</returns>
    private static async Task<string> GetChatCompletionStreaming(string prompt, string model = "gpt-4o")
    {
        try
        {
            StringBuilder result = new();
            ChatClient client = new(model, OpenAiApiKey);
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