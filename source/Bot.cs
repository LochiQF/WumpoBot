using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WumpoBot
{
    public class Bot : IDisposable
    {
        private DiscordShardedClient Client { get; set; }

        public static Config Configuration { get; set; }

        private CancellationTokenSource CancellationToken { get; set; }

        public Bot()
        {
            Configuration = Config.LoadFromFile("config.json");

            Client = new DiscordShardedClient(new DiscordConfiguration()
            {
                AutoReconnect = true,
                EnableCompression = true,
                LogLevel = LogLevel.Debug,
                Token = Configuration.token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
            });

            Client.GuildAvailable += OnGuildAvailable;
            Client.Ready += OnClientReady;

            CancellationToken = new CancellationTokenSource();
        }

        private Task OnGuildAvailable(GuildCreateEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(
                LogLevel.Info,
                "WumpoBot", $"Guild '{e.Guild.Name}' available",
                DateTime.Now
            );

            return Task.CompletedTask;
        }

        private async Task OnClientReady(ReadyEventArgs e)
        {
            foreach (DiscordClient shardedClient in Client.ShardClients.Values)
            {
                shardedClient.UseCommandsNext(new CommandsNextConfiguration()
                {
                    CaseSensitive = false,
                    EnableDefaultHelp = true,
                    EnableDms = true,
                    EnableMentionPrefix = true,
                    StringPrefix = Configuration.prefix,
                    IgnoreExtraArguments = true,
                });

                shardedClient.GetCommandsNext().RegisterCommands<CommandSets.Image>();
                shardedClient.GetCommandsNext().RegisterCommands<CommandSets.Miscellaneous>();
                shardedClient.GetCommandsNext().CommandErrored += OnCommandError;
            }

            DiscordGame presence = new DiscordGame()
            {
                Name = "!wumpus | !getwumpobot",
            };

            await Client.UpdateStatusAsync(presence, UserStatus.Online, DateTime.Now);

            await Task.Yield();
        }

        private Task OnCommandError(CommandErrorEventArgs e)
        {
            string commandName = e.Command?.Name;

            e.Context.Client.DebugLogger.LogMessage(
                LogLevel.Error,
                "WumpoBot", $"'{e.Context.User.Username}' in guild '{e.Context.Guild.Name}' tried executing '{commandName ?? "<unknown command>"}' but it errored: {e.Exception.GetType()}: {e.Exception.Message ?? "<no message>"}",
                DateTime.Now
            );

            return Task.CompletedTask;
        }

        public async Task RunAsync()
        {
            await Client.StartAsync();
            await WaitForCancellationAsync();
        }

        private async Task WaitForCancellationAsync()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                await Task.Delay(500);
            }
        }

        public void Dispose()
        {
            foreach (DiscordClient shardedClient in Client.ShardClients.Values)
            {
                shardedClient.DisconnectAsync();
            }

            Configuration = null;
        }
    }
}
