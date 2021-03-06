using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace TestBot.Models.Commands
{
    /// <summary>
    /// Дублирует соощение польователя
    /// </summary>
    public class EchoCommand : BaseCommand
    {
         ///<see cref="ICommand.Name"/>>
        public override string Name => "/echo";

        ///<see cref="ICommand.Execute(Message, TelegramBotClient)"/>>
        public override async Task Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;
            ///TODO Bot logic here

            await client.SendTextMessageAsync(chatId, $"{message.Text}");         

        }
    }
}