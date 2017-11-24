using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    class GameController
    {
        private Game MyLevel;
        private IView MyView;

        public GameController(IView view, Game level)
        {
            MyLevel = level;
            MyView = view;
        }

        public bool StartGame()
        {
            while (!MyLevel.IsComplete())
            {
                MyLevel.MovePlayer(MyView.GetMove());
            }
            return true;
        }

        public bool FinishGame()
        {
            return MyLevel.IsComplete();
        }
    }
}
