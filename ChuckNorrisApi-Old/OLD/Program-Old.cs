//using Microsoft.AspNetCore.HttpLogging;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();
//builder.Services.AddMvc().AddRazorRuntimeCompilation();
//builder.Services.AddHttpLogging(logging =>
//{
//logging.LoggingFields = HttpLoggingFields.ResponseStatusCode;
//});

//var app = builder.Build();

//app.UseStaticFiles();
//app.UseRouting();
//app.MapRazorPages();
//app.UseHttpLogging();

//app.MapControllerRoute(
//name: "default",
//pattern: "{controller=Home}/{action=Index}");


//app.Run();