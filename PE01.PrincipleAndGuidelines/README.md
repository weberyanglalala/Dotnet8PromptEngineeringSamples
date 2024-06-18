# PE01: Prompt Engineering Principles and Guidelines

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