using StringFormatter.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
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
            var sb = new StringBuilder();
            var opts = ViewModel.SplitOptions;
            var stringSeparators = new string[] { "\r\n" };
            var sbFmt = new StringBuilder();
            string[] lines;

            var find = Regex.Matches(ViewModel.StringFormat, @"\{[^\d]+\}");

            if (find.Count > 0)
            {
                foreach (var s in find)
                {
                    var xx = s.ToString().Replace("{", "{{").Replace("}", "}}");
                    sbFmt.Append(Regex.Replace(ViewModel.StringFormat, @"\{[^\d]+\}", xx));
                }
            }
            else
            {
                
            }

            if (opts[0] == "\\r\\n")
            {
                lines = ViewModel.Items.Split(stringSeparators, StringSplitOptions.None);
            }
            else
            {
                lines = ViewModel.Items.Split(opts[0].ToCharArray(), StringSplitOptions.None);
            }

            if (opts.Count > 1)
            {
                foreach (var strToSplit in lines)
                {
                    string[] tmpStr;

                    if (opts[1] == "\\r\\n")
                    {
                        tmpStr = strToSplit.Split(stringSeparators, StringSplitOptions.None);
                    }
                    else
                    {
                        tmpStr = strToSplit.Split(opts[1].ToCharArray(), StringSplitOptions.None);
                    }

                    sb.AppendLine(string.Format(sbFmt.ToString(), tmpStr as object[]));
                }
            }
            else
            {
                foreach (var str in lines)
                {
                    sb.AppendLine(string.Format(sbFmt.ToString(), str));
                }
            }

            sb.Replace("{{", "{").Replace("}}", "}");
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
