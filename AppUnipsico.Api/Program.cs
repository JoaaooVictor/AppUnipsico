using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Repositories;
using AppUnipsico.Api.Services.Impl;
using AppUnipsico.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEncryptService, EncryptService>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddAutoMapper(typeof(Program));


var connectionString = builder.Configuration.GetConnectionString("App");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

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
