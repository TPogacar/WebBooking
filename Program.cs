using Microsoft.EntityFrameworkCore;
using WebBooking.Data;
using WebBooking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApiContext>
//    (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ReservationsContext")));

builder.Services.AddDbContext<ApiContext>
    (opt => opt.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=WebBookingDb;Integrated Security=True;Multiple Active Result Sets=True"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Add seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservations}/{action=Create}/{id?}");

app.Run();
