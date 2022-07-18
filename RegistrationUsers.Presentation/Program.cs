using Microsoft.EntityFrameworkCore;
using RegistrationUsers.Infrastructure.CrossCutting.IOC;
using RegistrationUsers.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RegistrationUserDBContext>(options =>
                    options.UseSqlite(builder.Configuration.GetConnectionString("RegistrationUsersDB"), migration => migration.MigrationsAssembly("RegistrationUsers.Presentation")));
// Add services to the container.

builder.Services.AddControllers();

//Injection
ConfigurationIOC.RegisterServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cadastro de Usuários", Version = "v1.0" });
});

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin());

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
