using LegacyTest.Console;
using LegacyTest.Security;
using Moq;
using Xunit;

namespace LegacyUnitTests
{
    public class EncryptionTests
    {
        [Fact]
        public void TestPasswordEncryption()
        {
            var password = "kresten-elleby";
            var checker = new PasswordChecker(new Mock<IConsole>().Object);
            var encryptedPassword = checker.EncryptPassword(password);
            Assert.Equal("0zdZaCXmM7Bodtdc0Bs6VA==", encryptedPassword);

            var decryptedPassword = checker.DecryptPassword(encryptedPassword);
            Assert.Equal(password, decryptedPassword);
        }
    }
}
