using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TestBot.Models;
using TestBot.Models.Commands;

namespace TestBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController: ControllerBase
    {
        // [Route(@"api/message/update")]
        // public OKResult Update()
        // {

        // }

        // POST: api/MessageController/update
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<ActionResult> Update(Update update)
        {
            Message message = update.Message;
            TelegramBotClient client = await Bot.GetAsync();
            foreach (ICommand command in Bot.Commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();

        }
    }
}