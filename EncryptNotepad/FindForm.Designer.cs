
namespace EncryptNotepad
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.findWhatTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downRadioButton = new System.Windows.Forms.RadioButton();
            this.upRadioButton = new System.Windows.Forms.RadioButton();
            this.findTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.replaceButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.replaceWithTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.downRadioButton2 = new System.Windows.Forms.RadioButton();
            this.upRadioButton2 = new System.Windows.Forms.RadioButton();
            this.findWhat2TextBox = new System.Windows.Forms.TextBox();
            this.cancelButton2 = new System.Windows.Forms.Button();
            this.findNextButton2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.findTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // findWhatTextBox
            // 
            this.findWhatTextBox.Location = new System.Drawing.Point(115, 12);
            this.findWhatTextBox.Name = "findWhatTextBox";
            this.findWhatTextBox.Size = new System.Drawing.Size(270, 22);
            this.findWhatTextBox.TabIndex = 0;
            this.findWhatTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.findWhatTextBox_KeyUp);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(391, 11);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 25);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Find Next";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find what :";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(392, 44);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.downRadioButton);
            this.groupBox1.Controls.Add(this.upRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(223, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 60);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // downRadioButton
            // 
            this.downRadioButton.AutoSize = true;
            this.downRadioButton.Location = new System.Drawing.Point(74, 21);
            this.downRadioButton.Name = "downRadioButton";
            this.downRadioButton.Size = new System.Drawing.Size(64, 21);
            this.downRadioButton.TabIndex = 1;
            this.downRadioButton.TabStop = true;
            this.downRadioButton.Text = "Down";
            this.downRadioButton.UseVisualStyleBackColor = true;
            this.downRadioButton.CheckedChanged += new System.EventHandler(this.upRadioButton2_CheckedChanged);
            // 
            // upRadioButton
            // 
            this.upRadioButton.AutoSize = true;
            this.upRadioButton.Location = new System.Drawing.Point(11, 22);
            this.upRadioButton.Name = "upRadioButton";
            this.upRadioButton.Size = new System.Drawing.Size(47, 21);
            this.upRadioButton.TabIndex = 0;
            this.upRadioButton.TabStop = true;
            this.upRadioButton.Text = "Up";
            this.upRadioButton.UseVisualStyleBackColor = true;
            this.upRadioButton.CheckedChanged += new System.EventHandler(this.upRadioButton2_CheckedChanged);
            // 
            // findTab
            // 
            this.findTab.Controls.Add(this.tabPage1);
            this.findTab.Controls.Add(this.tabPage2);
            this.findTab.Location = new System.Drawing.Point(2, 0);
            this.findTab.Name = "findTab";
            this.findTab.SelectedIndex = 0;
            this.findTab.Size = new System.Drawing.Size(499, 178);
            this.findTab.TabIndex = 5;
            this.findTab.SelectedIndexChanged += new System.EventHandler(this.findTab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.findWhatTextBox);
            this.tabPage1.Controls.Add(this.cancelButton);
            this.tabPage1.Controls.Add(this.findButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 171);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Find";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.replaceButton);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.replaceWithTextBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.findWhat2TextBox);
            this.tabPage2.Controls.Add(this.cancelButton2);
            this.tabPage2.Controls.Add(this.findNextButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(491, 149);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Replace";
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(392, 44);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 25);
            this.replaceButton.TabIndex = 12;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Replace with :";
            // 
            // replaceWithTextBox
            // 
            this.replaceWithTextBox.Location = new System.Drawing.Point(115, 45);
            this.replaceWithTextBox.Name = "replaceWithTextBox";
            this.replaceWithTextBox.Size = new System.Drawing.Size(270, 22);
            this.replaceWithTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Find what :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.downRadioButton2);
            this.groupBox2.Controls.Add(this.upRadioButton2);
            this.groupBox2.Location = new System.Drawing.Point(224, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 60);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Direction";
            // 
            // downRadioButton2
            // 
            this.downRadioButton2.AutoSize = true;
            this.downRadioButton2.Location = new System.Drawing.Point(74, 21);
            this.downRadioButton2.Name = "downRadioButton2";
            this.downRadioButton2.Size = new System.Drawing.Size(64, 21);
            this.downRadioButton2.TabIndex = 1;
            this.downRadioButton2.TabStop = true;
            this.downRadioButton2.Text = "Down";
            this.downRadioButton2.UseVisualStyleBackColor = true;
            this.downRadioButton2.CheckedChanged += new System.EventHandler(this.upRadioButton2_CheckedChanged);
            // 
            // upRadioButton2
            // 
            this.upRadioButton2.AutoSize = true;
            this.upRadioButton2.Location = new System.Drawing.Point(11, 22);
            this.upRadioButton2.Name = "upRadioButton2";
            this.upRadioButton2.Size = new System.Drawing.Size(47, 21);
            this.upRadioButton2.TabIndex = 0;
            this.upRadioButton2.TabStop = true;
            this.upRadioButton2.Text = "Up";
            this.upRadioButton2.UseVisualStyleBackColor = true;
            this.upRadioButton2.CheckedChanged += new System.EventHandler(this.upRadioButton2_CheckedChanged);
            // 
            // findWhat2TextBox
            // 
            this.findWhat2TextBox.Location = new System.Drawing.Point(115, 12);
            this.findWhat2TextBox.Name = "findWhat2TextBox";
            this.findWhat2TextBox.Size = new System.Drawing.Size(270, 22);
            this.findWhat2TextBox.TabIndex = 5;
            // 
            // cancelButton2
            // 
            this.cancelButton2.Location = new System.Drawing.Point(392, 75);
            this.cancelButton2.Name = "cancelButton2";
            this.cancelButton2.Size = new System.Drawing.Size(75, 25);
            this.cancelButton2.TabIndex = 8;
            this.cancelButton2.Text = "Cancel";
            this.cancelButton2.UseVisualStyleBackColor = true;
            this.cancelButton2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // findNextButton2
            // 
            this.findNextButton2.Location = new System.Drawing.Point(392, 11);
            this.findNextButton2.Name = "findNextButton2";
            this.findNextButton2.Size = new System.Drawing.Size(75, 25);
            this.findNextButton2.TabIndex = 6;
            this.findNextButton2.Text = "Find Next";
            this.findNextButton2.UseVisualStyleBackColor = true;
            this.findNextButton2.Click += new System.EventHandler(this.findButton_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 191);
            this.Controls.Add(this.findTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find and Replace";
            this.Activated += new System.EventHandler(this.FindForm_Enter);
            this.Deactivate += new System.EventHandler(this.FindForm_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.findTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findWhatTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton downRadioButton;
        private System.Windows.Forms.RadioButton upRadioButton;
        private System.Windows.Forms.TabControl findTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox replaceWithTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton downRadioButton2;
        private System.Windows.Forms.RadioButton upRadioButton2;
        private System.Windows.Forms.TextBox findWhat2TextBox;
        private System.Windows.Forms.Button cancelButton2;
        private System.Windows.Forms.Button findNextButton2;
    }
}