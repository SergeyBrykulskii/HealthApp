﻿using ConsoleApp.ConsoleMenu;
using HealthApp.Application.Abstractions.ConsoleApp;
using HealthApp.Application.Services.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<Menu>();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<IDoctorService, DoctorService>();
            services.AddSingleton<IPatientService, PatientService>();
        });
}