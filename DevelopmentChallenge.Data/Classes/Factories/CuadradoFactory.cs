using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class CuadradoFactory : FormaFactory
    {
        private decimal lado;
        public CuadradoFactory(decimal lado, int id = 1): base(id)
        {
            this.lado = lado;
        }
        public override IForma CreateForma()
        {
            return new Cuadrado(this.lado);
        }
    }
}
