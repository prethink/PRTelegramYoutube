using PRTelegramBot.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramYoutube
{
    internal class Commands
    {
        [ReplyMenuHandler("Тест")]
        public static async Task TestMethod(ITelegramBotClient botclient, Update update)
        {
            string msg = "Hello World";
            await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
        }
    }
}
