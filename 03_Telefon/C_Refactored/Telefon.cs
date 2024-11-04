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
            // Die tats�chlich aufgerufene Methode ist abh�ngig vom aktuellen Zustand (sp�tes binden)
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

        public void W�hlen()
        {
            _aktuellerZustand = _aktuellerZustand.W�hlen();
        }
    }
}