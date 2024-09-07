using DotnetGeminiSDK;
using GeminiApiChatBot.Service;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddGeminiClient(config =>
{
    config.ApiKey = "AIzaSyDuFhXvKGQA8f_5oE35QkUN0-1RvhWT1AI";
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGeminiService, GeminiService>();

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