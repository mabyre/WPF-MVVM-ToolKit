using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using MvvmFramework.ViewModel;
using System.Windows.Media;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.ComponentModel;

namespace WPFPrimsToolKit.ViewModels
{
    public class InvokeCommandActionSampleViewModel : BaseViewModel
    {
        #region Public Variables
        public Brushes Brushes
        {
            get;
            private set;
        }

        /// <summary>
        /// The <see cref="LastUsedBrush" /> property's name.
        /// </summary>
        public const string LastUsedBrushPropertyName = "LastUsedBrush";

        private Brush _lastUsedBrush;

        /// <summary>
        /// Gets the LastUsedBrush property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Brush LastUsedBrush
        {
            get
            {
                return _lastUsedBrush;
            }

            private set
            {
                if (_lastUsedBrush == value)
                {
                    return;
                }

                _lastUsedBrush = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(LastUsedBrushPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Status" /> property's name.
        /// </summary>
        public const string StatusPropertyName = "Status";

        private string _status = "Initialized...";

        /// <summary>
        /// Gets the Status property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }

            private set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(StatusPropertyName);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the InvokeCommandActionSampleViewModel class.
        /// </summary>
        public InvokeCommandActionSampleViewModel()
        {
            Brushes = new Brushes();
            LastUsedBrush = Brushes.None;

            SimpleCommand = new DelegateCommand(() =>
            {
                Status = "Simple command executed";
                LastUsedBrush = Brushes.Brush1;
            });

            ResetCommand = new DelegateCommand(() =>
            {
                Status = "Activate a Command";
                LastUsedBrush = Brushes.None;
            });

            ParameterCommand1 = new DelegateCommand<string>(this.OnParameterCommand1);

            ParameterCommand2 = new DelegateCommand<string>(this.OnParameterCommand2);

            DisablableCommand = new DelegateCommand<string>(this.OnDisableCommand);

            // Breuk !
            //DisablableCommand = new DelegateCommand<string>(p =>
            //{
            //    Status = string.Format("Disablable command executed ({0})", p);
            //    LastUsedBrush = Brushes.Brush4;
            //},
            //p => p != "Hello");

            DisablableCommand = new DelegateCommand<string>(this.OnDisableCommand, this.CanExecuteDisableCommand);

            MoveMouseCommand = new DelegateCommand<MouseEventArgs>(this.OnMoveMouseCommand);

        }

        public ICommand ResetCommand { get; private set; }
        public ICommand SimpleCommand { get; private set; }

        public ICommand ParameterCommand1 { get; private set; }

        private void OnParameterCommand1(string param)
        {
            Status = string.Format("Parameter command executed ({0})", param);
            LastUsedBrush = Brushes.Brush2;
        }

        public ICommand ParameterCommand2 { get; private set; }

        private void OnParameterCommand2(string param)
        {
            Status = string.Format("Parameter command executed ({0})", param);
            LastUsedBrush = Brushes.Brush3;
        }

        public DelegateCommand<string> DisablableCommand { get; private set; }

        private void OnDisableCommand(string param)
        {
            if (param != "Hello")
            {
                Status = string.Format("Parameter command executed ({0})", param);
                LastUsedBrush = Brushes.Brush4;
            }
        }

        private bool CanExecuteDisableCommand(string param)
        {
            if (param != "Hello")
            {
                return true;
            }
            return false;
        }

        public DelegateCommand<MouseEventArgs> MoveMouseCommand { get; private set; }

        private void OnMoveMouseCommand(MouseEventArgs mouseArg)
        {
            if (mouseArg != null)
            {
                var element = mouseArg.OriginalSource as UIElement;
                var point = mouseArg.GetPosition(element);

                Status = string.Format("Position: {0}x{1}", point.X, point.Y);
                LastUsedBrush = Brushes.Brush5;
            }
        }
    }
}
