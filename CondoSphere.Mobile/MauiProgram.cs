using CondoSphere.Mobile.Services;
using CondoSphere.Mobile.ViewModels;
using CondoSphere.Mobile.Views;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CondoSphere.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.ClearProviders();
            builder.Logging.AddDebug();
#endif

            // --- Dependency Injection Registration ---

            // Services (Singletons: one instance for the entire app)
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<ApiClient>();

            // ViewModels (Transients: a new instance every time one is requested)
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ShellViewModel>();
            builder.Services.AddTransient<ResidentPortalViewModel>();
            builder.Services.AddTransient<DocumentsViewModel>();
            builder.Services.AddTransient<CondoListViewModel>();
            builder.Services.AddTransient<CondoDetailsViewModel>();
            builder.Services.AddTransient<AdminDashboardViewModel>();
            builder.Services.AddTransient<CreateOccurrenceViewModel>();
            builder.Services.AddTransient<ManagerOccurrenceDetailsViewModel>();
            builder.Services.AddTransient<QuotaDetailsViewModel>();
            builder.Services.AddTransient<MessagesViewModel>();
            builder.Services.AddTransient<MessageDetailsViewModel>();
            builder.Services.AddTransient<ComposeMessageViewModel>();

            // Pages (Transients)
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ResidentPortalPage>();
            builder.Services.AddTransient<DocumentsPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<CondoListPage>();
            builder.Services.AddTransient<AdminDashboardPage>();
            builder.Services.AddTransient<CondoDetailsPage>();
            builder.Services.AddTransient<CreateOccurrencePage>();
            builder.Services.AddTransient<ManagerOccurrenceDetailsPage>();
            builder.Services.AddTransient<QuotaDetailsPage>();
            builder.Services.AddTransient<MessagesPage>();
            builder.Services.AddTransient<MessageDetailsPage>();
            builder.Services.AddTransient<ComposeMessagePage>();


            return builder.Build();
        }
    }
}