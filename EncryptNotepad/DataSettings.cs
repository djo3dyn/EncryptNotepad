using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

namespace EncryptNotepad
{
    public class DataSettings
    {
        // Font
        public string FontName { get; set; }
        public float FontSize { get; set; }
        public FontStyle FontStyle { get; set; }

        // Format
        public bool WordwrapEnable { get; set; }

        // Find Replace
        public string FindText { get; set; }
        public string ReplaceText { get; set; }
        public bool DownDirection { get; set; }

        // view
        public bool StatusBarShow { get; set; }

        //public string CurrentFileName { get; set; }

    }
}
