using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;

namespace SokobanTest
{

    /*
     * NOTES:
     * 
     * To create a new level it requires certain attributes:
     * rowWidth is how WIDE the level is, e.g. how many columns if it was a table
     * rowCount is how TALL the level is, e.g. how many rows if it was a table
     * playerPosX and playerPosY is what cell the player starts in, e.g. 0, 0 would be top left
     * 
     * levelDesign is a string:
     * 
     * #####
     * #   #
     * #   #
     * #   #
     * ##### for example becomes "######   ##   ##   ######" when flattened into one string
     * and it's 5x5 in size, so the rowWidth would be 5, and the rowCount would be 5
     * then if you want the player to start in the middle, playerPosX and playerPosY would both be 2
     * 
     * To move the player, call the MovePlayer function
     * Pass the function a number, which represents the DIRECTION to move in
     * 1 = Up, 2 = Right, 3 = Down, 4 = Left
     * At some point this will surely be replaced by something like Keys.Up etc.
     * 
    */

    [TestClass]
    public class SokobanTests
    {
        // Player Moves Up Unit Test
        [TestMethod]
        public void MovePlayer_Up_UpdatesPlayerPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 2;
            int playerPosY = 2;
            string levelDesign = "######   ##   ##   ######";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(1);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosY();
            Assert.AreEqual(expected, actual, "Player failed to move up correctly");
        }

