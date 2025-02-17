using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFoodMvcApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  // Adds MVC services to the container

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Displays detailed error pages in development
}
else
{
    app.UseExceptionHandler("/Home/Error");  // Shows a generic error page in production
    app.UseHsts();  // Enforces strict HTTP security
}

app.UseHttpsRedirection();  // Forces HTTPS
app.UseStaticFiles();  // Serves static files (like CSS, JS, images)

app.UseRouting();  // Enables routing

app.UseAuthorization();  // Enables authorization middleware

// Configure the route for the TestController with the "GetAll" action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=GetAll}/{id?}");  // Default route: TestController, GetAll action

app.Run();  // Run the application
