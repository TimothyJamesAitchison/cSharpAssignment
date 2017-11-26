using System.Windows.Forms;

namespace SokobanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowWidth = 9;
            int rowCount = 9;
            int playerPosX = 2;
            int playerPosY = 2;
            string levelDesign = "#########"
                               + "# .     #"
                               + "#       #"
                               + "#   $   #"
                               + "#  $$$ .#"
                               + "#       #"
                               + "#.      #"
                               + "#      .#"
                               + "#########";
                               
            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new GameDrawingView(level));
            Application.Run(new GameView(level));
        }
    }
}
