using OverWallPapers.Componentes;
using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
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
using testWallNetCore.Datos;
using testWallNetCore.Modelos;

namespace testWallNetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //obtener la cantidad de monitores conectados a la pc 
            IDesktopWallpaper Wallpaper;

            Wallpaper = (IDesktopWallpaper)new DesktopWallpaper();

            uint monitorCount = Wallpaper.GetMonitorDevicePathCount();

            string x = File.ReadAllText(@"C:\Users\Charly\Desktop\Sets.json");

            //MessageBox.Show(x);

        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //mostrar los poner el administrador de sets en pantalla
           
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AdministradorWallPaper administrador = new AdministradorWallPaper();
            ContenedorComponentes.Children.Clear();
            ContenedorComponentes.Children.Add(administrador);
        }
        private void Pruebas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //ese metodo esta orientado a realizar pruebas

            
            
            //cambiar el fondo del monitor del final
            //recuperar los sets 
            List<WallPaperSet> sets= new List<WallPaperSet>();

            sets = DatosApi.RecuperarSets();

            // obtener la configuracion adecuada de los monitores
                //obtener la lista de monitores 
            List<string> monitores = WallPaperApi.ListaDeMonitoresActuales();
            //obtener la configuracion correspondiente
            //monitores = DatosApi.ObtenerConfiguracionMonitores(monitores);
            // mandar a colocar el primer set


            WallPaperApi.AplicarSet(sets[0],monitores);

        }

    }
}
