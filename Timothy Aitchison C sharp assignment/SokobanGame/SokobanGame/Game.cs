using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    class Game : IGame
    {
        private int PlayerX;
        private int PlayerY;
        private int RowCount;
        private int RowWidth;
        private List<GridSquare> MyGrid;
        private List<GridSquare> MyBoxes;
        private List<GridSquare> MyGoals;
        private Stack<Save> MoveHistory;

        public Game(int rowWidth, int rowCount, int playerPosX, int playerPosY, string levelDesign)
        {
            MoveHistory = new Stack<Save>();
            PlayerX = playerPosX;
            PlayerY = playerPosY;
            RowCount = rowCount;
            RowWidth = rowWidth;
            levelDesign = ValidateLevel(levelDesign);
            BuildLevel(levelDesign);
            if (Validate() && WhatIsHere(PlayerX, PlayerY) != '_' && WhatIsHere(PlayerX, PlayerY) != '.')
            {
                FindGridSquare(PlayerX, PlayerY).Contents = Blocks.Floor;
            }
        }

        public int PlayerPosX
        {
            get
            {
                return PlayerX;
            }
        }

        public int PlayerPosY
        {
            get
            {
                return PlayerY;
            }
        }

        public List<GridSquare> AllMyBoxes
        {
            get
            {
                return MyBoxes;
            }
        }

        public List<GridSquare> AllMyGoals
        {
            get
            {
                return MyGoals;
            }
        }

        /*
         *  Getters over properties because the interface requires them
         */
        public int GetPlayerPosX()
        {
            return PlayerX;
        }
        public int GetPlayerPosY()
        {
            return PlayerY;
        }
        public int GetRowCount()
        {
            return RowCount;
        }
        public int GetRowWidth()
        {
            return RowWidth;
        }

        public int GetMoveCount()
        {
            return MoveHistory.Count;
        }

        public Stack<Save> GetMoveHistory()
        {
            return MoveHistory;
        }

        public void UndoMove()
        {
            if (MoveHistory.Count > 0)
            {
                Save theSave = MoveHistory.Pop();
                PlayerX = theSave.GetPlayerX();
                PlayerY = theSave.GetPlayerY();
                BuildLevel(theSave.GetDesign());
            }
        }

        private void SaveMove()
        {
            Save newSave = new Save(GetLevelDesign(), PlayerX, PlayerY);
            MoveHistory.Push(newSave);
        }

        private string ValidateLevel(string levelDesign)
        {
            int expectedLength = RowCount * RowWidth;
            while (levelDesign.Length < expectedLength)
            {
                levelDesign = levelDesign + " ";
            }
            return levelDesign;
        }

        private void BuildLevel(string levelDesign)
        {
            MyGrid = new List<GridSquare>();
            MyBoxes = new List<GridSquare>();
            MyGoals = new List<GridSquare>();

            for (var y = 0; y < RowCount; y += 1)
            {
                for (var x = 0; x < RowWidth; x += 1)
                {
                    int stringPosition = y * RowWidth + x;
                    char stringContent = levelDesign[stringPosition];
                    Blocks contents;
                    Boolean isGoal = false;

                    if (stringContent == '.')
                    {
                        isGoal = true;
                        contents = (Blocks.Empty);
                    }
                    else if(stringContent == '!')
                    {
                        isGoal = true;
                        contents = (Blocks.Moveable);
                    }
                    else
                    {
                        contents = (Blocks)stringContent;
                    }
                    GridSquare newSquare = new GridSquare(x, y, contents, isGoal);
                    if (newSquare.Contents == Blocks.Moveable)
                    {
                        AllMyBoxes.Add(newSquare);
                    }
                    if (newSquare.Goal)
                    {
                        AllMyGoals.Add(newSquare);
                    }
                    MyGrid.Add(newSquare);
                }
            }
        }

        private GridSquare FindGridSquare(int x, int y)
        {
            foreach (GridSquare square in MyGrid)
            {

                if (square.YPos == y && square.XPos == x)
                {
                    return square;
                }
            }
            return null;
        }

        private Boolean CheckMove(Direction direction)
        {
            Boolean result = false;
            GridSquare target;
            GridSquare nextTarget;
            switch (direction)
            {
                case Direction.Up:
                    target = FindGridSquare(PlayerX, PlayerY - 1);
                    nextTarget = FindGridSquare(PlayerX, PlayerY - 2);
                    break;
                case Direction.Down:
                    target = FindGridSquare(PlayerX, PlayerY + 1);
                    nextTarget = FindGridSquare(PlayerX, PlayerY + 2);
                    break;
                case Direction.Left:
                    target = FindGridSquare(PlayerX - 1, PlayerY);
                    nextTarget = FindGridSquare(PlayerX - 2, PlayerY);
                    break;
                case Direction.Right:
                    target = FindGridSquare(PlayerX + 1, PlayerY);
                    nextTarget = FindGridSquare(PlayerX + 2, PlayerY);
                    break;
                default:
                    target = FindGridSquare(PlayerX, PlayerY);
                    nextTarget = FindGridSquare(PlayerX, PlayerY);
                    break;
            }
            if (target == null)
            {
                return false;
            }
            Blocks contents = target.Contents;
            switch (contents)
            {
                case Blocks.Empty:
                    result = true;
                    break;
                case Blocks.Solid:
                    result = false;
                    break;
                case Blocks.Moveable:
                    if (nextTarget == null || nextTarget.Contents != Blocks.Empty)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        public bool IsComplete()
        {
            foreach (GridSquare square in MyGoals)
            {
                if (square.Contents != Blocks.Moveable)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Validate()
        {
            bool playerExists = PlayerX >= 0 && PlayerY >= 0;
            int moveables = 0;
            int floors = 0;
            int goals = 0;
            foreach (GridSquare square in MyGrid)
            {
                if(square.Contents == Blocks.Moveable)
                {
                    moveables++;
                }
                if (square.Contents == Blocks.Floor)
                {
                    floors++;
                }
                if (square.Goal == true)
                {
                    goals++;
                }
            }
            return floors > 0 && goals == moveables && moveables > 0 && playerExists;
        }

        public char WhatIsHere(int x, int y)
        {
            GridSquare location = FindGridSquare(x, y);
            Blocks contents = location.Contents;
            if (location.Goal && location.Contents == Blocks.Empty)
            {
                return '.';
            }
            else if (location.Goal && location.Contents == Blocks.Moveable)
            {
                return '!';
            }
            else
            {
                return (char)contents;
            }
        }

        public void MovePlayer(int direction)
        {
            if (CheckMove((Direction)direction))
            {
                GridSquare playerSquare;
                GridSquare moveTo;
                SaveMove();
                switch ((Direction)direction)
                {
                    case Direction.Up:
                        PlayerY -= 1;
                        playerSquare = FindGridSquare(PlayerX, PlayerY);
                        if (playerSquare.Contents == Blocks.Moveable)
                        {
                            moveTo = FindGridSquare(PlayerX, PlayerY - 1);
                            playerSquare.Contents = Blocks.Empty;
                            moveTo.Contents = Blocks.Moveable;
                        }
                        break;
                    case Direction.Down:
                        PlayerY += 1;
                        playerSquare = FindGridSquare(PlayerX, PlayerY);
                        if (playerSquare.Contents == Blocks.Moveable)
                        {
                            moveTo = FindGridSquare(PlayerX, PlayerY + 1);
                            playerSquare.Contents = Blocks.Empty;
                            moveTo.Contents = Blocks.Moveable;
                        }
                        break;
                    case Direction.Left:
                        PlayerX -= 1;
                        playerSquare = FindGridSquare(PlayerX, PlayerY);
                        if (playerSquare.Contents == Blocks.Moveable)
                        {
                            moveTo = FindGridSquare(PlayerX - 1, PlayerY);
                            playerSquare.Contents = Blocks.Empty;
                            moveTo.Contents = Blocks.Moveable;
                        }
                        break;
                    case Direction.Right:
                        PlayerX += 1;
                        playerSquare = FindGridSquare(PlayerX, PlayerY);
                        if (playerSquare.Contents == Blocks.Moveable)
                        {
                            moveTo = FindGridSquare(PlayerX + 1, PlayerY);
                            playerSquare.Contents = Blocks.Empty;
                            moveTo.Contents = Blocks.Moveable;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string GetLevelDesign()
        {
            string levelDesign = "";
            foreach(GridSquare square in MyGrid)
            {
                switch (square.Contents)
                {
                    case Blocks.Empty:
                        if (square.Goal)
                        {
                            levelDesign += ".";
                        }
                        else
                        {
                            levelDesign += " ";
                        }
                        break;
                    case Blocks.Moveable:
                        if (square.Goal)
                        {
                            levelDesign += "!";
                        }
                        else
                        {
                            levelDesign += "$";
                        }
                        break;
                    case Blocks.Solid:
                        levelDesign += "#";
                        break;
                }
            }
            return levelDesign;
        }

        public Boolean IsWon()
        {
            foreach(var gridSquare in MyGrid)
            {
                if(gridSquare.Goal)
                {
                    if(gridSquare.Contents != Blocks.Moveable)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}