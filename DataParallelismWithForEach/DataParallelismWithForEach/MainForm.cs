using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace DataParallelismWithForEach
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }        
    }
}
