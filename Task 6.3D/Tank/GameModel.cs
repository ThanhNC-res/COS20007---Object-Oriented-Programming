using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks
{
    public enum BotDifficulty
    {
        Easy,
        Medium,
        Hard
    }



    public class GameModel
    {
        private delegate void CreateBotDelegate();
        private int currentBotAmount; // total number of bots on the map
        private int simultaneousBotAmount; // simultaneous number of bots on the map
        public int maxBotAmount; // max bot for difficulty
        public int killedBots;
        private int maxStepsInOneDirection = 80; // Bot max step in one dorection
        public bool gameOver = false;
        public bool playerWin = false;
        public Tank player = new PlayerTank();
        public Tank player2 = new Player2Tank();
        public List<Bullet> bullets = new List<Bullet>();
        public List<Tank> bots = new List<Tank>();
        private Point playerStartPosition;// player start point
        private Point player2StartPosition;// player 2 start point 
        public Map currentMap;
        private Random random = new Random();
        public Dictionary<int, Direction> directionForBot = new Dictionary<int, Direction>();
        private CreateBotDelegate[] createBot = new CreateBotDelegate[3];

        public GameModel(Map map, GameDifficulty difficulty, Mode mode)
        {
            currentMap = CreateMap(map);
            SelfMode(mode);
            SetDifficulty(difficulty);
            directionForBot.Add(0, Direction.East);
            directionForBot.Add(1, Direction.North);
            directionForBot.Add(2, Direction.South);
            directionForBot.Add(3, Direction.West);
            createBot[0] = new CreateBotDelegate(CreateEasyBot);
            createBot[1] = new CreateBotDelegate(CreateMediumBot);
            createBot[2] = new CreateBotDelegate(CreateHardBot);

            
        }

        public void ChangeMap(Map map)
        {
            killedBots = currentBotAmount = 0;
            currentMap = CreateMap(map);
            gameOver = false;
            playerWin = false;
            player = new PlayerTank();
            player2 = new Player2Tank();
            player.point = playerStartPosition = currentMap.startPosition;
            player2.point = player2StartPosition = currentMap.startPosition2;
            for (int i = 0; i < currentBotAmount; ++i) { AddBot(); }
        }

        private Map CreateMap(Map map)
        {
            if (map is Stage1) return new Stage1();
            else if (map is Stage2) return new Stage2();
            else return new Stage3();
        }

        private void CreateEasyBot()
        {
            int num = 0;
            Point position;
            do
            {
                num = random.Next(0, currentMap.startPositionForBots.Count);
                position = currentMap.startPositionForBots[num];
            } while (!IsEmptyPosition(position));

            bots.Add(new EasyBot(position));
        }

        private void CreateMediumBot()
        {
            int num = 0;
            Point position;
            do
            {
                num = random.Next(0, currentMap.startPositionForBots.Count);
                position = currentMap.startPositionForBots[num];
            } while (!IsEmptyPosition(position));

            bots.Add(new MediumBot(position));
        }

        private void CreateHardBot()
        {
            int num = 0;
            Point position;
            do
            {
                num = random.Next(0, currentMap.startPositionForBots.Count);
                position = currentMap.startPositionForBots[num];
            } while (!IsEmptyPosition(position));

            bots.Add(new HardBot(position));
        }

        private bool IsEmptyPosition(Point point)
        {
            Rectangle newBot = new Rectangle(point, new Size(player.size, player.size));

            foreach (var b in bots)
            {
                Rectangle bot = new Rectangle(b.point, new Size(b.size, b.size));
                if (newBot.IntersectsWith(bot)) return false;
            }

            if (new Rectangle(player.point, new Size(player.size, player.size)).IntersectsWith(newBot)) return false;
            else return true;
        }

        public void Move(Tank tank, Direction direction) // moving the user's tank
        {
            int dX = tank.shift[direction].Key; // x offset
            int dY = tank.shift[direction].Value; // y offset

            if (tank.direction == direction)
            {
                Point previous = tank.point;
                tank.point = new Point((tank.point.X + dX), (tank.point.Y + dY));


                if (!TankCanMove(tank))
                {
                    if (!(tank is PlayerTank || tank is Player2Tank)) { ((Bot)(tank)).canMove = false; ((Bot)(tank)).countStep = 0; }
                    tank.point = previous;

                }

                else
                {
                    if (!(tank is PlayerTank || tank is Player2Tank)) { ((Bot)(tank)).canMove = true; ((Bot)(tank)).countStep++; }
                }
            }

            else
            {
                if (!(tank is PlayerTank || tank is Player2Tank)) { ((Bot)(tank)).canMove = true; ((Bot)(tank)).countStep = 0; }

                RotateImage(tank, direction); // turn the picture in the desired direction
                tank.direction = direction;


            }
        }



        public void MoveBots(BotDifficulty difficulty) // moving bots
        {
            foreach (var bot in bots)
            {
                if (difficulty == BotDifficulty.Easy && bot is EasyBot ||
                    difficulty == BotDifficulty.Medium && bot is MediumBot ||
                    difficulty == BotDifficulty.Hard && bot is HardBot)
                {
                    if (((Bot)bot).canMove && ((Bot)bot).countStep < maxStepsInOneDirection) Move(bot, ((Bot)bot).direction);

                    else
                    {
                        int direction = random.Next(0, 4);
                        Move(bot, directionForBot[direction]);
                    }
                }
            }
        }

        public void AddBot() // adding a bot to the map
        {
            if (currentBotAmount == maxBotAmount && bots.Count == 0 && gameOver == false) playerWin = true;

            else if (bots.Count < simultaneousBotAmount && currentBotAmount < maxBotAmount)
            {
                int num = random.Next(0, 3);
                createBot[num]();
                currentBotAmount++;
            }

        }

        public void Shoot(Tank tank)
        {
            if (tank is Bot && random.Next(0, 2) == 1) return;

            if (!tank.isShooting)
            {
                bullets.Add(new Bullet(tank));
                tank.isShooting = true;
            }
        }

        public void MoveBullet()
        {
            List<Bullet> b = new List<Bullet>();
            DeleteCrossedBullets();

            foreach (var bullet in bullets)
            {
                int dX = bullet.shift[bullet.direction].Key; // x offset
                int dY = bullet.shift[bullet.direction].Value; // offset y
                bullet.middle = new Point(bullet.middle.X + dX, bullet.middle.Y + dY);
                bullet.point = new Point(bullet.point.X + dX, bullet.point.Y + dY);

                if (!BulletCanMove(bullet))
                {
                    bullet.tank.isShooting = false;
                    b.Add(bullet);
                }
            }

            foreach (var toDelete in b)
            {
                bullets.Remove(toDelete);
            }
        }

        private bool TankCanMove(Tank a_tank) // checks if the tank can move in a given direction
        {
            Rectangle tank = new Rectangle(a_tank.point, new Size(a_tank.size, a_tank.size));

            if (tank.Left < Map.mainFrame.Left || tank.Right > Map.mainFrame.Right
                || tank.Top < Map.mainFrame.Top || tank.Bottom > Map.mainFrame.Bottom)
            {
                return false;
            }

            if (a_tank is Bot)
            {
                Rectangle rect = new Rectangle(player.point, new Size(player.size, player.size));
                Rectangle rect2 = new Rectangle(player2.point, new Size(player2.size, player2.size));
                if (rect.IntersectsWith(tank)) return false;
                if(rect2.IntersectsWith(tank)) return false;
            }

            foreach (var bot in bots)
            {
                Rectangle rect = new Rectangle(bot.point, new Size(bot.size, bot.size));
                if (rect.IntersectsWith(tank) && bot != a_tank) return false;
            }

            foreach (var s in currentMap.stone)
            {
                Rectangle rect = new Rectangle(s, new Size(Map.size, Map.size));
                if (rect.IntersectsWith(tank)) return false;
            }

            foreach (var b in currentMap.brick)
            {
                Rectangle rect = new Rectangle(b, new Size(Map.size / 3, Map.size / 3));
                if (rect.IntersectsWith(tank)) return false;
            }

            Rectangle eagle = new Rectangle(currentMap.pointEagle, new Size(Map.size, Map.size));
            if (eagle.IntersectsWith(tank)) return false;

            return true;
        }

        private void DeleteCrossedBullets() //removing colliding bullets
        {
            List<Bullet> toDelete = new List<Bullet>();

            for (int i = 0; i < bullets.Count; ++i)
            {
                for (int j = 0; j < bullets.Count; ++j)
                {
                    if (i == j || toDelete.Contains(bullets[j])) continue;

                    Rectangle first = new Rectangle(new Point(bullets[i].middle.X - 10, bullets[i].middle.Y - 10), new Size(21, 21));

                    // bullet hitting another bullet
                    Rectangle second = new Rectangle(new Point(bullets[j].middle.X - 10, bullets[j].middle.Y - 10), new Size(21, 21));
                    if (first.IntersectsWith(second))
                    {
                        bullets[i].tank.isShooting = false;
                        bullets[j].tank.isShooting = false;
                        toDelete.Add(bullets[i]);
                        toDelete.Add(bullets[j]);
                    }
                }
            }

            foreach (var del in toDelete)
            {
                bullets.Remove(del);
            }
        }

        private bool BulletCanMove(Bullet bullet)
        {
            Rectangle rect;
            Rectangle rect2;

            rect = Map.mainFrame;
            rect2 = Map.mainFrame;
            if (bullet.middle.X <= rect.Left || bullet.middle.X >= rect.Right
                || bullet.middle.Y <= rect.Top || bullet.middle.Y >= rect.Bottom) return false;

            foreach (var s in currentMap.stone)
            {
                rect = new Rectangle(s, new Size(Map.size, Map.size));
                if (rect.Contains(bullet.middle)) return false;
            }

            foreach (var bot in bots) // hitting the bot
            {
                rect = new Rectangle(bot.point, new Size(bot.size, bot.size));
                if ((rect.IntersectsWith(new Rectangle(bullet.point, new Size(bullet.size, bullet.size))) && (bullet.tank is PlayerTank || bullet.tank is Player2Tank)))
                {
                    bot.hitpoints--;
                    if (bot.hitpoints == 0)
                    {
                        bots.Remove(bot);
                        if (killedBots < maxBotAmount) killedBots++;
                    }
                    return false;
                }
            }


            rect = new Rectangle(currentMap.pointEagle, new Size(Map.size, Map.size));
            if ((rect.IntersectsWith(new Rectangle(bullet.point, new Size(bullet.size, bullet.size)))))
            {
                if (!playerWin) gameOver = true;
                currentMap.eagle = new Bitmap(Image.FromFile("../../deadEagle.png"), new Size(Map.size, Map.size));
                return false;
            }

            if (bullet.tank is Bot) // hitting the player
            {
                rect = new Rectangle(player.point, new Size(player.size, player.size));
                rect2 = new Rectangle(player2.point, new Size(player2.size, player2.size));

                if (rect.Contains(bullet.middle))
                {
                    player.point = playerStartPosition;
                    if (player.hitpoints > -1) player.hitpoints--;

                    if (player.hitpoints == 0 && playerWin == false) gameOver = true;
                    return false;
                }
                if (rect2.Contains(bullet.middle))
                {
                    player2.point = player2StartPosition;
                    if (player2.hitpoints > -1) player2.hitpoints--;

                    if (player2.hitpoints == 0 && playerWin == false) gameOver = true;
                    return false;
                }
            }

            List<Point> brickToDelete = new List<Point>();
            bool result = true;
            // для расчистки прохода под размер танка
            rect = new Rectangle(new Point(bullet.middle.X - 10, bullet.middle.Y - 10), new Size(21, 21));
            foreach (var b in currentMap.brick)
            {
                Rectangle brick = new Rectangle(b, new Size(Map.size / 3, Map.size / 3));
                if (brick.IntersectsWith(rect))
                {
                    brickToDelete.Add(b);
                    result = false;
                }
            }

            foreach (var b in brickToDelete) { this.currentMap.brick.Remove(b); }

            rect = new Rectangle(currentMap.pointEagle, new Size(Map.size, Map.size));
            if (rect.Contains(bullet.middle)) return false;

            return result;
        }

        private void SetDifficulty(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    simultaneousBotAmount = 4;
                    maxBotAmount = 12;
                    break;
                case GameDifficulty.Medium:
                    simultaneousBotAmount = 5;
                    maxBotAmount = 20;
                    break;
                case GameDifficulty.Hard:
                    simultaneousBotAmount = 7;
                    maxBotAmount = 28;
                    break;
            }
        }

        private void SelfMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.Single:
                    player.point = playerStartPosition = currentMap.startPosition;
                    break;
                case Mode.Duo:
                    player.point = playerStartPosition = currentMap.startPosition;
                    player2.point = player2StartPosition = currentMap.startPosition2;
                    break;
            }
        }

        private static void RotateImage(Tank tank, Direction newDirection) // поворачиваем картинку на нужный угол
        {
            int angle = tank.windRose[newDirection] - tank.windRose[tank.direction];
            angle = angle < 0 ? angle + 360 : angle;

            switch (angle)
            {
                case 270:
                    tank.img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 180:
                    tank.img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 90:
                    tank.img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
        }

        
        
    }
}
