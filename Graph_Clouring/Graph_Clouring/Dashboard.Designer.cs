namespace Graph_Clouring
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btncourse = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btntimetable = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 61);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam Schedule System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.btncourse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 463);
            this.panel2.TabIndex = 1;
            // 
            // btncourse
            // 
            this.btncourse.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btncourse.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncourse.ForeColor = System.Drawing.Color.Maroon;
            this.btncourse.Location = new System.Drawing.Point(109, 184);
            this.btncourse.Name = "btncourse";
            this.btncourse.Size = new System.Drawing.Size(123, 85);
            this.btncourse.TabIndex = 0;
            this.btncourse.Text = "Courses";
            this.btncourse.UseVisualStyleBackColor = false;
            this.btncourse.Click += new System.EventHandler(this.btncourse_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.btntimetable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(368, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 463);
            this.panel3.TabIndex = 2;
            // 
            // btntimetable
            // 
            this.btntimetable.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btntimetable.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimetable.ForeColor = System.Drawing.Color.Maroon;
            this.btntimetable.Location = new System.Drawing.Point(190, 184);
            this.btntimetable.Name = "btntimetable";
            this.btntimetable.Size = new System.Drawing.Size(123, 85);
            this.btntimetable.TabIndex = 0;
            this.btntimetable.Text = "TimeTable\r\n";
            this.btntimetable.UseVisualStyleBackColor = false;
            this.btntimetable.Click += new System.EventHandler(this.btntimetable_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 524);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btncourse;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btntimetable;
    }
}