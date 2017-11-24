using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    class Loadable : ILoadable
    {
        private int PlayerPosX;
        private int PlayerPosY;
        private int RowCount;
        private int RowWidth;
        private string LevelDesign;

        public Loadable(int playerPosX, int playerPosY, int rowCount, int rowWidth, string levelDesign)
        {
            PlayerPosX = playerPosX;
            PlayerPosY = playerPosY;
            RowCount = rowCount;
            RowWidth = rowWidth;
            LevelDesign = levelDesign;
        }

        public string GetLevelDesign()
        {
            return LevelDesign;
        }

        public int GetPlayerPosX()
        {
            return PlayerPosX;
        }

        public int GetPlayerPosY()
        {
            return PlayerPosY;
        }

        public int GetRowCount()
        {
            return RowCount;
        }

        public int GetRowWidth()
        {
            return RowWidth;
        }
    }
}
