﻿#pragma checksum "..\..\Window2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC0073642387E625661D6A99344AAAEE638542D1"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Window2
    /// </summary>
    public partial class Window2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 108 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CpfSearch;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CpfNotRegistered;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SecretQuestion;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Answer;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IncorrectAnswer;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NovaSenhaLabel;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AnswerButton;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeButton;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox NewPassword;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label InvalidPassword;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\Window2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitNewPasswordButton;
        
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
            System.Uri resourceLocater = new System.Uri("/llsc;component/window2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window2.xaml"
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
            this.CpfSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\Window2.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CpfNotRegistered = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.SecretQuestion = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Answer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.IncorrectAnswer = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.NovaSenhaLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.AnswerButton = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\Window2.xaml"
            this.AnswerButton.Click += new System.Windows.RoutedEventHandler(this.AnswerButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\Window2.xaml"
            this.ChangeButton.Click += new System.Windows.RoutedEventHandler(this.ChangeButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.NewPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 136 "..\..\Window2.xaml"
            this.NewPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.NewPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.InvalidPassword = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.ExitNewPasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\Window2.xaml"
            this.ExitNewPasswordButton.Click += new System.Windows.RoutedEventHandler(this.ExitNewPasswordButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

