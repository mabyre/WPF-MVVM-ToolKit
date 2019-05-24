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

namespace WPFPrimsToolKit.Views
{
    /// <summary>
    /// Logique d'interaction pour StaticSampleView.xaml
    /// </summary>
    public partial class StaticSampleView : UserControl
    {
        public StaticSampleView()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, RoutedEventArgs e)
        {
            string text = textBoxMessage.Text;

            Employee.PrintNextEmpID(ref text);
            Employee.PrintCompagny(ref text);

            Employee emp1 = new Employee();
            Employee emp2 = new Employee();

            emp1.Print(ref text);
            emp2.Print(ref text);

            EmployeeDisposable empDisposable1 = new EmployeeDisposable();
            empDisposable1.Print(ref text);

            using (empDisposable1)
            {

            }

            textBoxMessage.Text = text;
        }
    }
}
