# Generative AI and Prompt Engineering Notes

## References

- [Open AI Prompt Engineering Guide](https://platform.openai.com/docs/guides/prompt-engineering)
- [Deep Learning AI: ChatGPT Prompt Engineering for Developers](https://www.deeplearning.ai/short-courses/chatgpt-prompt-engineering-for-developers/)
- [Latent Space: The rise of AI Engineer](https://www.latent.space/p/ai-engineer)
- [Learning Prompting: Prompt Engineering Guide](https://learnprompting.org/docs/intro)
- [Shift Left](https://github.com/billmalarky/shift-left)
- [Roadmap: Prompt Engineering](https://roadmap.sh/prompt-engineering)
- [Awesome Chatgpt Prompts](https://github.com/f/awesome-chatgpt-prompts)
- [Wonderful Prompts](https://github.com/langgptai/wonderful-prompts)
- [LangGPT](https://github.com/langgptai/LangGPT)

## 介紹

- 自從電腦發明以來，它們主要充當著高級計算器的角色，執行程式設計師給予的精確指令。
- 然而，最近的發展使電腦開始具備類似人類的學習、思考和交流能力。這種新能力被稱為「生成式 AI」，即能夠創造新的原創內容的人工智慧技術。

## 目錄

1. [什麼是生成式 AI？](#什麼是生成式-ai)
2. [生成式 AI 的運作原理](#生成式-ai的運作原理)
3. [生成式 AI 模型的類型](#生成式-ai模型的類型)
4. [提示工程](#提示工程)
5. [應用與影響](#應用與影響)

## 什麼是生成式 AI？

- 生成式 AI 是指能夠創造新內容的人工智慧技術，而不僅僅是分析或處理現有數據。
- 不同於傳統 AI 著重於分類和預測，生成式 AI 可以創造文本、圖像、音樂甚至視頻。
- 像 OpenAI 的 ChatGPT 就是生成式 AI 的例子，提供了類似擁有一個巨大知識庫助手的功能。

## 生成式 AI 的運作原理

- 生成式 AI 模型，尤其是像 GPT-4 這樣的大型語言模型（LLM），通過基於大量訓練數據來預測序列中的下一個單詞來運作。
- 這些模型是使用神經網路構建的，特別是使用了 Transformer 架構，使它們能夠處理並生成類人文本。

1. **訓練過程**：
    - **數據收集**：模型在包括互聯網和其他來源的龐大數據集上進行訓練。
    - **猜單詞遊戲**：模型通過「猜下一個單詞」遊戲，通過反向傳播過程調整其參數，直到其能夠熟練生成連貫的文本。
    - **人類反饋**：為了確保輸出有用且符合道德標準，模型進行了人類反饋的強化學習，人類評估並引導其回應。

2. **推理**：一旦訓練完成，模型可以通過接受輸入提示並基於其學習的模式生成文本。

3. 為什麼生成是AI的原理像文字接龍？
   - AI生成文字的原理確實類似文字接龍，因為它基於上下文來預測和生成下一個詞或句子
   - 資料集訓練：AI模型通過大量文本數據訓練，學習語言結構和詞語間的關聯。 
   - 語言模型：用像GPT這樣的語言模型，AI根據上下文預測下一個詞。例如，給定「天氣很好，我們可以去」，模型會預測「公園」、「海灘」等可能的詞。 
   - 機率預測：AI計算每個詞在當前上下文中的機率，選擇機率最高的詞來生成下一部分，類似於文字接龍中根據已知部分推測下一個詞。 
   - 上下文考量：AI 生成文字時考慮整個上下文，而不只是單獨的詞，這保證了內容的連貫性和合理性。 
   - 調整和優化：生成模型經過多次調整和優化，包括參數調整和更好的訓練數據，以提高生成文本的質量。

## 生成式 AI 模型的類型

生成式 AI 包括設計用於不同類型內容創作的各種模型：

1. **文本到文本模型**：從文本提示生成文本。
2. **文本到圖像模型**：根據文本描述創建圖像。
3. **圖像到圖像模型**：修改或組合現有圖像。
4. **圖像到文本模型**：描述圖像的內容。
5. **語音到文本模型**：將口語轉錄為文本。
6. **文本到音頻模型**：從文本提示生成聲音或音樂。
7. **文本到視頻模型**：根據文本描述生成視頻內容。

## 提示工程

- 提示工程或提示設計是設計有效輸入以引出 AI 模型有用回應的技巧。
- 這項技能對用戶和開發者都至關重要，因為它直接影響 AI 輸出的質量和相關性。

1. **提供背景**：明確說明提示中的背景和要求，以有效引導 AI。
2. **迭代改進**：根據 AI 的回應調整和改進提示，以獲得更好的結果。
3. **詢問問題**：使用後續問題來澄清和擴展初始輸出，確保全面和準確的答案。

## 應用與影響

生成式 AI 在各個領域有廣泛應用：

1. **內容創作**：自動化寫作、藝術、音樂和視頻製作。
2. **教育**：協助創建教育材料、評分和個性化輔導。
