using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task1_18013130GADE
{
    public partial class Form1 : Form
    {
        GameEngine engine;
        Map map = new Map(20, 20, 20);
        const int SIZE = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, txtInfo, groupBox1);
            DisplayMap();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
     
        }
        private void DisplayMap()
        {  
            groupBox1.Controls.Clear();
            
        }
            private void Timer2_Tick(object sender, EventArgs e)
        {
            
        }
        private void Button_click(object sender, EventArgs e)
        {
            int x = ((Button)sender).Location.X / SIZE - groupBox1.Location.X / SIZE;
            int y = ((Button)sender).Location.Y / SIZE - groupBox1.Location.Y / SIZE;
            foreach (MeleeUnit u in map.Units)
            {

                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit n = (MeleeUnit)u;
                    if (n.Xpos == x && n.Ypos == y)
                    {
                        txtInfo.Text = "Button CLicked at" + n.Tostring();
                    }

                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            engine.UpdateMap();
            txtInfo.Text = DateTime.Now.ToLongTimeString();
            DisplayMap();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Form1 b = new Form1();
            b.Name = txtName.Text;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("Map.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, b);
                    MessageBox.Show("Map Info Saved");
                }
            }
            catch
            {
                MessageBox.Show("Error occurred");
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            Form1 b = new Form1();

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("Map.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    b = (Form1)bf.Deserialize(fsin);
                    txtName.Text = b.ToString();
                    MessageBox.Show("Map Info Loaded");
                }
            }
            catch
            {
                MessageBox.Show("Error occurred");
            }
        }
    }
}
