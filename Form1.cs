using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShulteTable
{
    public partial class Form1 : Form
    {
        Button[,] buttons;
        int size = 4, buttonSize, x, y, index;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            size++;
            buttonSize = 40;
            x = 20; y = 20;
            index = 1;
            CreateTable();
        }
        private void CreateTable()
        {
            buttons = new Button[size, size];
            List<int> rangeList = new List<int>();
            Random random = new Random();
            int range = size * size + 1;

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Click += TableClick;
                    buttons[i, j].Size = new Size(buttonSize, buttonSize);
                    buttons[i, j].Location = new Point(x, y);
                    Controls.Add(buttons[i, j]);
                    x += 40;
                    while (true)
                    {
                        int value = random.Next(1, range);
                        if (!rangeList.Contains(value))
                        {
                            rangeList.Add(value);
                            buttons[i, j].Text = value.ToString();
                            break;
                        }
                    }
                }
                x = 20;
                y += 40;
            }
        }
        private void TableClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Text == index.ToString())
                {
                    button.BackColor = Color.Lime;
                    if (button.Text == (size * size).ToString())
                    {
                        if(size < 10)
                        {
                            MessageBox.Show("Поздравляем вы выиграли", "Победа");
                            Clear();
                            Init();
                        }
                        else
                        {
                            MessageBox.Show("Вот это да вы абсолютный чемпион");
                            Application.Exit();
                        }
                    }
                    else
                        index++;
                }
                else
                {
                    var s = MessageBox.Show("Упс, вы ошиблись!\nХотите попробовать снова??", "Ошибка", MessageBoxButtons.OKCancel);
                    if (s == DialogResult.OK)
                    {
                        Clear();
                        Init();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }
        private void Clear()
        {
            foreach (Button button in buttons)
            {
                Controls.Remove(button);
            }
        }
    }
}
