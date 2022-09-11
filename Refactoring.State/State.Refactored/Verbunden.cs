using System.Diagnostics;

namespace Jarai.Refactoring.State.Refactored
{
    public class Verbunden : Zustand
    {
        public Verbunden()
            : base("<Verbindung ist hergestellt>")
        {
        }

        public override Zustand Auflegen()
        {
            Debug.WriteLine("H�rer wird aufgelegt.");
            return new Aufgelegt();
        }

        public override Zustand Sprechen()
        {
            Debug.WriteLine("Es wird gesprochen.");
            return this;
        }
    }
}