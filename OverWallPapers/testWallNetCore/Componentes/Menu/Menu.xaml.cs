using OverWallPapers.Componentes;
using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {

        public  delegate void DelegateMenu(string opc);
        public event DelegateMenu EventoMenu;

        public List<ElementoMenu>Opciones;
        public Menu()
        {
            InitializeComponent();

            //configurar el ancho de la columna de los textos a cero
            //ColExtensible.Width = new GridLength(0);
            //ColTelon.Width = new GridLength(0);

            //alimentar las opciones 
            Opciones = new List<ElementoMenu>();

            Opciones.Add(new ElementoMenu("sets", "Recursos/Iconos/imgGray.png", "Recursos/Iconos/imgCyan.png"));
            Opciones.Add(new ElementoMenu("pruebas", "Recursos/Iconos/Experimental.png", "Recursos/Iconos/Experimental.png"));
            Opciones.Add(new ElementoMenu("comportamientos", "Recursos/Iconos/Calendario.png", "Recursos/Iconos/Calendario.png"));

            //insertarlos en la interfaz
            for (int i = 0; i < Opciones.Count;i++)
            {
                GrdContenedor.Children.Add(Opciones[i]);

                Opciones[i].SetValue(Grid.ColumnProperty, 0);
                Opciones[i].SetValue(Grid.RowProperty, i+2);

                Opciones[i].ClickEvent += EscuchadorOpciones;
            }
        }

        #region escuchador de opciones menu

        private void EscuchadorOpciones(string opc)
        {
            EventoMenu(opc);

            //deseleccionar las otras opciones
            for (int i = 0; i < Opciones.Count; i++)
            {
                if(Opciones[i].Opcion!=opc)
                {
                    Opciones[i].Deseleccionar();
                }
                
            }
        }
       
        #endregion

        #region comportamiento grafico

        private void ColIcono_MouseEnter(object sender, MouseEventArgs e)
        {
            //configurar el ancho de la columna de los textos a cero
            //ColExtensible.Width = GridLength.Auto;
            ColTelon.Width =new  GridLength(1,GridUnitType.Star);

            foreach(ElementoMenu elem in Opciones)
            {
                elem.Desplegar(true);
            }
        }

        #endregion

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {

            foreach (ElementoMenu elem in Opciones)
            {
                elem.Desplegar(false);
            }
            //configurar el ancho de la columna de los textos a cero
            //ColExtensible.Width = new GridLength(0);
            ColTelon.Width = new GridLength(0);
        }
    }



}
