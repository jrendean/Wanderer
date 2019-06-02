using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Robot.Wanderer;
using System.Threading;

namespace TestWanderer
{
    public class Arena : UserControl
    {
        private object threadLock = new object();
        private System.Threading.Timer timer;

        private List<Bot> bots;
        private Dictionary<Guid, Rectangle> botRectangles = new Dictionary<Guid, Rectangle>();
        
        private Pen botPen = new Pen(Color.Black);
        private Pen communicationPenIR = new Pen(Color.Red);
        private Pen communicationPenRF = new Pen(Color.Blue);
        private Graphics arenaGraphics;

        private const int BotSize = 15;

        
        public Arena()
        {
            InitializeComponent();

            this.bots = new List<Bot>();

            this.arenaGraphics = this.CreateGraphics();
            this.arenaGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            this.timer = new System.Threading.Timer(DrawArena, null, 0, 100);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            BorderStyle = BorderStyle.FixedSingle;

            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.UpdateStyles();

            this.SizeChanged += ArenaSizeChanged;

            this.ResumeLayout(true);
        }

        void ArenaSizeChanged(object sender, EventArgs e)
        {
            base.Size = this.Size;
            this.arenaGraphics = this.CreateGraphics();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
                this.timer = null;
            }

            if (this.arenaGraphics != null)
            {
                this.arenaGraphics.Dispose();
                this.arenaGraphics = null;
            }

            base.Dispose(disposing);
        }

        public void AddBot(Bot bot)
        {
            this.timer.Dispose();

            this.bots.Add(bot);

            int randX = new Random((int)DateTime.Now.Ticks).Next(0, this.Width - BotSize);
            int randY = new Random((int)DateTime.Now.Ticks).Next(0, this.Height - BotSize);

            this.botRectangles.Add(bot.EPROM.ID, new Rectangle(randX, randY, BotSize, BotSize));

            this.timer = new System.Threading.Timer(DrawArena, null, 0, 100);
        }

        private void DrawArena(object state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TimerCallback(DrawArena), state);
            }
            else
            {
                this.arenaGraphics.Clear(Color.White);

                foreach (Bot bot in bots)
                {
                    DrawBot(bot);
                }
            }
        }

        private void DrawBot(object sender, BotEventArgs botEventArgs)
        {
            DrawBot(botEventArgs.Bot);
        }
        private void DrawBot(Bot bot)
        {
            lock (threadLock)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new EventHandler<BotEventArgs>(DrawBot), new BotEventArgs(bot));
                }
                else
                {
                    Rectangle botRec = botRectangles[bot.EPROM.ID];

                    if (bot.DriveTrain.IsMoving)
                    {
                        //int step = bot.DriveTrain.Distance / 4;
                        int step = 4;

                        switch (bot.DriveTrain.Direction)
                        {
                            case Robot.Wanderer.Enums.MovementDirection.Backward:
                                botRec.Y += step;
                                break;

                            case Robot.Wanderer.Enums.MovementDirection.Forward:
                                botRec.Y -= step;
                                break;

                            case Robot.Wanderer.Enums.MovementDirection.Left:
                                botRec.X -= step;
                                break;

                            case Robot.Wanderer.Enums.MovementDirection.Right:
                                botRec.X += step;
                                break;
                        }
                    }
                    
                    // draw the bot body
                    this.arenaGraphics.DrawRectangle(this.botPen, botRec);
                    
                    CheckForBump(bot, botRec);


                    //draw the communication range
                    foreach (Robot.Wanderer.Components.TransmitterBase transmitter in bot.SensorArray.CommunicationArray.Transmitters)
                    {
                        int range = transmitter.Range * 4;
                        Pen pen = null;
                        if (transmitter.CommunicationType == Robot.Wanderer.Enums.CommunicationTypes.IR)
                            pen = this.communicationPenIR;
                        else if (transmitter.CommunicationType == Robot.Wanderer.Enums.CommunicationTypes.RF)
                            pen = this.communicationPenRF;

                        Rectangle transmitterRectangle = new Rectangle(
                            botRec.X - (range / 2), botRec.Y - (range / 2),
                            BotSize + range, BotSize + range);

                        this.arenaGraphics.DrawEllipse(pen, transmitterRectangle);

                        CheckForTransmission(bot, transmitterRectangle, pen.Color);
                    }

                    this.botRectangles[bot.EPROM.ID] = botRec;
                }
            }
        }

       
        private void CheckForBump(Bot bot, Rectangle botRec)
        {
            // check the arena x-axis
            if (botRec.X <= 0)
                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Left);
            else if (botRec.X + BotSize >= this.Size.Width)
                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Right);

            // check the arena y-axis
            if (botRec.Y <= 0)
                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Front);
            else if (botRec.Y + BotSize >= this.Size.Height)
                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Back);

            
            // check for other bots
            foreach (KeyValuePair<Guid, Rectangle> botRectangle in botRectangles)
            {
                // do not check the current one
                if (bot.EPROM.ID == botRectangle.Key)
                    continue;

                Rectangle intersect = Rectangle.Intersect(botRectangle.Value, botRec);

                if (intersect != Rectangle.Empty)
                {
                    arenaGraphics.DrawRectangle(new Pen(Color.Red, 5), intersect);

                    if (bot.DriveTrain.IsMoving)
                    {
                        if (botRec.X <= intersect.X)
                        {
                            if (bot.DriveTrain.Direction == Robot.Wanderer.Enums.MovementDirection.Left)
                                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Left);
                            else if (bot.DriveTrain.Direction == Robot.Wanderer.Enums.MovementDirection.Right)
                                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Right);
                        }

                        if (botRec.Y <= intersect.Y)
                        {
                            if (bot.DriveTrain.Direction == Robot.Wanderer.Enums.MovementDirection.Forward)
                                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Front);
                            else if (bot.DriveTrain.Direction == Robot.Wanderer.Enums.MovementDirection.Backward)
                                bot.PhysicalInteraction.TriggerBump(Robot.Wanderer.Enums.BumpSensorLocation.Back);
                        }
                    }
                }
            }
        }



        private void CheckForTransmission(Bot bot, Rectangle transmitterRectangle, Color transmitterColor)
        {
            foreach (KeyValuePair<Guid, Rectangle> botRectangle in botRectangles)
            {
                // do not check the current one
                if (bot.EPROM.ID == botRectangle.Key)
                    continue;

                Rectangle intersect = Rectangle.Intersect(botRectangle.Value, transmitterRectangle);

                if (intersect != Rectangle.Empty)
                {
                    bot.PhysicalInteraction.CommunicationInRange(transmitterColor == Color.Blue ? Robot.Wanderer.Enums.CommunicationTypes.RF : Robot.Wanderer.Enums.CommunicationTypes.IR);
                }
            }
        }
    }


    internal class BotEventArgs : EventArgs
    {
        private Bot bot;

        public BotEventArgs(Bot bot)
        {
            this.bot = bot;
        }

        public Bot Bot
        {
            get { return this.bot; }
        }
    }
}
