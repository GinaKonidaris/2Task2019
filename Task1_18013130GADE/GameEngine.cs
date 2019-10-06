using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_18013130GADE
{
    class GameEngine : Form
    {
        GroupBox groupBox1;
        private int round;
        Map map = new Map(20, 20, 20);
        const int START_X = 20;
        const int START_Y = 20;
        const int SPACING = 10;
        const int SIZE = 20;
        Random r = new Random();

        public int Round
        {
            get { return round; }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void InitializeMyGroupBox()
        {
            // Create and initialize a GroupBox and a Button control.
            GroupBox groupBox1 = new GroupBox();
            foreach (Unit u in map.Units)
            {
                if (GetType() == typeof(MeleeUnit))
                {
                    int start_x; int start_y;
                    start_x = groupBox1.Location.X;
                    start_y = groupBox1.Location.Y;
                    MeleeUnit n = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(START_X + (n.Xpos * SIZE), START_Y + (n.Ypos * SIZE));
                    b.Text = n.Symbol;
                    if (n.Team == 1)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                    if (n.Isdead())
                    {
                        b.ForeColor = Color.Black;
                    }
                    b.Click += new EventHandler(btnButton_Click);
                    groupBox1.Controls.Add(b);

                    this.Controls.Add(b);
                   
                }
                else if (u.GetType() == typeof(Building)) // displays building
                {
                    int start_x; int start_y;
                    start_x = groupBox1.Location.X;
                    start_y = groupBox1.Location.Y;
                    MeleeUnit n = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(START_X + (n.Xpos * SIZE), START_Y + (n.Ypos * SIZE));
                    b.Text = n.Symbol;
                    b.ForeColor = Color.Beige;
                }
            }

        }
        public void UpdateMap()
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit n = (MeleeUnit)u;
                    if (n.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: ((MeleeUnit)u).Move(Direction.North); break;
                            case 1: ((MeleeUnit)u).Move(Direction.East); break;
                            case 2: ((MeleeUnit)u).Move(Direction.South); break;
                            case 3: ((MeleeUnit)u).Move(Direction.West); break;
                        }
                    }
                    else // In comabt or moving towards
                    {
                        bool inCombat = false;

                        foreach (Unit e in map.Units)
                        {
                            if (u.Inranged(e)) // Incombat
                            {
                                u.Combat(e);
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.Closest(map.Units);

                            u.Move(n.DirectionTo(c));

                        }
                    }
                }
            }
            round++;
        }            
    public GameEngine(int numUnits, TextBox txtInfo, GroupBox gMap)
        {
            groupBox1 = gMap;
            map = new Map(numUnits, txtInfo);

            round = 1;
        }
        void btnButton_Click(object sender, EventArgs e)
        {

        }

     }
}

    

