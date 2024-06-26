# PE01: 提示工程原則和指南

## 引言
- LLM 允許使用 API 調用 LLM 來快速構建應用程式。
- 常見用例：
  1. 迭代
  2. 摘要
  3. 推論
  4. 轉換
  5. 擴展
  6. 聊天機器人
  7. 結論
  8. ...

## 兩種類型的 LLM
### 基礎 LLM
- 根據文本訓練數據預測下一個單詞。
### 指令微調型的 LLM
- 根據指令進行微調，並嘗試遵循特定指令來生成內容。
- 具有特定輸入和輸出的指令。

### 什麼是 Fine-Tune？

- [Microsoft Doc Fine-Tune](https://learn.microsoft.com/en-us/windows/ai/fine-tuning)
- [Microsoft Doc How to Fine-Tune](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/fine-tuning?tabs=turbo%2Cpython-new&pivots=programming-language-studio)

| 概念    | 檢索增強生成 (RAG)                                                                                                          | 微調大型語言模型 (Fine-Tuning)                                                                          |
|-------|-----------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
| 定義    | 將檢索機制與生成能力結合起來，通過將語言模型與外部知識庫或文件存儲集成來增強模型。                                                                             | 在特定數據集上調整預訓練語言模型，使其專門適應特定任務或領域。                                                                 |
| 機制    | **檢索**：當收到查詢時，系統首先從外部數據庫中檢索相關文檔或信息。<br>**生成**：檢索到的信息用作語言模型生成響應的上下文，確保響應基於準確和最新的信息。                                    | **預訓練**：模型首先在大型和多樣化的數據集上進行訓練，以學習一般語言模式。<br>**微調**：在較小的、針對特定任務的數據集上進一步訓練預訓練模型，使其適應該任務的特定要求或細微差別。 |
| 優點    | **準確性和相關性**：確保生成的內容基於外部知識庫中的最新信息。<br>**可擴展性**：可以應用於大型數據集而無需重新訓練模型，因為檢索系統可以獨立更新。<br>**適應性**：通過更新外部數據庫輕鬆整合新信息，無需重新訓練模型。 | **特定任務性能**：通過針對相關數據調整模型來提高模型在特定任務上的性能。<br>**定制化**：允許定制以滿足特定需求，提高模型在給定上下文中生成準確和相關響應的能力。          |
| 用例    | 需要最新信息的應用，如新聞生成、客戶支持或任何需要訪問大型和不斷變化的數據集的領域。                                                                            | 需要領域特定知識的情況，如醫療診斷、法律文件生成或任何需要專業知識的應用。                                                           |
| 數據依賴性 | 依賴外部數據源進行實時檢索                                                                                                         | 依賴於用於微調模型的特定數據集                                                                                 |
| 靈活性   | 由於檢索系統可以獨立更新，因此更靈活地適應新信息。                                                                                             | 由於需要重新訓練以整合更新，因此靈活性較差。                                                                          |
| 複雜性   | 涉及管理和維護額外的檢索系統                                                                                                        | 涉及管理訓練過程和數據集，但不需要單獨的檢索系統。                                                                       |


## 提示工程的關鍵原則

### 原則1：編寫清晰和具體的指示
- **表達清晰的指示**：提供盡可能多的細節來引導模型產生所需的輸出。
- **清晰優於簡短**：更長的提示可以提供更多的上下文，從而導致更相關的輸出。

#### 策略1：使用分隔符
- **目的**：明確指出輸入的不同部分。

#### 策略2：要求結構化的輸出
- **目的**：使解析模型的輸出更容易。

#### 策略3：檢查假設條件
- **目的**：確保完成任務前滿足所有假設條件。

#### 策略4：提供標準答案範本
- **目的**：在讓模型執行實際任務之前提供成功任務執行的範例。

### 原則2：給模型思考的時間
- **目的**：幫助模型在提供答案之前先推理問題。

#### 策略1：指定完成任務的步驟
- **目的**：將複雜任務分解為明確、有序的步驟。

#### 策略2：指示模型在得出結論之前自行解決問題
- **目的**：確保模型在評估給定解決方案之前自行解決問題。

## 處理模型的限制
- **知識邊界**：模型可能無法完美地記住所有信息，並可能產生聽起來合理但實際上不正確的回答，我們稱這些為幻想。

### 減少幻想
- **策略**：要求模型先找到相關引用，然後再生成答案，確保可追溯性和準確性。

## Prompt Guide
- Prompt Engineering Guide By ChatGPT
  - https://platform.openai.com/docs/guides/prompt-engineering
  - https://cookbook.openai.com/articles/related_resources
- Prompt Engineering Guide
  - https://www.coze.com/store/bot/7330103362614099986?bot_id=true
  - https://promptingguide.azurewebsites.net/introduction/tips

1. Write clear instructions
   - includes more details to your query: 提供更明確的上下文
   - adopt persona: 角色扮演
   - use delimiters to indicate distinct part: 利用 xml, markdown 語法、文字刪節號、文字分隔符、<tag>
   - Specify the steps required to complete a task: 告訴模型解題步驟
   - provide examples: 提供解題範例(few-shot prompting)
   - specify output result length or format: 定義模型輸出格式以及文字長度
2. Provide reference text
   - Instruct the model to answer using a reference text 要模型參考既有文件或知識庫
3. Split complex tasks into simpler subtasks 將複雜任務拆解成更細微的子任務
   - Give the model time to "think": Instruct the model to work out its own solution before rushing to a conclusion
4. Use external tools
   - RAG
   - 呼叫外部 API
5. Test changes systematically

## 好的提問
  - 指示：明確指示目的
  - 背景：完整的上下文說明
  - 輸出：定義輸出格式範例 
  - 範例：提供格式化的問答範例
   
## 技巧
  - 角色扮演
  - 要求 ChatGPT 擔任某領域的專家
  - 提問明確的主題
  - 限定輸出格式以及範圍

