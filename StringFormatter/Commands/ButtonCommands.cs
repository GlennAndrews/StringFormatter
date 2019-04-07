using StringFormatter.ViewModels;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;

namespace StringFormatter.Commands
{
    public class ButtonCommands
    {
        #region Properties
        public StringFormatterViewModel ViewModel { get; set; }
        #endregion

        #region Build Command
        private ICommand _buttonBuildClick;
        public ICommand CmdBuild
        {
            get
            {
                if (_buttonBuildClick == null)
                {
                    _buttonBuildClick = new RelayCommand(
                        p => true,
                        p => this.Build());
                }
                return _buttonBuildClick;
            }
        }

        /// <summary>
        /// Handles click on the button
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Build()
        {
            var sb = new System.Text.StringBuilder();

            if (!string.IsNullOrWhiteSpace(ViewModel.Input))
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = ViewModel.Input.Split(stringSeparators, StringSplitOptions.None);

                sb.AppendLine("var sb = new StringBuilder();\r\n");

                foreach (var line in lines)
                {
                    sb.AppendLine($"sb.AppendLine(\"{line}\");");
                }
            }

            ViewModel.Output = sb.ToString();
        }
        #endregion

        #region Copy Command
        private ICommand _buttonCopyClick;
        public ICommand CmdCopy
        {
            get
            {
                if (_buttonCopyClick == null)
                {
                    _buttonCopyClick = new RelayCommand(
                        p => true,
                        p => this.Copy());
                }
                return _buttonCopyClick;
            }
        }

        /// <summary>
        /// Handles click on the button
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Copy()
        {
            Clipboard.SetText(ViewModel.Output);
        }

        #endregion
    }
}
