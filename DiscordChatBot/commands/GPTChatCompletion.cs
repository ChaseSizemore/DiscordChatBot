using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using DotNetEnv;
using OpenAI;
using OpenAI_API.Models;
using DSharpPlus.Interactivity.Extensions;


namespace DiscordChatBot.commands
{
    public class GPTChatCompletion : BaseCommandModule
    {
        [Command("gpt")]
        public async Task GPT(CommandContext ctx, [RemainingText] string message)
        {
            string ENV = Env.GetString("OPEN_AI_TOKEN");

            var api = new OpenAI_API.OpenAIAPI(ENV);
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("You are a discord chat bot tasked with helping users with their problems. Users will ask questions and you will answer them in a helpful and kind way");

            while (true)
            {
                chat.AppendUserInput(message);
                string response = await chat.GetResponseFromChatbotAsync();
                await ctx.Channel.SendMessageAsync(response.ToString()).ConfigureAwait(false);
                var nextMessage = await WaitForNextMessageAsync(ctx);
                if (nextMessage.Content.ToLower() == "end chat")
                {
                    await ctx.Channel.SendMessageAsync("Ending chat...");
                    break;
                }
                message = nextMessage.Content;
            }
        }

        private async Task<DiscordMessage> WaitForNextMessageAsync(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var result = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Author == ctx.User).ConfigureAwait(false);
            return result.Result;
        }
    }
}
