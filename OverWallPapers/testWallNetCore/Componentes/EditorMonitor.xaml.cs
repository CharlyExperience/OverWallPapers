using Microsoft.Win32;
using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace OverWallPapers.Componentes
{
    public sealed partial class EditorMonitor : UserControl
    {
        public WallPaper Monitor;
        public EditorMonitor()
        {
            
            this.InitializeComponent();

            Monitor = new WallPaper();

        }

        
        public void CargarMonitor(WallPaper monitor)
        {
            Monitor = monitor;
            //cargar la imagen
            if(Monitor.FondoDePantalla != null || Monitor.FondoDePantalla!="")
            {
                CargarImagen(Monitor.FondoDePantalla);
            }
            
        }


        private void render_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MessageBox.Show("solo por si acaso"+ContenedorPrincipal.ActualWidth.ToString());
            ContenedorPrincipal.Height = (this.ActualWidth * 0.6d);
        }

        private void CargarRuta(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //abrir el expolorador de archivos para seleccionar la ruta 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if(openFileDialog.FileName.Contains(".jpg")|| openFileDialog.FileName.Contains(".png"))
                { 
                    //recuperar la imagen seleccionada y asignarla al modelo
                    Monitor.FondoDePantalla=openFileDialog.FileName;

                    //asignar la imagena la vista previa
                    CargarImagen(openFileDialog.FileName);
                    
                }
                else
                    MessageBox.Show("no mames que es esto");
            }
        }

        private void CargarImagen(string ruta)
        {
            //validar que exista el archivo
            if(File.Exists(ruta))
            {
                Uri fileUri = new Uri(ruta);
                Imagen.ImageSource = new BitmapImage(fileUri);
                Imagen.Stretch = Stretch.Fill;
            }
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //mostrar el letrero de cargar ruta
            BtnCargarRuta.Visibility = System.Windows.Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //ocultar el letrero de cargar ruta
            BtnCargarRuta.Visibility = System.Windows.Visibility.Collapsed;
            
        }
    }
}
