using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            FileProcessor.ProcessFiles();
        }
    }
}
