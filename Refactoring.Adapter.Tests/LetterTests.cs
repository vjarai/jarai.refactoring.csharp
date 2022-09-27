using Xunit;
using Jarai.Refactoring.Adapter.Original;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Jarai.Refactoring.Adapter.Original.Tests
{
    public class LetterTests
    {
        [Fact()]
        public void SendTo_calls_printer_print_method()
        {
            // Arrange
            var text = "Hallo welt!";
            var target = new Letter(text);
            var printerMock = new Mock<Printer>();
            printerMock.Setup(p => p.Print(text));

            // Act
            target.SendTo(printerMock.Object);
            
            // Assert
            printerMock.VerifyAll();
        }
    }
}