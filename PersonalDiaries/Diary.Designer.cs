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
            this.SaveButton.Location = new System.Drawing.Point(113, 39);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(99, 102);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(560, 316);
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
            this.textBoxOFtitle.Location = new System.Drawing.Point(308, 66);
            this.textBoxOFtitle.Name = "textBoxOFtitle";
            this.textBoxOFtitle.Size = new System.Drawing.Size(156, 24);
            this.textBoxOFtitle.TabIndex = 2;
            // 
            // comboBoxOFTags
            // 
            this.comboBoxOFTags.FormattingEnabled = true;
            this.comboBoxOFTags.Location = new System.Drawing.Point(576, 39);
            this.comboBoxOFTags.Name = "comboBoxOFTags";
            this.comboBoxOFTags.Size = new System.Drawing.Size(121, 24);
            this.comboBoxOFTags.TabIndex = 3;
            // 
            // Diary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxOFTags);
            this.Controls.Add(this.textBoxOFtitle);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.SaveButton);
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