using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    internal class TrianguloEquilatero : IForma
    {
        public const int Id = 2;
        private readonly decimal lado;
        public TrianguloEquilatero(decimal lado)
        {
            this.lado = lado;
        }
        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * lado * lado;
        }

        public decimal CalcularPerimetro()
        {
            return lado * 3;
        }
    }
}
