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
            Threads = new List<Thread>();
        }
        static public int end;
        static public int start;
        static public List<int> vs;
        public List<Thread> Threads;
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
        static void Fibonachi()
        {
            vs.Clear();
            int j = 1;
            for (int i = 1; i <= end; i += j)
            {
                j = i - j;
                vs.Add(i);
            }
        }
        static ThreadStart Start = new ThreadStart(ThreadFunk);
        static ThreadStart Start1 = new ThreadStart(Fibonachi);
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
                Threads.Add(thread);
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
            try
            {
              Thread.CurrentThread.Interrupt();
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            listBoxNum.Items.Clear();

        }

        private void btnFib_Click(object sender, EventArgs e)
        {
            if (txtMin.Text.Length != 0)
            { start = Convert.ToInt32(txtMin.Text); }
            if (txtMin.Text.Length == 0)
            {
                start = 1;
            }
            if (txtMax.Text.Length != 0)
            {
                end = Convert.ToInt32(txtMax.Text);
            }
            if (txtMax.Text.Length == 0)
            {
                end = int.MaxValue;
            }
            listBoxNum.Items.Clear();
            try
            {
                Thread thread = new Thread(Start1);
                thread.Start();
                Threads.Add(thread);
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

        private void btnShowThreads_Click(object sender, EventArgs e)
        {
            listBoxThreads.Items.Clear();
            foreach (var item in Threads)
            {
                listBoxThreads.Items.Add(item.ManagedThreadId.ToString() + " " + item.ThreadState);
            }
        }
    }
}
