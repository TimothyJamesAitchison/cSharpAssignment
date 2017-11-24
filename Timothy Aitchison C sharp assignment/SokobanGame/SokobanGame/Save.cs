using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    class Save
    {
        private string MyDesign;
        private int PlayerX;
        private int PlayerY;

        public Save(string design, int playerX, int playerY)
        {
            MyDesign = design;
            PlayerX = playerX;
            PlayerY = playerY;
        }

        public string GetDesign()
        {
            return MyDesign;
        }

        public int GetPlayerX()
        {
            return PlayerX;
        }

        public int GetPlayerY()
        {
            return PlayerY;
        }

    }
}
