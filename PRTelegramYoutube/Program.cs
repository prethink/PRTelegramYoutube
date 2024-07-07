using PRTelegramBot.Core;
using PRTelegramBot.Models.EventsArgs;

var bot = new PRBotBuilder("Token").Build();
bot.Events.OnCommonLog += Events_OnCommonLog;
_ = bot.Start();

async Task Events_OnCommonLog(CommonLogEventArgs arg)
{
    Console.WriteLine(arg.Message);
}

while (true)
{

}