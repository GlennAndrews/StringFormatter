using StringFormatter.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace StringFormatter.ViewModels
{
    public class SplitOptionsViewModel : INotifyPropertyChanged, ISplitOptionsViewModel
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public StringFormatterViewModel ParentVM { get; set; }
        public SplitOptionsViewModel ViewModel { get; set; }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != this._value)
                {
                    this._value = value;
                    ShowTextbox = this._value == "Other" ? "Visible" : "Hidden";
                    NotifyPropertyChanged();
                }
            }
        }

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

        private string _otherSplitBy;
        public string OtherSplitBy
        {
            get
            {
                return _otherSplitBy;
            }
            set
            {
                if (value != this._otherSplitBy)
                {
                    this._otherSplitBy = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<ISplitOption> AvailableOptions => Content.SplitOptions.GetSplitOptions();

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

    #region Interface
    public interface ISplitOptionsViewModel
    {
        StringFormatterViewModel ParentVM { get; set; }
        SplitOptionsViewModel ViewModel { get; set; }
        string LabelText { get; set; }
        //string SelectedOption { get; set; }
        string ShowTextbox { get; set; }
        string Value { get; set; }
        string OtherSplitBy { get; set; }
        ObservableCollection<ISplitOption> AvailableOptions { get; }
    }
    #endregion
}
