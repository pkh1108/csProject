using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dark_Echo
{
    public partial class Game : Form
    {
        int footIndex;  // 0 : leftfoot || 1 : rightfoot
        Image Lfoot;
        int LfootIndex;
        Image Rfoot;
        int RfootIndex;

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawImage(Lfoot, 0, 0);
            e.Graphics.DrawImage(Rfoot, 32, 0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            changeLfoot(LfootIndex);
            LfootIndex = (LfootIndex + 1) % 90;

            changeRfoot(RfootIndex);
            RfootIndex = (RfootIndex + 1) % 90;

            Invalidate();
        }

        // 필요 없을 것 같다;;
        private void steptimer_Tick(object sender, EventArgs e)
        {
            changefoot();

            Invalidate();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot00);
            Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot00);
        }

        // 발 내딛는 순서를 정합니다.
        void changefoot()
        {
            if (footIndex == 0) footIndex = 1;
            else if (footIndex == 1) footIndex = 0;
        }

        // 왼쪽발 애니메이션 인덱스를 정합니다.
        void changeLfoot(int index)
        {
            switch (index)
            {
                case 0:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot00);
                    break;
                case 1:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot01);
                    break;
                case 2:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot02);
                    break;
                case 3:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot03);
                    break;
                case 4:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot04);
                    break;
                case 5:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot05);
                    break;
                case 6:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot06);
                    break;
                case 7:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot07);
                    break;
                case 8:
                    Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot08);
                    break;
            }
        }

        // 오른발 애니메이션 인덱스를 정합니다.
        void changeRfoot(int index)
        {
            switch (index)
            {
                case 0:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot00);
                    break;
                case 1:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot01);
                    break;
                case 2:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot02);
                    break;
                case 3:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot03);
                    break;
                case 4:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot04);
                    break;
                case 5:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot05);
                    break;
                case 6:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot06);
                    break;
                case 7:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot07);
                    break;
                case 8:
                    Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot08);
                    break;
            }
        }

       
    }
}
