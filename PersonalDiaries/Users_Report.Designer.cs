
namespace PersonalDiaries
{
    partial class Users_Report
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
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.generate_tag2 = new System.Windows.Forms.Button();
            this.back_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(28, 77);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(972, 519);
            this.crystalReportViewer2.TabIndex = 2;
            // 
            // generate_tag2
            // 
            this.generate_tag2.Location = new System.Drawing.Point(434, 12);
            this.generate_tag2.Name = "generate_tag2";
            this.generate_tag2.Size = new System.Drawing.Size(127, 46);
            this.generate_tag2.TabIndex = 3;
            this.generate_tag2.Text = "Generate Report";
            this.generate_tag2.UseVisualStyleBackColor = true;
            this.generate_tag2.Click += new System.EventHandler(this.generate_tag2_Click);
            // 
            // back_Button
            // 
            this.back_Button.Font = new System.Drawing.Font("Tahoma", 10F);
            this.back_Button.Location = new System.Drawing.Point(28, 11);
            this.back_Button.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.back_Button.Name = "back_Button";
            this.back_Button.Size = new System.Drawing.Size(70, 41);
            this.back_Button.TabIndex = 6;
            this.back_Button.Text = "Back";
            this.back_Button.UseVisualStyleBackColor = true;
            this.back_Button.Click += new System.EventHandler(this.back_Button_Click);
            // 
            // Users_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 626);
            this.Controls.Add(this.back_Button);
            this.Controls.Add(this.generate_tag2);
            this.Controls.Add(this.crystalReportViewer2);
            this.Name = "Users_Report";
            this.Text = "User Report";
            this.Load += new System.EventHandler(this.Users_Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private System.Windows.Forms.Button generate_tag2;
        private System.Windows.Forms.Button back_Button;
    }
}