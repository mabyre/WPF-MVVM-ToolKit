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
using WPFPrimsToolKit.Views;

namespace WPFPrimsToolKit
{
    /// <summary>
    /// Logique d'interaction pour ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized( EventArgs e )
        {
            base.OnSourceInitialized( e );

            // Set default UserControl
            //ContentControlMain.Content = new InvokeCommandActionSample();
            //ContentControlMain.Content = new RetryPolicyView();
            ContentControlMain.Content = new StaticSampleView();

            // Make TreeView Item Selected
            foreach ( TreeViewItem tvi in TreeViewMain.Items )
            {
                //if (tvi.Header.ToString() == "InvokeCommandAction")
                //if ( tvi.Header.ToString() == "RetryPolicy" )
                if (tvi.Header.ToString() == "StaticSample")
                {
                    tvi.IsSelected = true;
                    break;
                }
            }
        }

        private void TreeView_SelectedItemChanged( object sender, RoutedPropertyChangedEventArgs<object> e )
        {
            TreeViewItem treeViewItemSelected = ( sender as TreeView ).SelectedItem as TreeViewItem;
            switch ( treeViewItemSelected.Header.ToString() )
            {
                case "StaticSample":
                    ContentControlMain.Content = new StaticSampleView();
                    break;
                case "DataTemplateAndTriggers":
                    ContentControlMain.Content = new DataTemplateAndTriggers();
                    break;
                case "HelloWorld":
                    ContentControlMain.Content = new HelloWorldView();
                    break;
                case "TreeView1":
                    ContentControlMain.Content = new UserControl1();
                    break;
                case "TreeView2":
                    ContentControlMain.Content = new UserControl2();
                    break;
                case "InvokeCommandAction":
                    ContentControlMain.Content = new InvokeCommandActionSample();
                    break;
                case "RetryPolicy":
                    ContentControlMain.Content = new RetryPolicyView();
                    break;
            }
        }

        private void MenuItemHelloWorld_Click( object sender, RoutedEventArgs e )
        {
            ContentControlMain.Content = new HelloWorldView();
        }

        private void MenuItemExit_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }
    }
}
