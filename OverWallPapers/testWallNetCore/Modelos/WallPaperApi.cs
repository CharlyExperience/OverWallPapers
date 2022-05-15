using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Modelos
{
    /// <summary>
    ///  esta clase se encarga de funcionar como intermediario entre los metodos crudos del administrador 
    ///  de wall papers y las operaciones nesesarias para hacer uso de los sets de wall papers
    /// </summary>
    internal class WallPaperApi
    {
        /// <summary>
        /// Enlista los monitores conectados a la computadora actual en el orden que windows los tiene de izquierda a derecha
        /// </summary>
        /// <returns></returns>
        public static List<string> ListaDeMonitoresActuales()
        {
            //crear la instancia del administrador
            //como tener la lista de id de los monitores 
            IDesktopWallpaper Wallpaper;

            Wallpaper = (IDesktopWallpaper)new DesktopWallpaper();
            uint x = Wallpaper.GetMonitorDevicePathCount();
            List<string> IdMonitores = new List<string>();
            List<PosicionMonitor> PosicionesMonitor = new List<PosicionMonitor>();
            for (uint i = 0; i < x; i++)
            {
                string id =Wallpaper.GetMonitorDevicePathAt(i);
                PosicionesMonitor.Add(new PosicionMonitor(id, Wallpaper.GetMonitorRECT(id)));
                
            }

            //reordenar el arreglo de monitores segun la posicion en windows
            List<PosicionMonitor> Ordenados = new List<PosicionMonitor>();
            Ordenados.Add(PosicionesMonitor[0]);
            //recorrer los monitores crudos a partir de la segunda posicion
            for(int i = 1; i < PosicionesMonitor.Count; i++)
            {
                //recorrer los elementos de los ordenados buscando el mayor
                //variable para controlar la adicion
                bool adicion = false;
                for (int j = 0; j < Ordenados.Count; j++)
                {
                    //el monitor entrante esta mas a la izquierda que el que esta acualmente en el orden se inserta antes de este
                    if(PosicionesMonitor[i].Rect.Left<Ordenados[j].Rect.Left)
                    {
                        Ordenados.Insert(j,PosicionesMonitor[i]);
                        adicion = true;
                        break;
                    }
                    
                }

                if(!adicion)
                {
                    Ordenados.Add(PosicionesMonitor[i]);
                }
            }

            //despues de ordenarlos se pasan solo las id a un arreglo 
            foreach (PosicionMonitor pos in Ordenados)
            {
                IdMonitores.Add(pos.Id);
            }
            return IdMonitores;
        }

        public static void AplicarSet(WallPaperSet set, List<string> configMonitores)
        {
            try
            {
                //crear la instancia del manager
                IDesktopWallpaper Wallpaper;
                Wallpaper = (IDesktopWallpaper)new DesktopWallpaper();

 
                //recorrer la lista de monitores para aplicar el wall
                for(int i=0;i<set.Monitores.Count;i++)
                {
                    //cambiar el fondo de pantalla
                    Wallpaper.SetWallpaper(configMonitores[i],set.Monitores[(int)i].FondoDePantalla);

                    //configurar el estilo
                    Wallpaper.SetPosition(set.Posicion);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
    public class PosicionMonitor
    {
        public string Id;
        public Rect Rect;

        public PosicionMonitor(string id, Rect rect)
        {
            Id = id;
            Rect = rect;
        }
    }
}
