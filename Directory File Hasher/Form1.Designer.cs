﻿namespace Directory_File_Hasher
{
    partial class fmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.tbDir = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.cbRecurse = new System.Windows.Forms.CheckBox();
            this.pnlUpper = new System.Windows.Forms.Panel();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.pnlLower = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pbToolStrip = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.ttRecurse = new System.Windows.Forms.ToolTip(this.components);
            this.ofdDir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfdResults = new System.Windows.Forms.SaveFileDialog();
            this.lblToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpper.SuspendLayout();
            this.pnlLower.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDir
            // 
            this.tbDir.Enabled = false;
            this.tbDir.Location = new System.Drawing.Point(3, 12);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(498, 20);
            this.tbDir.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(668, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbRecurse
            // 
            this.cbRecurse.AutoSize = true;
            this.cbRecurse.Location = new System.Drawing.Point(588, 14);
            this.cbRecurse.Name = "cbRecurse";
            this.cbRecurse.Size = new System.Drawing.Size(74, 17);
            this.cbRecurse.TabIndex = 2;
            this.cbRecurse.Text = "Recursive";
            this.cbRecurse.UseVisualStyleBackColor = true;
            // 
            // pnlUpper
            // 
            this.pnlUpper.Controls.Add(this.btnSave);
            this.pnlUpper.Controls.Add(this.btnOpenDir);
            this.pnlUpper.Controls.Add(this.tbDir);
            this.pnlUpper.Controls.Add(this.btnGo);
            this.pnlUpper.Controls.Add(this.cbRecurse);
            this.pnlUpper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpper.Location = new System.Drawing.Point(0, 0);
            this.pnlUpper.Name = "pnlUpper";
            this.pnlUpper.Size = new System.Drawing.Size(864, 48);
            this.pnlUpper.TabIndex = 3;
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(507, 10);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDir.TabIndex = 1;
            this.btnOpenDir.Text = "Browse...";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // pnlLower
            // 
            this.pnlLower.Controls.Add(this.statusStrip1);
            this.pnlLower.Controls.Add(this.dgvResults);
            this.pnlLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLower.Location = new System.Drawing.Point(0, 48);
            this.pnlLower.Name = "pnlLower";
            this.pnlLower.Size = new System.Drawing.Size(864, 373);
            this.pnlLower.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbToolStrip,
            this.lblToolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pbToolStrip
            // 
            this.pbToolStrip.Name = "pbToolStrip";
            this.pbToolStrip.Size = new System.Drawing.Size(100, 16);
            this.pbToolStrip.Step = 1;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToOrderColumns = true;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(864, 373);
            this.dgvResults.TabIndex = 4;
            // 
            // ttRecurse
            // 
            this.ttRecurse.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttRecurse.ToolTipTitle = "In Development";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(749, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sfdResults
            // 
            this.sfdResults.DefaultExt = "csv";
            this.sfdResults.FileName = "HashResults";
            this.sfdResults.Filter = "CSV|*.csv|All Files|*.*";
            this.sfdResults.InitialDirectory = "%HOME%";
            this.sfdResults.Title = "Save Results...";
            // 
            // lblToolStripStatus
            // 
            this.lblToolStripStatus.Image = global::Directory_File_Hasher.Properties.Resources.checkmark_16x16;
            this.lblToolStripStatus.Name = "lblToolStripStatus";
            this.lblToolStripStatus.Size = new System.Drawing.Size(58, 16);
            this.lblToolStripStatus.Text = "Ready.";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 421);
            this.Controls.Add(this.pnlLower);
            this.Controls.Add(this.pnlUpper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.Text = "FileHasher";
            this.pnlUpper.ResumeLayout(false);
            this.pnlUpper.PerformLayout();
            this.pnlLower.ResumeLayout(false);
            this.pnlLower.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox cbRecurse;
        private System.Windows.Forms.Panel pnlUpper;
        private System.Windows.Forms.Panel pnlLower;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.ToolTip ttRecurse;
        private System.Windows.Forms.FolderBrowserDialog ofdDir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pbToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblToolStripStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfdResults;
    }
}

