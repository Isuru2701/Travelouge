// Updated by XamlIntelliSenseFileGenerator 11/06/2023 3:50:40 PM
#pragma checksum "..\..\..\View\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CEA377CC6FB933B1585E4C565930295400AD7144279356956DBBFFFBC048BA29"
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
using Travelouge.View;


namespace Travelouge.View
{


    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 13 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button checkButton;

#line default
#line hidden


#line 23 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox locationBox;

#line default
#line hidden


#line 26 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kruskalButton;

#line default
#line hidden


#line 34 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button resetButton;

#line default
#line hidden


#line 46 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label locationsLabel;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Travelouge;component/view/home.xaml", System.UriKind.Relative);

#line 1 "..\..\..\View\Home.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.checkButton = ((System.Windows.Controls.Button)(target));

#line 14 "..\..\..\View\Home.xaml"
                    this.checkButton.Click += new System.Windows.RoutedEventHandler(this.checkButton_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.locationBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.kruskalButton = ((System.Windows.Controls.Button)(target));

#line 32 "..\..\..\View\Home.xaml"
                    this.kruskalButton.Click += new System.Windows.RoutedEventHandler(this.kruskalButton_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.resetButton = ((System.Windows.Controls.Button)(target));

#line 40 "..\..\..\View\Home.xaml"
                    this.resetButton.Click += new System.Windows.RoutedEventHandler(this.resetButton_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.pathLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.locationsLabel = ((System.Windows.Controls.Label)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock pathLabel;
    }
}

