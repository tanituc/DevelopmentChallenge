using DevelopmentChallenge.Data.Classes.Factories;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        string Imprimir(List<FormaFactory> formas, int idioma);
    }
}
