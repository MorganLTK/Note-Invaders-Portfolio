using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Enemy
    {
        public Size Size { get; set; }

        public Point Location { get; set; }

        public int Speed { get; set; }

        public int Health { get; set; }
        public int Type { get; set; }

        public bool MoveRight { get; set; }

        public Enemy(int t)
        {
            Type = t;
            if(t == 0 || t == 1)
            {
                Health = 1;
                Speed = 5;
            }
            else if (t  == 2 || t == 3) 
            {
                Health = 2;
                Speed = 4;
            }
        }
    }
}
