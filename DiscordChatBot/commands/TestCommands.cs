
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DotNetEnv;

namespace DiscordChatBot.commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("ping").ConfigureAwait(false);
        }

        [Command("echo")]
        public async Task Echo(CommandContext ctx, [RemainingText] string message)
        {
            await ctx.Channel.SendMessageAsync(message).ConfigureAwait(false);
        }

        [Command("add")]
        public async Task Add(CommandContext ctx, int numberOne, int numberTwo)
        {
            await ctx.Channel.SendMessageAsync((numberOne + numberTwo).ToString()).ConfigureAwait(false);
        }

    
    }
}