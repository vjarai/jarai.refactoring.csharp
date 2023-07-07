using System;

namespace Jarai.Refactoring.Telefon.Exercise
{
    public class Telefon
    {
        private TelefonZustand AktuellerZustand { get; set; }


        public Telefon()
        {

        }

        /// <summary>
        /// Konstruktor nur für Tests
        /// </summary>
        internal Telefon(TelefonZustand aktuellerZustand)
        {
            AktuellerZustand = aktuellerZustand;
        }


        public void Abheben()
        {
            switch (AktuellerZustand)
            {
                case TelefonZustand.Aufgelegt:
                    AktuellerZustand = TelefonZustand.Abgehoben;
                    break;
                case TelefonZustand.Abgehoben:
                case TelefonZustand.Verbunden:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void AnnehmenAnruf()
        {
            switch (AktuellerZustand)
            {
                case TelefonZustand.Aufgelegt:
                    AktuellerZustand = TelefonZustand.Verbunden;
                    break;
                case TelefonZustand.Abgehoben:
                case TelefonZustand.Verbunden:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public void Auflegen()
        {
            switch (AktuellerZustand)
            {
                case TelefonZustand.Verbunden:
                case TelefonZustand.Abgehoben:
                    AktuellerZustand = TelefonZustand.Aufgelegt;
                    break;
                case TelefonZustand.Aufgelegt:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Sprechen()
        {
            switch (AktuellerZustand)
            {
                case TelefonZustand.Abgehoben:
                case TelefonZustand.Aufgelegt:
                    throw new InvalidOperationException();
                case TelefonZustand.Verbunden:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Wählen()
        {
            switch (AktuellerZustand)
            {
                case TelefonZustand.Abgehoben:
                    AktuellerZustand = TelefonZustand.Verbunden;
                    break;

                case TelefonZustand.Aufgelegt:
                case TelefonZustand.Verbunden:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}