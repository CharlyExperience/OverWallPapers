﻿#pragma checksum "..\..\..\..\Componentes\FormularioWalPaperSet.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CDA75C4CA76189C67CEB872769C6BCECC4C706BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OverWallPapers.Componentes {
    
    
    /// <summary>
    /// FormularioWalPaperSet
    /// </summary>
    public partial class FormularioWalPaperSet : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titulo;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdForm;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nombre;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Posicion;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContenedorMonitores;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGuardar;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAplicar;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnVolver;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdCarga;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/testWallNetCore;component/componentes/formulariowalpaperset.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Titulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.GrdForm = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Posicion = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.Posicion.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Posicion_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ContenedorMonitores = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.BtnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.BtnGuardar.Click += new System.Windows.RoutedEventHandler(this.BtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnAplicar = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.BtnAplicar.Click += new System.Windows.RoutedEventHandler(this.BtnAplicar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnVolver = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.BtnVolver.Click += new System.Windows.RoutedEventHandler(this.BtnVolver_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GrdCarga = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

