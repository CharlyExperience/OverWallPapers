using Newtonsoft.Json;
using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace OverWallPapers.Componentes
{
    public sealed partial class ListaDeSets : UserControl
    {
        List<WallPaperSet> Sets;

        //evento para nueva creacion
        public delegate void NuevoRegistroDelegate();
        public event NuevoRegistroDelegate NuevoRegistroEvent;

        public delegate void Aplicar(string s);
        public event Aplicar AplicarEvent;

        //evento para eliminacion
        public delegate void Editar(string s);
        public event Editar EdicionEvent;
        public ListaDeSets()
        {
            this.InitializeComponent();
        }

        public void CargarSets(List<WallPaperSet> sets)
        {
            

            foreach (WallPaperSet set in sets)
            {
                ElementoWallPaper wallPaper = new ElementoWallPaper();
                wallPaper.EdicionEvent += EscuchadorEdicion;
                wallPaper.AplicarEvent += EscuchadorAplicar;
                wallPaper.CargarWallPaper(set);
                ContenedorSets.Children.Add(wallPaper);

            }
        }

        private void EscuchadorEdicion(string nombre)
        {
            
            EdicionEvent(nombre);
        }

        private void EscuchadorAplicar(string nombre)
        {
            AplicarEvent(nombre);
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //disparar el evento de creacion de componente 
            this.NuevoRegistroEvent();
        }
    }
}