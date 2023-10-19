using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Factories;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Toolkit;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private IFormaGeometrica _formaGeometrica = new FormaGeometrica();
        private SingletonLists _singleton = SingletonLists.GetInstance();
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                _formaGeometrica.Imprimir(new List<FormaFactory>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                _formaGeometrica.Imprimir(new List<FormaFactory>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaFactory> { new CuadradoFactory(5) };

            var resumen = _formaGeometrica.Imprimir(cuadrados, _singleton.languages.First(l => l.Value == "Castellano").IntId);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var trapecios = new List<FormaFactory> { new TrapecioFactory(5,5,7.5m) };

            var resumen = _formaGeometrica.Imprimir(trapecios, _singleton.languages.First(l => l.Value == "Castellano").IntId);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 31,25 | Perimetro 22,81 <br/>TOTAL:<br/>1 formas Perimetro 22,81 Area 31,25", resumen);
        }
        [TestCase]
        public void TestResumenListaConMasTrapecios()
        {
            var trapecios = new List<FormaFactory> { 
                new TrapecioFactory(5, 5, 7.5m),
                new TrapecioFactory(5, 3, 10m),
                new TrapecioFactory(10, 5, 7.5m)
            };

            var resumen = _formaGeometrica.Imprimir(trapecios, _singleton.languages.First(l => l.Value == "Castellano").IntId);

            Assert.AreEqual("<h1>Reporte de Formas</h1>3 Trapecios | Area 126,25 | Perimetro 80,67 <br/>TOTAL:<br/>3 formas Perimetro 80,67 Area 126,25", resumen);
        }
        
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaFactory>
            {
                new CuadradoFactory(5),
                new CuadradoFactory(1),
                new CuadradoFactory(3)
            };

            var resumen = _formaGeometrica.Imprimir(cuadrados, _singleton.languages.First(l => l.Value == "Ingles").IntId);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaFactory>
            {
                new CuadradoFactory(5),
                new CirculoFactory(3),
                new TrianguloEquilateroFactory(4),
                new CuadradoFactory(2),
                new TrianguloEquilateroFactory(9),
                new CirculoFactory(2.75m),
                new TrianguloEquilateroFactory(4.2m)
            };

            var resumen = _formaGeometrica.Imprimir(formas, _singleton.languages.First(l => l.Value == "Ingles").IntId);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaFactory>
            {
                new CuadradoFactory(5),
                new CirculoFactory(3),
                new TrianguloEquilateroFactory(4),
                new CuadradoFactory(2),
                new TrianguloEquilateroFactory(9),
                new CirculoFactory(2.75m),
                new TrianguloEquilateroFactory(4.2m)
            };

            var resumen = _formaGeometrica.Imprimir(formas, _singleton.languages.First(l => l.Value == "Castellano").IntId);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaFactory>
            {
                new CuadradoFactory(5),
                new CirculoFactory(3),
                new TrianguloEquilateroFactory(4),
                new CuadradoFactory(2),
                new TrianguloEquilateroFactory(9),
                new CirculoFactory(2.75m),
                new TrianguloEquilateroFactory(4.2m)
            };

            var resumen = _formaGeometrica.Imprimir(formas, _singleton.languages.First(l => l.Value == "Italiano").IntId);

            Assert.AreEqual(
                "<h1>Report di forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
