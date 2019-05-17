using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private bool crossTurn = false;
        private char[] map = new char[9] { get; private set; }
        
        public TicTacToeForm()
        {
            InitializeComponent();
            for (int i = 0; i < 9; ++i)
            {
                map[i] = ' ';
            }
        }

        private int Check()
        {
            bool haveEmpty = false;
            for (int i = 0; i < 9; ++i)
            {
                if (map[i] == ' ')
                {
                    haveEmpty = true;
                }
                if (i < 3 && map[i] == map[i + 3] && map[i + 3] == map[i + 6] && map[i] != ' ')
                {
                    return 1;
                }
                if (i % 3 == 0 && map[i] == map[i + 1] && map[i + 1] == map[i + 2] && map[i] != ' ')
                {
                    return 1;
                }
            }
            return haveEmpty ? -1: 0;
        }

        private void ButtonClick(int buttonNumber)
        {
            if (map[buttonNumber] == ' ')
            {
                if (crossTurn)
                {
                    map[buttonNumber] = 'X';
                }
                else
                {
                    map[buttonNumber] = 'O';
                }
                var check = Check();
                if (check == -1)
                {
                    crossTurn = !crossTurn;
                    return;
                }
                if (check == 0)
                {
                    MessageBox.Show("Ничья");
                    return;
                }
                if (crossTurn)
                {
                    MessageBox.Show("Победил второй игрок");
                }
                MessageBox.Show("Победил первый игрок");
            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            ButtonClick(0);
            button1.Text = map[0].ToString();
        }

        private void Button2Click(object sender, EventArgs e)
        {
            ButtonClick(1);
            button2.Text = map[1].ToString();
        }

        private void Button3Click(object sender, EventArgs e)
        {
            ButtonClick(2);
            button3.Text = map[2].ToString();
        }

        private void Button4Click(object sender, EventArgs e)
        {
            ButtonClick(3);
            button4.Text = map[3].ToString();
        }

        private void Button5Click(object sender, EventArgs e)
        {
            ButtonClick(4);
            button5.Text = map[4].ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ButtonClick(5);
            button6.Text = map[5].ToString();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ButtonClick(6);
            button7.Text = map[6].ToString();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ButtonClick(7);
            button8.Text = map[7].ToString();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ButtonClick(8);
            button9.Text = map[8].ToString();
        }
    }
}