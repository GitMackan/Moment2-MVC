var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();                 // Aktivera Model View Controller (MVC)
var app = builder.Build();

app.UseStaticFiles();                                       // Aktivera wwwroot
app.UseRouting();

app.MapControllerRoute(                                     // Specificera routing
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}"
);

app.Run();                                                  // Kör applikation
