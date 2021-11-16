using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptNotepad
{
    public interface IFindReplace
    {
        void FindNext(string text);
        void Replate(string text, string replaceText);
    }
}
