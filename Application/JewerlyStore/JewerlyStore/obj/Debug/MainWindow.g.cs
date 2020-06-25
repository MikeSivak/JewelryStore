﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C744408B49BEA3B56DF900390C6B965BFA85B60885522E22CF1F53889640F775"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JewerlyStore;
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


namespace JewerlyStore {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label login;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label email;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label password;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button signIn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink registration;
        
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
            System.Uri resourceLocater = new System.Uri("/JewerlyStore;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 8 "..\..\MainWindow.xaml"
            ((JewerlyStore.MainWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dragMove);
            
            #line default
            #line hidden
            
            #line 8 "..\..\MainWindow.xaml"
            ((JewerlyStore.MainWindow)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.closeHelloWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 10 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeLogin);
            
            #line default
            #line hidden
            return;
            case 3:
            this.login = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.email = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.emailBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.password = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.signIn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.signIn.Click += new System.Windows.RoutedEventHandler(this.signInClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.registration = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.registration.MouseEnter += new System.Windows.Input.MouseEventHandler(this.getRegLink);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.registration.MouseLeave += new System.Windows.Input.MouseEventHandler(this.lostRegLink);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.registration.Click += new System.Windows.RoutedEventHandler(this.clickRegLink);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

