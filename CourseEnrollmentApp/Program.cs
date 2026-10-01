// Create the application builder
var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add Session service
builder.Services.AddSession();

// Build the application
var app = builder.Build();

// Check if application is in Development mode
if (!app.Environment.IsDevelopment())
{
    // Use error handling in Production
    app.UseExceptionHandler("/Home/Error");

    // Enable HSTS
    app.UseHsts();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable static files
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable Session
app.UseSession();

// Enable authorization
app.UseAuthorization();

// Configure MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application
app.Run();