using DSharpPlus.Entities;
using Newtonsoft.Json;
using System.IO;

namespace WumpoBot
{
    public class Config
    {
        [JsonProperty("token")]
        internal string token;

        [JsonProperty("prefix")]
        internal string prefix;

        [JsonProperty("color")]
        internal string color;

        internal DiscordColor Color => new DiscordColor(color);

        public static Config LoadFromFile(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
            }
        }

        public void SaveToFile(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.Write(JsonConvert.SerializeObject(this));
            }
        }
    }
}