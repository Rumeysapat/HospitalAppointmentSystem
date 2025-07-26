using Microsoft.EntityFrameworkCore;
using Hospital.Data.Concrete.EntityFramework.Contexts;
using Hospital.Services.Abstract;
using Hospital.Services.Concrete;
using Hospital.Data.Abstract;
using Hospital.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HospitalAppointmentDbContext>(options =>
    options.UseSqlite("Data Source=../Hospital.Data/Hospital.db"));
builder.Services.AddScoped<IDoctorService, DoctorManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
builder.Services.AddScoped<IPatientService, PatientManager>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();//
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
