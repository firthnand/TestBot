using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    /// <summary>
    /// Команда приветствия
    /// </summary>
    public class HiCommand : BaseCommand
    {
         ///<see cref="ICommand.Name"/>>
        public override string Name => "/hi";

        ///<see cref="ICommand.Execute(Message, TelegramBotClient)"/>>
        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;
            int messageId = message.MessageId;
            string userName = message.From.Username;
            ///TODO Bot logic here

            await client.SendTextMessageAsync(chatId, $"Hi! {userName}", replyToMessageId:messageId);         

        }
    }
}