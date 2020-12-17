using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Memory;
using System.Threading;

namespace Cyberpunk_2077___Car_FoV_Changer
{
    public partial class Form1 : Form
    {
        Mem m = new Mem();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            int iProcID = m.GetProcIdFromName("Cyberpunk2077.exe");

            if (iProcID > 0)
            {
                m.OpenProcess(iProcID);

                Thread TH = new Thread(WriteMemory);
                TH.Start();
            }
            else
            {
                MessageBox.Show("Could not find PID!\n\nPlease make sure to start the game before you run the program.", "Could not find PID!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            void WriteMemory()
            {
                while (true)
                {
                    if (this.checkBox1.Checked)
                    {
                        m.WriteMemory("Cyberpunk2077.exe+0x0","float", label1.Text);
                    }
                    Thread.Sleep(50);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ko-fi.com/aveniir");
        }
    }
}
