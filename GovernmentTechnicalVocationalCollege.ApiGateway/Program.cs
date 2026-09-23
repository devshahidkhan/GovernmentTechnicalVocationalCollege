using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using GovernmentTechnicalVocationalCollege.Presentation.Persistence.AdmissionRepository.Implementation;
using GovernmentTechnicalVocationalCollege.Presentation.Persistence.ProgramRepository.Implementation;
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


builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IProgramService, ProgramService>();

builder.Services.AddScoped<IAdmissionRepository, AdmissionRepository>();
builder.Services.AddScoped<IAdmissionService, AdmissionService>();

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
