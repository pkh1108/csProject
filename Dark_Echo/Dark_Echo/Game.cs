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
        int x, y;
        int keyState;
        int isKeyDown;
        int xNum, yNum; // 가로 세로 사각형 수
        int[,] Map;
        bool goal;
        bool mapTimerEnd;
        int mapTimer;
        // protected bool[,] abChecked;

        //Point[] wave = new Point[8];   // 파장
        List<Point>[] wave = new List<Point>[8];
        
        Point waveXY;
        int time;
        int radius;
        public Game()
        {

            InitializeComponent();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            
            if(Stage01.Enabled == false)
            {
                Stage01.Visible = false;
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.White);

                Brush brush = Brushes.DarkGray;
                int mapX = (int)((x - 8) / 82);
                int mapY = (int)((y - 8) / 82);

                if (Map[mapX, mapY] == 3)
                {
                    // 목적지 도착
                   
                        if(mapTimer == 2)
                    {
                        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Dark_Echo.Resource.Door_Metal_Slam_Shut);
                        sound.Play();
                    

                    }
                    goal = true;
                    pen = new Pen(Color.Aqua);

                    for(int i = 0; i<yNum; i++)
                    {
                        for(int j = 0; j<mapTimer; j++)
                        {
                            if(Map[j, i] != 0)
                            {

                            brush = Brushes.DarkGray;
                            g.FillRectangle(brush, new Rectangle(new Point(j * 82, i * 82), new Size(82, 82)));

                            }
                            if(mapTimerEnd == true)
                            {
                                Clear.Enabled = true;
                                Clear.Visible = true;
                            }
                        }
                    }
                   
                }
                else
                {
                    for (int i = 0; i < yNum; i++)
                    {
                        for (int j = 0; j < xNum; j++)
                        {
                            //if (Map[j, i] == 2)
                            //{
                            //    brush = Brushes.DarkGray;
                            //    g.FillRectangle(brush, new Rectangle(new Point(j * 82, i * 82), new Size(82, 82)));
                            //}
                            if (Map[j, i] == 3)

                            {
                                brush = Brushes.DarkGray;
                                g.FillRectangle(brush, new Rectangle(new Point(j * 82, i * 82), new Size(82, 82)));
                            }
                            // g.DrawRectangle(pen, j * 82, i * 82, 82, 82);


                        }
                    }

                    if (footIndex == 0)
                    {
                       
                        e.Graphics.DrawImage(Lfoot, x, y);
                        setWavePoint(x + 20, y + 35);
                        if (isfootEnd == false) drawWave(g);
                    }
                    else if (footIndex == 1)
                    {
                        
                        e.Graphics.DrawImage(Rfoot, x, y);
                        setWavePoint(x + 20, y + 35);
                        if (isfootEnd == false) drawWave(g);
                    }
                    else if (footIndex == 2)
                    {
                        if (keyState == 0)
                        {
                            e.Graphics.DrawImage(Lfoot, x, y);
                            e.Graphics.DrawImage(Rfoot, x + 32, y);
                        }
                        else if (keyState == 1)
                        {
                            e.Graphics.DrawImage(Lfoot, x + 32, y);
                            e.Graphics.DrawImage(Rfoot, x, y);
                        }
                        else if (keyState == 2)
                        {
                            e.Graphics.DrawImage(Lfoot, x, y + 32);
                            e.Graphics.DrawImage(Rfoot, x, y);
                        }
                        else if (keyState == 3)
                        {
                            e.Graphics.DrawImage(Lfoot, x, y);
                            e.Graphics.DrawImage(Rfoot, x, y + 32);
                        }

                    }
                }
                
            }
            
           
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            if (isKeyDown > 15)
            {
                footIndex = 2;
                isfootEnd = false;
                LfootIndex = 0;
                RfootIndex = 0;
                isKeyDown = 0;
            }
            if (isfootEnd == false)
            {
                //setWavePoint(x, y);

                if (footIndex == 0)
                {
                    if (LfootIndex == 0 && isfootEnd == false)
                    {
                        System.Media.SoundPlayer s1 = new System.Media.SoundPlayer(Dark_Echo.Resource.step);
                        s1.Play();

                    }
                    changeLfoot(LfootIndex);
                    LfootIndex = (LfootIndex + 1) % 90;
                    setWavePoint(waveXY.X, waveXY.Y);
                    time++;
                    if (LfootIndex >= 8)
                    {

                        time = 0;
                        LfootIndex = 8;
                        changeLfoot(LfootIndex);
                        changefoot();
                        isfootEnd = true;                     
                    }

                }
                else if (footIndex == 1)
                {
                    if (RfootIndex == 0 && isfootEnd == false)
                    {
                        System.Media.SoundPlayer s2 = new System.Media.SoundPlayer(Dark_Echo.Resource.step);
                        s2.Play();
                    }
                    changeRfoot(RfootIndex);
                    RfootIndex = (RfootIndex + 1) % 90;
                    setWavePoint(waveXY.X, waveXY.Y);
                    time++;
                    if (RfootIndex >= 8)
                    {
                        time = 0;
                        RfootIndex = 8;
                        changeRfoot(RfootIndex);
                        changefoot();
                        isfootEnd = true;
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
            if (goal == true)
            {

                if (mapTimer <= xNum)
                    mapTimer++;
                else mapTimerEnd = true;
            }

            Invalidate();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Lfoot = new Bitmap(Dark_Echo.Resource.leftfoot08);
            Rfoot = new Bitmap(Dark_Echo.Resource.rightfoot08);
            xNum = ClientSize.Width / 82;
            yNum = ClientSize.Height / 82;
           // abChecked = new bool[yNum, xNum];
            Map = new int[xNum + 1, yNum + 1];
            x = (0 * 82) + 8;
            //n = (x-8)/82
            y = (7 * 82) + 8;
            
            isKeyDown = 0;
            footIndex = 2;

            for (int i = 0; i < xNum + 1; i++)
            {
                for (int j = 0; j < yNum + 1; j++)
                {
                    Map[i, j] = 0;
                }
            }
            makeMap();

            for(int i = 0; i<8; i++)
            {
                wave[i] = new List<Point>();
            }
            //for(int i = 0; i<8; i++)
            //{
            //    wave[i].Add(new Point(0, 0));
            //}
            waveXY = new Point(x, y);
            radius = 0;
            time = 0;
            mapTimer = 0;
            mapTimerEnd = false;
            goal = false;
        }
        // Load후 선언되는 변수들
    
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
            radius = 0;

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
            radius += 10;
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
            radius += 10;
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
           
          
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyDown = 1;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            Stage01.Enabled = false;
            int mapX;
            int mapY;
            
            
                if (isfootEnd == true)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            isKeyDown = 0;
                            keyState = 0;
                            y -= 82;
                        mapX = (int)((x - 8) / 82);
                        mapY = (int)((y - 8) / 82);
                        if (Map[mapX, mapY] == 0) y += 82;

                            break;
                        case Keys.Down:
                            isKeyDown = 0;
                            keyState = 1;
                            y += 82;
                        mapX = (int)((x - 8) / 82);
                        mapY = (int)((y - 8) / 82);
                        if (Map[mapX, mapY] == 0) y -= 82;

                        break;
                        case Keys.Left:
                            isKeyDown = 0;
                            keyState = 2;
                            x -= 82;
                         mapX = (int)((x - 8) / 82);
                         mapY = (int)((y - 8) / 82);
                        if (Map[mapX, mapY] == 0) x += 82;

                        break;
                        case Keys.Right:
                            isKeyDown = 0;
                            keyState = 3;
                            x += 82;
                        mapX = (int)((x - 8) / 82);
                        mapY = (int)((y - 8) / 82);
                        if (Map[mapX, mapY] == 0) x -= 82;


                        break;
                    }

                    isfootEnd = false;

                setWavePoint(x, y);
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

        private void makeMap()
        {
            Map[0, 7] = 2;  // 시작점
            Map[1, 7] = 1;
            Map[2, 7] = 1;
            Map[1, 6] = 1;
            Map[2, 6] = 1;
            Map[3, 6] = 1;
            Map[1, 5] = 1;
            Map[2, 5] = 1;
            Map[3, 5] = 1;
            Map[3, 4] = 1;
            Map[4, 4] = 1;
            Map[5, 4] = 1;
            Map[3, 3] = 1;
            Map[4, 3] = 1;
            Map[5, 3] = 1;
            Map[6, 3] = 1;
            Map[7, 3] = 1;
            Map[8, 3] = 1;
            Map[5, 2] = 1;
            Map[6, 2] = 1;
            Map[7, 2] = 1;
            Map[8, 2] = 1;
            Map[9, 2] = 1;
            Map[5, 1] = 1;
            Map[6, 1] = 1;
            Map[9, 1] = 1;
            Map[9, 0] = 3;  // 끝점

        }
        private void setWavePoint(int centerX, int centerY)
        {
            initWave();
            int tan = 0;
            //for(int i = 0; i<8; i++)
            //{
            //    wave[i].Add(new Point(centerX, centerY));
            //}
            int plusTime = 10 * time;
            wave[0].Add(new Point(centerX, centerY + plusTime));
            wave[1].Add(new Point(centerX + plusTime, centerY + plusTime));
            wave[2].Add(new Point(centerX + plusTime, centerY - plusTime));
            wave[3].Add(new Point(centerX + plusTime, centerY));
            wave[4].Add(new Point(centerX, centerY - plusTime));
            wave[5].Add(new Point(centerX - plusTime, centerY + plusTime));
            wave[6].Add(new Point(centerX - plusTime, centerY - plusTime));
            wave[7].Add(new Point(centerX - plusTime, centerY));
            //for (int i = 0; i < 8; i++)

            //{
            //    int tan = (int)Math.Tan(45 * i - 180);
            //    int my = (int)(tan + centerY - (tan * centerX));

            //    //if(my > 50)
            //    //{
            //    //    wave[i].Add(new Point(centerX, (int)(tan + centerY - (tan * centerX))));

            //    //}
            //    //else
            //    //{

            //    wave[i].Add(new Point(centerX + 50, (int)(tan * (centerX + 50) + centerY - (tan * centerX))));
            //    // }


            //}
            wave[0].Add(new Point(centerX, (centerY + plusTime) + 50));
            tan = (int)Math.Tan(45);
            wave[1].Add(new Point(centerX + plusTime + 50, (int)(tan * (centerX + 50) + centerY + plusTime - (tan * centerX))));
            tan = (int)Math.Tan(90);
            wave[2].Add(new Point(centerX + plusTime + 50, (int)(tan * (centerX + 50) + centerY - plusTime - (tan * centerX))));
            tan = (int)Math.Tan(135);
            wave[3].Add(new Point(centerX + plusTime + 50, (int)(tan * (centerX + 50) + centerY - (tan * centerX))));

            wave[4].Add(new Point(centerX, centerY - plusTime - 50));
            tan = (int)Math.Tan(45);
            wave[5].Add(new Point(centerX - plusTime - 50, (int)(tan * (centerX + 50) + centerY + plusTime - (tan * centerX))));
            tan = (int)Math.Tan(90);
            wave[6].Add(new Point(centerX - plusTime - 50, (int)(tan * (centerX + 50) + centerY - plusTime - (tan * centerX))));
            tan = (int)Math.Tan(135);
            wave[7].Add(new Point(centerX - plusTime - 50, (int)(tan * (centerX + 50) + centerY - (tan * centerX))));

            for(int i = 0; i<8; i++)
            {
                if (isWaveCol(wave[i].ElementAt(1)))
                {
                    //wave[i].Reverse();
                    //Point n = wave[i].ElementAt(1);
                    //wave[i].RemoveAt(1);
                    //n.X += -50;
                    //n.Y += -50;

                    //wave[i].Add(n);
                    wave[i].Clear();
                }
            }
        }
        
        private void setReflection()
        {

            //mapX = (int)((x - 8) / 82);
            //mapY = (int)((y - 8) / 82);
            //if (Map[mapX, mapY] == 0) y += 82;

        }
        private void drawWave(Graphics g)
        {

            Pen p = new Pen(Color.Black);
            //switch (time)
            //{
            //    case 0:
            //        p = new Pen(Color.White);
            //        break;
            //    case 1:
            //        p = new Pen(Color.SlateGray);

            //        break;
            //    case 2:
            //        p = new Pen(Color.LightSlateGray);

            //        break;
            //    case 3:
            //        p = new Pen(Color.LightGray);

            //        break;
            //    case 4:
            //        p = new Pen(Color.Gray);

            //        break;
            //    case 5:
            //        p = new Pen(Color.DimGray);

            //        break;
            //    case 6:
            //        p = new Pen(Color.DarkSlateGray);

            //        break;
            //    case 7:
            //        p = new Pen(Color.DarkGray);

            //        break;
            //    case 8:
            //        p = new Pen(Color.Black);

            //        break;


            //}
            p = new Pen(Color.FromArgb(255 - (time * 30), 255 - (time * 30), 255 - (time * 30)));
            p.Width = 5;
            p.StartCap = LineCap.Round;
            p.DashCap = DashCap.Round;
            p.EndCap = LineCap.Round;
            for (int i = 0; i < 8; i++)
            {
                if(wave[i].Count >= 1 )
                {
                Point start = wave[i].ElementAt(0);
                Point end = wave[i].ElementAt(1);

                g.DrawLine(p, start, end);

                }
            }

            //Point start = wave[6].ElementAt(0);
            //Point end = wave[6].ElementAt(1);

            //g.DrawLine(p, start, end);

        }
        private void initWave()
        {
            for (int i = 0; i < 8; i++)
            {
                wave[i].Clear();
            }
        }
        private bool isWaveCol(Point p)
        {
            int mapX = (int)(p.X / 82);
            int mapY = (int)(p.Y / 82);

            
            if (Map[Math.Abs(mapX), Math.Abs(mapY)] == 0)
            {
                return true;
            }
            return false;

        }
        private int getRoadIndex()

        {
            int index = 0;
            for(int i = 0; i<yNum; i++)
            {
                for(int j = 0; j<xNum; j++)
                {
                    if (Map[j, i] == 1) index++;
                }
            }
            return index;
        }

    }
}
