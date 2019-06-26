using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace WumpoBot.CommandSets
{
    internal class Miscellaneous
    {
        [Command("version")]
        public async Task Version(CommandContext context)
        {
            await context.RespondAsync("WumpoBot v0.0.3, created by AttixQF#9866. (https://github.com/LochiQF/WumpoBot)");
        }

        [Command("getwumpobot")]
        public async Task Invite(CommandContext context)
        {
            await context.RespondAsync($"Add me to your own discord! (https://discordapp.com/oauth2/authorize?client_id=593089411965517844&scope=bot&permissions=0)");
        }

        [Command("gone")]
        [Description("!gone <Mention>")]
        public async Task Gone(CommandContext context)
        {
            await context.RespondAsync($":crab: {context.Message.MentionedUsers[0].Mention} is gone :crab:");
        }
    }
}
