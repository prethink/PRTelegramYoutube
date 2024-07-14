using PRTelegramBot.Core.Middlewares;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace PRTelegramYoutube.Middlewares
{
    internal class ThreeMiddleware : MiddlewareBase
    {
        public override async Task InvokeOnPreUpdateAsync(ITelegramBotClient botClient, Update update, Func<Task> next)
        {
            Console.WriteLine("Третий обработчик до");
            await base.InvokeOnPreUpdateAsync(botClient, update, next);
        }

        public override async Task InvokeOnPostUpdateAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine("Третий обработчик после");
            await base.InvokeOnPostUpdateAsync(botClient, update);
        }
    }
}
