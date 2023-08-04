using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
namespace SQLBatchExecuter
{
    public partial class MainForm : Form
    {
        private string fileName;
        private static readonly IniFile SmOIniFile = new IniFile();
        private static readonly LogFile SmOLogFile = new LogFile();
        string strLogFile = "";
        string strWorkingDir = Directory.GetCurrentDirectory();
        private Setting setting;
        private DataBaseHelper dbHelper;
        private List<string> batchStatements;
        private Simulation simulation;
        private DataTable originTable;
        public LogFile Log
        {
            get { return SmOLogFile; }
        }

        static public IniFile Ini
        {
            get { return SmOIniFile; }
        }
        public MainForm()
        {
            InitializeComponent();
            string iniFile = strWorkingDir + "\\Options.ini";
            Ini.Read(iniFile);
            setting = new Setting();
            dbHelper = new DataBaseHelper();
            FillDatabaseList();
            this.cmb_filter.SelectedIndex = 0;
            this.bgw_Worker.WorkerReportsProgress = true;
            this.bgw_Worker.WorkerSupportsCancellation = true;
        }

        private void FillDatabaseList()
        {

            foreach (var item in setting.Connectionstrings)
            {
                this.tscmb_Database.ComboBox.Items.Add(item.Key);
            }

        }

        private void DisableColumnSorting()
        {
            for (int i = 0; i < this.dgv_DataLoaded.Columns.Count; i++)
            {
                this.dgv_DataLoaded.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void WriteProtocolHeader()
        {
            DateTime dtStart = DateTime.Now;
            strLogFile = strWorkingDir + "\\Protokoll_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            Log.LogAll = true;
            Log.Open(strLogFile);
            Log.WriteLine("Database: {0} :", this.tscmb_Database.ComboBox.SelectedItem);
            Log.WriteLine("---Start execution---");
        }

        public void ConvertCSVtoDataTable(string strFilePath)
        {
            this.originTable = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath, Encoding.GetEncoding(1252)))
            {
                List<string> headers = new List<string>();
                headers.AddRange(sr.ReadLine().Split(';').ToList());
                headers.Add("Processed");
                headers.Add("Errors");
                foreach (string header in headers)
                {
                    this.originTable.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    List<string> rows = new List<string>();
                    rows.AddRange(sr.ReadLine().Split(';').ToList());

                    DataRow dr = this.originTable.NewRow();
                    for (int i = 0; i < headers.Count-2; i++)
                    {
                        dr[i] = rows[i];
                    }
                    this.originTable.Rows.Add(dr);
                }
            }
        }


