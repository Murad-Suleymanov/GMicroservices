using EventBus.Messages.Common;
using GMicroservices.Ordering.Persistence;
using GMicroservices.Ordering.WebApi.EventBusConsumer;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config => {

    config.AddConsumer<ParcelCheckoutConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host("amqp://guest:guest@localhost:5672");

        cfg.ReceiveEndpoint(EventBusConstants.ParcelCheckoutQueue, c =>
        {
            c.ConfigureConsumer<ParcelCheckoutConsumer>(ctx);
        });
    });
});

// General Configuration
builder.Services.AddScoped<ParcelCheckoutConsumer>();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrderContext>();
    context.Database.Migrate();
}

app.Run();
