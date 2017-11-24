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
    public partial class GameView : Form
    {
        private IGame MyGame;

        public GameView(IGame game)
        {
            DoubleBuffered = true;
            AutoSize = true;
            InitializeComponent();
            this.MyGame = game;
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            this.DisplayLevel();

        }

        private void DisplayLevel()
        {
            this.Controls.Clear();
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
                                grid.Image = Image.FromFile(@"..\..\images\Empty.png");
                                break;
                            case '#':
                                grid.Image = Image.FromFile(@"..\..\images\Solid.png");
                                break;
                            case '$':
                                grid.Image = Image.FromFile(@"..\..\images\Moveable.png");
                                break;
                            case '.':
                                grid.Image = Image.FromFile(@"..\..\images\Goal.png");
                                break;
                            case '!':
                                grid.Image = Image.FromFile(@"..\..\images\Satisfied.png");
                                break;
                            default:
                                grid.Image = Image.FromFile(@"..\..\images\Empty.png");
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
                        grid.Image = Image.FromFile(@"..\..\images\Player.png");
                    }
                    grid.Location = new Point(51 * x + 5, 51 * y + 55);
                    grid.Size = new Size(50, 50);
                    this.Controls.Add(grid);
                    instructions.Text = "Move: Arrow Keys, Undo: Z, Restart: Esc ";
                    instructions.Text += " ///  Movecount: " + MyGame.GetMoveCount();
                    instructions.Text += " ///  Game Won: " + MyGame.IsWon();
                    instructions.Location = new Point(5, 5);
                    this.Controls.Add(instructions);
                }
            }     
        }

        private void LoadClick(object sender, EventArgs e)
        {
            this.DisplayLevel();
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
                    while(MyGame.GetMoveCount() != 0)
                    {
                        MyGame.UndoMove();
                    }
                    break;
                default:
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
