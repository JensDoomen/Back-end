using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NietDiscord.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NietDiscord.Models;

namespace NietDiscord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly DataContext dc;
        public MessageController(DataContext dc)
        {
            this.dc = dc;

        }

        //get api/messages
        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages = dc.Messages.ToList();
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult PostMessage(Message message)
        {
            dc.Messages.Add(message);
            dc.SaveChanges();
               
          /*  dc.Messages.Add(new Message()
                {
                    ID = message.ID,
                    sendfrom = message.sendfrom,
                    sento = message.sento,
                    messagecontents = message.messagecontents,
                    ispinned = message.ispinned,
                    isedited = message.isedited

                });*/

               
            
            return Ok();
        }
    }
}
