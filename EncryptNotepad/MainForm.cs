using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Xml.Serialization;
using System.Reflection;
// Custom Directive
using EncryptDecryptSymetric;

namespace EncryptNotepad
{
    public partial class MainForm : Form, IFindReplace
    {
        // Main Text Box :
        private string currentFileName;
        private string defaultFileName;
        private FileStream textStream;
        private bool edited;
        private bool encrypted;
        private bool forceEdit;

        // Find replace
        private string currentFindText;
        private string currentReplaceText;
        private int findPos = 0;
        private bool downDirection = true;
        private bool findingActive = false;

        // Status bar
        private Encoding textEncoding;
        private string newlineType;
        // File path
        string appPath;
        public MainForm(string[] args)
        {
            InitializeComponent();
            
            defaultFileName = "Untitled";
            CryptpadUpdate();
            if (args != null)
            {
                if (args.Length == 1)
                {
                    openFile(args[0]);
                }
                
            }
            else
            {
                
            }
            appPath = Application.StartupPath;
            // Load Settings
            LoadSettings();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CryptpadUpdate()
        {
            if (currentFileName == null)
            {
                currentFileName = defaultFileName;
                SetWindowTitle(currentFileName);
            }
        }

        private void SetWindowTitle(string text)
        {
            bool fullPath = false;
            string tempText = null;
            string encryptext = null;
            string editedText = null;
            if (fullPath) tempText = text;
            else
            {
                string[] spitFileName = text.Split('\\');
                tempText = spitFileName[spitFileName.Length - 1];
            }

            if (encrypted) encryptext = "[Encrypted]";
            else encryptext = String.Empty;

            if (edited) editedText = "*";
            else editedText = String.Empty;

            string header = " - Cryptpad";
            this.Text = tempText + editedText + encryptext + header;
        }

        private void newCryptpad()
        {
            mainTextBox.Clear();
            // My init
            currentFileName = defaultFileName;
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            SetWindowTitle(currentFileName);
            edited = false;
            cryptUIUpdate();

        }

        private void openFile(string fileName)
        {
            // Try to pen file
            FileStream fsSource;
            try
            {
                fsSource = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
            catch(Exception)
            {
                MsgBox.ShowError("Cryptpad", "Can not open file");
                return;
            }

            // Init file name
            int fileSize = (int)fsSource.Length;
            Console.WriteLine(fileSize);
            byte[] fileBytes = new byte[fileSize];
            string encodedTextTemp = String.Empty;

            using (StreamReader reader = new StreamReader(fsSource))
            {
                encodedTextTemp = reader.ReadToEnd();
                textEncoding = reader.CurrentEncoding;
                Console.WriteLine("The encoding used was {0}.", reader.CurrentEncoding);
            }
            if (encodedTextTemp.Contains("\r\n"))
            {
                newlineType = "Windows (CRLF)";

            }
            else if (encodedTextTemp.Contains("\n"))
            {
                newlineType = "Unix (LF)";

            }

            using (StringReader reader = new StringReader(encodedTextTemp))
            {
                string temp = String.Empty;
                string textBoxTemp = String.Empty;
                while (true)
                {
                    if ((temp = reader.ReadLine()) != null) textBoxTemp += temp + "\r\n";
                    else break;
                }
                mainTextBox.Text = textBoxTemp;

            }

            currentFileName = fileName;
            edited = false;
            SetWindowTitle(currentFileName);
            mainTextBox.Select(0, 0);
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            cryptUIUpdate();
        }

        private bool saveConfirmation()
        {
            if (edited)
            {
                String textMessage = "Do you want to save " + currentFileName + " ?";
                DialogResult result = MessageBox.Show(textMessage, "Cryptpad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (saveAsFile()) return true;
                    else return false;
                }
                else if (result == DialogResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        private bool saveAsFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFileName = saveFileDialog1.FileName;
                saveFile();
                return true;
            }
            else
            {
                return false;
            }

        }

        private void saveFile()
        {
            textStream = new FileStream(currentFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (textStream != null)
            {
                using (StreamWriter sw = new StreamWriter(textStream))
                {
                    sw.Write(mainTextBox.Text);
                }
                textStream.Close();
                edited = false;
                SetWindowTitle(currentFileName);
            }

        }

        private bool cryptConfirmation(bool encrypted)
        {
            String crypt = null;
            if (encrypted) crypt = "encrypted";
            else crypt = "decrypted";
            String textMessage = "This text looks like already " + crypt + "\nDo you want to continue  ?";
            DialogResult result = MessageBox.Show(textMessage, "Cryptpad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool cryptEditConfirmation()
        {

            String textMessage = "This text looks like encrypted. Editing text may cause this file cannot be decrypted.\nDo you want to continue edit this text?";
            DialogResult result = MessageBox.Show(textMessage, "Cryptpad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void cryptUIUpdate()
        {
            if (encrypted)
            {
                mainTextBox.ReadOnly = true;
                forceEdit = false;
            }
            else mainTextBox.ReadOnly = false;
            SetWindowTitle(currentFileName);
            statusBarUpdate();

        }

        private void statusBarUpdate()
        {
            if (encrypted) cryptStatus.Text = "Encrypted";
            else cryptStatus.Text = "Decrypted";

            newlineStatus.Text = newlineType;

            if (textEncoding == Encoding.ASCII) encodingStatus.Text = "ASCII";
            else if (textEncoding == Encoding.UTF8) encodingStatus.Text = "UTF-8";
            else if (textEncoding == Encoding.Unicode) encodingStatus.Text = "Unicode";
            else if (textEncoding == Encoding.UTF7) encodingStatus.Text = "UTF-7";
            else if (textEncoding == Encoding.Default) encodingStatus.Text = "Default";
            else if (textEncoding == Encoding.BigEndianUnicode) encodingStatus.Text = "Unicode BE";
            else encodingStatus.Text = "Unknow";

        }

        private void GetCursorPosition()
        {
            int carretIndex = mainTextBox.SelectionStart;
            int lineNumber = mainTextBox.GetLineFromCharIndex(carretIndex);
            int indexCurrentLine = mainTextBox.GetFirstCharIndexOfCurrentLine();
            int colPosition =  carretIndex - indexCurrentLine;

            positionStatus.Text = "Ln " + lineNumber + " , Col " + colPosition;

        }

        private void ShowStatusBar(bool show , bool first)
        {
            if (!show)
            {
                statusBar.Hide();
                mainTextBox.Height += statusBar.Height;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusBar.Show();
                if (!first) mainTextBox.Height -= statusBar.Height;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        private void saveSettings()
        {
            DataSettings settings = new DataSettings()
            {
                fontName = mainTextBox.Font.Name,
                fontSize = mainTextBox.Font.Size,
                fontStyle = mainTextBox.Font.Style,
                wordwrapEnable = mainTextBox.WordWrap,
                findText = currentFindText,
                replaceText = currentReplaceText,
                downDirection = this.downDirection,
                statusBarShow = statusBarToolStripMenuItem.Checked
            };
            XmlSerializer serializer = new XmlSerializer(typeof(DataSettings));
            using (TextWriter writer = new StreamWriter(appPath +"\\settings.config"))
            {
                serializer.Serialize(writer, settings);
            }
        }

        private void LoadSettings()
        {
            DataSettings settings = new DataSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(DataSettings));
            try
            {
                TextReader reader = new StreamReader(appPath + "\\settings.config");
                settings = (DataSettings)serializer.Deserialize(reader);
                reader.Close();
                // Debug
                Console.WriteLine("Font Setting : {0} , {1} , {2}", settings.fontName, settings.fontSize, settings.fontStyle);
                // Fetch data
                Font font = new Font(settings.fontName, settings.fontSize, settings.fontStyle);
                mainTextBox.Font = font;
                currentFindText = settings.findText;
                currentReplaceText = settings.replaceText;
                downDirection = settings.downDirection;
                mainTextBox.WordWrap = wordWrapToolStripMenuItem.Checked = settings.wordwrapEnable;
                statusBarToolStripMenuItem.Checked = settings.statusBarShow;
                ShowStatusBar(settings.statusBarShow , true);
            }
            catch (Exception)
            {
                // Do Nothing....
            }
            

        }
        // Interface Implementation -------------------------------------
        public void FindNext(string text, bool down)
        {
            currentFindText = text;
            downDirection = down;
            if (down) findPos = mainTextBox.Text.IndexOf(currentFindText, mainTextBox.SelectionStart + mainTextBox.SelectedText.Length, StringComparison.CurrentCultureIgnoreCase);
            else findPos = mainTextBox.Text.LastIndexOf(currentFindText, mainTextBox.SelectionStart, StringComparison.CurrentCultureIgnoreCase);

            try
            {
                mainTextBox.Focus();
                mainTextBox.Select(findPos, currentFindText.Length);
                mainTextBox.ScrollToCaret();
            }
            catch (ArgumentOutOfRangeException)
            {
                MsgBox.ShowWarning("Cryptpad", "Can't find \"" + currentFindText + "\"");
                findPos = mainTextBox.SelectionStart;
            }
        }

        public void Replace(string text, string replaceText, bool dir)
        {
            if (findPos > 0)
            {
                mainTextBox.Text = mainTextBox.Text.Remove(findPos, currentFindText.Length);
                mainTextBox.Text = mainTextBox.Text.Insert(findPos, replaceText);
                mainTextBox.Select(findPos + replaceText.Length, 0);
            }
            currentReplaceText = replaceText;
            FindNext(text, dir);
        }

        public void SetActive(bool active)
        {
            findingActive = active;
        }


            // UI Listener ========================================================

            // Encrypt - Decrypt -----
        private void encryptMenu_Click(object sender, EventArgs e)
        {
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            if (encrypted)
            {
                if (!cryptConfirmation(encrypted)) return;
            }

            if (mainTextBox.Text != String.Empty)
            {
                PasswordForm pwd = new PasswordForm();
                DialogResult res = pwd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    byte[] key = pwd.key;
                    string encryptedText = AesOperation.EncryptString(key, mainTextBox.Text);
                    mainTextBox.Text = encryptedText;
                    edited = true;
                    forceEdit = false;
                    mainTextBox.Select(0, 0);
                }
                
            }
            else
            {
                MsgBox.ShowError("Error", "Text Empty");
            }
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            cryptUIUpdate();

        }

        private void decryptMenu_Click(object sender, EventArgs e)
        {
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            if (!encrypted)
            {
                if (!cryptConfirmation(encrypted)) return;
            }
            if (mainTextBox.Text != String.Empty )
            {
                PasswordForm pwd = new PasswordForm();
                DialogResult res = pwd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    byte[] key = pwd.key;
                    string decryptedText = AesOperation.DecryptString(key, mainTextBox.Text);
                    if (decryptedText == null)
                    {
                        MsgBox.ShowError("Decrypt failed", "Failed to decrypt, wrong password or encrypted text has modified");
                    }
                    else
                    {
                        mainTextBox.Text = decryptedText;
                        edited = true;
                        forceEdit = false;
                        mainTextBox.Select(0, 0);
                        
                    }
                    
                }
            }
            else
            {
                MsgBox.ShowError("Error", "Text Empty");
            }
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            cryptUIUpdate();

        }

        // Main TextBox Behavior
        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!edited)
            {
                edited = true;
                SetWindowTitle(currentFileName);
            }
        }
        private void mainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (encrypted && !forceEdit)
            {
                if ((e.KeyValue >= 32 && e.KeyValue <= 255) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {

                    if (cryptEditConfirmation())
                    {
                        mainTextBox.ReadOnly = false;
                        forceEdit = true;
                    }
                }
                e.Handled = true;
            }
            GetCursorPosition();
            
        }

        private void mainTextBox_Validated(object sender, EventArgs e)
        {
            encrypted = AesOperation.CheckEncrypted(mainTextBox.Text);
            SetWindowTitle(currentFileName);


        }

        // File menu--------
        private void newMenu_Click(object sender, EventArgs e)
        {
            if (saveConfirmation()) newCryptpad();
        }

        private void newWinMenu_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(typeof(Program).Assembly.GetName().Name);

        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (!saveConfirmation()) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(openFileDialog.FileName);   
            }

        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            if (edited)
            {
                if (currentFileName == defaultFileName) saveAsMenu_Click(new object(), new EventArgs());
                else
                {
                    saveFile();
                }
            }

        }

        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            if (saveConfirmation()) this.Close();
        }

        

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saveConfirmation()) e.Cancel = true;
            else saveSettings();
        }



        // Edit menu
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Undo();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Paste();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm find = new FindForm(currentFindText , currentReplaceText , this , downDirection , false);
            find.Show(this);
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFindText == null)
            {
                findToolStripMenuItem_Click(new object(), new EventArgs());
            }
            else FindNext(currentFindText , true);
        }
        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFindText == null)
            {
                findToolStripMenuItem_Click(new object(), new EventArgs());
            }
            else FindNext(currentFindText, false);
        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm find = new FindForm(currentFindText, currentReplaceText, this, downDirection, true);
            find.Show(this);

        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.SelectAll();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int position = mainTextBox.SelectionStart;
            mainTextBox.Text = mainTextBox.Text.Insert(2, DateTime.Now.ToString());
        }

        // Format menu ........
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = mainTextBox.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                mainTextBox.Font = fontDialog.Font;
            }
        }
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                mainTextBox.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                mainTextBox.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        // View menu
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStatusBar(!statusBarToolStripMenuItem.Checked, false);
           

        }

        private void testButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void loadSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void mainTextBox_Click_1(object sender, EventArgs e)
        {
            GetCursorPosition();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm about = new AboutBoxForm();
            about.Show(this);
        }
    } 
    
}
