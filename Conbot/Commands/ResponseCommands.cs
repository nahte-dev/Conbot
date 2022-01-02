using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;


namespace Conbot.Commands
{
    public class ResponseCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Returns pong")]
        public async Task ReturnPong(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("say")]
        [Description("Returns your message")]
        public async Task ReturnMessage(CommandContext ctx, 
            [Description("Your input message to be returned")] string msg)
        {
            var user = ctx.User;

            await ctx.Channel.SendMessageAsync(msg).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync($"*Written by {user}*").ConfigureAwait(false);
        }
    }
}
