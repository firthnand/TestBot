using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;

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
        /// <param name="message">Сообщение бота</param>
        /// <param name="client">Телеграм бот клиент</param>
        Task Execute(Message message, TelegramBotClient client);

        /// <summary>
        /// Команда содержится в тексте
        /// </summary>
        /// <param name="comment">Текст</param>
        /// <returns></returns>
        bool Contains(string text);  
    }
}