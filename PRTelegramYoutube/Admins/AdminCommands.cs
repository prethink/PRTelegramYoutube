using PRTelegramBot.Attributes;
using PRTelegramBot.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramYoutube.Admins
{
    internal class AdminCommands
    {
        [ReplyMenuHandler("Admin")]
        public static async Task AdminTest(ITelegramBotClient botClient, Update update)
        {
            var isAdmin = await botClient.IsAdmin(update);
            isAdmin = await botClient.GetBotDataOrNull().Options.AdminManager.HasUser(update.GetChatId());
            if(isAdmin)
            {
                await botClient.SendTextMessageAsync(update.GetChatIdClass(), "Я админ");
            }
            else
            {
                await botClient.SendTextMessageAsync(update.GetChatIdClass(), "Я не админ");
            }
        }

        [AdminOnly]
        [ReplyMenuHandler("AdminOnly")]
        public static async Task AdminOnly(ITelegramBotClient botClient, Update update)
        {
            await botClient.SendTextMessageAsync(update.GetChatIdClass(), "Я админ");
        }
    }
}
