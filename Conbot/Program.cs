using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Conbot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private CommandHandler cmd;
       
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            //_client.Log += Log;

            
            var TOKEN = "";

            await _client.LoginAsync(TokenType.Bot, TOKEN);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

       /* private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            var msg = message as SocketUserMessage;
            var context = new SocketCommandContext(_client, msg);

            if (message.Author.IsBot) return;

            int argPos = 0;
            if (msg.HasStringPrefix("!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }
       */
    }
}
