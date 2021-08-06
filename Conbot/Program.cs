using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Conbot
{
    class Program
    {
        private DiscordSocketClient _client;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;

            var TOKEN = "ODcyMzEyMDk0NzQwMDc0NTA3.YQoB8g.KMN_Yh8KZrxIQA6L5GcWr5GYKEE";

            await _client.LoginAsync(TokenType.Bot, TOKEN);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
