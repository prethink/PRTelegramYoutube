using PRTelegramBot.Core.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramYoutube.Middlewares
{
    internal class OneMiddleware : MiddlewareBase
    {
        public override async Task InvokeOnPreUpdateAsync(ITelegramBotClient botClient, Update update, Func<Task> next)
        {
            Console.WriteLine("Первый обработчик до");
            await base.InvokeOnPreUpdateAsync(botClient, update, next);
        }

        public override async Task InvokeOnPostUpdateAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine("Первый обработчик после");
            await base.InvokeOnPostUpdateAsync(botClient, update);
        }
    }
}
