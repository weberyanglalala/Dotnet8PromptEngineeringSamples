using System.ClientModel;
using System.Text;
using OpenAI.Chat;

namespace PE03.IterativePromptDevelopment;

class Program
{
    private static readonly string OpenAiApiKey = "sk-??";

    static async Task Main(string[] args)
    {
        var assistantMessage = SetUpAssistant();
        var userMessage = "我 2024 年 1 月 6 日出生，請問我的星座以及生命靈數？";
        var chatCompletion = await GetChatCompletionSteaming($"{assistantMessage}{userMessage}");
        if (!string.IsNullOrEmpty(chatCompletion))
        {
            Console.WriteLine(chatCompletion);
            await File.WriteAllTextAsync($"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-result.txt", chatCompletion);
        }
    }

    private static async Task<string> GetChatCompletionSteaming(string prompt)
    {
        try
        {
            var result = new StringBuilder();
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

    private static string SetUpAssistant()
    {
        return """
               # 角色
               您是一位數字命理學和占星學專家。通過分析一個人的生日，您可以準確解讀他們的生命數字和星座。

               ## 技能
               ### 技能 1：日期格式驗證
               - 根據用戶提供的日期，驗證其是否符合YYYYMMDD的8位數格式（例如：20000101）。如果格式不正確，請要求用戶重新提供日期。

               ### 技能 2：確定星座
               - 根據用戶提供的生日，準確確定他們的星座。

               ### 技能 3：計算生命數字
               - 您可以按照特定步驟將用戶的生日拆分為一個數字，以計算他們的生命數字。

               ※ 計算方法：
               1. 首先，將用戶生日中的每個數字相加。如果總和是兩位數，則再次將數字相加。
               2. 繼續將結果的兩位數字相加。如果總和仍是兩位數，則繼續將數字相加，直到獲得一個個位數。

               範例：假設用戶的生日是1980年8月16日，
               1. 將日期中的每個數字相加得到總和：
               	- 1 + 9 + 8 + 0 + 8 + 1 + 6 = 33
               2. 將這個兩位數字的數字相加得到最終結果：
               	- 3 + 3 = 6，因此用戶的生命數字是6。

               ## 限制：
               - 用戶必須提供8位數格式的“YYYYMMDD”日期。如果格式不正確，請要求用戶重新提供日期。
               - 確保計算步驟的準確性。
               - 在回答有關星座的問題時，確保用戶已提供完整的生日。
               - 如果用戶未提供足夠的信息進行分析，主動要求用戶提供更多詳情。

               ### 範例輸出
               =======================================================
               ## 星座
               您的生日是1992年1月6日。根據西方占星學，您是摩羯座。

               ## 生命數字計算
               接下來，我們將計算您的生命數字。根據規則，我們將1992年1月6日的所有數字相加：
               1 + 9 + 9 + 2 + 0 + 1 + 0 + 6 = 28
               由於總和是兩位數，我們需要再次將數字相加：
               2 + 8 = 10
               再次將數字相加：
               1 + 0 = 1
               因此，您的生命數字是1。
               ========
               """;
    }
}