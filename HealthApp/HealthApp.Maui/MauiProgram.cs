using CommunityToolkit.Maui;
using HealthApp.Application.Abstractions;
using HealthApp.Application.Services;
using HealthApp.Domain.Abstractions;
using HealthApp.Maui.Pages;
using HealthApp.Maui.Services.Abstractions;
using HealthApp.Maui.Services.Implementation;
using HealthApp.Maui.ViewModels;
using HealthApp.Persistence.Data;
using HealthApp.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace HealthApp.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "HealthApp.Maui.appsettings.json";
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);
#if DEBUG
        builder.Logging.AddDebug();
#endif
        SetupServices(builder.Services);
        SetupPages(builder.Services);
        SetupViewModels(builder.Services);
        SetupAppDbContext(builder);
        return builder.Build();
    }
    private static void SetupPages(IServiceCollection services)
    {
        services.AddSingleton<LoginPage>();
        services.AddTransient<RegistrationPatientPage>();
        services.AddTransient<RegistrationDoctorPage>();

        services.AddTransient<DoctorPage>();
        services.AddTransient<DoctorInfoPage>();

        services.AddTransient<PatientPage>();
        services.AddTransient<AddRecordPage>();
        services.AddTransient<GetStatisticPage>();
    }
    private static void SetupServices(IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPatientService, PatientService>();
        services.AddSingleton<IDoctorService, DoctorService>();
        services.AddSingleton<ICardService, CardService>();
        services.AddSingleton<IRecordService, RecordService>();

        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IPasswordService, PasswordService>();
    }
    private static void SetupViewModels(IServiceCollection services)
    {
        services.AddSingleton<LoginViewModel>();
        services.AddTransient<RegistrationPatientViewModel>();
        services.AddTransient<RegistrationDoctorViewModel>();
        services.AddTransient<DoctorViewModel>();
        services.AddTransient<DoctorInfoViewModel>();
        services.AddTransient<PatientsViewModel>();
    }

    private static void SetupAppDbContext(MauiAppBuilder builder)
    {
        var connStr = builder.Configuration
         .GetConnectionString("SqliteConnection");
        string dataDirectory = string.Empty;
#if ANDROID
        dataDirectory = FileSystem.AppDataDirectory + Path.DirectorySeparatorChar;
#else
        dataDirectory = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar;
#endif
        connStr = string.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connStr).Options;

        builder.Services.AddSingleton((s) => new AppDbContext(options));

    }
}
