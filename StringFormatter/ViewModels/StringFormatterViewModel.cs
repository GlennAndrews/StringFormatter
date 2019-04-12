using StringFormatter.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StringFormatter.ViewModels
{
    public class StringFormatterViewModel : INotifyPropertyChanged
    {
        #region Privates
        private ButtonCommands _buttonCommands;
        private ObservableCollection<SplitOptions> _splitOptionsControls = new ObservableCollection<SplitOptions>();
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Buttons
        public ICommand CmdBuild => _buttonCommands.CmdBuild;
        public ICommand CmdCopy => _buttonCommands.CmdCopy;
        #endregion

        #region Properties
        public ObservableCollection<SplitOptions> SplitOptionControls
        {
            get
            {
                return _splitOptionsControls;
            }
            set
            {
                if(this._splitOptionsControls != value)
                {
                    this._splitOptionsControls = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _stringFormat;
        public string StringFormat
        {
            get
            {
                return _stringFormat;
            }
            set
            {
                if (value != this._stringFormat)
                {
                    this._stringFormat = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _items;
        public string Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (value != this._items)
                {
                    this._items = value;
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

        public List<string> SplitOptions
        {
            get
            {
                var opts = new List<string>();

                foreach (var ctrl in _splitOptionsControls)
                {
                    var selectedItem = (ctrl.DataContext as SplitOptionsViewModel).Value;
                    if(!string.IsNullOrWhiteSpace(selectedItem))
                    {
                        if (selectedItem.EndsWith("Other"))
                        {
                            var otherSplitBy = (ctrl.DataContext as SplitOptionsViewModel).OtherSplitBy;
                            opts.Add(otherSplitBy);
                        }
                        else
                        {
                            opts.Add(selectedItem);
                        }
                    }
                    
                }

                return opts;
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

            addSplitOptionControl("Split By:");
            addSplitOptionControl("Then By:");

        }
        #endregion

        #region Private Methods
        private void addSplitOptionControl(string labelText)
        {
            var ctrl = new SplitOptions();
            var vm = new SplitOptionsViewModel();

            ctrl.DataContext = vm;
            vm.ParentVM = this;
            vm.LabelText = labelText;

            SplitOptionControls.Add(ctrl);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
