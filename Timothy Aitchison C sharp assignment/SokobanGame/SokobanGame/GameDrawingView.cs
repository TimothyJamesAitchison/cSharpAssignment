using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SokobanGame
{
    public partial class GameDrawingView : Form
    {
        private IGame MyGame;

        public GameDrawingView(IGame game)
        {
            //DoubleBuffered = true;
            this.MyGame = game;
            InitializeComponent();
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            this.DisplayLevel();
        }

        private void DisplayLevel()
        {
            
            Color color = Color.White;
            PictureBox grid;
            String levelString = MyGame.GetLevelDesign();
            char[] level = levelString.ToCharArray();
            for (int y = 0; y < MyGame.GetRowCount(); y++)
            {
                for (int x = 0; x < MyGame.GetRowWidth(); x++)
                {
                    grid = new PictureBox();
                    try
                    {
                        switch (level[x + y * MyGame.GetRowWidth()])
                        {
                            case ' ':
                                color = Color.Wheat;
                                break;
                            case '#':
                                color = Color.Black;
                                break;
                            case '$':
                                color = Color.Gray;
                                break;
                            case '.':
                                color = Color.Pink;
                                break;
                            case '!':
                                color = Color.Purple;
                                break;
                            default:
                                color = Color.Wheat;
                                break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                        Console.WriteLine("Tried to draw at position " + x + ", " + y);
                        Console.WriteLine("The map has Width: " + MyGame.GetRowWidth());
                        Console.WriteLine("The map has Height: " + MyGame.GetRowCount());
                    }
                    if (this.MyGame.GetPlayerPosX() == x & this.MyGame.GetPlayerPosY() == y)
                    {
                        color = Color.Aquamarine;
                    }
                    DrawElement(color, 51 * x + 5, 51 * y + 55);
                    grid.Size = new Size(50, 50);
                    instructions.Text = "Move: Arrow Keys, Undo: Z, Restart: Esc ";
                    instructions.Text += " ///  Movecount: " + MyGame.GetMoveCount();
                    instructions.Text += " ///  Game Won: " + MyGame.IsWon();
                    instructions.Location = new Point(5, 5);
                    this.Controls.Add(instructions);
                }
            }
        }

        private void DrawElement(Color color, int startX, int startY)
        {
            SolidBrush myBrush = new SolidBrush(color);
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(startX, startY, 50, 50));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void LoadClick(object sender, EventArgs e)
        {
            int gameWidth = MyGame.GetRowWidth() * 51 + 25;
            int gameHeight = MyGame.GetRowCount() * 51 + 100;
            Size = new Size(gameWidth, gameHeight);
            Controls.Clear();
            instructions.Text += "You are the teal block \n";
            instructions.Text += "Move the grey blocks onto the pink blocks by pushing them \n";
            instructions.Text += "Press any key to begin...";
            instructions.Location = new Point(5, 5);
            this.Controls.Add(instructions);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.MyGame.MovePlayer(4);
                    break;
                case Keys.Right:
                    this.MyGame.MovePlayer(2);
                    break;
                case Keys.Up:
                    this.MyGame.MovePlayer(1);
                    break;
                case Keys.Down:
                    this.MyGame.MovePlayer(3);
                    break;
                case Keys.Z:
                    this.MyGame.UndoMove();
                    break;
                case Keys.Escape:
                    while (MyGame.GetMoveCount() != 0)
                    {
                        MyGame.UndoMove();
                    }
                    break;
                default:
                    DisplayLevel();
                    break;
            }
            DisplayLevel();
            if (MyGame.IsWon())
            {
                instructions.Text = "Congratulations! You win!";
            }
        }
    }
}
