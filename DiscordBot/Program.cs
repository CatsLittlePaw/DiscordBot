using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace DiscordBot
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            string token = ConfigurationManager.AppSettings["DiscordToken"].ToString();
            var discord = new DiscordClient(new DiscordConfiguration()
            {                
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            });
            discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "?" },
                EnableDms = false,
                EnableMentionPrefix = true
            });

            
            discord.MessageCreated += async (s, e) =>
            {                
                if (e.Message.Content.StartsWith("#"))
                {
                    switch (e.Message.Content.Substring(1))
                    {
                        case "湯俊章SB":
                            await e.Message.RespondAsync("湯俊章SB");
                            break;
                        case "湯SB":
                            await e.Message.RespondAsync("湯SB");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(e.Message.Content.Substring(1));
                }                    
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
