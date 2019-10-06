using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    class RangedUnit :Unit
    {
        public int Attack { get; internal set; }
        


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

        public RangedUnit(int x, int y, int Speed, int Range, int Health, int Team, string Symbol, int Attack)
        {
            xpos = x;
            ypos = y;
            Health = health;
            speed = Speed;
            Range = range;
            Team = team;
            symbol = Symbol;
            attack = Attack;
        }

        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit n = (MeleeUnit)u;
                int d = (xpos -  n.Xpos) + Math.Abs(ypos - n.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }

        public Direction DirectionTo(Unit u)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit n = (RangedUnit)u;
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
            if (u.GetType() == typeof(RangedUnit))
            {
                health -= ((RangedUnit)u).attack;

            }
            else if (u.GetType() == typeof(MeleeUnit))
            {
                health -= ((MeleeUnit)u).Attack;
                health -= ((MeleeUnit)u).Attack;

            }

        }
        public override bool Inranged(Unit u)
        {
            if (u.GetType() == typeof(RangedUnit))
            {
                RangedUnit n = (RangedUnit)u;
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
                if (((RangedUnit)u).team == team)
                {
                    if (DistanceTo(u) < closestDistance)
                    {
                        closest = u;
                        closestDistance = DistanceTo((RangedUnit)u);
                    }
                }             
            }
            return closest;
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
        public override string Tostring()
        {
            return "RU" + xpos + "," + ypos + "," + health + "," + Name + team;
        }

    }
}
