using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using System.IO;
using Newtonsoft.Json;

namespace Conbot
{
    class Conbot
    {
        private Controller controller;
        private ConfigJson config;
       
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public Conbot(Controller controller)
        {
            this.controller = controller;
        }

        public async Task RunAsync()
        {
            await this.SetConfig();

            this.Client = new DiscordClient(this.SetDiscordConfig());
            this.Commands = Client.UseCommandsNext(this.SetCommandConfig());

            await this.RegisterCommands();

            Client.Ready += OnClientReady;
            await this.Client.ConnectAsync();

            await Task.Delay(-1);
        }

        public async Task SetConfig()
        {
            var config = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                config = await sr.ReadToEndAsync().ConfigureAwait(false);

            var json = JsonConvert.DeserializeObject<ConfigJson>(config);

            this.config = json;
        }

        public DiscordConfiguration SetDiscordConfig()
        {
            var config = new DiscordConfiguration
            {
                Token = this.config.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            return config;
        }

        public CommandsNextConfiguration SetCommandConfig()
        {
            var config = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { this.config.prefix },
                EnableMentionPrefix = false,
                EnableDms = false,
            };

            return config;
        }

        public async Task RegisterCommands()
        {
            this.Commands.RegisterCommands<Commands.ResponseCommands>();
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
