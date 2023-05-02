using System.Text;

namespace ConsoleApp.Helpers;

public static class PasswordController
{
    public static string GetPassword(string message)
    {
        ConsoleKey key;
        StringBuilder password = new();
        while (true)
        {
            Console.Write($"{message}: ");
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password.Remove(password.Length - 1, 1);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password.Append(keyInfo.KeyChar);
                }
            } while (key != ConsoleKey.Enter);
            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long!");
                password.Clear();
                continue;
            }
            Console.WriteLine();
            break;
        }
        return password.ToString();
    }
}
