using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Memory;

namespace SaintsRowTheThirdRemasteredTrainer
{
    public partial class SaintsRow3RemasteredTrainer : Form
    {
        Mem m = new Mem();

        //offsets are working
        public SaintsRow3RemasteredTrainer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int PID = m.GetProcIdFromName("SRTTR");
            if (PID > 0)
            {
                m.OpenProcess(PID);
                label1.ForeColor = Color.Green;
                label1.Text = "Saints Row The Third Remastered connected!";
                label2.ForeColor = Color.Green;
                label2.Text = "Functions successfully loaded!";

                Thread AMM = new Thread(unlAmmo);
                AMM.Start();

                Thread UH = new Thread(unHealth);
                UH.Start();
            }
            else
            {
                MessageBox.Show("Game not found! Please start ur Game first and wait until u spawn ingame. Start Cheat again");
            }
        }

        private void addMoneyButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                m.WriteMemory("SRTTR.exe+0x11EAF30,1E90", "int", textBox1.Text + "00");

            }

            /*
             * alle grünen pointer:
             * SRTTR.exe+0x11EAF30,1E90
             * SRTTR.exe+0x1A24980,1E90
             * SRTTR.exe+0x1A598F8,1E90
             * SRTTR.exe+0x1E21490,1E90
             * SRTTR.exe+0x1E3DDF0,1E90
             * SRTTR.exe+0x2052398,1E90
             * SRTTR.exe+0x26CF328,1E90
             * SRTTR.exe+0x28C8650,1E90
             */
        }

        private void unlAmmo()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    m.WriteMemory("SRTTR.exe+0x1A0D0E8,204", "int", "8");
                    Thread.Sleep(10);
                }
            }
            /* green pointer
             * SRTTR.exe+0x1A0D0E8,204
             */
        }

        private void unHealth()
        {
            while (true)
            {
                if (checkBox2.Checked)
                {
                    m.WriteMemory("SRTTR.exe+0x11EAF30,1EA8", "int", "1148846080");
                    Thread.Sleep(10);
                }
            }
            /*
             * SRTTR.exe+0x11EAF30,1EA8
             * SRTTR.exe+0x1A24980,1EA8
             * SRTTR.exe+0x1A598F8,1EA8
             * SRTTR.exe+0x1E21490,1EA8
             * SRTTR.exe+0x1E3DDF0,1EA8
             * SRTTR.exe+0x2052398,1EA8
             * SRTTR.exe+0x26CF328,1EA8
             * SRTTR.exe+0x28C8650,1EA8
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.WriteMemory("SRTTR.exe+0x11EAF30,2054", "int", "255500");
            MessageBox.Show("Get ingame XP to trigger this hack. headshot on enemy or something");

            /*
             * SRTTR.exe+0x11EAF30,2054
             * SRTTR.exe+0x1A24980,2054
             * SRTTR.exe+0x1A598F8,2054
             * SRTTR.exe+0x1E21490,2054
             * SRTTR.exe+0x1E3DDF0,2054
             * SRTTR.exe+0x2052398,2054
             * SRTTR.exe+0x26CF328,2054
             */
        }
    }
}
