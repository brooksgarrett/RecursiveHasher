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
using System.Threading;

namespace com.brooksgarrett.RecursiveHasher
{
    public partial class fmMain : Form
    {
        private delegate void toggleStatusDelegate(bool busy);
        private delegate void updatePBarDelegate(int value);
        private delegate void addRowDelegate(string[] data);
        private delegate void changeStatusDelegate(string status);

        DataTable dtResults = new DataTable("Results");
        DataGridViewColumn dcFile = new DataGridViewColumn();
        DataGridViewColumn dcDateTime = new DataGridViewColumn();
        DataGridViewColumn dcMD5Hash = new DataGridViewColumn();
        string[] dir = null;

        Thread hashThread = null;

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
            if ((dgvResults.Rows.Count != 1))
            {
                if (MessageBox.Show("Are you sure you want to erase current results and start over?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                else
                {
                    dgvResults.Rows.Clear();
                }
            }

            // Threaded calls here...
            if (tbDir.Text != String.Empty)
            {
                if (cbRecurse.Checked) dir = Directory.GetFiles(tbDir.Text, "*", SearchOption.AllDirectories);
                else dir = Directory.GetFiles(tbDir.Text, "*", SearchOption.TopDirectoryOnly);

                hashThread = new Thread(doHash);

                try
                {
                    hashThread.Start();
                }
                catch (ThreadStateException tse)
                {
                    basicErrorHandler(tse);
                }
                catch (OutOfMemoryException oom)
                {
                    basicErrorHandler(oom);
                }
            }
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            if (ofdDir.ShowDialog() == DialogResult.OK)
            {
                tbDir.Text = ofdDir.SelectedPath;
            }
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            killHashThread();
            toggleStatus(false);
        }

        private string encodeByteArray(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++) sb.Append(byteArray[i].ToString("X2"));
            return sb.ToString();
        }

        private void doHash()
        {
            byte[] md5Sum = null;
            int pass = 0;
            double percentageDone = 0.00;
            MD5 hashService = MD5.Create();
            string[] temp = new string[3];



            // Check if controls are locked, if not, lock them.
            if (btnGo.InvokeRequired)
                this.Invoke(new toggleStatusDelegate(toggleStatus), new object[] { true });
            else toggleStatus(true);



            foreach (string file in dir)
            {
                md5Sum = hashService.ComputeHash(new StreamReader(File.OpenRead(file)).BaseStream);

                temp[0] = file;
                temp[1] = File.GetLastWriteTime(file).ToString();
                temp[2] = encodeByteArray(md5Sum);

                percentageDone = (double)pass / (double)dir.Length;
                percentageDone = percentageDone * 100;


                //Cleanup for next iteration
                if (btnGo.InvokeRequired)
                {
                    this.Invoke(new updatePBarDelegate(updatePBar), new object[] { Convert.ToInt16(percentageDone) });
                    this.Invoke(new addRowDelegate(addRow), new object[] { temp });
                    this.Invoke(new changeStatusDelegate(changeStatus), new object[] { Properties.Resources.workingStatusLabel + file });
                }
                else updatePBar((pass / dir.Length) * 100);
                pass++;
            }

            // Check if controls are unlocked, if not, unlock them.
            if (btnGo.InvokeRequired)
                this.Invoke(new toggleStatusDelegate(toggleStatus), new object[] { false });
            else toggleStatus(false);
        }

        private void basicErrorHandler(Exception e)
        {
            MessageBox.Show(e.Message, Properties.Resources.errorHandlerCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            toggleStatus(false);
        }

        private void toggleStatus(bool busy)
        {
            if (busy && btnGo.Enabled)
            {
                lblToolStripStatus.Image = Properties.Resources.waiting_20x20;
                pbToolStrip.Value = 0;
                btnGo.Enabled = false;
                btnGo.Visible = false;
                btnStop.Enabled = true;
                btnStop.Visible = true;
                btnSave.Enabled = false;
                btnOpenDir.Enabled = false;
            }
            else if (!busy && !btnGo.Enabled)
            {
                lblToolStripStatus.Image = Properties.Resources.checkmark_16x16;
                lblToolStripStatus.Text = Properties.Resources.idleStatusLabel;
                pbToolStrip.Value = 100;
                btnGo.Enabled = true;
                btnGo.Visible = true;
                btnStop.Enabled = false;
                btnStop.Visible = false;
                btnSave.Enabled = true;
                btnOpenDir.Enabled = true;
            }
        }

        private void updatePBar(int value)
        {
            this.pbToolStrip.Value = value;
        }

        private void addRow(string[] data)
        {
            int index = dgvResults.Rows.Add();
            dgvResults.Rows[index].Cells["file"].Value = data[0];
            dgvResults.Rows[index].Cells["date"].Value = data[1];
            dgvResults.Rows[index].Cells["hash"].Value = data[2];
        }

        private void changeStatus(string status)
        {
            this.lblToolStripStatus.Text = status;
        }

        private void killHashThread()
        {
            if ((hashThread != null) && hashThread.ThreadState == ThreadState.Running) hashThread.Abort();
        }
    }
}
