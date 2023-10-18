using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return (decimal)Math.PI * lado;
        }
    }
}
