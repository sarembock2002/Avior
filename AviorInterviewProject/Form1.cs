using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviorInterviewProject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            TestingFunctions.ClearDB();
        }

        private void btnUploadTestData_Click(object sender, EventArgs e)
        {
            TestingFunctions.InsertTestData();
        }
   

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FileProcessor.Directory = folderBrowserDialog1.SelectedPath;
                textBox1.Text = FileProcessor.Directory;

                FileProcessor.FilesToProcess = Directory.GetFiles(FileProcessor.Directory).Length;
                label5.Text = FileProcessor.FilesToProcess.ToString();
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            FileProcessor.FilesProcessed = 0;

            foreach (String filename in System.IO.Directory.GetFiles(FileProcessor.Directory))
            {

                //Check to see if there is already data
                bool isData = FileProcessor.IsLoaded(filename);

                progressBar1.Maximum = FileProcessor.FilesToProcess;
                

                if (!isData && File.Exists(filename))
                {
                    FileProcessor.ProcessFile(filename);
                    progressBar1.PerformStep();
                    
                }
            }

            label6.Text = FileProcessor.FilesProcessed.ToString();
        }

        
    }
}
