using System;

namespace Jarai.Refactoring.State.Original
{
    public class Telefon
    {
        private TelefonZustand _aktuellerZustand;


        public Telefon()
        {

        }

        internal Telefon(TelefonZustand aktuellerZustand)
        {
            _aktuellerZustand = aktuellerZustand;
        }


        public void Abheben()
        {
            switch (_aktuellerZustand)
            {
                case TelefonZustand.Aufgelegt:
                    _aktuellerZustand = TelefonZustand.Abgehoben;
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
            switch (_aktuellerZustand)
            {
                case TelefonZustand.Aufgelegt:
                    _aktuellerZustand = TelefonZustand.Verbunden;
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
            switch (_aktuellerZustand)
            {
                case TelefonZustand.Verbunden:
                case TelefonZustand.Abgehoben:
                    _aktuellerZustand = TelefonZustand.Aufgelegt;
                    break;
                case TelefonZustand.Aufgelegt:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Sprechen()
        {
            switch (_aktuellerZustand)
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
            switch (_aktuellerZustand)
            {
                case TelefonZustand.Abgehoben:
                    _aktuellerZustand = TelefonZustand.Verbunden;
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