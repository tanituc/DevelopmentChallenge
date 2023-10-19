using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class TrapecioFactory : FormaFactory
    {
        private decimal altura;
        private decimal base1;
        private decimal base2;
        public TrapecioFactory(decimal altura, decimal base1, decimal base2, int id = 4) : base(id)
        {
            this.altura = altura;
            this.base1 = base1;
            this.base2 = base2;
        }
        public override IForma CreateForma()
        {
            return new Trapecio(altura, base1, base2);
        }                               
    }                                   
}                                       
