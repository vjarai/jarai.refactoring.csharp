using System.Diagnostics;

namespace Jarai.Refactoring.Telefon.Refactored
{
    public class Telefon
    {
        private Zustand _aktuellerZustand;

        public Telefon()
        {
            AktuellerZustand = new Aufgelegt();
        }


        internal Telefon(Zustand zustand)
        {
            AktuellerZustand = zustand;
        }

        public Zustand AktuellerZustand
        {
            get
            {
                Debug.WriteLine("\nAktueller Zustand: " + _aktuellerZustand);
                return _aktuellerZustand;
            }
            private set { _aktuellerZustand = value; }
        }

        public void Abheben()
        {
            // Die tatsächlich aufgerufene Methode ist abhängig vom aktuellen Zustand (spätes binden)
            AktuellerZustand = AktuellerZustand.Abheben();
        }

        public void AnnehmenAnruf()
        {
            AktuellerZustand = AktuellerZustand.AnnehmenAnruf();
        }


        public void Auflegen()
        {
            AktuellerZustand = AktuellerZustand.Auflegen();
        }

        public void Sprechen()
        {
            AktuellerZustand = AktuellerZustand.Sprechen();
        }

        public void Wählen()
        {
            AktuellerZustand = AktuellerZustand.Wählen();
        }
    }
}