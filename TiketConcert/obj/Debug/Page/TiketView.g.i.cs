﻿#pragma checksum "..\..\..\Page\TiketView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81D3879AF7DA17B5550D19C5D54727604AAA3E61767ADEE2B0EB1B158BC02BEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TiketConcert.Page;


namespace TiketConcert.Page {
    
    
    /// <summary>
    /// TiketView
    /// </summary>
    public partial class TiketView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame NavigationFrame;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ViewFrame;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink PageReg;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border acc;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserNameBlock;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonProfile;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonHistory;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Paket;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Page\TiketView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonExith;
        
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
            System.Uri resourceLocater = new System.Uri("/TiketConcert;component/page/tiketview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Page\TiketView.xaml"
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
            this.NavigationFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.ViewFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.PageReg = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 65 "..\..\..\Page\TiketView.xaml"
            this.PageReg.Click += new System.Windows.RoutedEventHandler(this.TextAccount_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.acc = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.UserNameBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.ButtonProfile = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ButtonHistory = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\Page\TiketView.xaml"
            this.ButtonHistory.Click += new System.Windows.RoutedEventHandler(this.ButtonHistory_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Paket = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\Page\TiketView.xaml"
            this.Paket.Click += new System.Windows.RoutedEventHandler(this.Paket_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonExith = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\Page\TiketView.xaml"
            this.ButtonExith.Click += new System.Windows.RoutedEventHandler(this.ButtonExith_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

