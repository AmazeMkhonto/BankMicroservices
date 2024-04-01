using BankServices.Service.IService;
using BankServices.Service;
using BankServices.Utility;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAccountHolderService, AccountHolderService>();
builder.Services.AddHttpClient<IAccountService, AccountService>();
builder.Services.AddHttpClient<ITransactionService, TransactionService>();

SD.AccountHolderAPIBase = builder.Configuration["ServiceUrls:AccountHolderAPI"];
SD.AccountAPIBase = builder.Configuration["ServiceUrls:AccountAPI"];
SD.TransactionAPIBase = builder.Configuration["ServiceUrls:TransactionAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAccountHolderService, AccountHolderService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();


var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
