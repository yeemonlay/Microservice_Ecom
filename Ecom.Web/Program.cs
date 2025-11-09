using Ecom.Web.Interfaces;
using Ecom.Web.Services;
using Ecom.Web.Utilities;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
Common.EcomCouponServiceAPI = builder.Configuration["APIUrls:CouponAPIUrl"];
builder.Services.AddScoped<ICouponService,CouponService>();
builder.Services.AddScoped<IBaseService, BaseService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Coupon}/{action=Index}/{id?}");

app.Run();
