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
         static public List<int> vs;
        static void Method()
        {
            for (int i = 2; i <= end; i++)
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
        static ThreadStart Start = new ThreadStart(Method);
        Thread thread = new Thread(Start );
        private void btnStart_Click(object sender, EventArgs e)
        {
            thread.Start();
            foreach(var item in vs)
            {
              listBoxNum.Items.Add(item);
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            listBoxNum.Items.ToString();
        }
    }
}
