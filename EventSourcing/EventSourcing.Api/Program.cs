using EventSourcing.Api.EventStores;
using EventStore.ClientAPI;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = EventStoreConnection.Create(builder.Configuration.GetConnectionString("EventStore"));
await connection.ConnectAsync();
builder.Services.AddSingleton(connection);

builder.Services.AddSingleton<BookStream>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
