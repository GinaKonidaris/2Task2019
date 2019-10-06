using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    public abstract class Building
    {
        protected int Xpos;
        protected int Ypos;
        protected int team;
        protected int health;
        protected string symbol;
    
        abstract public bool Isdead();
        abstract public string Tostring();
    }
}
