using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Modelos
{
    public interface IComportamiento
    {
        IComportamiento Comportamiento { set; get;} 
        public void Actuar(object Estimulo);

    }
}
