using PRTelegramBot.Configs;
using PRTelegramBot.Core;
using PRTelegramBot.Models.EventsArgs;

var botProviders = new BotConfigJsonProvider(".\\Configs\\commands.json");
var dynamicCommands = botProviders.GetKeysAndValues();

var bot = new PRBotBuilder("Token")
    .SetBotId(0)
    .AddReplyDynamicCommands(dynamicCommands)
    .AddConfigPath("Message",".//Configs//message.json")
    .Build();

var botTwo = new PRBotBuilder("Token")
    .SetBotId(1)
    .AddReplyDynamicCommands(dynamicCommands)
    .AddConfigPath("Message", ".//Configs//message.json")
    .Build();


bot.Events.OnCommonLog += Events_OnCommonLog;
botTwo.Events.OnCommonLog += Events_OnCommonLog;
_ = bot.Start();
_ = botTwo.Start();

var bots = BotCollection.Instance.GetBots();

async Task Events_OnCommonLog(CommonLogEventArgs arg)
{
    Console.WriteLine(arg.Message);
}

while (true)
{

}