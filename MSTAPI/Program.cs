using Microsoft.EntityFrameworkCore;
using MSTCore.Entities;
using MSTRepository;
using MSTService;
using System.Reflection;
using MSTCore.UnitOfWorks;
using MSTRepository.UnitOfWorks;
using MSTRepository.Repositories;
using AutoMapper;
using MSTAPI;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lam�n� (AppDbContext) ekliyoruz
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Repository ve Service katmanlar�n� Dependency Injection ile ekliyoruz
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper yap�land�rmas�
builder.Services.AddAutoMapper(typeof(MappingProfile)); // MappingProfile'� ekliyoruz

// Controller'lar� ekliyoruz
builder.Services.AddControllers();

// Swagger/OpenAPI yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Development ortam�nda Swagger kullan�m�
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
