using LegacyTest.Console;
using Moq;
using Xunit;

namespace LegacyUnitTests
{
    public class ConsoleTests
    {
        [Fact]
        public void WriteToMockedRealConsole()
        {
            var sut = new Mock<IConsole>();
            sut.Setup(r => r.Write(It.IsAny<string>()));
            Assert.NotNull(sut);

            sut.Object.Write("Here is a simple text");
            sut.Verify(c => c.Write(It.IsAny<string>()), Times.Once());

            sut.Object.WriteLine("Here is another with a linebreak");
            sut.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void WriteToRealConsole()
        {
            IConsole sut = new RealConsole();
            sut.Write("Here is a simple text");
            sut.WriteLine("Here is another with a linebreak");
        }

        [Fact]
        public void ReadFromConsole()
        {
            // Note that because we mock the readline method, the coverage does not count
            var sut = new Mock<IConsole>();
            sut.Setup(r => r.ReadLine()).Returns(It.IsAny<string>());

            sut.Object.ReadLine();
            sut.Verify(c => c.ReadLine(), Times.Once());
        }
    }
}
