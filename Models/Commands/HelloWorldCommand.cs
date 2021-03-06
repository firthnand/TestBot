using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace TestBot.Models.Commands
{
    /// <summary>
    /// Команда приветствия
    /// </summary>
    public class HelloWorldCommand : BaseCommand
    {
         ///<see cref="ICommand.Name"/>>
        public override string Name => "/helloworld";

        ///<see cref="ICommand.Execute(Message, TelegramBotClient)"/>>
        public override async Task Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;
            int messageId = message.MessageId;
            ///TODO Bot logic here

            await client.SendTextMessageAsync(chatId, "Hello World!", replyToMessageId:messageId);         

        }
    }
}