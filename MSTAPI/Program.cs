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

// appAPIsettings.json dosyasýný yapýlandýrmaya ekliyoruz
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appAPIsettings.json", optional: false, reloadOnChange: true);
});

// CORS'u yapýlandýrýyoruz
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Veritabaný baðlamýný (AppDbContext) ekliyoruz
builder.Services.AddDbContext<AppDbContext>(x =>
{
    // "appAPIsettings.json" içindeki "DefaultConnection" ayarýný kullanýyoruz
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Repository ve Service katmanlarýný Dependency Injection ile ekliyoruz
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper yapýlandýrmasý
builder.Services.AddAutoMapper(typeof(MappingProfile)); // MappingProfile'ý ekliyoruz

// Controller'larý ekliyoruz
builder.Services.AddControllers();

// Swagger/OpenAPI yapýlandýrmasý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Development ortamýnda Swagger kullanýmý
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS'u kullanýyoruz
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
