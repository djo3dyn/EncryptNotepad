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
        public FindForm()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            findText = findWhatTextBox.Text;
            this.DialogResult = DialogResult.OK;

        }
    }
}
