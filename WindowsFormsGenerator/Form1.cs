using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            vs = new List<int>();
        }
        static public int end=int.MaxValue;
        static public int start = 2;
        static public List<int> vs;
        static void ThreadFunk()
        {
            for (int i = start; i <= end; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b) vs.Add(i);
            }

        }
        static ThreadStart Start = new ThreadStart(ThreadFunk);
        Thread thread = new Thread(Start );
        private void btnStart_Click(object sender, EventArgs e)
        {if (txtMax.Text.Length != 0)
            { end = Convert.ToInt32(txtMax.Text); }
            if (txtMin.Text.Length != 0)
            { start = Convert.ToInt32(txtMin.Text); }
            listBoxNum.Items.Clear();
            try
            {
                thread.Start();
            Thread.Sleep(1000);
            foreach (var item in vs)
            {
              listBoxNum.Items.Add(item);
            }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        [Obsolete]
        private void btnStop_Click(object sender, EventArgs e)
        {
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            listBoxNum.Items.Clear();
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            start = Convert.ToInt32(txtMin.Text);
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            end = Convert.ToInt32(txtMax.Text);
        }
    }
}
