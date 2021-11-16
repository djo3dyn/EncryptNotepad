using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncryptNotepad
{
    public partial class FindForm : Form
    {
        public string findText;
        private IFindReplace mfindReplace;
        public FindForm(string text , IFindReplace findReplace)
        {
            InitializeComponent();
            findText = text;
            findWhatTextBox.Text = findText;
            mfindReplace = findReplace;
            this.TopMost = true;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            findText = findWhatTextBox.Text;
            if (mfindReplace != null) mfindReplace.FindNext(findText);
            //this.DialogResult = DialogResult.OK;

        }

        private void findWhatTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                findButton_Click(new object(), new EventArgs());
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindForm_Leave(object sender, EventArgs e)
        {
            if (!this.IsDisposed)
            {
                this.Opacity = 0.5;
            }
            
        }

        private void FindForm_Enter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }
    }
}
