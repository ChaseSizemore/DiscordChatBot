using DotNetEnv;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DiscordChatBot.commands;


namespace DiscordChatBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Env.Load();
            string TOKEN = Env.GetString("TOKEN");

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All, //bot permissions
                Token = TOKEN,
                TokenType = TokenType.Bot,
                AutoReconnect = true, //bot will auto reconnect if it disconnects
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<GPTChatCompletion>();
            Commands.RegisterCommands<TestCommands>();

            await Client.ConnectAsync(); // Connects to the Discord API
            await Task.Delay(-1); // Prevents the program from closing
        }

        private static DiscordClient Client { get; set; } 
        private static CommandsNextExtension Commands { get; set; }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }





    }
}
