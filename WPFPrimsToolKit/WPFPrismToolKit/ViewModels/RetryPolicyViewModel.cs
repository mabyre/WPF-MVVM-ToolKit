using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmFramework.ViewModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace WPFPrimsToolKit.ViewModels
{
    public class RetryPolicyViewModel : BaseViewModel
    {
        public const string TextBoxTextPropertyName = "TextBoxText";
        private string _textBoxText = "Value initialized..." + Environment.NewLine;
        public string TextBoxText
        {
            get { return _textBoxText; }

            set
            {
                if ( _textBoxText == value )
                {
                    return;
                }

                _textBoxText = value;
                
                // Update bindings, no broadcast
                RaisePropertyChanged( TextBoxTextPropertyName );
            }
        }

        public DelegateCommand SimpleCommand { get; private set; }

        public RetryPolicyViewModel()
        {
            SimpleCommand = new DelegateCommand(() =>
            {
                TextBoxText = "You clicked on Ok!";
            });
        }
    }
}
