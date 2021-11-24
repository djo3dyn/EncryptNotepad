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
        private bool downDirection;
        private bool exiting = false;
        public FindForm(string text , string replaceText , IFindReplace findReplace , bool down , bool replace)
        {
            InitializeComponent();
            findText = text;
            replaceWithTextBox.Text = replaceText;
            findWhatTextBox.Text = findText;
            mfindReplace = findReplace;
            downDirection = down;
            if (down) downRadioButton.Checked = true;
            else upRadioButton.Checked = true;
            if (findWhatTextBox.Focus()) Console.WriteLine("Focus....");

            if (replace)
            {
                findTab.SelectedTab = tabPage2;
                if (down) downRadioButton2.Checked = true;
                else upRadioButton2.Checked = true;

            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (findTab.SelectedTab == tabPage1) findText = findWhatTextBox.Text;
            else if (findTab.SelectedTab == tabPage2) findText = findWhat2TextBox.Text;
            if (mfindReplace != null)mfindReplace.FindNext(findText , downDirection);

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
            exiting = true;
            this.Close();
        }

        private void FindForm_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!exiting) this.Opacity = 0.7;
            }
            catch(Win32Exception)
            {
                // Do nothing
            }
        }

        private void FindForm_Enter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void findTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            findWhat2TextBox.Text = findText;
            findWhatTextBox.Text = findText;
            if (downDirection)
            {
                upRadioButton.Checked = upRadioButton2.Checked = false;
                downRadioButton.Checked = downRadioButton2.Checked = true;
            }
            else
            {
                upRadioButton.Checked = upRadioButton2.Checked = true;
                downRadioButton.Checked = downRadioButton2.Checked = false;
            }
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            findText = findWhat2TextBox.Text;
            if (mfindReplace != null) mfindReplace.Replace(findText, replaceWithTextBox.Text , downDirection);
        }

        private void upRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (findTab.SelectedTab == tabPage1) downDirection = downRadioButton.Checked;
            else if (findTab.SelectedTab == tabPage2) downDirection = downRadioButton2.Checked;
        }
    }
}
