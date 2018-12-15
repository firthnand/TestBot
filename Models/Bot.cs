using System;
using Telegram.Bot;
using System.Threading.Tasks;
using System.Collections.Generic;
using TestBot.Models.Commands;
using Telegram.Bot.Types;

namespace TestBot.Models
{
    /// <summary>
    /// Бот
    /// </summary>
    public  static class Bot
    {
        #region Переменные

        /// <summary>
        /// Телеграмм Бот клиент
        /// </summary>
        private static TelegramBotClient _telegramBotClient;

        /// <summary>
        /// Хранилище комманд
        /// </summary>
        private static List<ICommand> _commands;
        
        #endregion Переменные

        
        #region Свойства

        public static IReadOnlyList<ICommand> Commands 
        { 
            get
            {
                if (_commands == null)
                {
                    _commands = new List<ICommand>();
                    _commands.Add(new HelloWorldCommand());
                    _commands.Add(new HiCommand());
                    _commands.Add(new EchoCommand());
                    //TODO: commands adding here
                }
                return _commands.AsReadOnly();
            } 
        }

        public static TelegramBotClient TelegramBotClient
        {
            get => _telegramBotClient = _telegramBotClient ?? new TelegramBotClient(AppSettings.Key);
        }

        #endregion Свойства

        
        #region Методы

        /// <summary>
        /// Получить телеграмм бот клиента
        /// </summary>
        /// <returns></returns>
        public static async Task<TelegramBotClient> GetAsync()
        {         
            string webHookUrl = string.Format(AppSettings.URL, AppSettings.ControllerRoute);
            await TelegramBotClient.SetWebhookAsync(webHookUrl);

            return TelegramBotClient;
        }

        /// <summary>
        /// Запустить longPolling
        /// </summary>
        /// <returns></returns>
        public static async Task RunAsync()
        {
            await TelegramBotClient.SetWebhookAsync("");
            try
            {
                int offset = 0; // отступ по сообщениям
                while (true)
                {
                    Update[] updates = await _telegramBotClient.GetUpdatesAsync(offset);
                    foreach (Update update in updates)
                    {
                        ExecuteCommands(update.Message);
                        offset = update.Id + 1;
                    }
                    
                    System.Threading.Thread.Sleep(5000);
                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExecuteCommands(Message message)
        {
            foreach (ICommand command in Commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, TelegramBotClient);
                    break;
                }
            }
        }

        #endregion Методы
    }
}