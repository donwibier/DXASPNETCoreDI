using aspnet.Code;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//services.Add(new ServiceDescriptor(typeof(IStringModifierService), typeof(ReverserService), ServiceLifetime.Transient));
builder.Services.AddTransient<IStringModifierService, ReReverserService>();
//builder.Services.AddTransient<IStringModifierService, UpperCaseService>();
//builder.Services.AddTransient<ISomeotherService, ReReverserService>();

builder.Services.AddTransient<ReverserService>();
builder.Services.AddTransient<UpperCaseService>();
builder.Services.AddTransient<ReReverserService>();
builder.Services.AddTransient<Func<ModifierEnum, IStringModifierService>>(provider => key =>
{
    switch (key)
    {
        case ModifierEnum.Uppercase:
            return provider.GetService<UpperCaseService>();
        case ModifierEnum.Reverser:
            return provider.GetService<ReverserService>();
        case ModifierEnum.ReReverser:
            return provider.GetService<ReReverserService>();
        default:
            return null;
    }
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


