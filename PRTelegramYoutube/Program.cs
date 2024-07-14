using PRTelegramBot.Configs;
using PRTelegramBot.Core;
using PRTelegramBot.Models.EventsArgs;
using PRTelegramYoutube.Middlewares;

var botProviders = new BotConfigJsonProvider(".\\Configs\\commands.json");
var dynamicCommands = botProviders.GetKeysAndValues();

var bot = new PRBotBuilder("Token")
    .SetBotId(0)
    .AddReplyDynamicCommands(dynamicCommands)
    .AddConfigPath("Message",".//Configs//message.json")
    .AddMiddlewares(new OneMiddleware(), new ThreeMiddleware(), new TwoMiddleware())
    .AddAdmin(111)
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