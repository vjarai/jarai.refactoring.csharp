using System.Diagnostics;

namespace Jarai.Refactoring.Telefon.Refactored
{
    public class Abgehoben : Zustand
    {
        public Abgehoben()
            : base("<H�rer ist abgenommen>")
        {
        }

        public override Zustand Auflegen()
        {
            Debug.WriteLine("H�rer wird aufgelegt.");
            return new Aufgelegt();
        }

        public override Zustand W�hlen()
        {
            Debug.WriteLine("Rufnummer wird gew�hlt.");
            return new Verbunden();
        }
    }
}