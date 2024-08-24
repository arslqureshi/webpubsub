using Microsoft.Azure.WebPubSub.AspNetCore;
using Microsoft.Extensions.Azure;
using sockets;
using sockets.DataService;
using sockets.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("reactApp", builder =>
    {
        builder
                .SetIsOriginAllowed(isOriginAllowed: _ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();



builder.Services.AddSingleton<SharedDb>();


builder.Services.AddWebPubSub(o => o.ServiceEndpoint = new WebPubSubServiceEndpoint("Endpoint=https://enwage-test.webpubsub.azure.com;AccessKey=aGoVU+aV0LaX4gDXWxJpsrycS2Fhl9AJrD499fd83uI=;Version=1.0;"))
    .AddWebPubSubServiceClient<PubSubHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapHub<ChatHub>("/Chat");

app.UseCors("reactApp");

//app.MapWebPubSubHub<PubSubHub>("/eventhandler");

app.Run();
