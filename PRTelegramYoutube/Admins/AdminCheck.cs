using PRTelegramBot.Core;
using PRTelegramBot.Extensions;
using PRTelegramBot.Interfaces;
using PRTelegramBot.Models;
using PRTelegramBot.Models.Enums;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramYoutube.Admins
{
    internal class AdminCheck : IInternalCheck
    {
        public async Task<InternalCheckResult> Check(PRBotBase bot, Update update, CommandHandler handler)
        {
            var method = handler.Command.Method;
            var adminAttribute = method.GetCustomAttribute<AdminOnlyAttribute>();
            if(adminAttribute != null)
            {
                var userIsAdmin = await bot.IsAdmin(update.GetChatId());
                if(userIsAdmin) 
                {
                    return InternalCheckResult.Passed;
                }
                else
                {
                    await bot.botClient.SendTextMessageAsync(update.GetChatIdClass(), "Доступ запрещен");
                    return InternalCheckResult.Custom;
                }
            }
            return InternalCheckResult.Passed;
        }
    }
}
