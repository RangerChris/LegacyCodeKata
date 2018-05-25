using LegacyTest.Console;

namespace LegacyTest.Security
{
    // http://www.devjoy.com/2013/01/legacy-code-katas/
    public class SecurityManager
    {
        private readonly IPassword checker;
        private readonly IConsole console;

        public SecurityManager(IConsole consoleInput)
        {
            console = consoleInput;
            checker = new PasswordChecker(console);
        }

        public void CreateUser()
        {
            console.WriteLine("Enter a username");
            var username = console.ReadLine();
            console.WriteLine("Enter your full name");
            var fullName = console.ReadLine();
            console.WriteLine("Enter your password");
            var password = console.ReadLine();
            console.WriteLine("Re-enter your password");
            var confirmPassword = console.ReadLine();

            if (checker.CheckPassword(password, confirmPassword, out var array))
            {
                console.WriteLine($"Saving Details for User ({username}, {fullName}, {array})");
            }

            console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}