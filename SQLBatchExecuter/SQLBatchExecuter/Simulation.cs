using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLBatchExecuter
{
    public partial class Simulation : Form
    {
        public Simulation(List<string> statementList)
        {
            InitializeComponent();
            this.dud_statementList.Items.AddRange(statementList);
            //this.textBox1.Text = statement;
        }

        private void dud_statementList_SelectedItemChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = this.dud_statementList.SelectedItem.ToString();
        }
    }
}
