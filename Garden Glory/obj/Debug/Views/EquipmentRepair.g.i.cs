﻿#pragma checksum "..\..\..\Views\EquipmentRepair.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FDE80B703BE5942AF4AC1B1ABC73286A822CCFDCA865A984D6F33AE185A63564"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Garden_Glory.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Garden_Glory.Views {
    
    
    /// <summary>
    /// EquipmentRepair
    /// </summary>
    public partial class EquipmentRepair : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid controls_container;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox equipmentID;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker repairDate;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amount;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox remarks;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete_btn;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit_btn;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\EquipmentRepair.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_customer;
        
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
            System.Uri resourceLocater = new System.Uri("/Garden Glory;component/views/equipmentrepair.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\EquipmentRepair.xaml"
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
            this.controls_container = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.equipmentID = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.repairDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.amount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.remarks = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 83 "..\..\..\Views\EquipmentRepair.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.add_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.delete_btn = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\Views\EquipmentRepair.xaml"
            this.delete_btn.Click += new System.Windows.RoutedEventHandler(this.delete_click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.edit_btn = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Views\EquipmentRepair.xaml"
            this.edit_btn.Click += new System.Windows.RoutedEventHandler(this.edit_click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.datagrid_customer = ((System.Windows.Controls.DataGrid)(target));
            
            #line 88 "..\..\..\Views\EquipmentRepair.xaml"
            this.datagrid_customer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.row_selected);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
