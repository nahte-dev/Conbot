using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Reflection;

namespace Conbot
{
    class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        // Retrieve client and CommandService instance
        public CommandHandler(DiscordSocketClient client, CommandService commands)
        {
            _commands = commands;
            _client = client;
        }

        public async Task InstallCommandAsync()
        {
            // Hook MessageReceived event into command handler
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Skip if command was system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create number to identify prefix and command index
            int argPos = 0;

            // Determine if message is command based on prefix
            if (!(message.HasCharPrefix('!', ref argPos)
                || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
                || message.Author.IsBot)

                return;

            // Create Websocket based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute command with the context just created along with service provider 
            // pre-condition checks
            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }
    }
}
