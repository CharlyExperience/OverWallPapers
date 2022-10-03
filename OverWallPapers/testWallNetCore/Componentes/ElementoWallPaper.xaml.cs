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
        Int64? Id;

        public delegate void Editar(Int64 Id);
        public event Editar EdicionEvent;

        public delegate void Aplicar(long id);
        public event Aplicar AplicarEvent;

        public delegate void Eliminar(long id);
        public event Aplicar EliminarEvent;
        public ElementoWallPaper()
        {
            this.InitializeComponent();
        }
        
        public void CargarWallPaper(WallPaperSet set)
        {
            //mapear los campos del set a la interfaz
            TxtId.Text = set.Id.ToString();
            TxtNombre.Text = set.Nombre;
            Nombre = set.Nombre;
            Id = set.Id;
        }

        private void MenuCancelar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("esta es la cancelacion");
            EliminarEvent((long)Id);
        }

        private void MenuEditar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
              
            //disparar el evento de la edicion
            EdicionEvent((Int64)Id);
        }

        private void MenuAplicar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //disparar el evento de la edicion
            AplicarEvent((long)Id);
        }
    }
}
