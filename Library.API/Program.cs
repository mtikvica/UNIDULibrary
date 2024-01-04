using Library.API.Extensions;
using Library.API.Middlewares;
using Library.Core.BackgroundServices;
using Library.Core.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpClient();
builder.Services.AddRepositories();
builder.Services.AddCoreServices();
builder.Services.AddContext();
builder.Services.AddHostedService<ReservationBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
