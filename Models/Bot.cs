using System;
using Telegram.Bot;
using System.Threading.Tasks;
using System.Collections.Generic;
using TestBot.Models.Commands;

namespace TestBot.Models
{
    /// <summary>
    /// Бот
    /// </summary>
    public  static class Bot
    {
        /// <summary>
        /// Телеграмм Бот клиент
        /// </summary>
        private static TelegramBotClient _telegramBotClient;

        private static List<ICommand> _commands;

        public static IReadOnlyList<ICommand> Commands 
        { 
            get
            {
                _commands = _commands ?? new List<ICommand>();
                return _commands.AsReadOnly();
            } 
        }

        /// <summary>
        /// Получить телеграмм бот клиента
        /// </summary>
        /// <returns></returns>
        public static async Task<TelegramBotClient> GetAsync()
        {
            if (_telegramBotClient != null)
            {
                return _telegramBotClient;
            }
            _telegramBotClient = new TelegramBotClient(AppSettings.Key);
            
            string webHookUrl = string.Format(AppSettings.URL, AppSettings.ControllerRoute);

            await _telegramBotClient.SetWebhookAsync(webHookUrl);
            _commands = new List<ICommand>();
            _commands.Add(new HelloWorldCommand());

            //TODO: commands adding here

            return _telegramBotClient;
        }
    }
}