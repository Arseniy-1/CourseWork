using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoTiles
{
    public partial class Form1 : Form
    {
        public int[,] map = new int[8, 4];
        public int cellWidth = 50;
        public int cellHeight = 80;
        private Timer timer;
        private bool keyPressedThisTurn = false;
        private bool gameStarted = false;

        private Timer timerCountdown;
        private int score = 0;
        private int timeLeft = 0;
        private int timePerTile = 2000; // 2 секунды на старт


        public Form1()
        {
            InitializeComponent();

            this.Text = "Piano";
            cellWidth = Width / 4;
            this.Paint += new PaintEventHandler(Repaint);
            this.KeyUp += new KeyEventHandler(OnKeyboardPressed);
            Init();

            // Таймер для управления логикой игры
            timer = new Timer();
            timer.Interval = 50; // обновляем каждую 50 мс
            timer.Tick += new EventHandler(OnTimerTick);


            this.Controls.Add(labelTimer);


            this.Controls.Add(labelScore);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (!gameStarted) return;

            timeLeft -= timer.Interval;
            labelTimer.Text = $"Time left: {timeLeft} ms";

            if (timeLeft <= 0)
            {
                Lose();
            }
        }

        private void Lose()
        {
            timer.Stop();
            MessageBox.Show($"You lost!\nScore: {score}");
            Init();
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D1":
                    CheckForPressedButton(0);
                    break;
                case "D2":
                    CheckForPressedButton(1);
                    break;
                case "D3":
                    CheckForPressedButton(2);
                    break;
                case "D4":
                    CheckForPressedButton(3);
                    break;
            }
        }

        public void CheckForPressedButton(int i)
        {
            if (map[7, i] != 0)
            {
                if (!gameStarted)
                {
                    gameStarted = true;
                    timer.Start();
                    timeLeft = timePerTile;
                }

                keyPressedThisTurn = true;
                MoveMap();
                PlaySound(i);

                score++;
                labelScore.Text = $"Score: {score}";

                // Сложнение игры
                if (timePerTile > 500)
                    timePerTile -= 50; // Уменьшаем время на 50 мс каждый раз

                timeLeft = timePerTile; // Сбрасываем таймер для следующей плитки
            }
            else
            {
                Lose();
            }
        }


        public void PlaySound(int sound)
        {
            System.IO.Stream str = null;

            switch (sound)
            {
                case 0:
                    str = Properties.Resources.g6;
                    break;
                case 1:
                    str = Properties.Resources.f6;
                    break;
                case 2:
                    str = Properties.Resources.d6;
                    break;
                case 3:
                    str = Properties.Resources.e6;
                    break;
            }

            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        public void MoveMap()
        {
            for(int i = 7; i > 0; i--)
            {
                for(int j = 0; j < 4; j++)
                {
                    map[i, j] = map[i - 1, j];
                }
            }

            AddNewLine();
            Invalidate();
        }

        public void AddNewLine()
        {
            Random r = new Random();
            int j = r.Next(0, 4);

            for (int k = 0; k < 4; k++)
                map[0, k] = 0;
            map[0, j] = 1;
        }

        public void Init()
        {
            timer?.Stop();
            ClearMap();
            GenerateMap();
            Invalidate();
            gameStarted = false;
            keyPressedThisTurn = false;
            score = 0;
            timePerTile = 2000;
            labelScore.Text = $"Score: {score}";
            labelTimer.Text = $"Time left: {timePerTile} ms";
        }


        public void ClearMap()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        public void GenerateMap()
        {
            Random r = new Random();
            for(int i = 0; i < 8; i++)
            {
                int j = r.Next(0, 4);
                map[i, j] = 1;
            }
        }

        public void DrawMap(Graphics g)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(map[i,j] == 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.White), cellWidth * j, cellHeight * i, cellWidth, cellHeight);
                    }

                    if(map[i,j] == 1)
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), cellWidth * j, cellHeight * i, cellWidth, cellHeight);
                    }
                }
            }

            for(int i = 0; i < 8; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black)), 0, i * cellHeight, 4 * cellWidth, i * cellHeight);
            }

            for(int i = 0; i < 4; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black)), i * cellWidth, 0, i * cellWidth, 8 * cellHeight);
            }
        }

        private void Repaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMap(g);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelScore_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
