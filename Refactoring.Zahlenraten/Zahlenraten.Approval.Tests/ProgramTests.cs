using Xunit;
using Glücksspiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glücksspiel.Tests
{
    public class ProgramTests
    {
        [Fact()]
        public void MainTest()
        {
            // Arrange
            var fakeConsole = new FakeUiService(new[] { "200", "-1", "50", "" });
            Program.Console = fakeConsole;
            Program.Z = 50;

            // Act
            Program.Main(new[] { "" });

            // Assert
            var message = fakeConsole.OutputBuffer.ToArray();
            Assert.Equal("Ihre Zahl ist zu groß", message[1]);
            Assert.Equal("Ihre Zahl ist zu klein", message[3]);
            Assert.Equal("Richtig", message[5]);
            Assert.Equal("du hast2Versuche gebraucht", message[6]);
        }
    }
}