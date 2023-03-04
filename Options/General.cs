using System.ComponentModel;
using System.Runtime.InteropServices;

namespace OpenFileInExternalApplication
{
    internal partial class OptionsProvider
    {
        // Register the options with this attribute on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "OpenFileInExternalApplication", "General", 0, 0, true, SupportsProfiles = true)]
        [ComVisible(true)]
        public class GeneralOptions : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>
    {
        [Category("External App")]
        [DisplayName("Application path")]
        [Description("Path to appilcation file")]
        [DefaultValue("notepad.exe")]
        public string ExternalApp { get; set; }

        [Category("External App")]
        [DisplayName("Arguments")]
        [Description("Arguments will be inserted before active file path")]
        [DefaultValue("")]
        public string Args { get; set; }
    }
}
