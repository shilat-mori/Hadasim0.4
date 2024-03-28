using DAL.HMO;
using DAL.Interfaces;
using BLL.Interfaces;
using BLL.DTO;
using BLL.Func;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using DAL.Func;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(opotion => opotion.AddPolicy("All",//נתינת שם להרשאה
    p => p.AllowAnyOrigin()//מאפשר כל מקור
    .AllowAnyMethod()//כל מתודה - פונקציה
    .AllowAnyHeader()));//וכל כותרת פונקציה

//העברת האותיות בגודל האמיתי (פתירת בעיית הותיות הגדולות)
builder.Services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

//הזרקת תלות של מסד הנתונים
builder.Services.AddDbContext<HmoCoronaContext>(options => options.UseSqlServer("Server=DESKTOP-2ACF5FN\\SQLEXPRESS;Database=HMO_corona;Trusted_Connection=True; TrustServerCertificate=True"));


builder.Services.AddScoped(typeof(ICoronaVaccine_bll), typeof(CoronaVaccine_bll));
builder.Services.AddScoped(typeof(ICoronaVaccine_dal), typeof(CoronaVaccine_dal));
builder.Services.AddScoped(typeof(IPatient_bll), typeof(Patient_bll));
builder.Services.AddScoped(typeof(IPatient_dal), typeof(Patient_dal));
builder.Services.AddScoped(typeof(IPatientAddress_bll), typeof(PatientAddress_bll));
builder.Services.AddScoped(typeof(IPatientAddress_dal), typeof(PatientAdress_dal));
builder.Services.AddScoped(typeof(IProducter_bll), typeof(Producter_bll));
builder.Services.AddScoped(typeof(IProducer_dal), typeof(Producer_dal));
builder.Services.AddScoped(typeof(ISerologion_bll), typeof(Serologion_bll));
builder.Services.AddScoped(typeof(ISerologion_dal), typeof(Serologion_dal));
builder.Services.AddScoped(typeof(IVaccine_bll), typeof(Vaccine_bll));
builder.Services.AddScoped(typeof(IVaccine_dal), typeof(Vaccine_dal));

var app = builder.Build();

app.UseCors("All");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