        private void btn_ProcessStatement_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txt_SQLToExecute.Text))
            {
                if (this.dgv_DataLoaded.Rows.Count > 0)
                {
                    batchStatements = new List<string>();
                    Regex reg = new Regex("{[0-9]*}");
                    MatchCollection matches = reg.Matches(this.txt_SQLToExecute.Text);

                    if (matches.Count > 0)
                    {
                        for (int x = 0; x < this.dgv_DataLoaded.Rows.Count; x++)
                        {
                            string query = this.txt_SQLToExecute.Text;
                            for (int i = 0; i < matches.Count; i++)
                            {
                                int index = Convert.ToInt32(matches[i].Value.Replace("{", "").Replace("}", ""));
                                query = query.Replace(matches[i].Value,
                                    "'" + this.dgv_DataLoaded.Rows[x].Cells[index].Value.ToString() + "'");

                            }
                            batchStatements.Add(query);

                        }
                    }
                    else
                    {
                        batchStatements.Add(this.txt_SQLToExecute.Text);

                    }
                    this.txt_Log.Text += "Statements created.\r\n";
                }
                else
                {
                    this.txt_Log.Text += "GridView is empty no statements created.\r\n";
                }
            }
            else
            {
                this.txt_Log.Text += "There is no valid SQL statement!\r\n";
            }
        }


        private void btn_ClearGrid_Click(object sender, EventArgs e)
        {
            this.dgv_DataLoaded.DataSource = null;
            this.dgv_DataLoaded.Refresh();

        }

        private void dgv_DataLoaded_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txt_SQLToExecute.Text += " {" + e.ColumnIndex + "} ";
        }


        private void loadFromSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txt_SQLToExecute.Text))
                {
                    this.btn_ClearGrid_Click(this, null);
                    dbHelper.odbcCommand = dbHelper.odbcConnection.CreateCommand();
                    dbHelper.odbcCommand.CommandText = this.txt_SQLToExecute.Text.Trim();

                    OdbcDataAdapter adapter = new OdbcDataAdapter(dbHelper.odbcCommand);
                    this.originTable = new DataTable();
                    this.originTable.TableName = "Table";
                    adapter.Fill(this.originTable);
                    this.originTable.Columns.Add("Processed");
                    this.originTable.Columns.Add("Errors");
                   
                    this.dgv_DataLoaded.DataSource = this.originTable;
                    this.dgv_DataLoaded.Refresh();
                    DisableColumnSorting();
                    this.dgv_DataLoaded.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                this.txt_Log.Text += "There is no valid SQL statement! " + ex.Message + "\r\n";
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string statement = "";
            if (batchStatements != null)
                for (int i = 0; i < batchStatements.Count; i++)
                {
                    statement += batchStatements[i] + "\r\n";
                }

            this.simulation = new Simulation(batchStatements);
            this.simulation.Show();
        }

        private void ExportDgvToXML()
        {
            DataTable dt = (DataTable)this.dgv_DataLoaded.DataSource;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dt.TableName = Path.GetFileNameWithoutExtension(sfd.FileName);
                    dt.WriteXml(sfd.FileName);
                }
                catch (Exception ex)
                {
                    this.txt_Log.Text +=   ex.ToString()+"\r\n";
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgv_DataLoaded.DataSource != null)
            {
                ExportDgvToXML();
            }
            else
            {
                this.txt_Log.Text += "The gridview contains no data.\r\n";
            }
        }

        private void ConvertXMLtoDataTable(string fileName)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(fileName, XmlReadMode.InferSchema);
            this.originTable = dataSet.Tables[0];
        }

        private void cmb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.originTable != null)
            {
                DataView dv;

                string value = this.cmb_filter.GetItemText(this.cmb_filter.SelectedItem);
                switch (value)
                {
                    case "All":
                        this.dgv_DataLoaded.DataSource = this.originTable;

                        break;
                    case "Not processed":

                        dv = new DataView(this.originTable, "Processed = '' ", "", DataViewRowState.CurrentRows);
                        this.dgv_DataLoaded.DataSource = dv.ToTable();
                        break;
                    case "Errors":

                        dv = new DataView(this.originTable, "Errors <> '' ", "", DataViewRowState.CurrentRows);
                        this.dgv_DataLoaded.DataSource = dv.ToTable();
                        break;
                    default:

                        this.dgv_DataLoaded.DataSource = this.originTable;
                        break;

                }

                this.dgv_DataLoaded.Refresh();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Stop threads if running
            //AutoSave 
        }

        private void tscmb_Database_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connection = "";
            string instance = this.tscmb_Database.ComboBox.SelectedItem.ToString();
            setting.Connectionstrings.TryGetValue(instance, out connection);
            dbHelper.connectionstring = connection;
            if (dbHelper.ConnectODBC())
            {
                this.txt_Log.Text += instance + " is online\r\n";

            }
            else
            {
                this.txt_Log.Text += instance + " is offline\r\n";

            }
        }

        private void loadFromFileXMLCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this.openFileDialog1.Filter = "XML Files| *.xml| CSV Files (*.csv)|*.csv";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fileName = this.openFileDialog1.FileName;
                string extension = Path.GetExtension(fileName);
                bool valid = true;
                if (extension == ".csv")
                {
                    ConvertCSVtoDataTable(fileName);
                }
                else if (extension == ".xml")
                {
                    ConvertXMLtoDataTable(fileName);
                }
                else
                {
                    this.txt_Log.Text += "Invalid file type.\r\n";
                    valid = false;
                }

                if (valid)
                {
                    this.dgv_DataLoaded.DataSource = this.originTable;
                    this.dgv_DataLoaded.Refresh();
                    DisableColumnSorting();
                    this.dgv_DataLoaded.ClearSelection();
                }
            }
        }

        private void btn_startProcessing_Click(object sender, EventArgs e)
        {
            if (batchStatements != null)
            {
                if (this.cbx_Protokol.Checked == true)
                {
                    WriteProtocolHeader();
                }
                this.txt_Log.Text += "Start executing statements.\r\n";
                this.btn_startProcessing.Enabled = false;
                this.bgw_Worker.RunWorkerAsync();

            }
        }


        private async void ProcessBatchAsync()
        {
            int allStatementsCount = (int)(batchStatements.Count / this.nud_threadCount.Value);
            int startIndex = 0;
            int count = 0;
            int indexToUpdate = 0;
            string message = "";
            for (int j = 1; j <= this.nud_threadCount.Value; j++)
            {
                if (j == this.nud_threadCount.Value)
                {
                    count = (allStatementsCount * j) + (batchStatements.Count-(int)(this.nud_threadCount.Value * allStatementsCount));
                }
                else
                {
                    count = (allStatementsCount * j);
                }

                if (j == 1)
                {
                    startIndex = 0;
                }
                else
                {
                    startIndex += allStatementsCount;
                }

                for (int i = startIndex; i < count; i++)
                {
                    
                    int cellCount = this.dgv_DataLoaded.Columns.Count;
                    int result = await dbHelper.ExcequteQueryODBCAsyncTransactionBased(batchStatements[i]);
                    if (result == 1)
                    {
                        indexToUpdate = 2;
                        message = " successful executed.";
                    }
                    else
                    {
                        indexToUpdate = 1;
                        message = " executed with errors.";
                    }

                    this.dgv_DataLoaded.BeginInvoke(new Action(() =>
                    {
                        if (i < this.dgv_DataLoaded.Rows.Count)
                        {
                            this.dgv_DataLoaded.Rows[i].Cells[cellCount - indexToUpdate].Value = DateTime.Now.ToString();

                            Log.WriteLine("Statement " + batchStatements[i] + message);
                        }
                    }));
                }
            }
        }

        private void bgw_Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            int cellCount = this.dgv_DataLoaded.Columns.Count;
            int indexToUpdate = 0;
            string message = "";
            for (int i = 0; i <= batchStatements.Count - 1; i++)
            {
                if (this.bgw_Worker.CancellationPending) { e.Cancel = true; return; }
                if (dbHelper.ExcequteQueryODBCTransactionBasedAsync(batchStatements[i]) == 1)
                {
                    indexToUpdate = 2;
                    message = " successful executed.";
                }
                else
                {
                    indexToUpdate = 1;
                    message = " executed with errors.";
                }

                this.dgv_DataLoaded.BeginInvoke(new Action(() =>
                {
                    if (i < this.dgv_DataLoaded.Rows.Count)
                    {
                        this.dgv_DataLoaded.Rows[i].Cells[cellCount - indexToUpdate].Value = DateTime.Now.ToString();

                        Log.WriteLine("Statement " + batchStatements[i] + message );
                    }
                }));

                this.bgw_Worker.ReportProgress((int)((i + 1) * 100 / batchStatements.Count));
            }
        }

        private void bgw_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pgb_Progress.Value = e.ProgressPercentage;
        }

        private void bgw_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.txt_Log.Text += "Processing canceld.\r\n";
            }
            else {
                this.txt_Log.Text += "Statements processed.\r\n";
            }
            this.pgb_Progress.Value = 0;
            this.btn_startProcessing.Enabled = true;
        }

        private void btn_stopProcessing_Click(object sender, EventArgs e)
        {
            this.bgw_Worker.CancelAsync();
            this.txt_Log.Text += "Waiting for cancellation.\r\n";
        }
    }
}
