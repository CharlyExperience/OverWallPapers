using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWallNetCore.Modelos.Condiciones
{
    internal class Horario:IComportamiento
    {
        public IComportamiento Comportamiento { set; get; }

        List<Instante> Instantes;
        public Horario(List<Instante> instantes, IComportamiento comp)
        {
            //ordenar arreglo de momentos del mas temprano al mas tardio
            Instantes = OrdenarOrarios(instantes);

            Comportamiento = comp;

        }

        //implementando la interfaz de condicion
        public void Actuar(object Estimulo)
        {
            //evaluar si alguno de los momentos coincide con el momento actual del sistema
                //obtener el momento del dia
            DateTime fecha=DateTime.Now;
                //generar el momento del dia 
            TimeOnly ahora = new TimeOnly(ahora.Hour,ahora.Minute);

            //evaluar en cual de los instantes debe estar actuando, para definir esto busca el momento mas cercano que
            //lo revase y se asigna el instante previo

            int? posicionValida = null;
            for(int i=0;i<Instantes.Count;i++)
            {
                //evaluar si el momento real en el que esta transcurriendo esto, es previo al momento actual del arreglo
                // de ser asi se aplica la posicion anterior del arreglo
                if(EsPrevio(Instantes[i].Tiempo,ahora))
                {
                    //de ser previo devolver la posicion anterior a la actual 
                    posicionValida = i == 0 ? Instantes.Count - 1 : i - 1;

                    break;
                }
            }

            //una vez definida la posicion del arreglo se debe llamar el comportamiento
            if(posicionValida ==null )
            {
                throw new Exception("instante actual no definido");
            }
            Instantes[(int) posicionValida].Comportamiento.Actuar(null);

            return;
        }

        /// <summary>
        /// se encarga de organizar una lista de instantes de la mas temprana a la mas tardia
        /// </summary>
        /// <param name="instantes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private List<Instante> OrdenarOrarios( List<Instante> instantes)
        {
            List<Instante> ordenados = new List<Instante>();

            //si la lista de instantes viene vacia solo regresa el vacio
            if (instantes == null || instantes.Count==0)
            {
                return ordenados;
            }

            //se agrega el primer elemento a la lista 
            ordenados.Add(Instantes[0]);
            for(int J = 1; J < instantes.Count; J++)
            {
                
                
                for (int i = 0; i < ordenados.Count; i++)
                {
                    //si el elemento entrante es mas temprano que el actual lo agrega una posicion antes
                    if (instantes[J].Tiempo.Hour < ordenados[i].Tiempo.Hour)
                    {
                        ordenados.Insert(i, instantes[J]);
                        break;
                    }

                    // de lo contrario se debe revisar si las horas son las mismas para ordenarlos por los minutos
                    if(instantes[J].Tiempo.Hour == ordenados[i].Tiempo.Hour)
                    {
                        //si los minutos son iguales lanzara una excepcion no puede existir un horario con elmismo momento
                        if (instantes[J].Tiempo.Minute == ordenados[i].Tiempo.Minute)
                            throw new Exception("no pueden existir instantes repetidos!" + ordenados[i].ToString());

                        // si en cuestion de minutos es mas temprano el entrante se inserta de lo contrario se deja 
                        //pasar para la siguiente iteracion
                        if(instantes[J].Tiempo.Minute < ordenados[i].Tiempo.Minute)
                        {
                            ordenados.Insert(i, instantes[J]);
                            break;
                        }
                            
                    }

                    //si las validaciones previas no aplican quiere decir que el instante entrante es mas tarde y no debe ser insertado
                    //antes que este

                }

                //si al final del arreglo la longitud de los ordenados es igual a al contador J 
                //quiere decir que no se inserto en ninguna posicion antes por lo que se trata de el instante mas tardio hasta ahora,
                //y debe insertarse al final
                if (ordenados.Count == J)
                    ordenados.Add(instantes[J]);
            }

            //una vez ordenados se regresa la lista
            return ordenados;
        }
        
        /// <summary>
        /// evalua si un momento es previo a otro haha
        /// </summary>
        /// <param name="original"></param>
        /// <param name="comparar"></param>
        /// <returns></returns>
        public bool EsPrevio(TimeOnly original, TimeOnly comparar)
        {
            //cero es no / uno es si y 2 es igualdad
            int resp = 0;

            //si el elemento entrante es mas temprano que el actual lo agrega una posicion antes
            if (original.Hour > comparar.Hour ||(original.Hour == comparar.Hour && original.Minute > comparar.Minute))
            {
                return true;
            }

            // de lo contrario es igual o tardio
            return false;
 
        }
    }

    public class Instante
    {
        public TimeOnly Tiempo;

        public IComportamiento Comportamiento { set; get; }

    }
}
