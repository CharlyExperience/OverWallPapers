using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Modelos
{
    internal class Perfil
    {
        public string Nombre { set; get; }

        /// <summary>
        /// la condicion define los intervalos de tiempo o las condiciones en las que se dispararan las acciones a realizar por el perfil
        /// </summary>
        public object Condicion { get; set; }

        /// <summary>
        /// define las acciones a realizar una vez que se ha cumplido una de las condiciones que definen el perfil
        /// </summary>
        public object Comportamiento { get; set; }

    }
}


