using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo02_Game_Caro
{
    public partial class frmMain : Form
    {
        // True: Player 01 - False: Player 02
        private Boolean flag_Player = true;

        // 0 - Empty; 1 - Player01; 2 - Player02
        private int[][] Board = new int[10][];

        public frmMain()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                Board[i] = new int[10];
            }

            ResetBoard();
        }

        private void ResetBoard()
        {
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    Board[i][j] = 0;
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            Button btnCheck = (Button)sender;
            String posCheck = (btnCheck).Name.Substring(3, 2);
            
            int i = int.Parse(posCheck[0].ToString());
            int j = int.Parse(posCheck[1].ToString());

            if (btnCheck.Text == String.Empty)
            {
                if (flag_Player)
                {
                    btnCheck.ForeColor = Color.Red;
                    btnCheck.Text = "X";
                    Board[i][j] = 1;
                }
                else
                {
                    btnCheck.ForeColor = Color.Blue;
                    btnCheck.Text = "O";
                    Board[i][j] = 2;
                }

                if(Check_Win(i, j) == true)
                {
                    String player = (flag_Player == true) ? "Player 01" : "Player 02";
                    MessageBox.Show(player + " Win");
                }

                flag_Player = !flag_Player;
            }

        }

        private Boolean Check_Win(int i, int j)
        {
            return Check_Win_LeftToRight(i, j) || Check_Win_TopToBottom(i, j) || Check_Win_LeftTopToRightBottom(i, j) || Check_Win_LeftBottomToRightTop(i, j);
        }

        private bool Check_Win_LeftBottomToRightTop(int i, int j)
        {
            int count = 1;
            int value = (flag_Player == true) ? 1 : 2;

            int m = i + 1;
            int n = j - 1;
            while (m < 10 && n >= 0 && Board[m][n] == value)
            {
                count++;
                m++;
                n--;
            }

            m = i - 1;
            n = j + 1;
            while (m >= 0 && n < 10 && Board[m][n] == value)
            {
                count++;
                m--;
                n++;
            }

            return count == 5;
        }

        private bool Check_Win_LeftTopToRightBottom(int i, int j)
        {
            int count = 1;
            int value = (flag_Player == true) ? 1 : 2;

            int m = i + 1;
            int n = j + 1;
            while(m < 10 && n < 10 && Board[m][n] == value)
            {
                count++;
                m++;
                n++;
            }

            m = i - 1;
            n = j - 1;
            while (m >= 0 && n >= 0 && Board[m][n] == value)
            {
                count++;
                m--;
                n--;
            }

            return count == 5;
        }

        private Boolean Check_Win_TopToBottom(int i, int j)
        {
            int count = 1;
            int value = (flag_Player == true) ? 1 : 2;

            int m = i + 1;
            while(m < 10 && Board[m][j] == value)
            {
                count++;
                m++;
            }

            m = i - 1; 
            while(m >= 0 && Board[m][j] == value)
            {
                count++;
                m--;
            }

            return count == 5;
        }

        private Boolean Check_Win_LeftToRight(int i, int j)
        {
            int count = 1;
            int value = (flag_Player == true) ? 1 : 2;

            int m = j + 1;
            while(m < 10 && Board[i][m] == value)
            {
                count++;
                m++;
            }

            m = j - 1;
            while(m >= 0 && Board[i][m] == value)
            {
                count++;
                m--;
            }

            return count == 5;
        }
    }
}
