using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dark_Echo
{
    public partial class Game : Form
    {
       
        bool isfootEnd;
        int footIndex;  // 0 : leftfoot || 1 : rightfoot
        Bitmap Lfoot;
        int LfootIndex;
        Bitmap Rfoot;
        int RfootIndex;
        int mouseX, mouseY;
        int x, y;
        int tempX, tempY;
        double m;
        double angle;
        int keyState;
        int isKeyDown;

        public Game()
        {

            InitializeComponent();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {

            
            if (footIndex == 0)
            {
                
                e.Graphics.DrawImage(Lfoot, x, y);

            }
            else if (footIndex == 1)
            {
               
                e.Graphics.DrawImage(Rfoot, x, y);
            }
            else if (footIndex == 2)
            {
                if(keyState == 0)
                {
                    e.Graphics.DrawImage(Lfoot, x, y);
                    e.Graphics.DrawImage(Rfoot, x + 32, y);
                }
                else if(keyState == 1)
                {
                    e.Graphics.DrawImage(Lfoot, x + 32, y);
                    e.Graphics.DrawImage(Rfoot, x, y);
                }
                else if(keyState == 2)
                {
                    e.Graphics.DrawImage(Lfoot, x, y + 32);
                    e.Graphics.DrawImage(Rfoot, x, y);
                }
                else if(keyState == 3)
                {
                    e.Graphics.DrawImage(Lfoot, x, y);
                    e.Graphics.DrawImage(Rfoot, x, y + 32);
                }
               
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isKeyDown > 20)
            {
                footIndex = 2;
                isfootEnd = false;
                LfootIndex = 0;
                RfootIndex = 0;
                isKeyDown = 0;
            }
            if (isfootEnd == false)
            {
                
                if (footIndex == 0)
                {
                    changeLfoot(LfootIndex);
                    LfootIndex = (LfootIndex + 1) % 90;
                    if (LfootIndex >= 8)
                    {
                        

                        LfootIndex = 8;
                        changeLfoot(LfootIndex);
                        changefoot();
                        isfootEnd = true;

                        //if (x != mouseX && y != mouseY)
                        //{
                        //    getMoveXY();
                        //    isfootEnd = false;
                        //}
                    }

                }
                else if (footIndex == 1)
                {
                    changeRfoot(RfootIndex);
                    RfootIndex = (RfootIndex + 1) % 90;
                    if (RfootIndex >= 8)
                    {
                        RfootIndex = 8;
                        changeRfoot(RfootIndex);
                        changefoot();
                        isfootEnd = true;

                        //if (x != mouseX && y != mouseY)
                        //{
                        //    getMoveXY();
                        //    isfootEnd = false;
                        //}
                    }
                }
                else if (footIndex == 2)
                {
                    changeLfoot(LfootIndex);
                    LfootIndex = (LfootIndex + 1) % 90;
                    changeRfoot(RfootIndex);
                    RfootIndex = (RfootIndex + 1) % 90;
                    if (RfootIndex >= 8)
                    {
                        RfootIndex = 8;
                        changeRfoot(RfootIndex);
                        LfootIndex = 8;
                        changeLfoot(LfootIndex);
                        changefoot();
                        isfootEnd = true;
                    }
                }

            }
            isKeyDown++;
            Invalidate();
        }

        // 필요 없을 것 같다;;
        private void steptimer_Tick(object sender, EventArgs e)
        {
            //changefoot();

            Invalidate();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot08);
            Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot08);
            
            x = 500;
            y = 500;
            //mouseX = x;
            //mouseY = y;
            //tempX = x;
            //tempY = y;
            angle = 0;
            isKeyDown = 0;
            footIndex = 2;
        }

        // 발 내딛는 순서를 정합니다.
        void changefoot()
        {
            if (footIndex == 0)
            {
                footIndex = 1;
                RfootIndex = 0;
            }
            else if (footIndex == 1 || footIndex == 2)
            {
                footIndex = 0;
                LfootIndex = 0;
            }

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
            RotateLFoot();
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
            RotateRFoot();
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            //mouseX = e.X;
            //mouseY = e.Y;
            //tempX = x;
            //tempY = y;
            //m = ((tempY - mouseY) / (tempX - mouseX));

            
            //if (isfootEnd == true)
            //{
               
            //    getMoveXY();

            //    isfootEnd = false;
            //}
            ////Invalidate();


        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //if (e.KeyChar == Keys.Up)
            //{
            //    y -= 10;
            //}
            //if (e.Keychar == Keys.Down)
            //{
            //    y += 10;
            //}
            //if (e.Keychar == Keys.Left)
            //{
            //    x -= 10;
            //}
            //if (e.Keychar == Keys.Right)
            //{
            //    x += 10;
            //}

            //if(e.KeyChar == 'w' || e.KeyChar == 'W')
            //{
            //    y -= 10;
            //}
            //if (e.KeyChar == 's' || e.KeyChar == 'S')
            //{
            //    y += 10;
            //}
            //if (e.KeyChar == 'a' || e.KeyChar == 'A')
            //{
            //    x -= 10;
            //}
            //if (e.KeyChar == 'd' || e.KeyChar == 'D')
            //{
            //    x += 10;
            //}

            //Invalidate();
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyDown = 1;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (isfootEnd == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        isKeyDown = 0;
                        keyState = 0;
                        y -= 50;
                        
                        break;
                    case Keys.Down:
                        isKeyDown = 0;
                        keyState = 1;
                        y += 50;
                        break;
                    case Keys.Left:
                        isKeyDown = 0;
                        keyState = 2;
                        x -= 50;
                        break;
                    case Keys.Right:
                        isKeyDown = 0;
                        keyState = 3;
                        x += 50;
                        
                        break;
                }
                
                isfootEnd = false;
                Invalidate();

            }
            
        }
        private void RotateLFoot()
        {
            switch (keyState)
            {
                case 0:
                    Lfoot.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
                case 1:
                    Lfoot.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 2:
                    Lfoot.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    break;
                case 3:
                    Lfoot.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
        }
        private void RotateRFoot()
        {
            switch (keyState)
            {
                case 0:
                    Rfoot.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
                case 1:
                    Rfoot.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 2:
                    Rfoot.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    break;
                case 3:
                    Rfoot.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
        }

        //private void getMoveXY()
        //{
        //    // y = mx + n
        //    // y = mx + b -am

        //    angle = GetAngleFromPoint(new Point(mouseX, mouseY), new Point(x, y));
        //    if (tempX > mouseX)
        //    {
        //        x -= 20;
        //        y = (int)((m * x) + tempY - (tempX * m));
        //    }
        //    else
        //    {
        //        x += 20;
        //        y = (int)((m * x) + tempY - (tempX * m));
        //    }



        //}
        //internal double GetAngleFromPoint(Point point, Point centerPoint)
        //{
        //    //double dy = (point.Y - centerPoint.Y);
        //    //double dx = (point.X - centerPoint.X);


        //    //double theta = Math.Atan2(dy, dx);

        //    //double cal = (90 - ((theta * 180) / Math.PI)) % 360;
        //    ////double cal = theta * 90 / Math.PI;

        //    //return cal;

        //    double cal = Math.Atan(point.Y/point.X) * (360 / (2 * Math.PI));
        //    return cal;
        //}


    }
}
