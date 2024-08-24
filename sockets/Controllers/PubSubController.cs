using Azure.Core;
using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebPubSub.AspNetCore;
using Microsoft.Extensions.Primitives;
using sockets.DataService;
using sockets.Hubs;

namespace sockets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubSubController : Controller
    {
        private WebPubSubServiceClient<PubSubHub> service;

        private SharedDb sharedDb;


        public PubSubController(WebPubSubServiceClient<PubSubHub> _service, SharedDb _sharedDb)
        {
            service = _service;
            sharedDb = _sharedDb;
        }

        [HttpGet("/{id}")]
        public IActionResult Get(string id)
        {
            //if (sharedDb[id] != null)
            //{

            //}
            return Ok(new
            {
                url = service.GetClientAccessUri(userId: id).AbsoluteUri
            });
        }

        [HttpGet("/sendmessage")]
        public async Task SendMessage()
        {
            await service.SendToAllAsync(RequestContent.Create(
            new
            {
                from = "Id",
                message = "Message from Backend"
            }),
            ContentType.ApplicationJson);
        }
    }
}
