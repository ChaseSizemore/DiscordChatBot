using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

using DotNetEnv;
using OpenAI;
using OpenAI_API.Models;


namespace DiscordChatBot.commands
{
    public class GPTChatCompletion : BaseCommandModule
    {
        [Command("gpt")]
        public async Task GPT(CommandContext ctx, [RemainingText] string message)
        {

            string ENV = Env.GetString("OPEN_AI_TOKEN");

            OpenAIAPI api = new OpenAIAPI(ENV);
            // Console.WriteLine(message);
            // var result = await api.Completions.CreateCompletionAsync(message);
            // Console.WriteLine(result.ToString());
            // var chat = api.Completions
            // await ctx.Channel.SendMessageAsync(chat.ToString()).ConfigureAwait(false);



        }
    }
}
