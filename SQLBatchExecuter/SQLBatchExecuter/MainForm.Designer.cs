namespace SQLBatchExecuter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.lbl_threadCount = new System.Windows.Forms.Label();
            this.nud_threadCount = new System.Windows.Forms.NumericUpDown();
            this.cbx_Protokol = new System.Windows.Forms.CheckBox();
            this.lbl_Sort = new System.Windows.Forms.Label();
            this.cmb_filter = new System.Windows.Forms.ComboBox();
            this.btn_ProcessStatement = new System.Windows.Forms.Button();
            this.lbl_Connected = new System.Windows.Forms.Label();
            this.btn_ClearGrid = new System.Windows.Forms.Button();
            this.txt_SQLToExecute = new System.Windows.Forms.TextBox();
            this.dgv_DataLoaded = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFileXMLCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscmb_Database = new System.Windows.Forms.ToolStripComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_startProcessing = new System.Windows.Forms.Button();
            this.bgw_Worker = new System.ComponentModel.BackgroundWorker();
            this.pgb_Progress = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_stopProcessing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_threadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataLoaded)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Log
            // 
            this.txt_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Log.Location = new System.Drawing.Point(657, 57);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ReadOnly = true;
            this.txt_Log.Size = new System.Drawing.Size(311, 321);
            this.txt_Log.TabIndex = 30;
            // 
            // lbl_threadCount
            // 
            this.lbl_threadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_threadCount.AutoSize = true;
            this.lbl_threadCount.Location = new System.Drawing.Point(161, 31);
            this.lbl_threadCount.Name = "lbl_threadCount";
            this.lbl_threadCount.Size = new System.Drawing.Size(49, 13);
            this.lbl_threadCount.TabIndex = 29;
            this.lbl_threadCount.Text = "Threads:";
            this.lbl_threadCount.Visible = false;
            // 
            // nud_threadCount
            // 
            this.nud_threadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_threadCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_threadCount.Location = new System.Drawing.Point(216, 29);
            this.nud_threadCount.Name = "nud_threadCount";
            this.nud_threadCount.Size = new System.Drawing.Size(89, 20);
            this.nud_threadCount.TabIndex = 28;
            this.nud_threadCount.Visible = false;
            // 
            // cbx_Protokol
            // 
            this.cbx_Protokol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Protokol.AutoSize = true;
            this.cbx_Protokol.Location = new System.Drawing.Point(216, 58);
            this.cbx_Protokol.Name = "cbx_Protokol";
            this.cbx_Protokol.Size = new System.Drawing.Size(89, 17);
            this.cbx_Protokol.TabIndex = 26;
            this.cbx_Protokol.Text = "write protocol";
            this.cbx_Protokol.UseVisualStyleBackColor = true;
            // 
            // lbl_Sort
            // 
            this.lbl_Sort.AutoSize = true;
            this.lbl_Sort.Location = new System.Drawing.Point(7, 33);
            this.lbl_Sort.Name = "lbl_Sort";
            this.lbl_Sort.Size = new System.Drawing.Size(32, 13);
            this.lbl_Sort.TabIndex = 25;
            this.lbl_Sort.Text = "Filter:";
            // 
            // cmb_filter
            // 
            this.cmb_filter.FormattingEnabled = true;
            this.cmb_filter.Items.AddRange(new object[] {
            "All",
            "Not processed",
            "Errors"});
            this.cmb_filter.Location = new System.Drawing.Point(45, 30);
            this.cmb_filter.Name = "cmb_filter";
            this.cmb_filter.Size = new System.Drawing.Size(102, 21);
            this.cmb_filter.TabIndex = 24;
            this.cmb_filter.SelectedIndexChanged += new System.EventHandler(this.cmb_filter_SelectedIndexChanged);
            // 
            // btn_ProcessStatement
            // 
            this.btn_ProcessStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ProcessStatement.Location = new System.Drawing.Point(6, 29);
            this.btn_ProcessStatement.Name = "btn_ProcessStatement";
            this.btn_ProcessStatement.Size = new System.Drawing.Size(114, 23);
            this.btn_ProcessStatement.TabIndex = 23;
            this.btn_ProcessStatement.Text = "CreateStatements";
            this.btn_ProcessStatement.UseVisualStyleBackColor = true;
            this.btn_ProcessStatement.Click += new System.EventHandler(this.btn_ProcessStatement_Click);
            // 
            // lbl_Connected
            // 
            this.lbl_Connected.AutoSize = true;
            this.lbl_Connected.Location = new System.Drawing.Point(304, 8);
            this.lbl_Connected.Name = "lbl_Connected";
            this.lbl_Connected.Size = new System.Drawing.Size(0, 13);
            this.lbl_Connected.TabIndex = 22;
            // 
            // btn_ClearGrid
            // 
            this.btn_ClearGrid.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ClearGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearGrid.Location = new System.Drawing.Point(6, 116);
            this.btn_ClearGrid.Name = "btn_ClearGrid";
            this.btn_ClearGrid.Size = new System.Drawing.Size(114, 23);
            this.btn_ClearGrid.TabIndex = 21;
            this.btn_ClearGrid.Text = "Clear Grid";
            this.btn_ClearGrid.UseVisualStyleBackColor = false;
            this.btn_ClearGrid.Click += new System.EventHandler(this.btn_ClearGrid_Click);
            // 
            // txt_SQLToExecute
            // 
            this.txt_SQLToExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SQLToExecute.Location = new System.Drawing.Point(10, 384);
            this.txt_SQLToExecute.Multiline = true;
            this.txt_SQLToExecute.Name = "txt_SQLToExecute";
            this.txt_SQLToExecute.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_SQLToExecute.Size = new System.Drawing.Size(641, 211);
            this.txt_SQLToExecute.TabIndex = 20;
            // 
            // dgv_DataLoaded
            // 
            this.dgv_DataLoaded.AllowUserToAddRows = false;
            this.dgv_DataLoaded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DataLoaded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataLoaded.Location = new System.Drawing.Point(10, 57);
            this.dgv_DataLoaded.Name = "dgv_DataLoaded";
            this.dgv_DataLoaded.Size = new System.Drawing.Size(641, 321);
            this.dgv_DataLoaded.TabIndex = 19;
            this.dgv_DataLoaded.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_DataLoaded_ColumnHeaderMouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tscmb_Database});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(980, 27);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromFileXMLCSVToolStripMenuItem,
            this.loadFromSQLToolStripMenuItem});
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // loadFromFileXMLCSVToolStripMenuItem
            // 
            this.loadFromFileXMLCSVToolStripMenuItem.Name = "loadFromFileXMLCSVToolStripMenuItem";
            this.loadFromFileXMLCSVToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.loadFromFileXMLCSVToolStripMenuItem.Text = "Load from file (XML,CSV)";
            this.loadFromFileXMLCSVToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileXMLCSVToolStripMenuItem_Click);
            // 
            // loadFromSQLToolStripMenuItem
            // 
            this.loadFromSQLToolStripMenuItem.Name = "loadFromSQLToolStripMenuItem";
            this.loadFromSQLToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.loadFromSQLToolStripMenuItem.Text = "Load from SQL";
            this.loadFromSQLToolStripMenuItem.Click += new System.EventHandler(this.loadFromSQLToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(100, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.customizeToolStripMenuItem.Text = "&Siumulation";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // tscmb_Database
            // 
            this.tscmb_Database.Name = "tscmb_Database";
            this.tscmb_Database.Size = new System.Drawing.Size(121, 23);
            this.tscmb_Database.SelectedIndexChanged += new System.EventHandler(this.tscmb_Database_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_startProcessing
            // 
            this.btn_startProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_startProcessing.Location = new System.Drawing.Point(6, 58);
            this.btn_startProcessing.Name = "btn_startProcessing";
            this.btn_startProcessing.Size = new System.Drawing.Size(114, 23);
            this.btn_startProcessing.TabIndex = 32;
            this.btn_startProcessing.Text = "Start";
            this.btn_startProcessing.UseVisualStyleBackColor = true;
            this.btn_startProcessing.Click += new System.EventHandler(this.btn_startProcessing_Click);
            // 
            // bgw_Worker
            // 
            this.bgw_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Worker_DoWork);
            this.bgw_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_Worker_ProgressChanged);
            this.bgw_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Worker_RunWorkerCompleted);
            // 
            // pgb_Progress
            // 
            this.pgb_Progress.Location = new System.Drawing.Point(6, 182);
            this.pgb_Progress.Name = "pgb_Progress";
            this.pgb_Progress.Size = new System.Drawing.Size(114, 23);
            this.pgb_Progress.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_stopProcessing);
            this.groupBox1.Controls.Add(this.btn_ProcessStatement);
            this.groupBox1.Controls.Add(this.pgb_Progress);
            this.groupBox1.Controls.Add(this.btn_ClearGrid);
            this.groupBox1.Controls.Add(this.btn_startProcessing);
            this.groupBox1.Controls.Add(this.cbx_Protokol);
            this.groupBox1.Controls.Add(this.nud_threadCount);
            this.groupBox1.Controls.Add(this.lbl_threadCount);
            this.groupBox1.Location = new System.Drawing.Point(657, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 211);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btn_stopProcessing
            // 
            this.btn_stopProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stopProcessing.Location = new System.Drawing.Point(6, 87);
            this.btn_stopProcessing.Name = "btn_stopProcessing";
            this.btn_stopProcessing.Size = new System.Drawing.Size(114, 23);
            this.btn_stopProcessing.TabIndex = 34;
            this.btn_stopProcessing.Text = "Stop";
            this.btn_stopProcessing.UseVisualStyleBackColor = true;
            this.btn_stopProcessing.Click += new System.EventHandler(this.btn_stopProcessing_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.lbl_Sort);
            this.Controls.Add(this.cmb_filter);
            this.Controls.Add(this.lbl_Connected);
            this.Controls.Add(this.txt_SQLToExecute);
            this.Controls.Add(this.dgv_DataLoaded);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.nud_threadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataLoaded)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Label lbl_threadCount;
        private System.Windows.Forms.NumericUpDown nud_threadCount;
        private System.Windows.Forms.CheckBox cbx_Protokol;
        private System.Windows.Forms.Label lbl_Sort;
        private System.Windows.Forms.ComboBox cmb_filter;
        private System.Windows.Forms.Button btn_ProcessStatement;
        private System.Windows.Forms.Label lbl_Connected;
        private System.Windows.Forms.Button btn_ClearGrid;
        private System.Windows.Forms.TextBox txt_SQLToExecute;
        private System.Windows.Forms.DataGridView dgv_DataLoaded;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscmb_Database;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileXMLCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromSQLToolStripMenuItem;
        private System.Windows.Forms.Button btn_startProcessing;
        private System.ComponentModel.BackgroundWorker bgw_Worker;
        private System.Windows.Forms.ProgressBar pgb_Progress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_stopProcessing;
    }
}