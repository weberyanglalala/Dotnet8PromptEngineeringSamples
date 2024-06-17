# Prompt Engineering Notes

## References

- [Deep Learning AI: ChatGPT Prompt Engineering for Developers](https://www.deeplearning.ai/short-courses/chatgpt-prompt-engineering-for-developers/)
- [Open AI Guides: Prompt Engineering](https://platform.openai.com/docs/guides/prompt-engineering)
- [Latent Space: The rise of AI Engineer](https://www.latent.space/p/ai-engineer)
- [Learning Prompting: Prompt Engineering Guide](https://learnprompting.org/docs/intro)

## Introduction

- LLM is a developer tool that allows to use API calls to LLMs to quickly build applications.
- Best practices for writing prompts for common use cases:
    - Iterative
    - Summarization
    - Inferring
    - Transforming
    - Expanding
    - Chatbot
    - Conclusion

## Two Types of LLMs

### Base LLM

- Predicts next word, based on text training data.

### Instruction Tuned LLM

- Fine tune on instructions and good attempts at following particular instruction to generate content.
- With particular inputs and outputs that are instructions

#### Interact with Instruction Tuned LLMs

- When interacting with LLMs, think of giving instructions to a person that is smart but not knowing specific task that
  you are willing to do.

#### What is fine tune?

- [Microsoft Doc Fine-Tune](https://learn.microsoft.com/en-us/windows/ai/fine-tuning)
- [Microsoft Doc How to Fine-Tune](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/fine-tuning?tabs=turbo%2Cpython-new&pivots=programming-language-studio)

| 概念    | 檢索增強生成 (RAG)                                                                                                          | 微調大型語言模型 (LLM)                                                                                  |
|-------|-----------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
| 定義    | 將檢索機制與生成能力結合起來，通過將語言模型與外部知識庫或文件存儲集成來增強模型。                                                                             | 在特定數據集上調整預訓練語言模型，使其專門適應特定任務或領域。                                                                 |
| 機制    | **檢索**：當收到查詢時，系統首先從外部數據庫中檢索相關文檔或信息。<br>**生成**：檢索到的信息用作語言模型生成響應的上下文，確保響應基於準確和最新的信息。                                    | **預訓練**：模型首先在大型和多樣化的數據集上進行訓練，以學習一般語言模式。<br>**微調**：在較小的、針對特定任務的數據集上進一步訓練預訓練模型，使其適應該任務的特定要求或細微差別。 |
| 優點    | **準確性和相關性**：確保生成的內容基於外部知識庫中的最新信息。<br>**可擴展性**：可以應用於大型數據集而無需重新訓練模型，因為檢索系統可以獨立更新。<br>**適應性**：通過更新外部數據庫輕鬆整合新信息，無需重新訓練模型。 | **特定任務性能**：通過針對相關數據調整模型來提高模型在特定任務上的性能。<br>**定制化**：允許定制以滿足特定需求，提高模型在給定上下文中生成準確和相關響應的能力。          |
| 用例    | 需要最新信息的應用，如新聞生成、客戶支持或任何需要訪問大型和不斷變化的數據集的領域。                                                                            | 需要領域特定知識的情況，如醫療診斷、法律文件生成或任何需要專業知識的應用。                                                           |
| 數據依賴性 | 依賴外部數據源進行實時檢索                                                                                                         | 依賴於用於微調模型的特定數據集                                                                                 |
| 靈活性   | 由於檢索系統可以獨立更新，因此更靈活地適應新信息。                                                                                             | 由於需要重新訓練以整合更新，因此靈活性較差。                                                                          |
| 複雜性   | 涉及管理和維護額外的檢索系統                                                                                                        | 涉及管理訓練過程和數據集，但不需要單獨的檢索系統。                                                                       |

## Principles of Prompt Engineering

### Clear and specific instructions

#### Tactic1: Use delimiters

- quotes, backticks, brackets, dashes, xml tags, etc.
- LangGPT, Wonderful prompts

#### Tactic 2: ask for structured output
- json, markdown, csv, etc.

#### Tactic3: Check whether conditions are satisfied and check assumptions required to do the task

#### Tactic4: Few-shot prompting
- give successful examples of completing tasks then ask model to perform similar tasks
- e.g. what is a proper structure article for student to learn about a new topic?
- LAB: SQL(TODO) how to use few-shot prompting?
  - 問題本質
  - 解題的步驟
  - 輸出格式

### Give the model time to think
- prevent the model rushing to give out an incorrect answer
- try to rephrase the question, give more context, or give more examples

#### Tactic1: Specify the steps to complete the task
- Step1: ...
- Step2: ...
- Step3: ...
- StepN: ...
- Lab: SQL(TODO) how to use this tactic?
- Lab: Life number(TODO) how to use this tactic?

#### Tactic2: Instruct the model to work out its own solution before running to a conclusion

## Model Limitations
- Hallucination

## How to prevent hallucination
- Ask model to find relevant information from a given text, then answer the question based on the relevant information