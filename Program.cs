using FR_Groups_websites.DAL;
using FR_Groups_websites.DB;
using FR_Groups_websites.Interface;
using FR_Groups_websites.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 EF DAL
builder.Services.AddScoped<ILogoImageRepo, LogoImageRepo>();

// 🔹 Services
builder.Services.AddScoped<ILogoImageService, LogoImageService>();

// 🔹 MVC + Web API
builder.Services.AddControllersWithViews();

// 🔹 Swagger services ✅
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();          // ✅ enable swagger
    app.UseSwaggerUI();        // ✅ swagger UI
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 🔹 MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 🔹 API routing (important for controllers)
app.MapControllers();

app.Run();