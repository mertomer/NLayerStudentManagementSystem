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

// appAPIsettings.json dosyasını yapılandırmaya ekliyoruz
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appAPIsettings.json", optional: false, reloadOnChange: true);
});

// CORS'u yapılandırıyoruz
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Veritabanı bağlamını (AppDbContext) ekliyoruz
builder.Services.AddDbContext<AppDbContext>(x =>
{
    // "appAPIsettings.json" içindeki "DefaultConnection" ayarını kullanıyoruz
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Repository ve Service katmanlarını Dependency Injection ile ekliyoruz
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper yapılandırması
builder.Services.AddAutoMapper(typeof(MappingProfile)); // MappingProfile'ı ekliyoruz

// Controller'ları ekliyoruz
builder.Services.AddControllers();

// Swagger/OpenAPI yapılandırması
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Development ortamında Swagger kullanımı
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS'u kullanıyoruz
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
