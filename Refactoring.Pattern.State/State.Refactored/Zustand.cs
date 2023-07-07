using System;

namespace Jarai.Refactoring.State.Refactored
{
    public abstract class Zustand
    {
        protected Zustand(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
        }

        public string Bezeichnung { get; }

        public virtual Zustand Abheben()
        {
            throw new InvalidOperationException("Sie k�nnen derzeit den H�rer nicht abheben.");
        }

        public virtual Zustand AnnehmenAnruf()
        {
            throw new InvalidOperationException("Sie k�nnen derzeit keinen Anruf annehmen.");
        }

        public virtual Zustand Auflegen()
        {
            throw new InvalidOperationException("Sie k�nnen derzeit den H�rer nicht auflegen.");
        }

        public virtual Zustand Sprechen()
        {
            throw new InvalidOperationException("Sie k�nnen derzeit nicht sprechen.");
        }


        public override string ToString()
        {
            return Bezeichnung;
        }

        public virtual Zustand W�hlen()
        {
            throw new InvalidOperationException("Sie k�nnen derzeit keine Nummer w�hlen.");
        }
    }
}