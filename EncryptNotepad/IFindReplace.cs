
namespace EncryptNotepad
{
    public interface IFindReplace
    {
        void FindNext(string text , bool dir);
        void Replace(string text, string replaceText , bool dir);
        void SetActive(bool active);
    }
}
