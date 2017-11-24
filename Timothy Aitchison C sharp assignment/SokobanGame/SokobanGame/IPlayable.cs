using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public interface IPlayable
    {
        void MovePlayer(int direction);

        int GetMoveCount();

        void UndoMove();

        Boolean IsWon();
    }
}
