namespace LegacyTest.Console
{
    public interface IConsole
    {
        void WriteLine(string s);
        void Write(string s);
        string ReadLine();
    }
}