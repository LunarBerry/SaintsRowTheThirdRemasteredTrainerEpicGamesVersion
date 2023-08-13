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
                m.WriteMemory("SRTTR.exe+0x11E9F20,1E90", "int", textBox1.Text + "00");

            }

            /*
             * alle offset möglichkeiten:
             * SRTTR.exe+11E9F20,1E90
             * SRTTR.exe+1A588F8,1E90
             * SRTTR.exe+1E22A10,1E90
             * SRTTR.exe+1E3F370,1E90
             * SRTTR.exe+254B710,1E90
             * SRTTR.exe+2884028,1E90
             */
        }

        private void unlAmmo()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    m.WriteMemory("SRTTR.exe+0x1A0C0E8,204", "int", "40");
                    Thread.Sleep(50);
                }
            }
            /*
             * 1A8B812CD78,204
             * 1A8B8087DD8,204
             * 1A8B7AF6038,204
             * 1A8B7A6C1A0,204
             * 1A8B7A3B1D8,204
             */
        }

        private void unHealth()
        {
            while (true)
            {
                if (checkBox2.Checked)
                {
                    m.WriteMemory("SRTTR.exe+0x1E22A10,1EA8", "int", "1148846080");
                    Thread.Sleep(50);
                }
            }
            /*
             * SRTTR.exe+0x1A23980,1EA8
             * SRTTR.exe+1A588F8,1EA8
             * SRTTR.exe+1E22A10,1EA8
             * SRTTR.exe+1E26668,1EA8
             * SRTTR.exe+1E3F370,1EA8
             * SRTTR.exe+20538F8,1EA8
             * SRTTR.exe+254B7F0,1EA8
             * SRTTR.exe+26C4A40,1EA8
             * SRTTR.exe+2884028,1EA8
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.WriteMemory("SRTTR.exe+0x1E22A10,2054", "int", "255500");
            MessageBox.Show("Deine XP/EP wurden gesetzt. Steig in ein Straßenfahrzeug und mache knappe überholmanöver. Anschließend stehen bleiben und 3-10 Sekunden warten bis die XP/EP gezählt werden.");

            /*
             * SRTTR.exe+1E22A10,2054
             * SRTTR.exe+026C4A58,178
             * SRTTR.exe+026C4A58
             */
        }
    }
}
