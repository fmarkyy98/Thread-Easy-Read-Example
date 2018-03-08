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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Thread t = new Thread(dummyRead); // Created a thread vith dummiRead parameter. It means the Thread will execute that function.

        public Form1()
        {
            InitializeComponent();
        }

        static private void dummyRead()
        {
            Thread.Sleep(3000); // Here you can write your file reading (the long period of time reading).
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start(); // Here I start the Thread to start the reading.
            timer1.Start(); // I created a timer as a listener, that detect the time when the reading is finished.
            // You can type here any code that doesn't requires a succesfull reading.
        }

        private void timer1_Tick(object sender, EventArgs e) // Here is the listener.
        {
            #region labelProgressTextChanger
            switch (label1.Text)
            {
                case "Reading in progress":
                    label1.Text = "Reading in progress.";
                    break;
                case "Reading in progress.":
                    label1.Text = "Reading in progress..";
                    break;
                case "Reading in progress..":
                    label1.Text = "Reading in progress...";
                    break;
                case "Reading in progress...":
                    label1.Text = "Reading in progress";
                    break;
                default:
                    label1.Text = "Reading in progress";
                    break;
            }
            #endregion
            // Just some design.

            if (t.ThreadState == ThreadState.Stopped) // if the t Thread stopped returns true.
            {
                label1.Text = "Reading finished!";
                label1.ForeColor = Color.Green;
                timer1.Stop(); // Stop the timer to finish the listening.
            }
        }
    }
}
