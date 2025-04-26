
namespace PersonalDiaries
{
    partial class Tag_Report
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
            this.generate_tag = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.back_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generate_tag
            // 
            this.generate_tag.Location = new System.Drawing.Point(435, 12);
            this.generate_tag.Name = "generate_tag";
            this.generate_tag.Size = new System.Drawing.Size(127, 46);
            this.generate_tag.TabIndex = 0;
            this.generate_tag.Text = "Generate Report";
            this.generate_tag.UseVisualStyleBackColor = true;
            this.generate_tag.Click += new System.EventHandler(this.generate_tag_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(29, 77);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(972, 519);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // back_Button
            // 
            this.back_Button.Location = new System.Drawing.Point(29, 11);
            this.back_Button.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.back_Button.Name = "back_Button";
            this.back_Button.Size = new System.Drawing.Size(70, 41);
            this.back_Button.TabIndex = 6;
            this.back_Button.Text = "Back";
            this.back_Button.UseVisualStyleBackColor = true;
            this.back_Button.Click += new System.EventHandler(this.back_Button_Click);
            // 
            // Tag_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 620);
            this.Controls.Add(this.back_Button);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.generate_tag);
            this.Name = "Tag_Report";
            this.Text = "Tag Report";
            this.Load += new System.EventHandler(this.Tag_Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generate_tag;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button back_Button;
    }
}