﻿#pragma checksum "..\..\..\..\Componentes\FormularioWalPaperSet.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ECF6834AEAD42337BB3CC9CD1D5B8A6B73213ED"
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
        
        
        #line 28 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titulo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nombre;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Posicion;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContenedorMonitores;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGuardar;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAplicar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
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
            this.Nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Posicion = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.Posicion.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Posicion_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ContenedorMonitores = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.BtnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.BtnGuardar.Click += new System.Windows.RoutedEventHandler(this.BtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnAplicar = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\Componentes\FormularioWalPaperSet.xaml"
            this.BtnAplicar.Click += new System.Windows.RoutedEventHandler(this.BtnAplicar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

