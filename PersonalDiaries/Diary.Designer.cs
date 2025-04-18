namespace PersonalDiaries
{
    partial class Diary
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
            this.components = new System.ComponentModel.Container();
            this.SaveButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxOFtitle = new System.Windows.Forms.TextBox();
            this.comboBoxOFTags = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(97, 32);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(64, 19);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox.Location = new System.Drawing.Point(85, 83);
            this.textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(481, 258);
            this.textBox.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxOFtitle
            // 
            this.textBoxOFtitle.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxOFtitle.Location = new System.Drawing.Point(264, 54);
            this.textBoxOFtitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOFtitle.Name = "textBoxOFtitle";
            this.textBoxOFtitle.Size = new System.Drawing.Size(134, 20);
            this.textBoxOFtitle.TabIndex = 2;
            // 
            // comboBoxOFTags
            // 
            this.comboBoxOFTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOFTags.FormattingEnabled = true;
            this.comboBoxOFTags.Location = new System.Drawing.Point(494, 32);
            this.comboBoxOFTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxOFTags.Name = "comboBoxOFTags";
            this.comboBoxOFTags.Size = new System.Drawing.Size(104, 21);
            this.comboBoxOFTags.TabIndex = 3;
            // 
            // Diary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 366);
            this.Controls.Add(this.comboBoxOFTags);
            this.Controls.Add(this.textBoxOFtitle);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.SaveButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Diary";
            this.Text = "Diary";
            this.Load += new System.EventHandler(this.Diary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxOFtitle;
        private System.Windows.Forms.ComboBox comboBoxOFTags;
    }
}