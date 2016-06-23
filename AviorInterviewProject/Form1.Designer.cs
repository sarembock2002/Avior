namespace AviorInterviewProject
{
    partial class frmMain
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
            this.btnClearDB = new System.Windows.Forms.Button();
            this.btnUploadTestData = new System.Windows.Forms.Button();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDisplayFiles = new System.Windows.Forms.Button();
            this.checkBoxOverWrite = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnClearDB
            // 
            this.btnClearDB.Location = new System.Drawing.Point(22, 78);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(75, 72);
            this.btnClearDB.TabIndex = 0;
            this.btnClearDB.Text = "Clear Database";
            this.btnClearDB.UseVisualStyleBackColor = true;
            this.btnClearDB.Click += new System.EventHandler(this.btnClearDB_Click);
            // 
            // btnUploadTestData
            // 
            this.btnUploadTestData.Location = new System.Drawing.Point(103, 78);
            this.btnUploadTestData.Name = "btnUploadTestData";
            this.btnUploadTestData.Size = new System.Drawing.Size(75, 72);
            this.btnUploadTestData.TabIndex = 1;
            this.btnUploadTestData.Text = "Upload Test Data";
            this.btnUploadTestData.UseVisualStyleBackColor = true;
            this.btnUploadTestData.Click += new System.EventHandler(this.btnUploadTestData_Click);
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Location = new System.Drawing.Point(184, 78);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(75, 72);
            this.btnProcessFiles.TabIndex = 2;
            this.btnProcessFiles.Text = "Process Files";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select Directory:";
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Location = new System.Drawing.Point(97, 23);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(32, 23);
            this.btnSelectDirectory.TabIndex = 9;
            this.btnSelectDirectory.Text = "...";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 211);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(254, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Files processed:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Files in Directory: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 16;
            // 
            // btnDisplayFiles
            // 
            this.btnDisplayFiles.Location = new System.Drawing.Point(184, 182);
            this.btnDisplayFiles.Name = "btnDisplayFiles";
            this.btnDisplayFiles.Size = new System.Drawing.Size(27, 21);
            this.btnDisplayFiles.TabIndex = 17;
            this.btnDisplayFiles.Text = "...";
            this.btnDisplayFiles.UseVisualStyleBackColor = true;
            this.btnDisplayFiles.Click += new System.EventHandler(this.btnDisplayFiles_Click);
            // 
            // checkBoxOverWrite
            // 
            this.checkBoxOverWrite.AutoSize = true;
            this.checkBoxOverWrite.Checked = true;
            this.checkBoxOverWrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOverWrite.Location = new System.Drawing.Point(135, 27);
            this.checkBoxOverWrite.Name = "checkBoxOverWrite";
            this.checkBoxOverWrite.Size = new System.Drawing.Size(142, 17);
            this.checkBoxOverWrite.TabIndex = 18;
            this.checkBoxOverWrite.Text = "Overwrite Existing Data?";
            this.checkBoxOverWrite.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 283);
            this.Controls.Add(this.checkBoxOverWrite);
            this.Controls.Add(this.btnDisplayFiles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnProcessFiles);
            this.Controls.Add(this.btnUploadTestData);
            this.Controls.Add(this.btnClearDB);
            this.Name = "frmMain";
            this.Text = "Avior Interview Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearDB;
        private System.Windows.Forms.Button btnUploadTestData;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDisplayFiles;
        private System.Windows.Forms.CheckBox checkBoxOverWrite;
    }
}

