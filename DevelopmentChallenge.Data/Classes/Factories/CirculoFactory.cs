using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class CirculoFactory : FormaFactory, IFormaFactory
    {
        private decimal radio;
        public CirculoFactory(decimal radio, int id = 3) : base(id)
        {
            this.radio = radio;
        }
        public override IForma CreateForma()
        {
            return new Circulo(radio);
        }
    }
}
