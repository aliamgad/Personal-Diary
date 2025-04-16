using System.Drawing;
using System.Windows.Forms;

namespace Personal_Diary_Application
{
    partial class Home
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
            this.dark_mode_btn = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dark_mode_btn
            // 
            this.dark_mode_btn.AutoSize = true;
            this.dark_mode_btn.Location = new System.Drawing.Point(596, 25);
            this.dark_mode_btn.Name = "dark_mode_btn";
            this.dark_mode_btn.Size = new System.Drawing.Size(77, 17);
            this.dark_mode_btn.TabIndex = 0;
            this.dark_mode_btn.Text = "Dark Mode";
            this.dark_mode_btn.UseVisualStyleBackColor = true;
            this.dark_mode_btn.CheckedChanged += new System.EventHandler(this.dark_mode_btn_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.tag,
            this.CreatedAt});
            this.dataGridView1.Location = new System.Drawing.Point(36, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(344, 255);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // title
            // 
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            // 
            // tag
            // 
            this.tag.HeaderText = "Tag";
            this.tag.Name = "tag";
            // 
            // CreatedAt
            // 
            this.CreatedAt.HeaderText = "CreatedAt";
            this.CreatedAt.Name = "CreatedAt";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dark_mode_btn);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox dark_mode_btn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn tag;
        private DataGridViewTextBoxColumn CreatedAt;
    }
}