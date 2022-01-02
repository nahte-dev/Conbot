using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;


namespace Conbot
{
    class Controller
    {
        private Conbot conbot;

        public Controller()
        {
            this.conbot = new Conbot(this);
        }

        public async Task MainAsync()
        {
            await this.conbot.RunAsync();
        }
    }
}
