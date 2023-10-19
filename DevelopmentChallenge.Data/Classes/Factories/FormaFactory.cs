using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public abstract class FormaFactory : IFormaFactory
    {
        public int id;
        public FormaFactory(int id)
        {
            this.id = id;
        }
        public abstract IForma CreateForma();
        public IForma GetForma() {
            IForma forma = CreateForma();
            forma.CalcularArea();
            forma.CalcularPerimetro();
            return forma;
        }

    }
}
