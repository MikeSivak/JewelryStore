﻿#pragma checksum "..\..\Cashier.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D12061D0EA9F478A497837C2CDF95AB75D71876F5605666E1D692DEBE2F19A42"
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
    /// Cashier
    /// </summary>
    public partial class Cashier : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid cashierManagementGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ordersList;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid cashierInfoGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstNameBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastNameBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Cashier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneNumberBox;
        
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
            System.Uri resourceLocater = new System.Uri("/JewerlyStore;component/cashier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Cashier.xaml"
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
            
            #line 8 "..\..\Cashier.xaml"
            ((JewerlyStore.Cashier)(target)).Loaded += new System.Windows.RoutedEventHandler(this.cashierOpenWindow);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Cashier.xaml"
            ((JewerlyStore.Cashier)(target)).Closed += new System.EventHandler(this.closedCashierWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cashierManagementGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 12 "..\..\Cashier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.showCashierProfile);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ordersList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\Cashier.xaml"
            this.ordersList.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.updateOrders);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\Cashier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.sendOrderClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cashierInfoGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Cashier.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.emailBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.passwordBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.firstNameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.lastNameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.phoneNumberBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 48 "..\..\Cashier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.saveClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

