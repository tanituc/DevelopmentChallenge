using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IForma
    {
        public const int Id = 4;
        private readonly decimal lado;
        public Trapecio(decimal lado)
        {
            this.lado = lado;
        }
        public decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }
    }
}
