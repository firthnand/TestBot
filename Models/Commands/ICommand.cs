using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    /// <summary>
    /// Интерфейс комманды
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Имя комманды
        /// </summary>
        string Name {get;}

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="message">Соббщение бота</param>
        /// <param name="client">Телеграм бот клиент</param>
         void Execute(Message message, TelegramBotClient client);

        /// <summary>
        /// Команда содержится в тексте
        /// </summary>
        /// <param name="comment">Текст</param>
        /// <returns></returns>
         bool Contains(string text);  
    }
}