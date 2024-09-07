# Gemini Api Chat Bot Project

This project includes a chatbot application developed using the Gemini API. The application provides a chatbot that can perform various tasks by interacting with users.

In this project, I developed a tool that corrects spelling errors and grammar mistakes in the given Turkish sentence. You can also use the Gemini API by giving prompts according to your own needs.

## What is Google Gemini ?
Google Gemini is a family of multimodal large language models (LLMs) announced by Google on December 6, 2023, the successor to LaMDA and PaLM 2. Positioned as a competitor to GPT-4, Gemini is a new generation artificial intelligence model that can understand and process content in different formats such as text, image, audio, video and coding.

Google Gemini, developed by Google, is an artificial intelligence-based platform. Its main purpose is to provide more accurate and faster answers to users' search queries. This platform aims to improve user experience and take personalization in digital advertising one step further by integrating with Google's existing search and advertising services.

Source : https://www.webtures.com/tr/blog/google-gemini-nedir-nasil-kullanilir/

## What is Google Gemini Api?
The Gemini API gives you access to Gemini models created by Google DeepMind. Gemini models are built from the ground up to be multimodal, so you can reason seamlessly across text, images, code, and audio. You can use these to develop a range of applications.

Source : https://github.com/google-gemini/cookbook
## Project Features

- Integrated with Gemini API
- Text-based interaction with users
- Ability to customize responses
- Simple and user-friendly interface

## Project Usage

In this project, I used both the REST API request that I created and the SDK developed by [Guilherme Martin](https://github.com/gsilvamartin). You can find detailed information about the Gemini .NET SDK [here](https://github.com/gsilvamartin/dotnet-gemini-sdk).

1. **Set API Keys :**
    `GeminiService.cs, program.cs` Add your Gemini API key in the file :
    ```c#
       ApiKey = "Google-Api-Key"
    ```
## License

This project is licensed under the [MIT License](LICENSE).


