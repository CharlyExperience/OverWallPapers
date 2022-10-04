using Newtonsoft.Json;
using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using testWallNetCore.Datos;
using testWallNetCore.Datos.Interfaces;
using testWallNetCore.Modelos;



// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace OverWallPapers.Componentes
{
    public sealed partial class AdministradorWallPaper : UserControl
    {

        //lista de sets
        List<WallPaperSet> Sets;

        //variables para mostrar u ocultar la lista de sets
        int Fase;

        //variables para guardar los componenettes que no se pudieron asignar en xaml
        ListaDeSets CompListaSets;

        FormularioWalPaperSet CompFormularioSets;

        //injeccion de dependencias
        IAgenteDatos Agente;

        public AdministradorWallPaper(IAgenteDatos agente)
        {
            this.InitializeComponent();

            //datos
            Agente = agente;

            // las fases son 0 registros, 1 formulario,
            Fase = 0;

            //inicializar los componentes
            CompListaSets = new ListaDeSets(Agente);

            CompFormularioSets = new FormularioWalPaperSet(Agente);


            //suscribirse a los eventos de los componentes
            CompListaSets.NuevoRegistroEvent += NuevoRegiostroListener;

            CompFormularioSets.OperacionCompletaEvent += GuardarSetListener;

            //agregarlos a la interfaz
            Contenedor.Children.Add(CompListaSets);
            Contenedor.Children.Add(CompFormularioSets);

            //leer los sets disponibles
            Sets = new List<WallPaperSet>();

            ////leer el archivo de config
            //string json = File.ReadAllText(@"C:\Users\Charly\Desktop\Sets.json");

            ////using (StreamReader r = new StreamReader(@"C:\Users\Charly\Desktop\Sets.json"))
            ////{
            ////    string json = r.ReadToEnd();
            ////    Sets = JsonConvert.DeserializeObject<List<WallPaperSet>>(json);
            ////}

            //Sets = JsonConvert.DeserializeObject<List<WallPaperSet>>(json);

            //cargar los sets

            Sets=Agente.ConsultarSets();

            Sets = Sets == null ? new List<WallPaperSet>() : Sets;

            //enviar a construir la lista de sets


            CompListaSets.CargarSets(Sets);

            CompListaSets.EdicionEvent += EscuchadorEdicion;
            CompListaSets.AplicarEvent += EscuchadorAplicar;
            CompListaSets.EliminarEvent += EscuchadorEliminacion;
            //navegar fase 0
            NavegarEntreFase(0);
        }
        

        private void NavegarEntreFase(int fase)
        {
            this.Fase = fase;
            
            switch(Fase)
            {
                case 0:
                    {

                        //oculatar el ocmponente de formulario
                        CompListaSets.Visibility = System.Windows.Visibility.Visible;
                        CompFormularioSets.Visibility = System.Windows.Visibility.Collapsed;

                        break;
                    }
                case 1:
                    {
                        //ocultar el ocmponente para registros
                        CompListaSets.Visibility = System.Windows.Visibility.Collapsed;
                        CompFormularioSets.Visibility = System.Windows.Visibility.Visible;
                        break;
                    }
            }

        }

        #region escuchadores de eventos

        public void NuevoRegiostroListener()
        {
            CompFormularioSets.NuevoSet();
            NavegarEntreFase(1);
        }

        private void EscuchadorEdicion(Int64 Id)
        {
            //buscar el set correspondiente a ese nombre
            //viejo
            //WallPaperSet Set = Sets.Where(x => x.Nombre == nombre).FirstOrDefault();

            //sqlite
            WallPaperSet Set=Agente.ConsultarSet(Id);

            if(Set != null)
            {
                CompFormularioSets.CargarSet(Set);
                NavegarEntreFase(1);
            }
        }

        private void EscuchadorAplicar(long id)
        {
            //buscar el set correspondiente a ese nombre
            WallPaperSet Set = Sets.Where(x => x.Id == id).FirstOrDefault();

            if (Set != null)
            {
                //aplicar 
                WallPaperApi.AplicarSet(Set,WallPaperApi.ListaDeMonitoresActuales());
                
            }
            else
            {
                MessageBox.Show("El set no fue encntrado");
            }
        }

        private void EscuchadorEliminacion(long id)
        {
            //hacer uso del agente para remover el registro de la base de datos

            try
            {
                if(Agente.EliminarSet(id))
                {
                    CompListaSets.CargarSets(Agente.ConsultarSets());
                }
            }
            catch(Exception e)
            {

            }
            
        }
        public void GuardarSetListener()
        {
            NavegarEntreFase(0);
            CompListaSets.CargarSets(Agente.ConsultarSets());
        }



        #endregion 
    }
}
