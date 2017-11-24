using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    class GridSquare
    {
        private int MyX;
        private int MyY;
        private Boolean IsGoal;
        private Blocks MyContents;

        public GridSquare(int xPos, int yPos, Blocks contents, Boolean isGoal)
        {
            IsGoal = isGoal;
            MyY = yPos;
            MyX = xPos;
            MyContents = contents;
        }

        public Boolean Goal
        {
            get
            {
                return IsGoal;
            }
        }

        public int XPos
        {
            get
            {
                return MyX;
            }
        }

        public int YPos
        {
            get
            {
                return MyY;
            }
        }

        public Blocks Contents
        {
            set
            {
                MyContents = value;
            }
            get
            {
                return MyContents;
            }
        }
    }
}
