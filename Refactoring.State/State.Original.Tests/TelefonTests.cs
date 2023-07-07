using System;
using Xunit;

namespace Jarai.Refactoring.State.Original.Tests
{
    public class TelefonTests
    {
        [Fact()]
        public void Kann_abheben_wählen_sprechen_sprechen_auflegen()
        {
            // Arrange
            var telefon = new Telefon();

            // Act
            telefon.Abheben();
            telefon.Wählen();
            telefon.Sprechen();
            telefon.Sprechen();
            telefon.Auflegen();
        }


        [Fact()]
        public void Kann_auflegen_wenn_Verbunden()
        {
            // Arrange
            var telefon = new Telefon();

            // Act
            telefon.AnnehmenAnruf();
            telefon.Auflegen();

        }

        [Fact()]
        public void Kann_auflegen_wenn_Abgehoben()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Abgehoben);

            // Act
            telefon.Auflegen();

        }

        [Fact()]
        public void Kann_NICHT_sprechen_wenn_Abgehoben()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Abgehoben);

            // Act
            
            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Sprechen);
        }


        [Fact()]
        public void Kann_NICHT_wählen_wenn_verbunden()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Verbunden);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Wählen);
        }

        [Fact()]
        public void Kann_NICHT_abheben_wenn_verbunden()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Verbunden);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Abheben);
        }

        [Fact()]
        public void Kann_NICHT_annehmenAnruf_wenn_Verbunden()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Verbunden);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.AnnehmenAnruf);
        }


        [Fact()]
        public void Kann_NICHT_annehmenAnruf_wenn_Abgehoben()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Abgehoben);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.AnnehmenAnruf);
        }

        [Fact()]
        public void Kann_NICHT_wählen_wenn_Aufgelegt()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Aufgelegt);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Wählen);
        }

        [Fact()]
        public void Kann_NICHT_sprechen_wenn_Aufgelegt()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Aufgelegt);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Sprechen);
        }

        [Fact()]
        public void Kann_NICHT_auflegen_wenn_Aufgelegt()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Aufgelegt);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Auflegen);
        }


        [Fact()]
        public void Kann_NICHT_abheben_wenn_Abgehoben()
        {
            // Arrange
            var telefon = new Telefon(TelefonZustand.Abgehoben);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(telefon.Abheben);
        }


    }
}