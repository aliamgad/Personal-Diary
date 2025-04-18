﻿using System.Drawing;
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
            this.New_Diary = new System.Windows.Forms.Button();
            this.manageTags = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dark_mode_btn
            // 
            this.dark_mode_btn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dark_mode_btn.Location = new System.Drawing.Point(506, 25);
            this.dark_mode_btn.Name = "dark_mode_btn";
            this.dark_mode_btn.Size = new System.Drawing.Size(135, 35);
            this.dark_mode_btn.TabIndex = 0;
            this.dark_mode_btn.Text = "Dark Mode";
            this.dark_mode_btn.UseVisualStyleBackColor = true;
            this.dark_mode_btn.CheckedChanged += new System.EventHandler(this.dark_mode_btn_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(437, 353);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // New_Diary
            // 
            this.New_Diary.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.New_Diary.Location = new System.Drawing.Point(506, 94);
            this.New_Diary.Name = "New_Diary";
            this.New_Diary.Size = new System.Drawing.Size(135, 47);
            this.New_Diary.TabIndex = 2;
            this.New_Diary.Text = "New Diary";
            this.New_Diary.UseVisualStyleBackColor = true;
            this.New_Diary.Click += new System.EventHandler(this.New_Diary_Click);
            // 
            // manageTags
            // 
            this.manageTags.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageTags.Location = new System.Drawing.Point(455, 193);
            this.manageTags.Name = "manageTags";
            this.manageTags.Size = new System.Drawing.Size(100, 49);
            this.manageTags.TabIndex = 4;
            this.manageTags.Text = "Manage Tags";
            this.manageTags.UseVisualStyleBackColor = true;
            this.manageTags.Click += new System.EventHandler(this.manageTags_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(574, 210);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.manageTags);
            this.Controls.Add(this.New_Diary);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dark_mode_btn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox dark_mode_btn;
        private DataGridView dataGridView1;
        private Button New_Diary;
        private Button manageTags;
        private ComboBox comboBox2;
    }
}