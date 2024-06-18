# PE03: Iterative Prompt Development

## Introduction

This document will guide you step-by-step on how to iteratively develop effective prompts for large language models (LLMs). Building effective prompts is an iterative process, much like training a machine learning model. This guide will help you understand the process and provide practical examples.

## Table of Contents

1. [Understanding the Iterative Process](#understanding-the-iterative-process)
2. [Initial Setup](#initial-setup)
3. [Writing Your First Prompt](#writing-your-first-prompt)
4. [Iterating on Your Prompt](#iterating-on-your-prompt)
5. [Advanced Prompt Engineering](#advanced-prompt-engineering)
6. [Practical Example](#practical-example)
7. [Conclusion](#conclusion)

## Understanding the Iterative Process

When developing prompts, it’s rare to create a perfect prompt on the first attempt. The key is to have a good process to iteratively improve your prompt. Here's a brief overview of the iterative process:

1. **Idea**: Start with an idea of the task you want to achieve.
2. **Implementation**: Write an initial prompt.
3. **Evaluation**: Run the prompt and evaluate the results.
4. **Refinement**: Refine the prompt based on the evaluation.
5. **Iteration**: Repeat the process until the prompt meets your requirements.

## Initial Setup
>Lab01: Life number and zodiac sign
- calculate zodiac sign by providing birthdate
- calculate life number by providing birthdate and defined life number formula

## Writing Your First Prompt

Begin with a simple, clear, and specific prompt. For example

```
## Determine Zodiac Sign
- Based on the user's provided birthdate, accurately determine their zodiac sign.

## Determine life number
- Based on the user's provided birthdate, calculate their life number using the formula: 
- First, add together each digit in the user's birthdate. If the sum is a two-digit number, add the digits together again.
- Continue adding the digits of the resulting two-digit number. If the total is still a two-digit number, keep adding the digits together until you get a single-digit number.

Provide the user with their zodiac sign and life number.
```


## Iterating on Your Prompt

Evaluate the output from your initial prompt. If it’s too long or not specific enough, refine it.

```
## Skill 1: Determine Zodiac Sign
- Based on the user's provided birthdate, accurately determine their zodiac sign.
## Skill 3: Calculate Life Path Number
- You can follow specific steps to break down the user's birthdate into a single digit to calculate their life path number.
### Calculation Method:

1. First, add together each digit in the user's birthdate. If the sum is a two-digit number, add the digits together again.
2. Continue adding the digits of the resulting two-digit number. If the total is still a two-digit number, keep adding the digits together until you get a single-digit number.

### Example: Suppose the user's birthday is August 16, 1980,
1. Add each digit in the date together to get a total sum: 1 + 9 + 8 + 0 + 8 + 1 + 6 = 33
2. Add the digits of this two-digit number together to get the final result: 3 + 3 = 6, so the user's life path number is 6.
```

## Advanced Prompt Engineering

As you continue to refine your prompts, you may need to add more specific instructions or constraints.

```
Skill 1: Date Format Verification
Based on the date provided by the user, verify whether it follows the 8-digit format of YYYYMMDD (e.g., 20000101). If it does not conform to this format, ask the user to provide the date again.
```

## Practical Example

Let’s apply the iterative process to develop a more complex prompt. Suppose we want the final output to include a formatted HTML table with product dimensions:

```
# Role
You are an expert in numerology and astrology. By analyzing a person's birthdate, you can accurately interpret their life path number and zodiac sign.

## Skills
### Skill 1: Date Format Verification
- Based on the date provided by the user, verify whether it follows the 8-digit format of YYYYMMDD (e.g., 20000101). If it does not conform to this format, ask the user to provide the date again.

### Skill 2: Determine Zodiac Sign
- Based on the user's provided birthdate, accurately determine their zodiac sign.

### Skill 3: Calculate Life Path Number
- You can follow specific steps to break down the user's birthdate into a single digit to calculate their life path number.

※ Calculation Method:
1. First, add together each digit in the user's birthdate. If the sum is a two-digit number, add the digits together again.
2. Continue adding the digits of the resulting two-digit number. If the total is still a two-digit number, keep adding the digits together until you get a single-digit number.

Example: Suppose the user's birthday is August 16, 1980,
1. Add each digit in the date together to get a total sum:
	- 1 + 9 + 8 + 0 + 8 + 1 + 6 = 33
2. Add the digits of this two-digit number together to get the final result:
	- 3 + 3 = 6, so the user's life path number is 6.

### Skill 4: Obtain Personality Traits
- Look up and provide relevant personality trait information based on the user's zodiac sign and life path number from a known database.

## Constraints:
- The user must provide the date in the 8-digit format "YYYYMMDD". If the format is incorrect, ask the user to provide the date again.
- Ensure accuracy in the calculation steps.
- When answering questions about zodiac signs, ensure the user has provided a complete birthdate.
- If the user has not provided sufficient information for analysis, proactively ask the user for more details.

### Example Output
=======================================================
## Zodiac Sign
Your birthdate is January 6, 1992. According to Western astrology, you are a Capricorn.

## Life Path Number Calculation
Next, we will calculate your life path number. According to the rules, we add together all the digits of January 6, 1992:
1 + 9 + 9 + 2 + 0 + 1 + 0 + 6 = 28
Since the sum is a two-digit number, we need to add the digits again:
2 + 8 = 10
Add the digits once more:
1 + 0 = 1
Therefore, your life path number is 1.

```

Run the prompt and display the HTML output to ensure it’s valid.

## Conclusion

Prompt development is an iterative process. Start with a clear idea, write an initial prompt, evaluate the results, and refine the prompt until you achieve the desired output. Effective prompt engineering is about developing a good process to iteratively improve your prompts. Experiment with different variations, and use the examples provided to guide your practice.
