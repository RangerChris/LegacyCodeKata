using LegacyTest.Console;
using LegacyTest.Security;

namespace LegacyTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new SecurityManager(new RealConsole());
            manager.CreateUser();
        }
    }
}