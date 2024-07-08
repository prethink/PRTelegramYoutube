using PRTelegramBot.Attributes;
using PRTelegramBot.Configs;
using PRTelegramBot.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramYoutube
{
    internal class ConfigsAndCommands
    {
        [ReplyMenuDynamicHandler("START")]
        public static async Task ReplyDynamic(ITelegramBotClient botClient, Update update)
        {
            string msg = botClient.GetConfigValue<BotConfigJsonProvider, string>("Message", "MSG");
            await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
        }
    }
}
