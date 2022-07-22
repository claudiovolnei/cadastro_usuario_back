﻿using Microsoft.EntityFrameworkCore;
using RegistrationUsers.Infrastructure.CrossCutting.IOC;
using RegistrationUsers.Infrastructure.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RegistrationUserDBContext>(options =>
                    options.UseSqlite(builder.Configuration.GetConnectionString("RegistrationUsersDB"), migration => migration.MigrationsAssembly("RegistrationUsers.Presentation")));
// Add services to the container.

builder.Services.AddControllers();

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.AddSerilog(logger);

//Injection
ConfigurationIOC.RegisterServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://localhost:5005");
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cadastro de Usuários", Version = "v1.0" });
});

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(ui =>
{
    ui.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Cadastro de Usuários");
});

app.MapControllers();

app.Run();
