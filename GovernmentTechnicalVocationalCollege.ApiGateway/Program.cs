using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using GovernmentTechnicalVocationalCollege.Presentation.Persistence.StudentRepository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

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
