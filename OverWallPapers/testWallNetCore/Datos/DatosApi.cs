using Newtonsoft.Json;
using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Datos
{
    internal class DatosApi
    {

        public static List<WallPaperSet> RecuperarSets()
        {
            try
            {
                //removido por incapacidad de crear un puto app.settings
                //string ruta = ConfigurationManager.AppSettings.Get("sets");

                string json = File.ReadAllText(@"C:\Users\Charly\Desktop\Sets.json");

                List<WallPaperSet> sets = JsonConvert.DeserializeObject<List<WallPaperSet>>(json);

                return sets;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static void EscribirSets(List<WallPaperSet> sets)
        {
            try
            {
                string ruta = (string)ConfigurationManager.GetSection("rutas:sets");

                string json = JsonConvert.SerializeObject(sets);

                
                File.WriteAllText(ruta,json);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //configuracion de monitores
        /// <summary>
        /// devuelve la configuracion que encaja con las id de los monitores conectados actualmente
        /// </summary>
        /// <returns></returns>
        public static List<string> ObtenerConfiguracionMonitores(List<string> monitores)
        {
            List<string>configRes = new List<string>();

            //obtener las ids de los monitores

            //obtener las listas
            string json = File.ReadAllText("ConfiguracionMonitores.json");

            List<List<string>> configuraciones = JsonConvert.DeserializeObject<List<List<string>>>(json);

            List<string> monitoresTemp = monitores;

            //recorrer las configuraciones
            foreach ( List<string> config in configuraciones)
            {
                List<string> tempConfig = config;

                //recorrer cada elemento de la config
                foreach (string id in config)
                {
                    //recorrer los monitores actuales
                    foreach (string monitor in monitoresTemp)
                    {
                        //si coincide se elimina de los temp
                        if (id.Equals(monitor))
                        {
                            monitoresTemp.Remove(monitor);
                        }
                    }
                    
                }

                //validar si todos los monitores actuales coincidieron
                if(monitoresTemp.Count==0)
                {
                    return config;
                }
                else
                {
                    //si no se asigna otra vez la lista de monitores 
                    monitoresTemp = monitores;
                }
            }

            //si al final de la lista de configuraciones no existe una coincidencia entonces 
            //entonces se devuelve el orden que dicta windows por defecto
            

            return monitores;

        }
    }
}