        // Player Moves Right Unit Test
        [TestMethod]
        public void MovePlayer_Right_UpdatesPlayerPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 2;
            int playerPosY = 2;
            string levelDesign = "######   ##   ##   ######";
            int expected = 3;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosX();
            Assert.AreEqual(expected, actual, "Player failed to move right correctly");
        }

        // Player Moves Down Unit Test
        [TestMethod]
        public void MovePlayer_Down_UpdatesPlayerPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 2;
            int playerPosY = 2;
            string levelDesign = "######   ##   ##   ######";
            int expected = 3;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(3);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosY();
            Assert.AreEqual(expected, actual, "Player failed to move down correctly");
        }

        // Player Moves Left Unit Test 
        [TestMethod]
        public void MovePlayer_Left_UpdatesPlayerPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 2;
            int playerPosY = 2;
            string levelDesign = "######   ##   ##   ######";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(4);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosX();
            Assert.AreEqual(expected, actual, "Player failed to move left correctly");
        }

        // Wall Above Player, and Player Tries to Move Up
        [TestMethod]
        public void MovePlayer_Up_IntoWall_UpdatesPlayerPosition()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "#### ####";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(1);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosY();
            Assert.AreEqual(expected, actual, "Wall above player failed to block player");
        }

        // Wall to Right of Player, and Player Tries to Move Right
        [TestMethod]
        public void MovePlayer_Right_IntoWall_UpdatesPlayerPosition()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "#### ####";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosX();
            Assert.AreEqual(expected, actual, "Wall to right of player failed to block player");
        }

        // Wall Under Player, and Player Tries to Move Down
        [TestMethod]
        public void MovePlayer_Down_IntoWall_UpdatesPlayerPosition()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "#### ####";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(3);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosY();
            Assert.AreEqual(expected, actual, "Wall below player failed to block player");
        }

        // Wall to Left of Player, and Player Tries to Move Left
        [TestMethod]
        public void MovePlayer_Left_IntoWall_UpdatesPlayerPosition()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "#### ####";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(4);    // 1 is up, 2 is right, 3 is down, 4 is left

            int actual = level.GetPlayerPosX();
            Assert.AreEqual(expected, actual, "Wall to left of player failed to block player");
        }

        //Player cannot move Block
        [TestMethod]
        public void CantMoveBlock()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 1;
            int playerPosY = 2;
            string levelDesign = "######   ## # ##   ######";
            int expected = ' ';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left

            //check Block not moved right
            int actual = level.WhatIsHere(3, 2);
            Assert.AreEqual(expected, actual, "Block mistakenly moved");
        }

        public void CantMoveGoal()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 1;
            int playerPosY = 2;
            string levelDesign = "######   ## . ##   ######";
            int expected = ' ';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left
            int actual = level.WhatIsHere(3, 2);
            Assert.AreEqual(expected, actual, "Goal mistakenly moved");

        }

        // Brick Element in Game Where LevelDesign String Wants it to be
        [TestMethod]
        public void Brick_LoadedIntoGame_InCorrectLocation()
        {
            int rowWidth = 2;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " #";
            char expected = '#';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            char actual = level.WhatIsHere(1, 0);
            Assert.AreEqual(expected, actual, "Brick not in expected location");
        }

        // Box Element in Game Where LevelDesign String Wants it to be
        [TestMethod]
        public void Box_LoadedIntoGame_InCorrectLocation()
        {
            int rowWidth = 2;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " $";
            char expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            char actual = level.WhatIsHere(1, 0);
            Assert.AreEqual(expected, actual, "Box not in expected location");
        }

        // Goal Element in Game Where LevelDesign String Wants it to be
        [TestMethod]
        public void Goal_LoadedIntoGame_InCorrectLocation()
        {
            int rowWidth = 2;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " .";
            char expected = '.';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            char actual = level.WhatIsHere(1, 0);
            Assert.AreEqual(expected, actual, "Goal not in expected location");
        }

        // Floor Element in Game Where LevelDesign String Wants it to be
        [TestMethod]
        public void Player_LoadedIntoGame_InCorrectLocation()
        {
            int rowWidth = 2;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " _";
            char expected = '_';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            char actual = level.WhatIsHere(1, 0);
            Assert.AreEqual(expected, actual, "Floor not in expected location");
        }

        // Same amount of boxes as goals
        [TestMethod]
        public void CheckAmountofBoxesAndGoals()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " $.";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            bool actual = (level.AllMyBoxes.Count == level.AllMyGoals.Count);
            Assert.AreEqual(expected, actual, "The box to goal ratio does not match");
        }

        //Tests that all goals are completed
        [TestMethod]
        public void CheckCompletedGoals()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " $.";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);

            bool actual = level.IsComplete();
            Assert.AreEqual(expected, actual, "The level did not complete when box went onto goal");
        }

        //Tests that there is a box element in the level
        [TestMethod]
        public void IsBoxElementPresent()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " $";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            int actual = level.AllMyBoxes.Count;
            Assert.AreEqual(expected, actual, "A box element is not present");
        }

        //Tests that there is a Goal element in the level
        [TestMethod]
        public void IsGoalElementPresent()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " .";
            int expected = '.';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            int actual = level.WhatIsHere(1, 0);
            Assert.AreEqual(expected, actual, "A goal element is not present");
        }

        //checks that the player cannot exit out the top of the level
        [TestMethod]
        public void CheckPlayerCantExitTop()
        {
            int rowWidth = 1;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " ";
            int expected = 0;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(1);

            int actual = level.PlayerPosY;
            Assert.AreEqual(expected, actual, "The Player moved out the top of the level");
        }

        //checks that the player cannot exit out the left of the level
        [TestMethod]
        public void CheckPlayerCantExitRight()
        {
            int rowWidth = 1;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " ";
            int expected = 0;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);

            int actual = level.PlayerPosX;
            Assert.AreEqual(expected, actual, "The Player moved out the right of the level");
        }

        //checks that the player cannot exit out the Right of the level
        [TestMethod]
        public void CheckPlayerCantExitBottom()
        {
            int rowWidth = 1;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " ";
            int expected = 0;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(3);

            int actual = level.PlayerPosY;
            Assert.AreEqual(expected, actual, "The Player moved out the bottom of the level");
        }

        //checks that the player cannot exit out the Right of the level
        [TestMethod]
        public void CheckPlayerCantExitLeft()
        {
            int rowWidth = 1;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " ";
            int expected = 0;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(1);

            int actual = level.PlayerPosX;
            Assert.AreEqual(expected, actual, "The Player moved out the left of the level");
        }

        //checks that the player cannot push a box out the top of the level
        [TestMethod]
        public void Player_PushingBox_Up_WontPushBoxOutOfBounds()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "$$$$ $$$$";
            char expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(1);

            int actual = level.WhatIsHere(1, 0);
            Assert.AreEqual(expected, actual, "The Player pushed the box past top of bounds");
        }

        //checks that the player cannot push a box out the top of the level
        [TestMethod]
        public void Player_PushingBox_Right_WontPushBoxOutOfBounds()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "$$$$ $$$$";
            char expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);

            int actual = level.WhatIsHere(2, 1);
            Assert.AreEqual(expected, actual, "The Player pushed the box past right of bounds");
        }

        //checks that the player cannot push a box out the top of the level
        [TestMethod]
        public void Player_PushingBox_Down_WontPushBoxOutOfBounds()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "$$$$ $$$$";
            char expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(3);

            int actual = level.WhatIsHere(1, 2);
            Assert.AreEqual(expected, actual, "The Player pushed the box past bottom of bounds");
        }

        //checks that the player cannot push a box out the top of the level
        [TestMethod]
        public void Player_PushingBox_Left_WontPushBoxOutOfBounds()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "$$$$ $$$$";
            char expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(4);

            int actual = level.WhatIsHere(0, 1);
            Assert.AreEqual(expected, actual, "The Player pushed the box past left of bounds");
        }

        // Player pushes a box Up Unit Test
        [TestMethod]
        public void MovePlayer_Up_UpdatesBoxPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 2;
            int playerPosY = 3;
            string levelDesign = "######   ## $ ##   ######";
            int expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(1);    // 1 is up, 2 is right, 3 is down, 4 is left

            //check box moved up
            int actual = level.WhatIsHere(2, 1);
            Assert.AreEqual(expected, actual, "Box failed to move up correctly");

        }

        // Player pushes a box Down Unit Test
        [TestMethod]
        public void MovePlayer_Down_UpdatesBoxPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 2;
            int playerPosY = 1;
            string levelDesign = "######   ## $ ##   ######";
            int expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(3);    // 1 is up, 2 is right, 3 is down, 4 is left

            //check box moved down
            int actual = level.WhatIsHere(2, 3);
            Assert.AreEqual(expected, actual, "Box failed to move down correctly");

        }

        // Player pushes a box Right Unit Test
        [TestMethod]
        public void MovePlayer_Right_UpdatesBoxPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 1;
            int playerPosY = 2;
            string levelDesign = "######   ## $ ##   ######";
            int expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left

            //check box moved right
            int actual = level.WhatIsHere(3, 2);
            Assert.AreEqual(expected, actual, "Box failed to move Right correctly");

        }

        // Player pushes a box Left Unit Test
        [TestMethod]
        public void MovePlayer_Left_UpdatesBoxPosition()
        {
            int rowWidth = 5;
            int rowCount = 5;
            int playerPosX = 3;
            int playerPosY = 2;
            string levelDesign = "######   ## $ ##   ######";
            int expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(4);    // 1 is up, 2 is right, 3 is down, 4 is left

            //check box moved left
            int actual = level.WhatIsHere(1, 2);
            Assert.AreEqual(expected, actual, "Box failed to move Left correctly");

        }

        // Level has one Player position
        [TestMethod]
        public void CheckPlayerValue()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 2;
            int playerPosY = 0;
            string levelDesign = "# _";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            //bool actual = (level.PlayerPosX != null && level.PlayerPosY != null);
            bool actual = (level.PlayerPosX == 2 && level.PlayerPosY == 0);
            Assert.AreEqual(expected, actual, "The Player does not have a position on the board");
        }


        // Player Starts the level on top of Floor or Goal Tile  _ or .
        [TestMethod]
        public void CheckPlayerStartingOnTop()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 2;
            int playerPosY = 0;
            string levelDesign = "# _";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            bool actual = (level.WhatIsHere(playerPosX, playerPosY) == '_' || level.WhatIsHere(playerPosX, playerPosY) == '.');
            Assert.AreEqual(expected, actual, "The Player does not start on a Floor or Goal tile");
        }

        // Player Starts the level on top of Floor or Goal Tile  _ or .
        [TestMethod]
        public void CheckPlayerNotStartingOnTop()
        {
            int rowWidth = 3;
            int rowCount = 2;
            int playerPosX = 2;
            int playerPosY = 1;
            string levelDesign = ".$_   ";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            bool actual = (level.WhatIsHere(playerPosX, playerPosY) == '_' || level.WhatIsHere(playerPosX, playerPosY) == '.');
            Assert.AreEqual(expected, actual, "The Player does not start on a Floor or Goal tile");
        }

        // One goal
        [TestMethod]
        public void CheckLevelForNoGoal()
        {
            int rowWidth = 3;
            int rowCount = 2;
            int playerPosX = 0;
            int playerPosY = 1;
            string levelDesign = "# $_ #";
            bool expected = false;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            
            bool actual = level.Validate();
            Assert.AreEqual(expected, actual, "Validator should reject no goal");
        }

        // One box
        [TestMethod]
        public void CheckLevelForNoBox()
        {
            int rowWidth = 3;
            int rowCount = 2;
            int playerPosX = 0;
            int playerPosY = 1;
            string levelDesign = "# ._ #";
            bool expected = false;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            bool actual = level.Validate();
            Assert.AreEqual(expected, actual, "Validator should reject no box");
        }

        // One box
        [TestMethod]
        public void CheckLevelForExcessGoals()
        {
            int rowWidth = 3;
            int rowCount = 2;
            int playerPosX = 0;
            int playerPosY = 1;
            string levelDesign = "$.._ #";
            bool expected = false;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            bool actual = level.Validate();
            Assert.AreEqual(expected, actual, "Validator should reject more goals than boxes");
        }

        // One player
        [TestMethod]
        public void CheckLevelForNoPlayer()
        {
            int rowWidth = 3;
            int rowCount = 2;
            int playerPosX = 1;
            int playerPosY = -1;
            string levelDesign = "# ._ #";
            bool expected = false;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            bool actual = level.Validate();
            Assert.AreEqual(expected, actual, "Validator should reject no player");
        }

        // Box Cannot be pushed into a Wall
        [TestMethod]
        public void CheckBoxNotPushedIntoWall()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = "_$#";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            level.MovePlayer(2);
            //Player should not move so should have same starting position
            //Only need to check the x position because player moving right

            bool actual = (level.PlayerPosX == playerPosX);
            Assert.AreEqual(expected, actual, "The Box is being pushed into a wall");
        }

        // Box Cannot be pushed into a Box
        [TestMethod]
        public void CheckBoxNotPushedIntoBox()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = "_$$";
            bool expected = true;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);

            level.MovePlayer(2);
            //Player should not move so should have same starting position
            //Only need to check the x position because player moving right

            bool actual = (level.PlayerPosX == playerPosX);
            Assert.AreEqual(expected, actual, "The Box is being pushed into a another box");
        }

        // Check movecount
        [TestMethod]
        public void CheckMoveCount()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = "  ";
            int expected = 2;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left 
            level.MovePlayer(4);
            int actual = level.GetMoveCount();
            Assert.AreEqual(expected, actual, "Wrong Movecount");

        }

        // Check keystrokes are saved into an array
        [TestMethod]
        public void LevelKeystrokes_CheckSaved()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = "  ";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left 

            int actual = level.GetMoveHistory().Count;
            Assert.AreEqual(expected, actual, "Moved history failed to save keystrokes");

        }
        // Ability to reverse last move(s)
        [TestMethod]
        public void LevelKeystrokes_ReverseMove()
        {
            int rowWidth = 5;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = " $ ";
            char expected = '$';

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left
            level.UndoMove();

            char actual = level.WhatIsHere(1,0);
            Assert.AreEqual(expected, actual, "Failed to undo last move");
        }

        // Ability to reverse more then one move
        [TestMethod]
        public void LevelKeystrokes_ReverseMoveMultiple()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 0;
            int playerPosY = 0;
            string levelDesign = "   ";
            int expected = 0;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left
            level.UndoMove();
            level.UndoMove();

            int actual = level.GetPlayerPosX();
            Assert.AreEqual(expected, actual, "Failed to apply undo multiple times");
        }

        // Reverse more then the move history
        [TestMethod]
        public void LevelKeystrokes_ReverseMoveMass()
        {
            int rowWidth = 3;
            int rowCount = 1;
            int playerPosX = 1;
            int playerPosY = 0;
            string levelDesign = "   ";
            int expected = 1;

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            level.MovePlayer(2);    // 1 is up, 2 is right, 3 is down, 4 is left
            level.UndoMove();
            level.UndoMove();

            int actual = level.GetPlayerPosX();
            Assert.AreEqual(expected, actual, "Failed to stop undo when it should have");
        }

        // Ability to start game
        [TestMethod]
        public void GameControl_StartGame()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "#### ####";

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            GameBoardView view = new GameBoardView();
            GameController game = new GameController(view, level);

            Assert.IsTrue(game.StartGame(), "Failed to start game");
        }

        // Ability to finish game
        [TestMethod]
        public void GameControl_FinishGame()
        {
            int rowWidth = 3;
            int rowCount = 3;
            int playerPosX = 1;
            int playerPosY = 1;
            string levelDesign = "#$,# ####";

            Game level = new Game(rowWidth, rowCount, playerPosX, playerPosY, levelDesign);
            GameBoardView view = new GameBoardView();
            GameController game = new GameController(view, level);

            Assert.IsTrue(game.FinishGame(), "Failed to finish game");
        }

        // Check the file api handler loaded
        [TestMethod]
        public void FileAPI_Exists()
        {
            GameFileAPI fileAPI = new GameFileAPI();
            Assert.AreNotEqual(null, fileAPI, "Failed to load file handler api");
        }

        // Check api has all the required methods
        [TestMethod]
        public void FileAPI_HasMethods()
        {
            GameFileAPI fileAPI = new GameFileAPI();
            Assert.AreNotEqual(null, fileAPI.GetType().GetMethod("LoadLevels"), "Failed to load file handler api methods");
        }

        // Check the file api has found game files
        [TestMethod]
        public void FileAPI_HasGameFiles()
        {
            GameFileAPI fileAPI = new GameFileAPI();
            Assert.IsTrue(fileAPI.GetGameFiles(), "Failed to load file handler api game files");
        }

    }
}