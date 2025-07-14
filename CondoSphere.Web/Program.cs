using CondoSphere.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Add services to the container. ---

// 1. Configure standard MVC services.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); // Required for the handler to access the current HttpContext

// 2. Register the handler. It's transient because handlers can have state.
builder.Services.AddTransient<JwtForwardingDelegatingHandler>();

// 3. Configure Authentication services using the "Cookies" scheme.
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        // The name of the cookie that will store our authentication session.
        options.Cookie.Name = "CondoSphere.AuthCookie";
        // If an unauthenticated user tries to access a protected page, redirect them to the Login page.
        options.LoginPath = "/Account/Login";
        // If a logged-in user tries to access a resource they don't have permission for.
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// 4. Configure Authorization services. This can be expanded with policies later.
builder.Services.AddAuthorization();

// 5. Configure our typed HttpClient for communicating with the API.
builder.Services.AddHttpClient<ApiClient>(client =>
{
    // Set the base URL for all API calls made by this client.
    // This value comes from our appsettings file (e.g., appsettings.Development.json).
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
})
.AddHttpMessageHandler<JwtForwardingDelegatingHandler>(); // Attach the handler to the HttpClient pipeline

var app = builder.Build();

// --- Configure the HTTP request pipeline. ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// The correct order for authentication middleware in the pipeline:
// 1. UseAuthentication: Identifies who the user is by reading the cookie.
// 2. UseAuthorization: Checks if the identified user has permission to access the requested resource.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();