﻿#pragma checksum "..\..\..\wndMathMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "52A9B27FC3116E4706C043D9706F85C10BB724A91E98664EB52FC1579938AB44"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace WPF_Math_Game_Outline {
    
    
    /// <summary>
    /// wndMathMenu
    /// </summary>
    public partial class wndMathMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\wndMathMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\wndMathMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdPlayGame;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\wndMathMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdHighScores;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\wndMathMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdEnterUserData;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\wndMathMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorLabelJediInput;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF Math Game Outline;component/wndmathmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\wndMathMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cmdPlayGame = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\wndMathMenu.xaml"
            this.cmdPlayGame.Click += new System.Windows.RoutedEventHandler(this.cmdPlayGame_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmdHighScores = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\wndMathMenu.xaml"
            this.cmdHighScores.Click += new System.Windows.RoutedEventHandler(this.cmdHighScores_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmdEnterUserData = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\wndMathMenu.xaml"
            this.cmdEnterUserData.Click += new System.Windows.RoutedEventHandler(this.cmdEnterUserData_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ErrorLabelJediInput = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

