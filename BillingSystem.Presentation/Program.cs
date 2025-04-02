using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.BusinessLayer.Concrete;
using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.DataAccessLayer.Concrete;
using BillingSystem.DataAccessLayer.EntityFramework;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser() // Kimlik do�rulama zorunlu
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy)); // T�m sayfalara uygula
});

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // �ifre politikalar�
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
})
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// Rolleri desteklemek i�in (RoleManager i�in gerekli)
builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// Set the culture to ensure correct decimal formatting
var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IProductService and its concrete implementation
builder.Services.AddScoped<IProductService, ProductManager>(); // IProductService'i ProductManager ile ili�kilendiriyoruz
builder.Services.AddScoped<IUserService, UserManager>(); // IUserService'i UserManager ile ili�kilendiriyoruz
builder.Services.AddScoped<ICategoryService, CategoryManager>(); // ICategoryService'i CategoryManager ile ili�kilendiriyoruz
builder.Services.AddScoped<ITableService, TableManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderItemService, OrderItemManager>();
builder.Services.AddScoped<IPaymentService, PaymentManager>();

// IProductDal ve IProductDal implementasyonlar�n� kaydediyoruz.

builder.Services.AddScoped<IProductDal, EfProductRepository>(); // IProductDal'� EfProductRepository ile ili�kilendiriyoruz.
builder.Services.AddScoped<IUserDal, EfUserRepository>(); // IUserDal'� EfUserRepository ile ili�kilendiriyoruz.
builder.Services.AddScoped<ICategoryDal, EfCategoryRepository>(); // ICategoryDal'� EfCategoryRepository ile ili�kilendiriyoruz.
builder.Services.AddScoped<ITableDal, EfTableRepository>();
builder.Services.AddScoped<IOrderDal, EfOrderRepository>();
builder.Services.AddScoped<IOrderItemDal, EfOrderItemRepository>();
builder.Services.AddScoped<IPaymentDal, EfPaymentRepository>();


// Cookie ayarlar�
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/AdminUser/SignIn";
    options.AccessDeniedPath = "/Admin/AdminUser/AccessDenied";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=AdminHome}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapStaticAssets();

app.Run();