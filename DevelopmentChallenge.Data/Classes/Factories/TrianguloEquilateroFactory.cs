using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class TrianguloEquilateroFactory : FormaFactory
    {
        public override IForma CreateForma(decimal lado)
        {
            return new TrianguloEquilatero(lado);
        }
    }
}
