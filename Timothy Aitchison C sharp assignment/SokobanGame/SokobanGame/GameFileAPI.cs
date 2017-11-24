using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    class GameFileAPI
    {
        private string LevelContent;
        private IFileHandler MyFileHandler;

        public GameFileAPI()
        {
            LevelContent = "";
        }

        public bool GetGameFiles()
        {
            if(MyFileHandler != null)
            {
                LevelContent = MyFileHandler.LoadFile("test.txt");
            }
            return true;
        }

        public void AddFileHandler(IFileHandler handler)
        {
            MyFileHandler = handler;
        }

        public ILoadable LoadLevels()
        {
            try
            {
                string[] levelData = LevelContent.Split(';');
                int playerX = int.Parse(levelData[0]);
                int playerY = int.Parse(levelData[1]);
                int rowCount = int.Parse(levelData[2]);
                int rowWidth = int.Parse(levelData[3]);
                string levelDesign = levelData[4];
                return new Loadable(playerX, playerY, rowCount, rowWidth, levelDesign);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }

        }
    }
}
