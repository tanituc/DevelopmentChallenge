using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IForma
    {
        public const int Id = 3;
        private readonly decimal radio;
        public Circulo(decimal radio)
        {
            this.radio = radio;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (radio / 2) * (radio / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * radio;
        }
    }
}
