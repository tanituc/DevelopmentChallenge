using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IForma
    {
        public const int Id = 4;
        private readonly decimal altura;
        private readonly decimal base1;
        private readonly decimal base2;
        public Trapecio(decimal altura, decimal base1, decimal base2)
        {
            this.altura = altura;
            this.base1  = base1;
            this.base2  = base2;
        }
        public decimal CalcularArea()
        {
            return (base1 + base2) * altura / 2.0m;
        }

        public decimal CalcularPerimetro()
        {
            return base1 + base2 + 2 * (decimal)Math.Sqrt((double)(altura * altura + ((base1 - base2) / 2) * ((base1 - base2) / 2)));
        }
    }
}
