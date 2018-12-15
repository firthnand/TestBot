using System;

namespace TestBot.Models
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Ссылка на бот
        /// TODO: Вынести в отдельный конфиг.!-- После публикации веб хука обновить URL
        /// </summary>
        public static string URL { get; set; } = "";
        
        /// <summary>
        /// Путь до контроллера
        /// </summary>     
        public static string ControllerRoute {get;} = "api/MessageController/update";

        /// <summary>
        /// Имя бота
        /// </summary>
        public static string Name {get; set; } = "Alpha";
        
        /// <summary>
        /// API Кюч бота
        /// </summary>
        public static string Key {get; set;} = "717493953:AAHs-ikDgGkjCtmJ_-wc5hFWYQekGIUpMjU";
    }
}