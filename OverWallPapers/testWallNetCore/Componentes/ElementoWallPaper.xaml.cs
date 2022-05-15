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
    public sealed partial class ElementoWallPaper : UserControl
    {
        string Nombre;

        public delegate void Editar(string s);
        public event Editar EdicionEvent;

        public delegate void Aplicar(string s);
        public event Aplicar AplicarEvent;
        public ElementoWallPaper()
        {
            this.InitializeComponent();
        }
        
        public void CargarWallPaper(WallPaperSet set)
        {
            //mapear los campos del set a la interfaz
            TxtNombre.Text = set.Nombre;
            Nombre = set.Nombre;
        }

        private void MenuCancelar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("esta es la cancelacion");
        }

        private void MenuEditar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
              
            //disparar el evento de la edicion
            EdicionEvent(Nombre);
        }

        private void MenuAplicar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("esta es la edicio");
            //disparar el evento de la edicion
            AplicarEvent(Nombre);
        }
    }
}
