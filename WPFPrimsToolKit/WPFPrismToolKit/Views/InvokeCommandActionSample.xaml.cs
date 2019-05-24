using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFPrimsToolKit.ViewModels;

namespace WPFPrimsToolKit.Views
{
    /// <summary>
    /// Interaction logic for EventToCommandPrism.xaml
    /// </summary>
    public partial class InvokeCommandActionSample : UserControl
    {
        public InvokeCommandActionSample()
        {
            InitializeComponent();

            this.DataContext = new InvokeCommandActionSampleViewModel();

            //Messenger.Default.Register<DialogMessage>(this, HandleDialogMessage);
        }

    }
}
