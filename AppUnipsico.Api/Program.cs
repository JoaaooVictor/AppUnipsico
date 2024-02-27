using AppUnipsico.Api.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
//builder.Services.AddScoped<ICriptografiaServico, CriptografiaServico>();
//builder.Services.AddScoped<IConsultaServico, ConsultaServico>();
//builder.Services.AddScoped<IAlunoServico, AlunoServico>();

builder.Services.AddAuthorization();

var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Segredos.ChaveSecretaToken));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = chaveSecreta
        };
    });

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(Program));

var connectionString = builder.Configuration.GetConnectionString("App");



//builder.Services.AddDbContext<AppDbContext>(opt =>
//{
//    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});

var app = builder.Build();

app.UseCors(policy =>
{
    policy
        .WithOrigins("https://localhost:7242", "http://localhost:5154")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithHeaders(HeaderNames.ContentType);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
