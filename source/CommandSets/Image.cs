using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WumpoBot.CommandSets
{
    internal class Image
    {
        internal class Source
        {
            public string Artist;
            public string Origin;
            public string Title;
        }

        internal Dictionary<Source, string> wumpuses = new Dictionary<Source, string>()
        {
            {
                new Source { Artist = "Matthias Halfmann", Origin = "https://www.dribbble.com/", Title = "Headbob Wumpus" },
                "https://cdn.dribbble.com/users/2049851/screenshots/5343272/animation_design_wumpusfanart_43.gif"
            },
            {
                new Source { Artist = "SpecularDesign", Origin = "http://www.reddit.com/", Title = "Twisted Wumpus" },
                "https://i.redd.it/onpl08xomix01.png"
            },
            {
                new Source { Artist = "Psychpsyo", Origin = "https://www.twitter.com/", Title = "Wumpi? Wumpuses?" },
                "https://pbs.twimg.com/media/DZxiPaYX0AAHwbk.jpg"
            },
            {
                new Source { Artist = "Wumpus Universe", Origin = "https://www.twitter.com/", Title = "Mixed Family" },
                "https://pbs.twimg.com/media/D7Mzvu0W4AA07aS.jpg"
            },
            {
                new Source { Artist = "feve", Origin = "https://www.furaffinity.net", Title = "Shy Wumpus" },
                "https://d.facdn.net/art/feve/1533617764/1533617764.feve_wumpus.png"
            },
            {
                new Source { Artist = "Grim-Autumn", Origin = "https://www.deviantart.com/", Title = "Sleepy Wumpus" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593112223337938944/wumpus_is_three__by_grim_autumn_dcbh8s5-pre.png"
            },
            {
                new Source { Artist = "inklessrambles", Origin = "https://www.deviantart.com/", Title = "Anniversary Wumpus" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593112400207806465/wumpus_by_inklessrambles_dd6kejv-fullview.png"
            },
            {
                new Source { Artist = "cylcca", Origin = "https://www.deviantart.com/", Title = "Just Chatting Wumpus" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593112519430635550/dbd59dt-06fd5da9-1128-4748-9933-150b315046eb.png"
            },
            {
                new Source { Artist = "Jukka Seppänen", Origin = "https://www.myminifactory.com", Title = "Asleep Wumpus" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593112639987515392/720X720-img-20170915-151330.png"
            },
            {
                new Source { Artist = "Unknown", Origin = "https://www.pngkey.com/", Title = "Waving Wumpus" },
                "https://www.pngkey.com/png/full/357-3577863_crear-bot-de-discord-wumpus-discord-png.png"
            },
            {
                new Source { Artist = "PolygoniCal", Origin = "https://www.deviantart.com/", Title = "Wumpus X DeviantArt" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593112766664146954/deviantart_wumpus___grateful_april_by_polygonical_db62bfq-pre.png"
            },
            {
                new Source { Artist = "Alaraxia", Origin = "https://alaraxia.tumblr.com/", Title = "Sir Wumpus" },
                "https://66.media.tumblr.com/e41c4147607873aad1204c6b377774ff/tumblr_pkuc8xU6Vc1tqxdnpo1_1280.png"
            },
            {
                new Source { Artist = "Moatdd", Origin = "https://moatdd.tumblr.com/", Title = "Gaming Wumpus" },
                "https://66.media.tumblr.com/d2fbb6dceab3af92dd6df48593275315/tumblr_p2ma6anKVk1rnv6lfo1_400.gif"
            },
            {
                new Source { Artist = "voltis", Origin = "https://discordemoji.com/", Title = "WumpusPls" },
                "https://discordemoji.com/assets/emoji/2184_wumpus_color_gif.gif"
            },
            {
                new Source { Artist = "Karen Dessire", Origin = "https://www.dribbble.com/", Title = "Donut Wumpus" },
                "https://cdn.dribbble.com/users/19216/screenshots/3540556/donutsdribbble.gif"
            },
            {
                new Source { Artist = "PAMVllo", Origin = "https://www.deviantart.com/", Title = "King Wumpus" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593112892967223308/dcbgidn-3192184a-0240-46af-b8d4-ea60efcf0586.png"
            },
            {
                new Source { Artist = "riddasarus", Origin = "https://www.instagram.com/", Title = "Vacation Wumpus" },
                "https://cdn.discordapp.com/attachments/356478690961522688/593113050425458754/56363705_574997069672314_169499349996331110_n.png"
            },
        };

        [Command("wumpus")]
        public async Task GetRandomWumpus(CommandContext context)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, wumpuses.Count);

            Source selected = wumpuses.Keys.ElementAt(r);

            DiscordEmbed embed = new DiscordEmbedBuilder
            {
                Title = $":frame_photo: {selected.Title} :file_folder:",
                Description = $":mag_right: on {selected.Origin} \n :writing_hand: by **{selected.Artist}**",
                ImageUrl = wumpuses.Values.ElementAt(r),
                Color = Bot.Configuration.Color
            };

            await context.RespondAsync(embed: embed);
        }
    }
}
