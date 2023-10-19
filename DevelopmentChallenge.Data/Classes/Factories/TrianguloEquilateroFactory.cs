using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class TrianguloEquilateroFactory : FormaFactory
    {
        private decimal lado;
        public TrianguloEquilateroFactory(decimal lado, int id = 2): base(id)
        {
            this.lado = lado;
        }
        public override IForma CreateForma()
        {
            return new TrianguloEquilatero(lado);
        }
    }
}
