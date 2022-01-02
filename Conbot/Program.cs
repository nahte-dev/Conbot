using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Conbot
{
    class Program
    {
        Controller controller = new Controller();
       
        static void Main(string[] args)
        {
            new Program().controller.MainAsync().GetAwaiter().GetResult();
        }
    }
}
