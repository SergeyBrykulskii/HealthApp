using ConsoleApp.ConsoleMenu;
using ConsoleApp.Helpers;
using HealthApp.Application.Abstractions.ConsoleApp;
using HealthApp.Application.Services.ConsoleApp;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Persistence.Data;
using HealthApp.Persistence.FakeUnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;
Menu menu;

try
{
    menu = services.GetRequiredService<Menu>();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<Menu>();
            services.AddSingleton<IFakeDbContext, FakeDbContext>();
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<IDoctorService, DoctorService>();
            services.AddSingleton<IPatientService, PatientService>();
        });
}

(string Status, string Email, int Id) currUser = ("", "Def", -1);
while (true)
{
    LogIn();
}
void LogIn()
{
    while (true)
    {
        string email = string.Empty;
        string password = string.Empty;

        Console.WriteLine("To sign up press 1\nTo log in press 2\nTo exit press e");
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("If you are doctor press \"d\"\nIf you are patient press any other key");
            var typeOfUser = Console.ReadLine();

            Console.Write("Enter email:  ");
            email = Console.ReadLine();

            password = PasswordController.GetPassword("Enter password");

            while (true)
            {
                string passwordCopy = PasswordController.GetPassword("Confirm password");
                if (password != passwordCopy)
                {
                    Console.WriteLine("Password mismatch!");
                    continue;
                }
                break;
            }

            if (typeOfUser == "d")
            {
                if (menu.IsDoctorExists(u => u.Email == MyHasher.GetHash(email)))
                {
                    Console.WriteLine("User already exists!");
                    continue;
                }

                Doctor user = new(MyHasher.GetHash(password), MyHasher.GetHash(email));
                menu.AddDoctor(user);
                currUser.Status = "d";
                currUser.Email = email;
                currUser.Id = user.Id;
            }
            else
            {
                if (menu.IsDoctorExists(u => u.Email == MyHasher.GetHash(email)))
                {
                    Console.WriteLine("User already exists!");
                    continue;
                }

                Patient user = new(MyHasher.GetHash(password), MyHasher.GetHash(email));
                menu.AddPatient(user);
                currUser.Status = "p";
                currUser.Email = email;
                currUser.Id = user.Id;
            }
            break;
        }
        else if (choice == "2")
        {
            Console.WriteLine("If you are doctor press \"d\"\nIf you are patient press any other key");
            var typeOfUser = Console.ReadLine();

            Console.Write("Enter email:  ");
            email = Console.ReadLine();

            password = PasswordController.GetPassword("Enter password");
            if (typeOfUser == "d")
            {
                if (!menu.IsDoctorExists(u => u.Email == MyHasher.GetHash(email)
                                      && u.Password == MyHasher.GetHash(password)))
                {
                    Console.WriteLine("Invalid email or password");
                    continue;
                }
                currUser.Status = "d";
                currUser.Id = menu.GetDoctorId(u => u.Email == MyHasher.GetHash(email));
            }
            else
            {
                if (!menu.IsPatientExists(u => u.Email == MyHasher.GetHash(email)
                                      && u.Password == MyHasher.GetHash(password)))
                {
                    Console.WriteLine("Invalid email or password");
                    continue;
                }

                currUser.Status = "p";
                currUser.Id = menu.GetPatientId(u => u.Email == MyHasher.GetHash(email));
            }

            currUser.Email = email;
            break;
        }
        else if (choice == "exit" || choice == "e")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Please enter correct coьmand\nTo sign up press 1\nTo log in press\nTo exit press e\n");
        }
    }
}