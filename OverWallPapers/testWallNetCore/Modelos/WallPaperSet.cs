using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverWallPapers.Modelos
{
    /// <summary>
    /// esta clase esta pensada para ser un elemento que describira una configuracion  de fondo de pantalla
    /// </summary>
    public class WallPaperSet
    {
        public Int64? Id;
        public string Nombre { get; set; }
        public List<WallPaper> Monitores { set; get; }

        public DesktopWallpaperPosition Posicion { set; get; }

        public WallPaperSet()
        {
            Id = 0;
            Nombre = null;
            Monitores = new List<WallPaper>();
        }
        public WallPaperSet(string nombre, TimeSpan horaAplicacion, List<WallPaper>fondosDePantalla, DesktopWallpaperPosition posicion)
        {
            Nombre = nombre;
            Monitores=fondosDePantalla;
            Posicion = posicion;
        }
    }

    public class WallPaper
    {
        public int Monitor { set; get; }
        public string FondoDePantalla { set; get; }

        public WallPaper()
        {
            Monitor = 0;
            FondoDePantalla = null;
        }
        public WallPaper(int pantallaAsignada,string ruta)
        {
            Monitor = pantallaAsignada;
            FondoDePantalla = ruta;
        }
    }
}
