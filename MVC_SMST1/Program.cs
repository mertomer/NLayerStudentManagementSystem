﻿using Microsoft.EntityFrameworkCore;
using MSTService;
using MSTRepository;
using MSTCore.UnitOfWorks;
using MSTRepository.Repositories;
using MSTRepository.UnitOfWorks;
using MSTCore.Entities;
using MSTAPI;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant�s�n� appsettings.json'dan al
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>(); // Course service ekleme
builder.Services.AddScoped<ITeacherService, TeacherService>(); // Teacher service ekleme
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGenericRepository<Admin>, AdminRepository>();
builder.Services.AddScoped<IGenericRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IGenericRepository<Course>, CourseRepository>(); // Course repository ekleme
builder.Services.AddScoped<IGenericRepository<Teacher>, TeacherRepository>(); // Teacher repository ekleme
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));


// MVC ayarlar�
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware ve y�nlendirme
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Login}/{id?}");

app.Run();