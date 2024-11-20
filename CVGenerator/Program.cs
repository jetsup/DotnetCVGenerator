using CVGenerator.Services;
using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add my pdf download service to the container
// builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
// builder.Services.AddScoped<PdfGeneration>();

builder.Services.AddSingleton<IConverter, SynchronizedConverter>(_ => new SynchronizedConverter(new PdfTools()));
// Add PdfGeneration to the DI container
builder.Services.AddScoped<PdfGeneration>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
