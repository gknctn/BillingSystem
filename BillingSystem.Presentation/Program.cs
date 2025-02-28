using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.BusinessLayer.Concrete;
using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.DataAccessLayer.EntityFramework;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

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