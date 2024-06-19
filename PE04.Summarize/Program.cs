using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Channels;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;

namespace PE04.Summarize
{
    class Program
    {
        private static readonly string OpenApiKey = "sk-??";
        private static readonly string DefaultModel = "gpt-4o";

        [Experimental("SKEXP0050")]
        static async Task Main(string[] args)
        {
            var builder = Kernel.CreateBuilder();
            builder.AddOpenAIChatCompletion(DefaultModel, OpenApiKey);
            builder.Plugins.AddFromType<ConversationSummaryPlugin>();
            var kernel = builder.Build();

            // Create a Semantic Kernel template for chat
            var chat = kernel.CreateFunctionFromPrompt(
                @"{{$history}}
                            User: {{$request}}
                            Assistant: ");
            // Create choices
            List<string> choices = ["Continue", "End", "Summarize"];

            // Create a chat history
            ChatHistory history = [];

            // Create handlebars template for intent
            var functionFromPrompt = kernel.CreateFunctionFromPrompt(
                new()
                {
                    Template = """
                               <message role="system">
                               You are a experienced web developer.
                               You are willing to answer questions about web development.
                               if user intend to summarize the conversation, please summarize the all the chat histories in markdown with
                               clear headings and bullet points and ask for end conversation.
                               if user intend to end the conversation, reply with {{choices.[1]}}.
                               If you are unsure, reply with {{choices.[0]}}.
                               Choices: {{choices}}.</message>
                               {{#each chatHistory}}
                                   <message role="{{role}}">{{content}}</message>
                               {{/each}}

                               <message role="user">{{request}}</message>
                               <message role="system">Intent:</message>
                               """,
                    TemplateFormat = "handlebars"
                },
                new HandlebarsPromptTemplateFactory()
            );

            // Start the chat loop
            while (true)
            {
                // Get user input
                Console.Write("User > ");
                var request = Console.ReadLine();

                // Invoke prompt
                var intent = await kernel.InvokeAsync(
                    functionFromPrompt,
                    new()
                    {
                        { "request", request },
                        { "choices", choices },
                        { "history", history }
                    }
                );

                // End the chat if the intent is "Stop"
                if (intent.ToString().ToUpper() == "END")
                {
                    WriteHistoryToFile(history);
                    break;
                }

                // Get chat response
                var chatResult = kernel.InvokeStreamingAsync<StreamingChatMessageContent>(
                    chat,
                    new()
                    {
                        { "request", request },
                        { "history", string.Join("\n", history.Select(x => x.Role + ": " + x.Content)) }
                    }
                );

                // Stream the response
                var message = new StringBuilder();
                await foreach (var chunk in chatResult)
                {
                    if (chunk.Role.HasValue)
                    {
                        Console.Write(chunk.Role + " > ");
                    }

                    message.Append(chunk.Content);
                    Console.Write(chunk);
                }
                Console.WriteLine();

                // Append to history
                history.AddUserMessage(request!);
                history.AddAssistantMessage(message.ToString());
            }
        }

        private static void WriteHistoryToFile(ChatHistory history)
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-result.txt";
            File.WriteAllText(fileName, string.Join("\n", history.Select(x => x.Role + ": " + x.Content)));
        }

        private static async Task SaveResponseToFileAsync(string response)
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-result.txt";
            await File.WriteAllTextAsync(fileName, response);
        }
    }
}