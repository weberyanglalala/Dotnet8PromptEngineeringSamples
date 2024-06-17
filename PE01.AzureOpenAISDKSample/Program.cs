using System.ClientModel;
using System.Text;
using OpenAI;
using OpenAI.Chat;

namespace PE01.AzureOpenAISDKSample;

class Program
{
    private static string _defaultModel = "gpt-4o";
    private static readonly string _openApiKey = "sk-??????";

    static void Main(string[] args)
    {
        ApiKeyCredential credential = new ApiKeyCredential(_openApiKey);
        OpenAIClient client = new OpenAIClient(credential);
        ChatClient chatClient = client.GetChatClient(_defaultModel);

        ChatCompletion completion = chatClient.CompleteChat(
        [
            // System messages represent instructions or other guidance about how the assistant should behave
            new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
            // User messages represent user input, whether historical or the most recen tinput
            new UserChatMessage("Hi, can you help me?"),
            // Assistant messages in a request represent conversation history for responses
            new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
            new UserChatMessage("What's the best way to train a parrot?"),
        ]);

        Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
    }
}