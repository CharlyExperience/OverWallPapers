﻿#pragma checksum "..\..\..\..\Componentes\EditorMonitor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70E672E46E77E9056C33522A06B772CB4BDAF2BC"
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
    /// EditorMonitor
    /// </summary>
    public partial class EditorMonitor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\Componentes\EditorMonitor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OverWallPapers.Componentes.EditorMonitor render;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Componentes\EditorMonitor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ContenedorPrincipal;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Componentes\EditorMonitor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush Imagen;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Componentes\EditorMonitor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BtnCargarRuta;
        
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
            System.Uri resourceLocater = new System.Uri("/testWallNetCore;component/componentes/editormonitor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Componentes\EditorMonitor.xaml"
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
            this.render = ((OverWallPapers.Componentes.EditorMonitor)(target));
            
            #line 10 "..\..\..\..\Componentes\EditorMonitor.xaml"
            this.render.SizeChanged += new System.Windows.SizeChangedEventHandler(this.render_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ContenedorPrincipal = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            
            #line 38 "..\..\..\..\Componentes\EditorMonitor.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Grid_MouseEnter);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\Componentes\EditorMonitor.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Grid_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Imagen = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 5:
            this.BtnCargarRuta = ((System.Windows.Controls.Border)(target));
            
            #line 55 "..\..\..\..\Componentes\EditorMonitor.xaml"
            this.BtnCargarRuta.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CargarRuta);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

