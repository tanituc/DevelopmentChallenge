using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public abstract class FormaFactory
    {
        public abstract IForma CreateForma(decimal lado);
        public IForma OrderForma(decimal lado) {
            IForma forma = CreateForma(lado);
            forma.CalcularArea();
            forma.CalcularPerimetro();
            return forma;
        }

    }
}
