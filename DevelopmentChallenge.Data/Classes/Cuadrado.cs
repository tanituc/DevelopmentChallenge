using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : IForma
    {
        public const int Id = 1;
        private readonly decimal lado;
        public Cuadrado(decimal lado)
        {
            this.lado = lado;
        }
        public decimal CalcularArea()
        {
            return lado * lado;
        }

        public decimal CalcularPerimetro()
        {
            return 4 * lado;
        }
    }
}
