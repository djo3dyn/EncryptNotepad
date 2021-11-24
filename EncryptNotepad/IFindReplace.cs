using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptNotepad
{
    public interface IFindReplace
    {
        void FindNext(string text , bool dir);
        void Replace(string text, string replaceText , bool dir);
        void SetActive(bool active);
    }
}
