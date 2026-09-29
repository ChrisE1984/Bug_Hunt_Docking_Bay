using DockingBayApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IShipService, ShipService>();
builder.Services.AddScoped<IPilotService, PilotService>();

var app = builder.Build();

app.MapControllers();

app.Run();
