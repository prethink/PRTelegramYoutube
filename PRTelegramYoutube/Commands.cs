using PRTelegramBot.Attributes;
using PRTelegramBot.Interfaces;
using PRTelegramBot.Models;
using PRTelegramBot.Models.CallbackCommands;
using PRTelegramBot.Models.InlineButtons;
using PRTelegramBot.Utils;
using PRTelegramYoutube.Headers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace PRTelegramYoutube
{
    internal class Commands
    {
        public static int count = 0;
        #region reply

        [ReplyMenuHandler("Тест")]
        public static async Task TestMethod(ITelegramBotClient botclient, Update update)
        {
            string msg = "Hello World";
            await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
        }

        [ReplyMenuHandler("Пример 1", "Пример 2")]
        public static async Task TestMethodTwo(ITelegramBotClient botclient, Update update)
        {
            string msg = "Пример";
            await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
        }

        [ReplyMenuHandler(PRTelegramBot.Models.Enums.CommandComparison.Contains, "Текст")]
        public static async Task TestMethodText(ITelegramBotClient botclient, Update update)
        {
            string msg = "Есть текст";
            await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
        }

        [ReplyMenuHandler("Меню")]
        public static async Task ExampleMenu(ITelegramBotClient botclient, Update update)
        {
            string msg = "Hello World";
            var menuList = new List<KeyboardButton>();
            menuList.Add(new KeyboardButton("Кнопка 1"));
            menuList.Add(new KeyboardButton("Пример 1"));
            menuList.Add(new KeyboardButton("Текст"));
            menuList.Add(new KeyboardButton($"Меню ({count})"));

            count++;

            var menu = MenuGenerator.ReplyKeyboard(1, menuList, true, "Главное меню");
            var option = new OptionMessage();
            option.MenuReplyKeyboardMarkup = menu;
            await PRTelegramBot.Helpers.Message.Send(botclient, update, msg, option);
        }

        #endregion
        #region Slash

        [SlashHandler("/example")]
        public static async Task Slash(ITelegramBotClient botclient, Update update)
        {
            var msg = "\n /get_1 - команда 1" +
                "\n /get_2 - команда 2" +
                "\n /get_3 - команда 3" +
                "\n /get_4 - команда 4";
            await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
        }

        [SlashHandler("/get")]
        public static async Task GetSlash(ITelegramBotClient botclient, Update update)
        {
            if(update.Message.Text.Contains("_"))
            {
                var spl = update.Message.Text.Split('_');
                if(spl.Length > 1 )
                {
                    string msg = $"Команда /get содержит значение {spl[1]}";
                    await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
                }
                else
                {
                    string msg = "Команда /get";
                    await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
                }
            }
            else
            {
                string msg = "Команда /get";
                await PRTelegramBot.Helpers.Message.Send(botclient, update, msg);
            }
        }

        #endregion

        #region Inline

        [ReplyMenuHandler("Inline")]
        public static async Task Inline(ITelegramBotClient botClient, Update update)
        {
            var exampleOne = new InlineCallback("Пример", PRHeaders.Example);
            var exampleTwo = new InlineCallback<EntityTCommand<long>>("Передача", PRHeaders.ExampleTwo, new EntityTCommand<long>(5));

            var list = new List<IInlineContent>();
            list.Add(exampleOne);
            list.Add(exampleTwo);

            var menu = MenuGenerator.InlineKeyboard(2, list);

            var option = new OptionMessage();
            option.MenuInlineKeyboardMarkup = menu;
            await PRTelegramBot.Helpers.Message.Send(botClient, update, "Inline", option);
        }

        [InlineCallbackHandler<PRHeaders>(PRHeaders.Example)]
        public static async Task HandlerExample(ITelegramBotClient botClient, Update update)
        {
            await PRTelegramBot.Helpers.Message.Send(botClient, update, "Пример");
        }

        [InlineCallbackHandler<PRHeaders>(PRHeaders.ExampleTwo)]
        public static async Task HandlerExampleTwo(ITelegramBotClient botClient, Update update)
        {
            var command = InlineCallback<EntityTCommand<long>>.GetCommandByCallbackOrNull(update.CallbackQuery.Data);
            if(command != null)
            {
                await PRTelegramBot.Helpers.Message.Send(botClient, update, $"Пример {command.Data.EntityId}");
            }
        }

        #endregion
    }
}
