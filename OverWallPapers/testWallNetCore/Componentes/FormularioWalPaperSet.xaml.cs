using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OverWallPapers.Modelos;
using System.Windows.Controls;
using System.Windows;
using Newtonsoft.Json;
using testWallNetCore.Modelos;
using System.Threading;
using System.Threading.Tasks;
using testWallNetCore.Datos;
using testWallNetCore.Datos.Interfaces;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace OverWallPapers.Componentes
{
    public sealed partial class FormularioWalPaperSet : UserControl
    {

        public delegate void OperacionCompleta();
        public OperacionCompleta OperacionCompletaEvent;

        public WallPaperSet Set;

        private List<EditorMonitor> Monitores;

        private bool Nuevo;

        //injeccion de dependencias
        IAgenteDatos Agente;

        public FormularioWalPaperSet()
        {
            this.InitializeComponent();

            GrdCarga.Visibility=Visibility.Collapsed;
        }
        
        public FormularioWalPaperSet(IAgenteDatos agente)
        {
            this.InitializeComponent();

            //datos
            Agente = agente;

            GrdCarga.Visibility=Visibility.Collapsed;
        }

        public void NuevoSet()
        {
            Set = new WallPaperSet();
            Set.Posicion = DesktopWallpaperPosition.Fill;
            Set.Id = null;
            Set.Nombre = null;

            Nuevo = true;

            Posicion.SelectedIndex = 4;

            //configurar el contexto para el bindeo
            GrdForm.DataContext=Set;

            //obtener la cantidad de monitores conectados a la pc 
            IDesktopWallpaper Wallpaper;

            Wallpaper = (IDesktopWallpaper)new DesktopWallpaper();

            uint monitorCount = Wallpaper.GetMonitorDevicePathCount();
            for (uint i = 0; i < monitorCount; i++)
            {
                //Crear un monitor nuevo por cada uno 
                WallPaper mon = new WallPaper();
                mon.Monitor = (int)i;
                Set.Monitores.Add(mon);
            }

            GenerarMonitores();
        }

        public void CargarSet(WallPaperSet set)
        {
            //asignar el parametro al modelo
            Set = set;
            //llenar el formulario con la informacion previa del set
            Nombre.Text = Set.Nombre;

            Posicion.SelectedIndex = (int)Set.Posicion;
            //generar las pantallas 
            GenerarMonitores();

            //configurar como edicion
            Nuevo = false;

            //configurar el contexto para el bindeo
            GrdForm.DataContext = Set;
        }

        public void GenerarMonitores()
        {
            Monitores = new List<EditorMonitor>();
            //generar un componente monitor y una columna para cada uno


            ContenedorMonitores.Children.Clear();
            ContenedorMonitores.ColumnDefinitions.Clear();
            for (int i = 0; i < Set.Monitores.Count; i++)
            {
                //Construir la columna a la que pertenecera el monitor
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(1, GridUnitType.Star);
                ContenedorMonitores.ColumnDefinitions.Add(col);

                //construir el componenete editor monitor que residira hai
                EditorMonitor CompMonitor = new EditorMonitor();

                //configurar la ingo del monitor
                CompMonitor.CargarMonitor(Set.Monitores[i]);
                    //agregarlo al arreglo de componentes 
                Monitores.Add(CompMonitor);

                    //inicializar el componente 
                CompMonitor.CargarMonitor(Set.Monitores[i]);

                //asignar el componente a la grilla y asignarle posicion
                ContenedorMonitores.Children.Add(CompMonitor);

                CompMonitor.SetValue(Grid.ColumnProperty, i);
                CompMonitor.SetValue(Grid.RowProperty, 1);
            }

            //agregar un texto a la primer columna 
            

        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //poner la ventana de cargando
            GrdCarga.Visibility = Visibility.Visible;

            //guardar
            
            await GuardarAsync();

            //poner la ventana de cargando
            GrdCarga.Visibility = Visibility.Collapsed;
            return;
        }

        public async Task<bool> GuardarAsync()
        {

            //esperar 10 segundos

            //await Task.Delay(5000);
            //guardar con el metodo original

            //validar que los campos no esten vacios
            Nombre.Text = Nombre.Text.Trim();
            if (Nombre.Text == null || Nombre.Text.Length == 0)
            {
                MessageBox.Show("El Nombre del set no ha sido indicado");
                return false;
            }

            //asignar los valores del formulario al modelo del set 
            Set.Nombre = Nombre.Text;


            switch (Posicion.Text)
            {
                case "Rellenar":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Fill;
                        break;
                    }
                case "Ajustar":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Fit;
                        break;
                    }
                case "Expandir":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Stretch;
                        break;
                    }
                case "Icono":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Tile;
                        break;
                    }
                case "Centro":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Center;
                        break;
                    }
                case "Distribuir":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Span;
                        break;
                    }
            }

            //reconstruir los monitores del modelo
            Set.Monitores.Clear();
            foreach (EditorMonitor mon in Monitores)
            {
                Set.Monitores.Add(mon.Monitor);
            }

            #region Guardado Sqlite

            long? id = Agente.GuardarSet(Set);


            #endregion

            #region guardado en el json
            ////guardar el set en la ista de sets existentes
            ////recuperar la lista de sets
            //string json = File.ReadAllText(@"C:\Users\Charly\Desktop\Sets.json");
            //List<WallPaperSet> Sets = JsonConvert.DeserializeObject<List<WallPaperSet>>(json);

            ////si se trata de un nuevo registo
            //string msg;
            //if (Nuevo)
            //{
            //    //verificar que no exista un set con el mismo nombre
            //    if (Sets.Where(x => x.Nombre == Nombre.Text).Count() > 0)
            //    {
            //        MessageBox.Show("Ya existe un Set con ese Nombre");

            //        return false;
            //    }
            //    msg = "Nuevo set creado!";
            //    //guardar incluir el set a la lista y escribir el json
            //    Sets.Add(Set);
            //}
            //else
            //{
            //    //modificar el set corresponda al nombre con el nuevo a guardar
            //    for (int i = 0; i < Sets.Count; i++)
            //    {
            //        if (Sets[i].Nombre == Set.Nombre)
            //        {
            //            Sets[i] = Set;

            //        }
            //    }
            //    msg = "Edicion Exitosa";
            //}



            //json = JsonConvert.SerializeObject(Sets);

            ////escribir el json
            //File.WriteAllText(@"C:\Users\Charly\Desktop\Sets.json", json);

            //MessageBox.Show(msg);

            #endregion

            //asiganr al set el id insertado
            Set.Id = id;

            Titulo.Text = "Editar Set #"+Set.Id.ToString();



            return true;

        }

        private void BtnAplicar_Click(object sender, RoutedEventArgs e)
        {
            //validar que los campos no esten vacios
            WallPaperApi.AplicarSet(Set, WallPaperApi.ListaDeMonitoresActuales());
        }

        private void Posicion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccionNueva = (System.Windows.Controls.ComboBoxItem)e.AddedItems[0];
            switch (seleccionNueva.Content)
            {
                case "Rellenar":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Fill;
                        break;
                    }
                case "Ajustar":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Fit;
                        break;
                    }
                case "Expandir":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Stretch;
                        break;
                    }
                case "Icono":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Tile;
                        break;
                    }
                case "Centro":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Center;
                        break;
                    }
                case "Distribuir":
                    {
                        Set.Posicion = DesktopWallpaperPosition.Span;
                        break;
                    }
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            OperacionCompletaEvent();
        }
    }
}
