using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PianoTiles
{
    public partial class Form1 : Form
    {
        private const int HorizontalTilesCount = 4;
        private const int VerticalTilesCount = 10;

        private const char EmptyTileSymbol = '0';
        private const char FilledTileSymbol = '1';
        private const char CompletedTileSymbol = '2';
        private const char FailedTileSymbol = '3';

        private const int _cellWidth = 50;
        private const int _cellHeight = 80;

        private readonly Color _emptyTileColor = Color.White;
        private readonly Color _filledTileColor = Color.Black;
        private readonly Color _completedTileColor = Color.Blue;
        private readonly Color _failedTileColor = Color.Red;

        private readonly int _startHealth = 3;

        private char[,] _map = new char[VerticalTilesCount, HorizontalTilesCount];

        private float _offset = 0f;
        private float _speed = 20;

        private int _score = 0;

        private HealthView _healthView;
        private Health _health;

        private List<PictureBox> _heartViews;
        private List<string> _levelFiles;
        private int _currentLevelIndex;
        private string _levelsDirectory = Path.Combine(Application.StartupPath, "Maps");

        public Form1()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(OnKeyboardPressed);
            DoubleBuffered = true;

            _heartViews = new List<PictureBox>
            {
                HeartView1,
                HeartView2,
                HeartView3
            };

            _health = new Health(_startHealth);
            _healthView = new HealthView(_health, _heartViews);

            _health.LostHealth += GameOver;

            if (!Directory.Exists(_levelsDirectory))
            {
                Directory.CreateDirectory(_levelsDirectory);
            }

            _levelFiles = LevelLoader.GetAllLevelFiles(_levelsDirectory);

            Console.WriteLine(_levelFiles.Count);

            InitializeGame();
        }

        private void InitializeGame()
        {
            Random random = new Random();
            _map = LevelLoader.LoadLevelFromFile(_levelFiles[0]);

            _offset = 0f;
            _score = 0;
            timer.Start();
        }

        private void UpdateScore()
        {
            labelScore.Text = $"Счёт: {_score}";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _offset += _speed;

            if (_offset == _cellHeight)
            {
                _offset = 0f;
                CreateNewLine();
            }

            DrawMap(e.Graphics, _offset);
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                int number = e.KeyCode - Keys.D0;

                if (number > _map.GetLength(1))
                    return;

                if (_map[VerticalTilesCount - 2, number - 1] == FilledTileSymbol)
                {
                    _score++;
                    UpdateScore();

                    _map[VerticalTilesCount - 2, number - 1] = CompletedTileSymbol;
                }
                else
                {
                    _health.TakeDamage();
                    _map[VerticalTilesCount - 2, number - 1] = FailedTileSymbol;
                }
            }
        }

        private void CreateNewLine()
        {
            char[] newLine = new char[HorizontalTilesCount];

            Random random = new Random();
            int FilledTileIndex = random.Next(newLine.Length);

            for (int i = 0; i < newLine.Length; i++)
            {
                if (i == FilledTileIndex)
                    newLine[i] = FilledTileSymbol;
                else
                    newLine[i] = EmptyTileSymbol;
            }

            UpdateMap(newLine);
        }

        void UpdateMap(char[] newRow)
        {
            int rows = _map.GetLength(0);
            int cols = _map.GetLength(1);

            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    _map[i + 1, j] = _map[i, j];
                }
            }

            for (int j = 0; j < cols; j++)
            {
                _map[0, j] = newRow[j];
            }
        }

        public void DrawMap(Graphics g, float verticalOffset)
        {
            g.TranslateTransform(0, Height - VerticalTilesCount * _cellHeight);

            for (int i = 0; i < VerticalTilesCount; i++)
            {
                for (int j = 0; j < HorizontalTilesCount; j++)
                {
                    Color tileColor;

                    switch (_map[i, j])
                    {
                        case EmptyTileSymbol:
                            tileColor = _emptyTileColor;
                            break;

                        case FilledTileSymbol:
                            tileColor = _filledTileColor;
                            break;

                        case CompletedTileSymbol:
                            tileColor = _completedTileColor;
                            break;

                        case FailedTileSymbol:
                            tileColor = _failedTileColor;
                            break;

                        default:
                            tileColor = _emptyTileColor;
                            break;
                    }

                    g.FillRectangle(new SolidBrush(tileColor), _cellWidth * j, _cellHeight * i + verticalOffset, _cellWidth, _cellHeight);

                    float xStart = 0;
                    float xEnd = _cellWidth * HorizontalTilesCount;
                    float yStart = Height + 25;
                    float yEnd = yStart;
                    float lineBold = 5;

                    using (Pen thickPen = new Pen(Color.Black, lineBold))
                    {
                        g.DrawLine(thickPen, xStart, yStart, xEnd, yEnd);
                    }
                }
            }

            for (int i = 0; i < VerticalTilesCount; i++)
            {
                float xStartPosition = 0;
                float xEndPosition = _cellWidth * HorizontalTilesCount;
                float yStartPosition = i * _cellHeight + _offset;
                float yEndPosition = yStartPosition;

                g.DrawLine(new Pen(new SolidBrush(Color.Black)), xStartPosition, yStartPosition, xEndPosition, yEndPosition);
            }

            for (int i = 0; i < HorizontalTilesCount; i++)
            {
                float xStartPosition = i * _cellWidth;
                float xEndPosition = xStartPosition;
                float yStartPosition = 0 + _offset;
                float yEndPosition = _cellHeight * VerticalTilesCount + _offset;

                g.DrawLine(new Pen(new SolidBrush(Color.Black)), xStartPosition, yStartPosition, xEndPosition, yEndPosition);
            }
        }

        private void GameOver()
        {
            timer.Stop();

            DialogResult result = MessageBox.Show(
                $"Игра окончена! Ваш счёт: {_score}\nХотите начать заново?",
                "Конец игры",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Обрабатываем выбор пользователя
            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void RestartGame()
        {
            _score = 0;
            _offset = 0f;
            _health.Reset();

            for (int i = 0; i < VerticalTilesCount; i++)
            {
                for (int j = 0; j < HorizontalTilesCount; j++)
                {
                    _map[i, j] = EmptyTileSymbol;
                }
            }

            CreateNewLine();

            _healthView.ShowHealth(_health.CurrentHealth);

            timer.Start();

            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void labelScore_Click(object sender, EventArgs e)
        {

        }
    }
}
