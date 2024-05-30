using System.Text.Json.Serialization;
using System.Text.Json;
using CoreTest.JsonConverters.Pakistan;
using common_logger;
using common_request_logger;
using common_request_logger.Interfaces;
using common_request_logger.Middleware;
using CoreTest.Cores;
using CoreTest.Data.Pakistan;

ILog? log = null;
try
{
    var builder = WebApplication.CreateBuilder(args);
    
    var lb = Log.Builder
        .UseLocalDatabase("logs\\logs.db")
        .UseConsole();
    log = lb.Build();
    builder.Services.AddSingleton(lb);
    builder.Services.AddScoped<ILog, Log>();

    var rb = RequestLogger.CreateBuilder("CoreTest")
        .UseLog(lb)
        .UseSQLite(new common_request_logger.Data.SQLite.Settings("logs\\rl.db"));
    builder.Services.AddSingleton(rb);
    builder.Services.AddScoped<IRequestLogger, RequestLogger>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers().AddJsonOptions((x =>
    {
        x.JsonSerializerOptions.WriteIndented = true;
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.Converters.Add(new ClientConverter());
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }));

    builder.Services.AddSingleton(new Setup()
    {
        Actions = new List<ActionElement>()
        {
            new ActionElement(1, CoreTest.Models.Enums.ActionType.SendNotification, CoreTest.Models.Enums.CaseType.AfterCreateClient),
            new ActionElement(2, CoreTest.Models.Enums.ActionType.SendCallback, CoreTest.Models.Enums.CaseType.AfterCreateClient)
        }
    }); 
    builder.Services.AddScoped<INotificationCore, NotificationCore>();
    builder.Services.AddSingleton<IClientData>(new ClientData());
    builder.Services.AddScoped<IClientCore, CoreTest.Cores.Pakistan.ClientCore>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseMiddleware<RequestLoggerMiddleware>();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    log?.Fatal("FATAL STOP APP", ex);
}