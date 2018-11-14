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

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
                {
                    ProcessIntData();
                });
        }       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
        private void ProcessIntData()
        {
            try
            {
                int[] innum = Enumerable.Range(1, 50000000).ToArray();
                int[] mas3 = null;
                try
                {
                    mas3 = (from nm in innum.AsParallel().WithCancellation(cts.Token) where nm % 3 == 0 orderby nm descending select nm).ToArray();
                    MessageBox.Show(string.Format("Found {0} numbers that match query!", mas3.Count()));
                }
                catch (OperationCanceledException ex)
                {
                    this.Invoke((Action)delegate
                    {
                        textBox1.Text = ex.Message;
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}", ex.Message));
            }
        }
    }
}
