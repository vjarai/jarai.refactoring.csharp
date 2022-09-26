using Moq;
using Xunit;

namespace Jarai.Refactoring.Zahlenraten.Refactored.Tests
{
    public class ZahlenratenGameTests
    {
        [Fact()]
        public void Can_handle_to_small_input()
        {
            // Arrange
            var uiMock = new Mock<IUiService>();
            uiMock.Setup(m => m.WriteInputToSmall());

            var target = new ZahlenratenGame(uiMock.Object, 50);

            // Act
            target.ProzessInput(-1);

            // Assert
            uiMock.VerifyAll();
        }

        [Fact()]
        public void Can_handle_to_big_input()
        {
            // Arrange
            var uiMock = new Mock<IUiService>();
            uiMock.Setup(m => m.WriteInputToBig());

            var target = new ZahlenratenGame(uiMock.Object, 50);

            // Act
            target.ProzessInput(100);

            // Assert
            uiMock.VerifyAll();
        }



        [Fact()]
        public void Can_handle_correct_input()
        {
            // Arrange
            var uiMock = new Mock<IUiService>();
            uiMock.Setup(m => m.WriteInputCorrect());

            var target = new ZahlenratenGame(uiMock.Object, 50);

            // Act
            target.ProzessInput(50);

            // Assert
            uiMock.VerifyAll();
        }
    }
}