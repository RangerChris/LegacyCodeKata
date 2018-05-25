using LegacyTest.Console;
using LegacyTest.Security;
using Moq;
using Xunit;

namespace LegacyUnitTests
{
    public class PasswordCheckerTests
    {
        private const string P1 = "longpassword";
        private const string P2 = "longpassword2";

        [Fact]
        public void TestMockedPasswordCompare()
        {
            // Arrange
            var sut = new Mock<IPassword>();
            sut.Setup(r => r.ComparePassword(P1, P1)).Returns(true);

            // Act
            var result = sut.Object.ComparePassword(P1, P1);

            // Assert
            Assert.True(result);
            sut.Verify(c => c.ComparePassword(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void TestPasswordCompare()
        {
            var checker = new PasswordChecker(new Mock<IConsole>().Object);
            var result = checker.ComparePassword(P1, P1);
            Assert.True(result);

            result = checker.ComparePassword("2233435", "2");
            Assert.False(result);
        }

        [Fact]
        public void TestPasswordCompareNoMatch()
        {
            var checker = new PasswordChecker(new Mock<IConsole>().Object);
            var result = checker.CheckPassword(P1, P2, out _);
            Assert.False(result);
        }

        [Fact]
        public void TestPasswordTooShortValidation()
        {
            var checker = new PasswordChecker(new Mock<IConsole>().Object);
            var isValid = checker.CheckPassword("short", "short", out _);
            Assert.False(isValid);
        }

        [Fact]
        public void TestPasswordValidation()
        {
            var checker = new PasswordChecker(new Mock<IConsole>().Object);
            var isValid = checker.CheckPassword(P2, P2, out var myPassword);
            Assert.True(isValid);
            Assert.Equal("gfHBWzLIsM3JeoVSJtVflw==", myPassword);

            isValid = checker.ComparePassword("rtHjiKmfreDswVV", "SeffhdfuiDfrgrg");
            Assert.False(isValid);
        }
    }
}