using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StringFormatter.ViewModels
{
    public class SplitOptionsViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public StringFormatterViewModel ParentVM { get; set; }
        public SplitOptionsViewModel ViewModel { get; set; }

        private string _label = "Split By:";
        public string LabelText
        {
            get
            {
                return _label;
            }
            set
            {
                if (value != this._label)
                {
                    this._label = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _option;
        public string SelectedOption
        {
            get
            {
                return _option;
            }
            set
            {
                if (value != this._option)
                {
                    this._option = value;

                    ShowTextbox = this._option.EndsWith("Other") ? "Visible" : "Hidden";

                    NotifyPropertyChanged();
                }
            }
        }

        private string _showTextbox = "Hidden";
        public string ShowTextbox
        {
            get
            {
                return _showTextbox;
            }
            set
            {
                if (value != this._showTextbox)
                {
                    this._showTextbox = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        public SplitOptionsViewModel()
        {
            ViewModel = this;
        }

        #region Private Methods
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
