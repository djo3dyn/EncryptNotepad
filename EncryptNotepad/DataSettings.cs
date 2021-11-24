using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EncryptNotepad
{
    public class DataSettings
    {
        // Font
        public string fontName { get; set; }
        public float fontSize { get; set; }
        public FontStyle fontStyle { get; set; }

        // Format
        public bool wordwrapEnable { get; set; }

        // Find Replace
        public string findText { get; set; }
        public string replaceText { get; set; }
        public bool downDirection { get; set; }

        // view
        public bool statusBarShow { get; set; }

    }
}
