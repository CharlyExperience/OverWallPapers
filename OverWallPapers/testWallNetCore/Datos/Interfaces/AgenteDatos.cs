using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Datos.Interfaces
{
    public interface IAgenteDatos
    {
        public long? GuardarSet(WallPaperSet set);

        public List<WallPaperSet> ConsultarSets();

        public WallPaperSet ConsultarSet(long id);

        public bool EliminarSet(long id);
    }
}
