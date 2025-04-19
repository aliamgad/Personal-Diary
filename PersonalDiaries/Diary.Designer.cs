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
            this.statusLabel = new System.Windows.Forms.Label();
            this.back_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(113, 39);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textBox.Location = new System.Drawing.Point(99, 102);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(560, 317);
            this.textBox.TabIndex = 1;
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
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
            this.textBoxOFtitle.Location = new System.Drawing.Point(308, 66);
            this.textBoxOFtitle.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxOFtitle.Name = "textBoxOFtitle";
            this.textBoxOFtitle.Size = new System.Drawing.Size(156, 24);
            this.textBoxOFtitle.TabIndex = 2;
            this.textBoxOFtitle.Enter += new System.EventHandler(this.textBoxOFtitle_Enter);
            this.textBoxOFtitle.Leave += new System.EventHandler(this.textBoxOFtitle_Leave);
            // 
            // comboBoxOFTags
            // 
            this.comboBoxOFTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOFTags.FormattingEnabled = true;
            this.comboBoxOFTags.Location = new System.Drawing.Point(660, 44);
            this.comboBoxOFTags.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.comboBoxOFTags.Name = "comboBoxOFTags";
            this.comboBoxOFTags.Size = new System.Drawing.Size(121, 24);
            this.comboBoxOFTags.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Tahoma", 15F);
            this.statusLabel.Location = new System.Drawing.Point(322, 9);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(142, 34);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "New Diary";
            // 
            // back_Button
            // 
            this.back_Button.Location = new System.Drawing.Point(12, 12);
            this.back_Button.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.back_Button.Name = "back_Button";
            this.back_Button.Size = new System.Drawing.Size(70, 41);
            this.back_Button.TabIndex = 5;
            this.back_Button.Text = "Back";
            this.back_Button.UseVisualStyleBackColor = true;
            this.back_Button.Click += new System.EventHandler(this.back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(570, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Tag";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(679, 404);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Diary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.back_Button);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.comboBoxOFTags);
            this.Controls.Add(this.textBoxOFtitle);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.SaveButton);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
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
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button back_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}