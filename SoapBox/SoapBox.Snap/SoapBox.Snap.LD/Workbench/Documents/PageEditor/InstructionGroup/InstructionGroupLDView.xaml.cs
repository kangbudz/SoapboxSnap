﻿#region "SoapBox.Snap License"
/// <header module="SoapBox.Snap"> 
/// </header>
#endregion
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using SoapBox.Utilities;

namespace SoapBox.Snap.LD
{
    [Export(SoapBox.Core.ExtensionPoints.Host.Views, typeof(ResourceDictionary))]
    public partial class InstructionGroupLDView : ResourceDictionary
    {
        public InstructionGroupLDView()
        {
            InitializeComponent();
        }
    }
}
