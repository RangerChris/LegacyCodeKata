using LegacyTest.Console;
using LegacyTest.Encryption;

namespace LegacyTest.Security
{
    public class PasswordChecker : IPassword
    {
        private readonly IConsole console;
        private readonly string secretKey = "BAECAwQFBgcICqoLDA4ODw==";

        public PasswordChecker(IConsole consoleInput)
        {
            console = consoleInput;
        }

        public bool CheckPassword(string password, string confirmPassword, out string array)
        {
            array = "";
            if (!ComparePassword(password, confirmPassword))
            {
                console.WriteLine("The passwords don't match");
                return false;
            }

            if (password.Length < 8)
            {
                console.WriteLine("Password must be at least 8 characters in length");
                return false;
            }

            array = EncryptionHelper.Encrypt(password, secretKey);
            return true;
        }

        public bool ComparePassword(string password1, string password2)
        {
            if (password1 != password2)
                return false;

            return true;
        }

        public string EncryptPassword(string input)
        {
            var result = EncryptionHelper.Encrypt(input, secretKey);
            return result;
        }

        public string DecryptPassword(string input)
        {
            var result = EncryptionHelper.Decrypt(input, secretKey);
            return result;
        }
    }
}