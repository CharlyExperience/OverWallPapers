using Newtonsoft.Json;
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
using testWallNetCore.Componentes.Comportamientos;
using testWallNetCore.Datos;
using testWallNetCore.Datos.Interfaces;
using testWallNetCore.Modelos;

namespace testWallNetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        //injeccion de dependencias
        public IAgenteDatos Agente;
        public MainWindow()
        {
            InitializeComponent();

            //obtener la cantidad de monitores conectados a la pc 
            IDesktopWallpaper Wallpaper;

            Wallpaper = (IDesktopWallpaper)new DesktopWallpaper();

            uint monitorCount = Wallpaper.GetMonitorDevicePathCount();

            string x = File.ReadAllText(@"C:\Users\Charly\Desktop\Sets.json");

            //MessageBox.Show(x);

            //inicializar el agente de base de datos
            Agente = new DatosApiSqlite(@"C:\Users\Charly\Desktop\FondosPantalla.db");


            //escuchar el evento del menu
            Menu.EventoMenu += EscuchadorMenu;

        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //mostrar los poner el administrador de sets en pantalla
           
        }

        public void EscuchadorMenu(string opc)
        {
            switch(opc)
            {
                case "sets":
                    {
                        Sets();
                        break;
                    }
                case "prueba":
                    {
                        Pruebas();
                        break;
                    }
                case "comportamientos":
                    {
                        Comportamiento();
                        break;
                    }
            }
        }

        private void Sets()
        {
            AdministradorWallPaper administrador = new AdministradorWallPaper(Agente);
            ContenedorComponentes.Children.Clear();
            ContenedorComponentes.Children.Add(administrador);
        }
        private void Pruebas()
        {
            //ese metodo esta orientado a realizar pruebas

            //Pruebas respecto a sqlite

            DesktopWallpaperPosition x = (DesktopWallpaperPosition)2;

            WallPaperSet set = new WallPaperSet();
            set.Posicion = x;

        }

        private void Comportamiento()
        {
            //ese metodo esta orientado a iniciar el componente de creacion de comportamientos

            AdministradorComportamientos administrador = new AdministradorComportamientos(Agente);
            ContenedorComponentes.Children.Clear();
            ContenedorComponentes.Children.Add(administrador);

        }

    }
}
