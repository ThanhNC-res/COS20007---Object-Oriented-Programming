using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks
{
    public enum Direction
    {
        North,
        South,
        West,
        East
    }
    public enum Direction_2
    {
        North,
        South,
        West,
        East
    }

    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    public enum Mode
    {
        Single,
        Duo
    }

    public partial class MainForm : Form
    {
        private bool left = false;
        private bool right = false;
        private bool up = false;
        private bool down = false;
        private bool shoot = false;
        private bool left2 = false;
        private bool right2 = false;
        private bool up2 = false;
        private bool down2 = false;
        private bool shoot2 = false;
        private bool playStage = false;
        public bool twoPlayerMode = false;  
        private bool beforeStage = false; 
        private bool menu = true; 
        private bool chooseDifficulty = false;
        private bool chooseMode = false; 
        private bool gameOver = false;
        private bool mapWinner = false;
        private Dictionary<string, Rectangle> menuItems = new Dictionary<string, Rectangle>(); 
        private Dictionary<string, Rectangle> difficultyItems = new Dictionary<string, Rectangle>();
        private Dictionary<string, Rectangle> playerMode = new Dictionary<string, Rectangle>();
        private GameModel game;
        private Timer updateViewTimer = new Timer(); 
        private Timer bulletsTimer = new Timer(); 
        private Timer shootTimer = new Timer(); 
        private Timer shootTimerForBots = new Timer();
        private Timer moveTimerForEasyBots = new Timer(); 
        private Timer moveTimerForMediumBots = new Timer(); 
        private Timer moveTimerForHardBots = new Timer(); 
        private Timer beforeStageTimer = new Timer(); 
        private Timer addBotTimer = new Timer();
        private Timer winOrLoseAnimationTimer = new Timer();
        private Timer singlePlayerTimer = new Timer();
        private Timer twoPlayerTimer = new Timer();
        private Bitmap menuImage; 
        private Bitmap difficultyImage; 
        private List<Map> maps = new List<Map>();
        private Bitmap bots = new Bitmap(Image.FromFile("../../bots.png"), new Size(20, 20));
        private Bitmap health = new Bitmap(Image.FromFile("../../health.png"), new Size(40, 40));
        private int currentMap = 0;
        private GameDifficulty currentDifficulty = GameDifficulty.Medium;
        private Mode currentMode = Mode.Single;
        private List<string> stages = new List<string>(); 
        private string winOrLose; 
        private Point winOrLoseCoordinates;
        private Point winOrLoseAnimation;
        private int countMiliseconds = 0;
       
        public MainForm()
        {
            InitializeComponent();
            menuImage = new Bitmap(Image.FromFile("../../MenuImage.jpg"), new Size(Map.mainFrame.Width, Map.mainFrame.Height));
            difficultyImage = new Bitmap(Image.FromFile("../../Difficulty.jpg"), new Size(Map.mainFrame.Width, Map.mainFrame.Height));
            updateViewTimer.Interval = 30; // fps
            updateViewTimer.Tick += UpdateViewTimer_Tick;
            updateViewTimer.Start();
            bulletsTimer.Interval = 1; // fps
            bulletsTimer.Tick += BulletsTimer_Tick;
            bulletsTimer.Start();
            shootTimer.Interval = 150;
            shootTimer.Tick += ShootTimer_Tick;
            shootTimer.Start();
            shootTimerForBots.Interval = 500;
            shootTimerForBots.Tick += ShootTimerForBots_Tick;
            shootTimerForBots.Start();
            moveTimerForEasyBots.Interval = 30;
            moveTimerForEasyBots.Tick += MoveTimerForEasyBots_Tick;
            moveTimerForEasyBots.Start();
            moveTimerForMediumBots.Interval = 50;
            moveTimerForMediumBots.Tick += MoveTimerForMediumBots_Tick;
            moveTimerForMediumBots.Start();
            moveTimerForHardBots.Interval = 70;
            moveTimerForHardBots.Tick += MoveTimerForHardBots_Tick;
            moveTimerForHardBots.Start();
            addBotTimer.Interval = 500;
            addBotTimer.Tick += AddBotTimer_Tick;
            addBotTimer.Start();
            beforeStageTimer.Interval = 3000;
            beforeStageTimer.Tick += BeforeStageTimer_Tick;
            winOrLoseAnimationTimer.Interval = 30;
            winOrLoseAnimationTimer.Tick += WinOrLoseAnimationTimer_Tick;
            maps.Add(new Stage1());
            maps.Add(new Stage2());
            maps.Add(new Stage3());
            game = new GameModel(maps[currentMap], currentDifficulty, currentMode);
            menuItems.Add("Start", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, Map.mainFrame.Y + (Map.mainFrame.Height - 160) / 2), new Size(140, 40)));
            menuItems.Add("Difficulty", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, menuItems["Start"].Bottom + 20), new Size(190, 40)));
            menuItems.Add("Mode", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, menuItems["Difficulty"].Bottom + 20), new Size(190, 40)));
            menuItems.Add("Exit", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, menuItems["Mode"].Bottom + 20), new Size(140, 40)));
            difficultyItems.Add("Easy", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, Map.mainFrame.Y + (Map.mainFrame.Height - 160) / 2), new Size(140, 40)));
            difficultyItems.Add("Medium", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, difficultyItems["Easy"].Bottom + 20), new Size(140, 40)));
            difficultyItems.Add("Hard", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, difficultyItems["Medium"].Bottom + 20), new Size(140, 40)));
            playerMode.Add("Single",  new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, Map.mainFrame.Y + (Map.mainFrame.Height - 160) / 2), new Size(140, 40)));
            playerMode.Add("Duo", new Rectangle(new Point(Map.mainFrame.X + (Map.mainFrame.Width - 140) / 2, playerMode["Single"].Bottom + 20), new Size(140, 40)));
            stages.Add("Stage 1");
            stages.Add("Stage 2");
            stages.Add("Stage 3");
            winOrLoseAnimation = winOrLoseCoordinates = new Point(Map.mainFrame.X + Map.mainFrame.Width / 2 - 100, Map.mainFrame.Y + 5);
        }

        private void WinOrLoseAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (countMiliseconds < 4000)
            {
                if (winOrLoseAnimation.Y < Map.mainFrame.Y + Map.mainFrame.Height / 2)
                {
                    winOrLoseAnimation = new Point(winOrLoseAnimation.X, winOrLoseAnimation.Y + 5);
                }
                countMiliseconds += 30;
            }

            else
            {
                if (gameOver) { menu = true; }
                playStage = false;

                if (currentMap == maps.Count - 1 || gameOver) { menu = true; currentMap = 0; }
                else if (!gameOver) { currentMap++; beforeStage = true; beforeStageTimer.Start(); }
                winOrLoseAnimationTimer.Stop();
                countMiliseconds = 0;
                winOrLoseAnimation = winOrLoseCoordinates;
                gameOver = mapWinner = game.playerWin = game.playerWin = game.gameOver = false;
                StopMove();
                shoot = false;
            }
        }

        private void BeforeStageTimer_Tick(object sender, EventArgs e)
        {
            beforeStage = false;
            game.ChangeMap(maps[currentMap]);
            playStage = true;
            beforeStageTimer.Stop();
        }


        private void UpdateViewTimer_Tick(object sender, EventArgs e)
        {
            if (playStage)
            {
                if (twoPlayerMode) { 
                if (left2) game.Move(game.player2, Direction.West);
                else if (right2) game.Move(game.player2, Direction.East);
                else if (up2) game.Move(game.player2, Direction.North);
                else if (down2) game.Move(game.player2, Direction.South);
                }

                if (left) game.Move(game.player, Direction.West);
                else if (right) game.Move(game.player, Direction.East);
                else if (up) game.Move(game.player, Direction.North);
                else if (down) game.Move(game.player, Direction.South);
                

            }

            Invalidate();
            Update();
        }
        //private void UpdateViewTimer2_Tick(object sender, EventArgs e)
        //{
        //    if (playStage)
        //    {
        //        if (left) game.Move(game.player2, Direction.West);
        //        else if (right) game.Move(game.player2, Direction.East);
        //        else if (up) game.Move(game.player2, Direction.North);
        //        else if (down) game.Move(game.player2, Direction.South);
        //    }
        //}

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Main Form Draw
            e.Graphics.Clear(Color.Gray);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), Map.mainFrame);

            if (beforeStage) // drawing the splash screen before starting the map
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), Map.mainFrame);
                e.Graphics.DrawString(stages[currentMap], new Font(new Font(FontFamily.GenericSansSerif, 24.0F), FontStyle.Bold),
                        new SolidBrush(Color.Black), Map.mainFrame.X + Map.mainFrame.Width / 2 - 50, Map.mainFrame.Y + Map.mainFrame.Height / 2 - 10);
            }

            if (menu) // rendering of menu items
            {

                e.Graphics.DrawImage(menuImage, new Point(Map.mainFrame.X, Map.mainFrame.Y));

                foreach (var m in menuItems)
                {
                    e.Graphics.DrawString(m.Key, new Font(new Font(FontFamily.GenericSansSerif, 24.0F), FontStyle.Bold),
                        new SolidBrush(Color.White), m.Value);
                }
            }

            if (chooseDifficulty) // Choose Difficulty
            {
                e.Graphics.DrawImage(difficultyImage, new Point(Map.mainFrame.X, Map.mainFrame.Y));
                foreach (var d in difficultyItems)
                {
                    e.Graphics.DrawString(d.Key, new Font(new Font(FontFamily.GenericSansSerif, 24.0F), FontStyle.Bold),
                        new SolidBrush(Color.DarkOrange), d.Value);
                }
            }

            if (chooseMode)
            {
                e.Graphics.DrawImage(difficultyImage, new Point(Map.mainFrame.X, Map.mainFrame.Y));
                foreach(var c in playerMode)
                {
                    e.Graphics.DrawString(c.Key, new Font(new Font(FontFamily.GenericSansSerif, 24.0F), FontStyle.Bold),
                       new SolidBrush(Color.DarkOrange), c.Value);
                }
            }

            if (playStage) // drawing gameplay on the map
            {
                if (twoPlayerMode)
                {
                    e.Graphics.DrawImage(game.player2.img, new Point(game.player2.point.X, game.player2.point.Y));
                }
                e.Graphics.DrawImage(game.player.img, new Point(game.player.point.X, game.player.point.Y)); // drawing a tank

                foreach (var t in game.bots)
                {
                    e.Graphics.DrawImage(t.img, new Point(t.point.X, t.point.Y)); // drawing bots
                }

                e.Graphics.DrawImage(game.currentMap.eagle, game.currentMap.pointEagle); // drawing an eagle

                foreach (var s in game.currentMap.stone)
                {
                    e.Graphics.DrawImage(game.currentMap.imgStone, s);
                }

                foreach (var f in game.currentMap.forest)
                {
                    e.Graphics.DrawImage(game.currentMap.imgForest, f);
                }

                foreach (var b in game.currentMap.brick)
                {
                    e.Graphics.DrawImage(game.currentMap.imgBrick, b);
                }

                foreach (var b in game.bullets) // drawing bullets
                {
                    if (b.tank is PlayerTank || b.tank is Player2Tank) e.Graphics.FillEllipse(new SolidBrush(Color.Aquamarine), new RectangleF(b.point, new Size(b.size, b.size)));
                    else e.Graphics.FillEllipse(new SolidBrush(Color.Orange), new RectangleF(b.point, new Size(b.size, b.size)));
                }

                Point point = new Point(Map.mainFrame.X + Map.mainFrame.Width + 10, Map.mainFrame.Y + 10);

                for (int i = 1; i <= game.maxBotAmount - game.killedBots; ++i)
                {
                    e.Graphics.DrawImage(bots, point);
                    if (i % 2 == 0) point = new Point(point.X - 20, point.Y + 20);
                    else point = new Point(point.X + 20, point.Y);
                }

                point = new Point(Map.mainFrame.X + Map.mainFrame.Width + 20, Map.mainFrame.Y + Map.mainFrame.Height - 100);
                e.Graphics.DrawImage(health, point);
                e.Graphics.DrawString(game.player.hitpoints.ToString(), new Font(new Font(FontFamily.GenericSansSerif, 18.0F), FontStyle.Bold),
                        new SolidBrush(Color.Red), new Point(point.X + 50, point.Y + 5));
                e.Graphics.DrawString(game.player2.hitpoints.ToString(), new Font(new Font(FontFamily.GenericSansSerif, 18.0F), FontStyle.Bold),
                        new SolidBrush(Color.Red), new Point(point.X + 50, point.Y + 5));
            }


            if (gameOver || mapWinner)
            {
                e.Graphics.DrawString(winOrLose, new Font(new Font(FontFamily.GenericSansSerif, 26.0F), FontStyle.Bold),
                        new SolidBrush(Color.DeepPink), winOrLoseAnimation);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (playStage)
            {
                
                    if (e.KeyCode == Keys.A) { StopMove(); left2 = true; }
                    if (e.KeyCode == Keys.D) { StopMove(); right2 = true; }
                    if (e.KeyCode == Keys.W) { StopMove(); up2 = true; }
                    if (e.KeyCode == Keys.S) { StopMove(); down2 = true; }
                    if (e.KeyCode == Keys.V) shoot2 = true;
                    if (e.KeyCode == Keys.Left) { StopMove(); left = true; }
                    if (e.KeyCode == Keys.Right) { StopMove(); right = true; }
                    if (e.KeyCode == Keys.Up) { StopMove(); up = true; }
                    if (e.KeyCode == Keys.Down) { StopMove(); down = true; }
                    if (e.KeyCode == Keys.L) shoot = true;

               
            }
            
        }

        private void StopMove()
        {
            left = false;
            right = false;
            up = false;
            down = false;

            left2 = false;
            right2 = false;
            up2 = false;
            down2 = false;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (playStage)
            {
               
                if (e.KeyCode == Keys.A) left2 = false;
                else if (e.KeyCode == Keys.D) right2 = false;
                else if (e.KeyCode == Keys.W) up2 = false;
                else if (e.KeyCode == Keys.S) down2 = false;
                if (e.KeyCode == Keys.V) shoot2 = false;
               
                if (e.KeyCode == Keys.Left) left = false;
                else if (e.KeyCode == Keys.Right) right = false;
                else if (e.KeyCode == Keys.Up) up = false;
                else if (e.KeyCode == Keys.Down) down = false;
                if (e.KeyCode == Keys.L) shoot = false;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (menu)
            {
                foreach (var m in menuItems)
                {
                    if (m.Value.Contains(new Point(e.X, e.Y)))
                    {
                        Cursor.Current = Cursors.Hand;
                        break;
                    }
                }
            }

            else if (chooseDifficulty)
            {
                foreach (var d in difficultyItems)
                {
                    if (d.Value.Contains(new Point(e.X, e.Y)))
                    {
                        Cursor.Current = Cursors.Hand;
                        break;
                    }
                }
            }

            else if (chooseMode)
            {
                foreach (var p in playerMode)
                {
                    if (p.Value.Contains(new Point(e.X, e.Y)))
                    {
                        Cursor.Current = Cursors.Hand;
                        break;
                    }
                }
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (menu)
            {
                if (menuItems["Start"].Contains(new Point(e.X, e.Y)))
                {
                    menu = false;
                    beforeStage = true;
                    beforeStageTimer.Start();
                    game = new GameModel(maps[currentMap], currentDifficulty, currentMode);
                }
                else if (menuItems["Difficulty"].Contains(new Point(e.X, e.Y)))
                {
                    menu = false;
                    chooseDifficulty = true;
                }
                else if (menuItems["Mode"].Contains(new Point(e.X, e.Y)))
                {
                    menu = false;
                    chooseMode = true;
                }
                else if (menuItems["Exit"].Contains(new Point(e.X, e.Y)) ) { Close(); }
            }

            else if (chooseDifficulty)
            {
                if (difficultyItems["Easy"].Contains(new Point(e.X, e.Y)))
                {
                    currentDifficulty = GameDifficulty.Easy;
                    SetTimersForEasyGame();
                    menu = true;
                    chooseDifficulty = false;
                }

                else if (difficultyItems["Medium"].Contains(new Point(e.X, e.Y)))
                {
                    currentDifficulty = GameDifficulty.Medium;
                    SetTimersForMediumGame();
                    menu = true;
                    chooseDifficulty = false;
                }

                else if (difficultyItems["Hard"].Contains(new Point(e.X, e.Y)))
                {
                    currentDifficulty = GameDifficulty.Hard;
                    SetTimersForHardGame();
                    menu = true;
                    chooseDifficulty = false;
                }
            }
            else if (chooseMode)
            {
                if(playerMode["Single"].Contains(new Point(e.X, e.Y)))
                {
                    currentMode = Mode.Single;
                    chooseMode = false;
                    menu = true;
                }
                else if(playerMode["Duo"].Contains(new Point(e.X, e.Y)))
                {
                    currentMode = Mode.Duo;
                    menu = true;
                    chooseMode = false;
                    twoPlayerMode = true;
                    
                }
                
            }
        }

        private void SetTimersForEasyGame()
        {
            moveTimerForEasyBots.Interval = 45;
            moveTimerForMediumBots.Interval = 60;
            moveTimerForHardBots.Interval = 70;
            shootTimerForBots.Interval = 500;
        }

        private void SetTimersForMediumGame()
        {
            moveTimerForEasyBots.Interval = 35;
            moveTimerForMediumBots.Interval = 50;
            moveTimerForHardBots.Interval = 70;
            shootTimerForBots.Interval = 350;
        }

        private void SetTimersForHardGame()
        {
            moveTimerForEasyBots.Interval = 30;
            moveTimerForMediumBots.Interval = 40;
            moveTimerForHardBots.Interval = 60;
            shootTimerForBots.Interval = 200;
        }

        private void AddBotTimer_Tick(object sender, EventArgs e)
        {
            if (playStage) game.AddBot();
        }

        private void MoveTimerForHardBots_Tick(object sender, EventArgs e)
        {
            if (playStage) game.MoveBots(BotDifficulty.Hard);
        }

        private void MoveTimerForMediumBots_Tick(object sender, EventArgs e)
        {
            if (playStage) game.MoveBots(BotDifficulty.Medium);
        }

        private void MoveTimerForEasyBots_Tick(object sender, EventArgs e)
        {
            if (playStage) game.MoveBots(BotDifficulty.Easy);
        }

        private void ShootTimerForBots_Tick(object sender, EventArgs e)
        {
            if (playStage)
            {
                foreach (var bot in game.bots) { game.Shoot(bot); }
            }
        }

        private void ShootTimer_Tick(object sender, EventArgs e)
        {
            if (shoot) game.Shoot(game.player);
            else if (shoot2) game.Shoot(game.player2);
        }

        //private void SinglePlayer_Tick(object sender, EventArgs e)
        //{
        //    if(playStage && (twoPlayerMode = false))
        //    {
        //        game.
        //    }
        //}
        private void BulletsTimer_Tick(object sender, EventArgs e)
        {

            if (playStage)
            {
                if (game.gameOver)
                {
                    gameOver = true;
                    winOrLose = "You Lose!!";
                    winOrLoseAnimationTimer.Start();
                }

                else if (game.playerWin)
                {
                    mapWinner = true;
                    winOrLose = "Victory!";
                    winOrLoseAnimationTimer.Start();
                }

                game.MoveBullet();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
