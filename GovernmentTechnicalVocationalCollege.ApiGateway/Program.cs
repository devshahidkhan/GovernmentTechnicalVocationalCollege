using GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.InstructorService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.InstructorService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.NumberGenerationService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.NumberGenerationService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Implementation;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructorRepository;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories;


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IProgramService, ProgramService>();

builder.Services.AddScoped<IAcademicSessionRepository, AcademicSessionRepository>();
builder.Services.AddScoped<IAcademicSessionService, AcademicSessionService>();

builder.Services.AddScoped<IAdmissionRepository, AdmissionRepository>();
builder.Services.AddScoped<IAdmissionService, AdmissionService>();

builder.Services.AddScoped<IInstructorRepository,InstructorRepository>();
builder.Services.AddScoped<IInstructorService,InstructorService>();


builder.Services.AddScoped<INumberGeneratorService,NumberGenerationService>();

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
