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
        static public int end;
        static public int start;
        static public List<int> vs;
        static void ThreadFunk()
        {
            vs.Clear();
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
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtMin.Text.Length != 0)
            { start = Convert.ToInt32(txtMin.Text); }
            if(txtMin.Text.Length == 0)
            {
                start = 2;
            }
            if (txtMax.Text.Length != 0)
            { 
                end = Convert.ToInt32(txtMax.Text);
            }
            if(txtMax.Text.Length== 0)
            {
                end = int.MaxValue;
            } 
            listBoxNum.Items.Clear();    
            try
            {Thread thread = new Thread(Start );
                thread.Start();
                Thread.Sleep(1000);
                foreach (var item in vs)
                {
                    listBoxNum.Items.Add(item);
                }
                MessageBox.Show("Текущий поток " + thread.ManagedThreadId.ToString() + " в состоянии " + thread.ThreadState);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
        private void btnStop_Click(object sender, EventArgs e)
        {
           
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            listBoxNum.Items.Clear();
            
        }

        
    }
}
