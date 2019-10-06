using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    class BuildingResources: Building
    {
        private string ResourceType;

        public string RT
        {
            get { return ResourceType; }
            set { ResourceType = value; }
        }

        private int ResourcePerGameTick;

        public int RPGT
        {
            get { return ResourcePerGameTick; }
            set { ResourcePerGameTick = value; }
        }
        private int ResourceRemaing;

        public int resourceremaing
        {
            get { return ResourceRemaing; }
            set { ResourceRemaing = value; }
        }

        private int xpos;

        public int Xpos
        {
            get { return xpos; }
            set { xpos = value; }
        }

        private int ypos;

        public int Ypos
        {
            get { return Ypos; }
            set { Ypos = value; }
        }
     
        public void Resources() //brings resources to the map
        {
            if (resourceremaing < RPGT)
            {
                resourceremaing = resourceremaing + 50;
            }
            else if (resourceremaing > ResourcePerGameTick)
            {
                resourceremaing = resourceremaing - 50;
            }
        }
        public override bool Isdead()
        {
            if (resourceremaing < +0)
            {
               
               return false;
            }
            else
            {
                return true;
            }
        }
        private int DistanceTo(BuildingResources r)
        {
            if (r.GetType() == typeof(BuildingResources))
            {
                BuildingResources n = (BuildingResources)r;
                int d = (Xpos - n.Xpos) + Math.Abs(Ypos - n.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
        public BuildingResources(int x, int y ,int Health, int Team, string Symbol, int resourcesamount, int rescourcesremainin)
        {
            xpos -= x;
            ypos = y;
            Health = health;
            Team = team;
            Symbol = symbol;
            rescourcesremainin = resourceremaing;
            resourcesamount = ResourcePerGameTick ;
        }
        public override string Tostring()//displays nuilding resources
        {
            return "BR" + Xpos + "," + Ypos + "," + health + RT + ResourceRemaing + ResourcePerGameTick;
        }

    }
}
