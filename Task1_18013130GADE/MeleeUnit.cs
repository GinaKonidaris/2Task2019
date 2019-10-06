using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    class MeleeUnit : Unit
    {
        public int Attack { get; internal set; }
        public int Team { get; internal set; }
        public int Xpos { get; internal set; }
        public int Ypos { get; internal set; }
        public int Health { get; internal set; }
        public string Symbol { get; internal set; }
        public override void Move(Direction d)
        {
            switch (d)
            {
                case Direction.North:
                    {
                        ypos -= speed;
                        break;
                    }
                case Direction.East:
                    {
                        xpos += speed;
                        break;
                    }
                case Direction.West:
                    {
                        xpos -= speed;
                        break;
                    }
                case Direction.South:
                    {
                        ypos += speed;
                        break;
                    }
            }
        }
        public MeleeUnit(int x, int y, int Speed, int Range, int Health, int Team, string Symbol, int Attack)
        {
            xpos -= x;
            ypos = y;
            Health = this.Health;
            Speed = speed;
            Range = range;
            Team = team;
            Symbol = this.Symbol;
            Attack = attack;
        }

        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit n = (MeleeUnit)u;
                int d = (xpos - n.xpos) + Math.Abs(ypos - n.ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }

        public Direction DirectionTo(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit n = (MeleeUnit)u;
                if (n.xpos < n.ypos)
                {
                    return Direction.North;
                }
                else if (n.xpos > xpos)
                {
                    return Direction.South;
                }
                else if (n.ypos < ypos)
                {
                    return Direction.West;
                }
                else
                {
                    return Direction.East;
                }
            }
            else
            {
                return Direction.North;
            }
        }
        public override void Combat(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                Health -= ((MeleeUnit)u).attack;

            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                Health -= ((RangedUnit)u).Attack;
                Health -= ((RangedUnit)u).Attack;
            }
        }
        public override bool Inranged(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit n = (MeleeUnit)u;
                if (DistanceTo(u) <= range)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override Unit Closest(Unit[] units)
        {
            Unit closest = this;
            int closestDistance = 50;

            foreach (Unit u in units)
            {
                if (((MeleeUnit)u).team == team)
                {
                    if (DistanceTo(u) < closestDistance)
                    {
                        closest = u;
                        closestDistance = DistanceTo((MeleeUnit)u);
                    }
                }
            }   
            return closest;
        }
        public override bool Isdead()
        {
            if (Health < +0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string Tostring()
        {
            return "MU" + xpos + "," + ypos + "," + Health + "," + Name + team;
        }
    }
}
