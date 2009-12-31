using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Directory_File_Hasher
{
    public partial class fmMain : Form
    {
        MD5 hashService = MD5.Create();
        DataTable dtResults = new DataTable("Results");
        DataGridViewColumn dcFile = new DataGridViewColumn();
        DataGridViewColumn dcDateTime = new DataGridViewColumn();
        DataGridViewColumn dcMD5Hash = new DataGridViewColumn();

        public fmMain()
        {
            InitializeComponent();
            constructTable();
        }

        private void constructTable()
        {
            DataGridViewCell template = new DataGridViewTextBoxCell();

            dgvResults.Columns.Add("file", "File Name");
            dgvResults.Columns.Add("date", "Modified Date");
            dgvResults.Columns.Add("hash", "MD5Hash");

            dgvResults.Columns["date"].MinimumWidth = 80;
            dgvResults.Columns["hash"].MinimumWidth = 80;

            dgvResults.Columns["file"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns["date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvResults.Columns["hash"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            

            dgvResults.ColumnHeadersVisible = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.Refresh();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lblToolStripStatus.Image = Properties.Resources.waiting_20x20;
            string stProc = Properties.Resources.workingStatusLabel;
            btnGo.Enabled = false;
            btnSave.Enabled = false;
      
            // I would like to split the rest of this into a new thread so the form updates properly...
            byte[] md5Sum = null;
            int index = 0;
            int pass = 0;

            string[] dir = null;

            if (tbDir.Text != String.Empty)
            {
                if (cbRecurse.Checked) dir = Directory.GetFiles(tbDir.Text, "*", SearchOption.AllDirectories);
                else dir = Directory.GetFiles(tbDir.Text, "*", SearchOption.TopDirectoryOnly);
                
                foreach (string file in dir)
                {
                    lblToolStripStatus.Text = stProc + file; 
                    md5Sum = hashService.ComputeHash(new StreamReader(File.OpenRead(file)).BaseStream);
                    index = dgvResults.Rows.Add();
                    dgvResults.Rows[index].Cells["file"].Value = file;
                    dgvResults.Rows[index].Cells["date"].Value = File.GetLastWriteTime(file);
                    dgvResults.Rows[index].Cells["hash"].Value = encodeByteArray(md5Sum);
                    
                    //Cleanup for next iteration
                    pbToolStrip.Value = (pass / dir.Length) * 100;
                    pass++;
                }
            }
            pbToolStrip.Value = 100;
            lblToolStripStatus.Image = Properties.Resources.checkmark_16x16;
            lblToolStripStatus.Text = Properties.Resources.workingStatusLabel;
            btnGo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            if (ofdDir.ShowDialog() == DialogResult.OK)
            {
                tbDir.Text = ofdDir.SelectedPath;
            }
        }

        private string encodeByteArray(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++) sb.Append(byteArray[i].ToString("X2"));
            return sb.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sfdResults.ShowDialog() == DialogResult.OK)
            {
                StreamWriter output = new StreamWriter(sfdResults.OpenFile());

                output.WriteLine(Properties.Resources.csvOutputHeader);

                foreach (DataGridViewRow row in dgvResults.Rows)
                {
                    output.Write("\"" + row.Cells["file"] + "\",");
                    output.Write("\"" + row.Cells["date"] + "\",");
                    output.Write("\"" + row.Cells["hash"] + "\"");
                    output.Write(Environment.NewLine);
                }
                output.Dispose();
            }
        }
    }
}
