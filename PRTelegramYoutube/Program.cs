using PRTelegramBot.Configs;
using PRTelegramBot.Core;
using PRTelegramBot.Models;
using PRTelegramBot.Models.Enums;
using PRTelegramBot.Models.EventsArgs;
using PRTelegramYoutube.Admins;
using PRTelegramYoutube.Middlewares;

var botProviders = new BotConfigJsonProvider(".\\Configs\\commands.json");
var dynamicCommands = botProviders.GetKeysAndValues();

var admincheck = new InternalChecker(new List<CommandType>() { CommandType.Reply }, new AdminCheck());

var bot = new PRBotBuilder("Token")
    .SetBotId(0)
    .AddReplyDynamicCommands(dynamicCommands)
    .AddConfigPath("Message",".//Configs//message.json")
    .AddMiddlewares(new OneMiddleware(), new ThreeMiddleware(), new TwoMiddleware())
    .AddAdmin(2323)
    .AddCommandChecker(admincheck)
    .Build();


bot.Events.OnCommonLog += Events_OnCommonLog;
_ = bot.Start();

var bots = BotCollection.Instance.GetBots();

async Task Events_OnCommonLog(CommonLogEventArgs arg)
{
    Console.WriteLine(arg.Message);
}

while (true)
{

}