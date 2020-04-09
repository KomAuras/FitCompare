namespace FitCompare
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Split = new System.Windows.Forms.SplitContainer();
            this.ListDataGrid1 = new System.Windows.Forms.DataGridView();
            this.ListDataGrid2 = new System.Windows.Forms.DataGridView();
            this.StripStatus = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripTools = new System.Windows.Forms.ToolStrip();
            this.ButtonTest = new System.Windows.Forms.ToolStripButton();
            this.BackPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGrid2)).BeginInit();
            this.StripStatus.SuspendLayout();
            this.StripTools.SuspendLayout();
            this.BackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Split
            // 
            this.Split.Cursor = System.Windows.Forms.Cursors.Default;
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.Location = new System.Drawing.Point(0, 0);
            this.Split.Name = "Split";
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.Controls.Add(this.ListDataGrid1);
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.Controls.Add(this.ListDataGrid2);
            this.Split.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Split.Size = new System.Drawing.Size(587, 340);
            this.Split.SplitterDistance = 287;
            this.Split.TabIndex = 0;
            // 
            // ListDataGrid1
            // 
            this.ListDataGrid1.AllowUserToAddRows = false;
            this.ListDataGrid1.AllowUserToDeleteRows = false;
            this.ListDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.ListDataGrid1.Name = "ListDataGrid1";
            this.ListDataGrid1.ReadOnly = true;
            this.ListDataGrid1.Size = new System.Drawing.Size(287, 340);
            this.ListDataGrid1.TabIndex = 0;
            // 
            // ListDataGrid2
            // 
            this.ListDataGrid2.AllowUserToAddRows = false;
            this.ListDataGrid2.AllowUserToDeleteRows = false;
            this.ListDataGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.ListDataGrid2.Name = "ListDataGrid2";
            this.ListDataGrid2.ReadOnly = true;
            this.ListDataGrid2.Size = new System.Drawing.Size(296, 340);
            this.ListDataGrid2.TabIndex = 0;
            // 
            // StripStatus
            // 
            this.StripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StripStatus.Location = new System.Drawing.Point(0, 365);
            this.StripStatus.Name = "StripStatus";
            this.StripStatus.Size = new System.Drawing.Size(587, 22);
            this.StripStatus.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(64, 17);
            this.StatusLabel.Text = "EVE Online";
            // 
            // StripTools
            // 
            this.StripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonTest});
            this.StripTools.Location = new System.Drawing.Point(0, 0);
            this.StripTools.Name = "StripTools";
            this.StripTools.Size = new System.Drawing.Size(587, 25);
            this.StripTools.TabIndex = 2;
            this.StripTools.Text = "toolStrip1";
            // 
            // ButtonTest
            // 
            this.ButtonTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonTest.Image = ((System.Drawing.Image)(resources.GetObject("ButtonTest.Image")));
            this.ButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonTest.Name = "ButtonTest";
            this.ButtonTest.Size = new System.Drawing.Size(31, 22);
            this.ButtonTest.Text = "Test";
            this.ButtonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // BackPanel
            // 
            this.BackPanel.Controls.Add(this.Split);
            this.BackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPanel.Location = new System.Drawing.Point(0, 25);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(587, 340);
            this.BackPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 387);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.StripTools);
            this.Controls.Add(this.StripStatus);
            this.Name = "MainForm";
            this.Text = "Fit Compare";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGrid2)).EndInit();
            this.StripStatus.ResumeLayout(false);
            this.StripStatus.PerformLayout();
            this.StripTools.ResumeLayout(false);
            this.StripTools.PerformLayout();
            this.BackPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer Split;
        private System.Windows.Forms.StatusStrip StripStatus;
        private System.Windows.Forms.ToolStrip StripTools;
        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripButton ButtonTest;
        private System.Windows.Forms.DataGridView ListDataGrid1;
        private System.Windows.Forms.DataGridView ListDataGrid2;
    }
}

