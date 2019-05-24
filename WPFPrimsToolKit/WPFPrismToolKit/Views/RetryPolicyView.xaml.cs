// 
// https://github.com/App-vNext/Polly
// http://www.appvnext.com/blog/2015/11/19/polly-is-repetitive-and-i-love-it
//
// Circuit Breaker
// https://msdn.microsoft.com/en-us/library/dn589784.aspx
//
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Polly;
using Polly.Retry;
using WPFPrimsToolKit.ViewModels;
using CircuitBraker;

namespace WPFPrimsToolKit.Views
{
    /// <summary>
    /// Logique d'interaction pour RetryPolicyView.xaml
    /// </summary>
    public partial class RetryPolicyView : UserControl
    {
        private int nbRetry = 0;
        private bool errorChecked = false;

        public RetryPolicyView()
        {
            InitializeComponent();
            this.DataContext = new RetryPolicyViewModel();
        }

        private void printToTextBox1( string msg )
        {
            textBoxText.Text += msg + Environment.NewLine;
        }

        private void verifyRetryPolicy( bool error )
        {
            if ( error == true )
            {
                throw new RetryPolicyException( "Verify RetryPolicy is On Error" );
            }
        }

        private void verifyWaitAndRetryPolicy( bool error )
        {
            if ( error == true )
            {
                throw new RetryPolicyException( "Verify WaitAndRetryPolicy is On Error" );
            }
        }

        private void checkControls()
        {
            try
            {
                nbRetry = int.Parse( textBoxNbRetry.Text );
            }
            catch ( Exception )
            {
                textBoxNbRetry.Text = "0";
            }

            errorChecked = checkBoxOnError.IsChecked == true ? true : false;
        }

        private void textBoxText_TextChanged( object sender, TextChangedEventArgs e )
        {
            textBoxText.ScrollToEnd();
        }

        private void buttonRetry_Click( object sender, RoutedEventArgs e )
        {
            int cptRetry = 1;

            checkControls();

            RetryPolicy retry = Policy.Handle<RetryPolicyException>().Retry
            (
                nbRetry,
                ( ex, count ) =>
                {
                    if ( count == 1 )
                    {
                        printToTextBox1("Failed");
                    }

                    printToTextBox1( "Try: " + cptRetry.ToString() );
                    cptRetry += 1;
                }
            );

            try
            {
                retry.Execute( () => { verifyRetryPolicy( errorChecked ); } );
                printToTextBox1( "verifyRetryPolicy is Ok" );
            }
            catch ( Exception ex )
            {
                printToTextBox1( "Exception: " + ex.Message );
            }

            printToTextBox1( "End" );
        }

        private void buttonTry1_Click( object sender, RoutedEventArgs e )
        {

        }

        private void buttonWandR_Click( object sender, RoutedEventArgs e )
        {
            checkControls();

            DateTime date = DateTime.Now;

            RetryPolicy retry = Policy.Handle<RetryPolicyException>().WaitAndRetry
            (
                nbRetry,
                count =>
                {
                    date = DateTime.Now;
                    printToTextBox1( date.ToString("[hh:mm:ss.fff] ") + "Try to connect sensor: " + count.ToString() );
                    
                    //return TimeSpan.FromSeconds( Math.Pow( 2, count ) );
                    return TimeSpan.FromSeconds( 1 );
                }
            );

            try
            {
                retry.Execute( () => { verifyWaitAndRetryPolicy( errorChecked ); } );
                printToTextBox1( "verifyWaitAndRetryPolicy is Ok" );
            }
            catch ( Exception ex )
            {
                printToTextBox1( "Exception: " + ex.Message );
            }

            printToTextBox1( "End WaitAndRetry" );
        }

        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            checkControls();


        }
    }
}
