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

using DevelopmentChallenge.Data.Classes.Factories;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Toolkit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica : IFormaGeometrica
    {
        ResourceManager _rm = new ResourceManager("DevelopmentChallenge.Data.Messages", typeof(Messages).Assembly);
        CultureInfo _culture = new CultureInfo("es-ES");
        SingletonLists _singleton = SingletonLists.GetInstance();
        private string CultureHelper(string tag) => _rm.GetString(tag, _culture);
        public string Imprimir(List<FormaFactory> formas, int idioma = 1)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                _culture = new CultureInfo(_singleton.languages.FirstOrDefault(l => l.IntId == idioma).Culture);
            }
            catch {
                throw new Exception("Language out of range.");
            }
            if (!formas.Any())
            {
                sb.Append(CultureHelper("EmptyList"));
            }
            else
            {
                sb.Append(CultureHelper("Header"));
                List <OutputDTO> outputs = CalcularTotales(formas);
                foreach (var output in outputs)
                {
                    sb.Append(ObtenerLinea(output.Total, output.TotalAreas, output.TotalPerimetros, output.Id));
                }
                sb.Append(CultureHelper("FooterTitle"));
                sb.Append(outputs.Sum(o => o.Total).ToString() + " " + CultureHelper("ShapesWord").ToLower() + " ");
                sb.Append(CultureHelper("PerimeterWord") + " " + outputs.Sum(o => o.TotalPerimetros).ToString("#.##").Replace('.', ',') + " ");
                sb.Append(CultureHelper("AreaWord") + " " + outputs.Sum(o => o.TotalAreas).ToString("#.##").Replace('.', ','));

            }
            return sb.ToString();
        }

        private List<OutputDTO> CalcularTotales(List<FormaFactory> formas)
        {
            List<OutputDTO> outputs = new List<OutputDTO>();

            foreach (var formaFactory in formas)
            {
                IForma forma = formaFactory.GetForma();
                int id = formaFactory.id;

                if (forma != null)
                {
                    OutputDTO output = outputs.FirstOrDefault(o => o.Id == id);

                    if (output == null)
                    {
                        output = new OutputDTO { Id = id };
                        outputs.Add(output);
                    }

                    output.Total++;
                    output.TotalAreas += forma.CalcularArea();
                    output.TotalPerimetros += forma.CalcularPerimetro();
                }
            }

            return outputs;
        }

        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            return cantidad > 0 
                ? $"{cantidad} {PluralizarForma(tipo, cantidad)} | {CultureHelper("AreaWord")} {area:#.##} | {CultureHelper("PerimeterWord")} {perimetro:#.##} <br/>".Replace('.',',') 
                : string.Empty;
        }
        private string PluralizarForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case Cuadrado.Id:
                    return cantidad == 1 ? CultureHelper("SquareName") : CultureHelper("SquareNamePlural");
                case Circulo.Id:
                    return cantidad == 1 ? CultureHelper("CircleName") : CultureHelper("CircleNamePlural");
                case TrianguloEquilatero.Id:
                    return cantidad == 1 ? CultureHelper("TriangleName") : CultureHelper("TriangleNamePlural");
                case Trapecio.Id:
                    return cantidad == 1 ? CultureHelper("TrapezeName") : CultureHelper("TrapezeNamePlural");
            }

            return string.Empty;
        }
    }
}
