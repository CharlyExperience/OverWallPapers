using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testWallNetCore.Componentes.Menu
{

    
    /// <summary>
    /// Lógica de interacción para ElementoMenu.xaml
    /// </summary>
    public partial class ElementoMenu : UserControl
    {
        //variables para alimentar la interfaz
        public string Opcion;

        public string IconoBase;

        public string IconoSeleccionado;


        public bool Seleccionado;

        //evento click 
        public delegate void DelegadoClick(string opcion);
        public event DelegadoClick ClickEvent = delegate { };
        public ElementoMenu()
        {
            InitializeComponent();
        }


        public ElementoMenu(string opcion, string iconoBase, string iconoSeleccionado):this()
        {
            Opcion = opcion;

            IconoBase = iconoBase;

            IconoSeleccionado = iconoSeleccionado;

            string x = "pack://application:,,,/" + iconoBase;
            txtOpcion.Text = opcion;
            Uri fileUri = new Uri(x);
            ImgOpcion.Source = new BitmapImage(fileUri);

            Seleccionado = false;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            //sombrar el grid principal segun su estado de seleccion
            if(Seleccionado)
            {
                //cambiar el color al pr
            }
            else
            {
                //cambiar el color del fondo a un gris claro
                GrdPrincipal.Background = new SolidColorBrush(Color.FromRgb(200,200,200));
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            //devolver el color dependiendo su seleccion 
            if(Seleccionado)
            {

            }
            else
            {
                //poner el color base 
                GrdPrincipal.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClickEvent(Opcion);

            Seleccionado = true;

            //pintar de color primario el grid
            GrdPrincipal.Background= new SolidColorBrush(Color.FromRgb(255, 255, 255));

            txtOpcion.Foreground= new SolidColorBrush(Color.FromRgb(8, 207, 170));

            //configurar el icono de seleccion
            Uri fileUri = new Uri("pack://application:,,,/" + IconoSeleccionado);
            ImgOpcion.Source = new BitmapImage(fileUri);
        }

        public void Deseleccionar()
        {
            //GrdPrincipal.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            txtOpcion.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));

            //configurar el icono base
            Uri fileUri = new Uri("pack://application:,,,/" + IconoBase);
            ImgOpcion.Source = new BitmapImage(fileUri);

            Seleccionado = false;

        }

        public void Desplegar(bool desplegar)
        {
            ColDesplegable.Width= desplegar? GridLength.Auto: new GridLength(0);
        }
    }
}
