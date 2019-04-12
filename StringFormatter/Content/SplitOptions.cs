using System.Collections.ObjectModel;

namespace StringFormatter.Content
{
    public static class SplitOptions
    {
        public static ObservableCollection<ISplitOption> GetSplitOptions()
        {
            var opts = new ObservableCollection<ISplitOption>();
            opts.Add(new SplitOption { DisplayText = "CRLF", Value ="\\r\\n" });
            opts.Add(new SplitOption { DisplayText = "Comma", Value = "," });
            opts.Add(new SplitOption { DisplayText = "Back Slash (\\)", Value = "\\" });
            opts.Add(new SplitOption { DisplayText = "Forward Slash (/)", Value = "/" });
            opts.Add(new SplitOption { DisplayText = "Pipe (|)", Value = "|" });
            opts.Add(new SplitOption { DisplayText = "Other", Value = "Other" });

            return opts;
        }
    }

    public class SplitOption : ISplitOption
    {
        public string DisplayText { get; set; }
        public string Value { get; set; }
    }

    public interface ISplitOption
    {
        string DisplayText { get; set; }
        string Value { get; set; }

    }
}
