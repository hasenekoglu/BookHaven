using System.Text;
using LibraryManagementSystem.Application.Registration;
using LibraryManagementSystem.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
        options.TokenValidationParameters =new()
        {
            ValidateAudience = true,               //Olu�turulacak token de�erlerinin kimlerin/hangi originlerin/sitelerin kullan�c� belirledi�imiz de�erdir. www.bilmemne.com
            ValidateIssuer = true,                //Olu�turulacak token de�erini kimin da��tt���n� ifade eder www.myapi.com
            ValidateLifetime = true,             //Olu�turulan token de�erinin s�resini kontrol edece�imiz aland�r.
            ValidateIssuerSigningKey = true,    //�retilecek token de�erinin uygulamam�za ait bir de�er oldu�unu ifade eden sciry key verisinin do�rulanmas�d�r


            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))


        });

#endregion

builder.Services.AddCors(o =>
    o.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod(); }));

builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
