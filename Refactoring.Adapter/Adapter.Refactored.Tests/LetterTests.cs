﻿using Moq;
using Xunit;

namespace Jarai.Refactoring.Adapter.Refactored.Tests
{
    public class LetterTests
    {
        [Fact]
        public void SendTo_calls_printers_print_method()
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

        [Fact]
        public void SendTo_calls_pdfcreators_createPdf_method()
        {
            // Arrange
            var text = "Hallo welt!";
            var target = new Letter(text);

            var pdfCreatorMock = new Mock<PdfCreator>();
            pdfCreatorMock.Setup(pdfCreator => pdfCreator.CreatePdfFile(text));
            var pdfAdapter = new PdfCreatorToPrinterAdapter(pdfCreatorMock.Object);
            // Act
            target.SendTo(pdfAdapter);

            // Assert
            pdfCreatorMock.VerifyAll();
        }
    }
}