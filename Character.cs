using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders
{
    internal class Character
    {
        public Size Size { get; set; }

        public Point Location { get; set; }

        public int Speed { get; set; }

        public int Lives { get; set; }

        public bool MoveRight { get; set; }

        public bool MoveLeft { get; set; }
    }
}
