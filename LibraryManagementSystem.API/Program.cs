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
            ValidateAudience = true,               //Oluşturulacak token değerlerinin kimlerin/hangi originlerin/sitelerin kullanıcı belirlediğimiz değerdir. www.bilmemne.com
            ValidateIssuer = true,                //Oluşturulacak token değerini kimin dağıttığını ifade eder www.myapi.com
            ValidateLifetime = true,             //Oluşturulan token değerinin süresini kontrol edeceğimiz alandır.
            ValidateIssuerSigningKey = true,    //Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden sciry key verisinin doğrulanmasıdır


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
