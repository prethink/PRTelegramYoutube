using PRTelegramBot.Configs;
using PRTelegramBot.Core;
using PRTelegramBot.Models.EventsArgs;

var botProviders = new BotConfigJsonProvider(".\\Configs\\commands.json");
var dynamicCommands = botProviders.GetKeysAndValues();

var bot = new PRBotBuilder("Token")
    .AddReplyDynamicCommands(dynamicCommands)
    .AddConfigPath("Message",".//Configs//message.json")
    .Build();

bot.Events.OnCommonLog += Events_OnCommonLog;
_ = bot.Start();

async Task Events_OnCommonLog(CommonLogEventArgs arg)
{
    Console.WriteLine(arg.Message);
}

while (true)
{

}