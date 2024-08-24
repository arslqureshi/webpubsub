using Azure.Core;
using Microsoft.Azure.WebPubSub.AspNetCore;
using Microsoft.Azure.WebPubSub.Common;

namespace sockets.Hubs
{
    public sealed class PubSubHub: WebPubSubHub
    {

        private readonly WebPubSubServiceClient<PubSubHub> _serviceClient;

        public PubSubHub(WebPubSubServiceClient<PubSubHub> serviceClient)
        {
            _serviceClient = serviceClient;
        }
        //public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
        //{
        //    if (request.Query.TryGetValue("id", out var id))
        //    {
        //        return new ValueTask<ConnectEventResponse>(request.CreateResponse(userId: id.FirstOrDefault(), null, null, null));
        //    }

        //    // The SDK catches this exception and returns 401 to the caller
        //    throw new UnauthorizedAccessException("Request missing id");
        //}

        //public override async Task OnConnectedAsync(ConnectedEventRequest request)
        //{
        //    Console.WriteLine($"[SYSTEM] {request.ConnectionContext.UserId} joined.");
        //    await _serviceClient.SendToAllAsync(RequestContent.Create(
        //    new
        //    {
        //        from = request.ConnectionContext.UserId,
        //        message = $"{request.ConnectionContext.UserId} joined"
        //    }),
        //    ContentType.ApplicationJson);
        //}

        //public override async ValueTask<UserEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
        //{
        //    await _serviceClient.SendToAllAsync(RequestContent.Create(
        //    new
        //    {
        //        from = request.ConnectionContext.UserId,
        //        message = request.Data.ToString()
        //    }),
        //    ContentType.ApplicationJson);

        //    return new UserEventResponse();
        //}
    }
}
