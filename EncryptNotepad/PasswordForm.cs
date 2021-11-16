using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EncryptDecryptSymetric;

namespace EncryptNotepad
{
    public partial class PasswordForm : Form
    {
        public byte[] key;
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (passwordTxt.Text != String.Empty)
            {
                key = HashGenerator.ComputeSha256Hash(passwordTxt.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            

        }

        private void passwordTxt_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {  
                okBtn_Click(new object(), new EventArgs());
            }
        }
    }
}
