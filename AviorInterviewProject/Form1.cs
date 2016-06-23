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
            //Clear DB
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
                //  Update properties on selection of directory
                FileProcessor.Directory = folderBrowserDialog1.SelectedPath;
                textBox1.Text = FileProcessor.Directory;

                FileProcessor.FilesToProcess = Directory.GetFiles(FileProcessor.Directory, "*Options Traded*xls").Length;
                label5.Text = FileProcessor.FilesToProcess.ToString();
            }
        }

        //On pressing Process Files
        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            //Initialise variables
            progressBar1.Value = 0;
            label1.Text = "Busy..";


            FileProcessor.FilesProcessed = 0;
            FileProcessor.ProcessedFileNames = new List<string>();

            //Specific search pattern for only files which comply
            foreach (String filename in System.IO.Directory.GetFiles(FileProcessor.Directory,"*Options Traded*xls"))
            {

                //Indicates when the available files are loaded
                progressBar1.Maximum = FileProcessor.FilesToProcess;

                if (checkBoxOverWrite.Checked)
                {
                    FileProcessor.DeleteFileData(filename);
                }

                //Check to see if there is already data
                bool isData = FileProcessor.IsLoaded(filename);

                //If there is data and overwrite is checked OR there is no data
                if (!isData   && File.Exists(filename))
                {
                    
                    FileProcessor.ProcessFile(filename);
                    FileProcessor.ProcessedFileNames.Add(filename);
                    progressBar1.PerformStep();
                    label6.Text = FileProcessor.FilesProcessed.ToString();

                }
            }

            label1.Text = "Files processed:";


        }

        //Show Files that are processed
        private void btnDisplayFiles_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Join("\n", FileProcessor.ProcessedFileNames.ToArray()),"Processed Files");
        }

        
    }
}
