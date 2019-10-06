using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    public enum Direction { North, East, South, West };

    public abstract class Unit
    {
        protected int xpos;
        protected int ypos;
        protected int attack;
        protected int speed;
        protected int range;
        protected int team;
        protected int health;
        protected string symbol;
        protected string Name;

        abstract public void Move(Direction direction);
        abstract public void Combat(Unit u);
        abstract public bool Inranged(Unit u);
        abstract public Unit Closest(Unit[] units);
        abstract public bool Isdead();
        abstract public string Tostring();
    }
}
