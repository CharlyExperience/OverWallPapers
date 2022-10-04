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


// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace OverWallPapers.Componentes
{
    public sealed partial class ListaDeSets : UserControl
    {
        List<WallPaperSet> Sets;

        //evento para nueva creacion
        public delegate void NuevoRegistroDelegate();
        public event NuevoRegistroDelegate NuevoRegistroEvent;

        //evento para aplicacion
        public delegate void Aplicar(long Id);
        public event Aplicar AplicarEvent;

        //evento para Edicion
        public delegate void Editar(long Id);
        public event Editar EdicionEvent;

        //evento para Eliminacion
        public delegate void Eliminar(long Id);
        public event Editar EliminarEvent;

        //injeccion de dependencias 
        public IAgenteDatos AgenteDb;
        public ListaDeSets()
        {
            this.InitializeComponent();
        }

        public ListaDeSets(IAgenteDatos agente)
        {
            this.InitializeComponent();
            //AgenteDb = new DatosApiSqlite(@"C:\Users\Charly\Desktop\FondosPantalla.db");
            AgenteDb = agente;
        }

        public void CargarSets(List<WallPaperSet> sets)
        {
            ContenedorSets.Children.Clear();

            foreach (WallPaperSet set in sets)
            {
                ElementoWallPaper wallPaper = new ElementoWallPaper();
                wallPaper.EdicionEvent += EscuchadorEdicion;
                wallPaper.AplicarEvent += EscuchadorAplicar;
                wallPaper.EliminarEvent += EscuchadorEliminar;
                wallPaper.CargarWallPaper(set);
                ContenedorSets.Children.Add(wallPaper);

            }
        }

        private void EscuchadorEdicion(Int64 Id)
        {
            
            EdicionEvent(Id);
        }

        private void EscuchadorAplicar(long Id)
        {
            AplicarEvent(Id);
        }

        private void EscuchadorEliminar(long Id)
        {
            //usar el agente de datos para remover el registro indicado
            EliminarEvent(Id);
        }
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //disparar el evento de creacion de componente 
            this.NuevoRegistroEvent();
        }
    }
}