using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    class BuildingFactory: Building
    {
        private int UnitProduce;

        public int unitproduce
        {
            get { return UnitProduce; }
            set { UnitProduce = value; }
        }

        private int GameTickPerProduct;

        public int GTPP
        {
            get { return GameTickPerProduct; }
            set { GameTickPerProduct = value; }
        }

        private int Spawnpostion;

        public int spawnpostion
        {
            get { return Spawnpostion; }
            set { Spawnpostion = value; }
        }

        private int Xpos;

        public int xpos
        {
            get { return Xpos; }
            set { Xpos = value; }
        }

        private int Ypos;

        public int ypos
        {
            get { return Ypos; }
            set { Ypos = value; }
        }

        private string Symbol;

        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        private string Team;

        public string team
        {
            get { return Team; }
            set { Team = value; }
        }

        public void Spawn()// spawns building to other users
        {
            if (spawnpostion == unitproduce)
            {
                spawnpostion = spawnpostion + 1;
            }
            else if (spawnpostion < unitproduce)
            {
                spawnpostion = spawnpostion + 50;
            }
        }
        private int DistanceTo(BuildingResources b)//checks the distance to other buildings
        {
            if (b.GetType() == typeof(BuildingResources))
            {
                BuildingResources f = (BuildingResources)b;
                int d = (Xpos - f.Xpos) + Math.Abs(Ypos - f.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
        private int DistanceTo(Building b)
        {
            throw new NotImplementedException();
        }
        public override bool Isdead()
        {
            if (health < +0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public BuildingFactory(int x, int y, int Health, string Team, string Symbol, int resourcesamount, int rescourcesremainin)
        {
            xpos -= x;
            ypos = y;
            Health = health;
            Team = team;
            Symbol = symbol;
        }
        public override string Tostring()
        {
            return "BR" + Xpos + "," + Ypos + "," + health +symbol+ spawnpostion + team ;
        }

    }
}

