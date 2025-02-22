using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.BusinessLayer.Concrete;
using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.DataAccessLayer.EntityFramework;
using BillingSystem.DataAccessLayer.Repository;
using BillingSystem.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();

// Register IProductService and its concrete implementation
builder.Services.AddScoped<IProductService, ProductManager>(); // IProductService'i ProductManager ile iliþkilendiriyoruz
builder.Services.AddScoped<IUserService, UserManager>(); // IUserService'i UserManager ile iliþkilendiriyoruz

// IProductDal ve IProductDal implementasyonlarýný kaydediyoruz.
builder.Services.AddScoped<IProductDal, EfProductRepository>(); // IProductDal'ý EfProductRepository ile iliþkilendiriyoruz.
builder.Services.AddScoped<IUserDal, EfUserRepository>(); // IUserDal'ý EfUserRepository ile iliþkilendiriyoruz.



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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
