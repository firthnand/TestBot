using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    /// <summary>
    /// Базовая комманда
    /// </summary>
    public abstract class BaseCommand: ICommand
    {
         ///<see cref="ICommand.Name"/>>
        public abstract string Name {get;}
        
        ///<see cref="ICommand.Execute(Message, TelegramBotClient)"/>>
        public abstract void Execute(Message message, TelegramBotClient client);

        ///<see cref="ICommand.Contains(string))"/>>
        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }
    }
}