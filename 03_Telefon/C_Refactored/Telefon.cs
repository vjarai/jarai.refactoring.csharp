using System.Diagnostics;

namespace Jarai.Refactoring.Telefon.Refactored
{
    public class Telefon
    {
        private Zustand _aktuellerZustand;

        public Telefon()
        {
            _aktuellerZustand = new Aufgelegt();
        }


        internal Telefon(Zustand zustand)
        {
            _aktuellerZustand = zustand;
        }

        

        public void Abheben()
        {
            // Die tatsächlich aufgerufene Methode ist abhängig vom aktuellen Zustand (spätes binden)
            _aktuellerZustand = _aktuellerZustand.Abheben();
        }

        public void AnnehmenAnruf()
        {
            _aktuellerZustand = _aktuellerZustand.AnnehmenAnruf();
        }


        public void Auflegen()
        {
            _aktuellerZustand = _aktuellerZustand.Auflegen();
        }

        public void Sprechen()
        {
            _aktuellerZustand = _aktuellerZustand.Sprechen();
        }

        public void Wählen()
        {
            _aktuellerZustand = _aktuellerZustand.Wählen();
        }
    }
}