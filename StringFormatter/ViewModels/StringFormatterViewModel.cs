using StringFormatter.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StringFormatter.ViewModels
{
    public class StringFormatterViewModel : INotifyPropertyChanged
    {
        #region Privates
        private ButtonCommands _buttonCommands;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Buttons
        //public ICommand CmdBuild => _buttonCommands.CmdBuild;
        //public ICommand CmdCopy => _buttonCommands.CmdCopy;
        #endregion

        #region Properties
        private string _input;
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                if (value != this._input)
                {
                    this._input = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _output;
        public string Output
        {
            get
            {
                return _output;
            }
            set
            {
                if (value != this._output)
                {
                    this._output = value;
                    NotifyPropertyChanged();
                }

            }
        }
        #endregion

        #region Constructors
        public StringFormatterViewModel()
        {
            _buttonCommands = new ButtonCommands
            {
                ViewModel = this
            };
        }
        #endregion

        #region Private Methods
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
