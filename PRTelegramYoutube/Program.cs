using PRTelegramBot.Core;

var bot = new PRBotBuilder("Token").Build();
bot.Events.OnCommonLog += Events_OnCommonLog;
_ = bot.Start();

async Task Events_OnCommonLog(PRTelegramBot.Models.EventsArgs.CommonLogEventArgs arg)
{
    Console.WriteLine(arg.Message);
}

while (true)
{

}