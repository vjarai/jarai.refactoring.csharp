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
            // Die tats�chlich aufgerufene Methode ist abh�ngig vom aktuellen Zustand (sp�tes binden)
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

        public void W�hlen()
        {
            AktuellerZustand = AktuellerZustand.W�hlen();
        }
    }
}