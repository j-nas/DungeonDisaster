using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var openAiService = new OpenAIService(
    new OpenAiOptions() { ApiKey = config["OpenAIServiceOptions:ApiKey"] }
);

var completionResult = await openAiService.ChatCompletion.CreateCompletion(
    new ChatCompletionCreateRequest
    {
        Messages = new List<ChatMessage>
        {
            ChatMessage.FromSystem("You are a dungeons and dragons dungeon master"),
            ChatMessage.FromUser("Start a new campaign"),
        },
        Model = Models.Gpt_4,
    }
);
if (completionResult.Successful)
{
    Console.WriteLine(completionResult.Choices.First().Message.Content);
}
