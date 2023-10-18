/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        public CultureInfo Culture { get; private set; }
        #region Formas

        public const int _Cuadrado = 1;
        public const int _TrianguloEquilatero = 2;
        public const int _Circulo = 3;
        public const int _Trapecio = 4;
        public class Output 
        { 
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Total { get; set; }
            public decimal TotalPerimetros { get; set; }
            public decimal TotalAreas { get; set; }
        }
        #endregion

        #region Idiomas
        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        private readonly decimal _lado;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }
        public static string ImprimirV2(List<IForma> formas, int idioma)
        {
            StringBuilder sb = new StringBuilder();
            if (idioma == 2)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
            else throw new Exception();
            if (!formas.Any())
            {
                sb.Append(Messages.EmptyList);
            }
            else
            {
                sb.Append(Messages.Header);

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                formas.ForEach(forma => forma.CalcularPerimetro());
                sb.Append(ObtenerLineaV2(numeroCuadrados, areaCuadrados, perimetroCuadrados, _Cuadrado, idioma));
                sb.Append(ObtenerLineaV2(numeroCirculos, areaCirculos, perimetroCirculos, _Circulo, idioma));
                sb.Append(ObtenerLineaV2(numeroTriangulos, areaTriangulos, perimetroTriangulos, _TrianguloEquilatero, idioma));

                sb.Append(Messages.FooterTitle);
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + Messages.ShapesWord.ToLower() + " ");
                sb.Append(Messages.PerimeterWord + " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append(Messages.AreaWord + " " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }
            return sb.ToString();
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == _Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == _Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == _TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, _Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, _Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, _TrianguloEquilatero, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + Messages.ShapesWord.ToLower() + " ");
                sb.Append(Messages.PerimeterWord + " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append(Messages.AreaWord + " " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLineaV2(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | {Messages.AreaWord} {area:#.##} | {Messages.PerimeterWord} {perimetro:#.##} <br/>";
            }
            return string.Empty;
        }
        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }
        private static string TraducirFormaV2(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case _Cuadrado:
                    return cantidad == 1 ? Messages.SquareName : Messages.SquareNamePlural;
                case _Circulo:
                    return cantidad == 1 ? Messages.CircleName : Messages.CircleNamePlural;
                case _TrianguloEquilatero:
                    return cantidad == 1 ? Messages.TriangleName : Messages.TriangleNamePlural;
            }

            return string.Empty;
        }
        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case _Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case _Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case _TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case _Cuadrado: return _lado * _lado;
                case _Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case _TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case _Cuadrado: return _lado * 4;
                case _Circulo: return (decimal)Math.PI * _lado;
                case _TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
