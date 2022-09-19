using System;
using Refactoring3.Backend.Refactored.Handlers;
using Refactoring3.Backend.Refactored.Requests;
using Refactoring3.Backend.Refactored.Responses;
using Xunit;

namespace Refactoring3.Backend.Refactored.Tests
{
    public class BackendServiceTests
    {
        [Fact()]
        public void CanCalculateSum()
        {
            // Arrange
            var request = new CalculateSumRequest { Number1 = 100, Number2 = 200 };
            var target = new BackendService();

            // Act
            var result = (CalculateSumResponse)target.ProcessRequest(request);

            // Assert
            Assert.Equal(300, result.Sum);
        }


        [Fact()]
        public void CanCalculateTax()
        {
            // Arrange
            var request = new CalculateTaxRequest { Price = 100 };
            var target = new BackendService();

            // Act
            var result = (CalculateTaxResponse)target.ProcessRequest(request);

            // Assert
            Assert.Equal(19, result.Tax);
        }

        [Fact()]
        public void ThrowsOnUnhandledRequest()
        {
            // Arrange
            var request = new Request();
            var target = new BackendService();

            // Assert
            Assert.Throws<InvalidOperationException>(() => target.ProcessRequest(request));
        }
    }
}