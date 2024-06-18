# Summarizing Text with Large Language Models

## References

- https://learn.microsoft.com/en-us/training/modules/build-your-kernel/1-introduction
- https://learn.microsoft.com/en-us/training/modules/create-plugins-semantic-kernel/?source=recommendations

## Introduction

In today's fast-paced world, the ability to quickly consume large amounts of text is invaluable. One exciting
application of large language models is text summarization, allowing us to read more content efficiently. This guide
will walk you through the process of summarizing text using code, making it possible to integrate this functionality
into various software applications.

## Table of Contents

1. [Semantic Kernel Basics](#Semantic-Kernel-Basics)
2. [Summarization using semantic kernel](#Summarization-using semantic-kernel)

## Semantic Kernel Basics

### Install Semantic Kernel SDK

```bash
dotnet add package Microsoft.SemanticKernel
```

### Semantic Kernel Chat Completion Sample Code

```csharp
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

namespace PE04.Summarize
{
    class Program
    {
        private static readonly string OpenApiKey = "sk-??";
        private static readonly string DefaultModel = "gpt-4o";

        static async Task Main(string[] args)
        {
            try
            {
                string response = await GetChatbotResponseAsync("how to implement a chatbot using OpenAI API in C#?");
                await SaveResponseToFileAsync(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static async Task<string> GetChatbotResponseAsync(string prompt)
        {
            var builder = Kernel.CreateBuilder();
            builder.AddOpenAIChatCompletion(DefaultModel, OpenApiKey);
            var kernel = builder.Build();
            var response = kernel.InvokePromptStreamingAsync(prompt);
            var result = new StringBuilder();

            await foreach (var update in response)
            {
                Console.Write(update.ToString());
                result.Append(update.ToString());
            }

            return result.ToString();
        }

        private static async Task SaveResponseToFileAsync(string response)
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-result.txt";
            await File.WriteAllTextAsync(fileName, response);
        }
    }
}
```

## Summarization using semantic kernel

### Install Semantic Kernel Plugins Core SDK

```bash
dotnet add package Microsoft.SemanticKernel.Plugins.Core
```


