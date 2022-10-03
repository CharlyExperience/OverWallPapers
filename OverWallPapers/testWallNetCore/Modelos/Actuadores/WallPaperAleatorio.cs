using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Modelos.Actuadores
{
    internal class WallPaperAleatorio:IComportamiento
    {
        public IComportamiento Comportamiento { set; get; }

        public List<WallPaperSet> WallPapers { get; set; }
        public void Actuar(object Estimulo)
        {
            //seleccionar un fondo aleatorio para aplicar 
            int seleccion= new Random().Next(0, WallPapers.Count());

            //aplicar el fondo seleccionado
            WallPaperApi.AplicarSet(WallPapers[seleccion], WallPaperApi.ListaDeMonitoresActuales());
        }

    }
}
