using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("pt-PT")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(7);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddTransient<JwtForwardingDelegatingHandler>();

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Cookie.Name = "CondoSphere.AuthCookie";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
})
.AddHttpMessageHandler<JwtForwardingDelegatingHandler>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IAccessTokenStore, SessionAccessTokenStore>();

var app = builder.Build();

// This is the corrected middleware pipeline for production
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages(async context =>
    {
        var resp = context.HttpContext.Response;
        var path = context.HttpContext.Request.Path;
        await resp.WriteAsync($"HTTP {resp.StatusCode} at {path}");
    });
}
else
{
    // For a production environment without HTTPS, we only configure the error handler.
    app.UseExceptionHandler("/Home/Error");
    // DO NOT USE HSTS or HTTPS Redirection on an HTTP-only site.
    // app.UseHsts();
    // app.UseHttpsRedirection();
}

var staticFileCacheDuration = TimeSpan.FromDays(30);
var staticFileCacheControlValue = $"public,max-age={(int)staticFileCacheDuration.TotalSeconds}";

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers[HeaderNames.CacheControl] = staticFileCacheControlValue;
    }
});

var uploadPathSetting = builder.Configuration["FileUpload:Path"];
var resolvedUploadPath = Environment.ExpandEnvironmentVariables(
    string.IsNullOrWhiteSpace(uploadPathSetting) ? "CondoSphere_Uploads" : uploadPathSetting);

if (!Path.IsPathRooted(resolvedUploadPath))
{
    resolvedUploadPath = Path.GetFullPath(Path.Combine(app.Environment.ContentRootPath, resolvedUploadPath));
}

Directory.CreateDirectory(resolvedUploadPath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(resolvedUploadPath),
    RequestPath = "/uploads",
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers[HeaderNames.CacheControl] = staticFileCacheControlValue;
    }
});

app.UseRequestLocalization();
app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();