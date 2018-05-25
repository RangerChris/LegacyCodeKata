namespace LegacyTest.Security
{
    public interface IPassword
    {
        bool CheckPassword(string password, string confirmPassword, out string array);

        bool ComparePassword(string password1, string password2);
    }
}