using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace sortingVisualizer
{
    internal class Pong : IPongEngine
    {

        //public Pong()
        //{
        //    InitializeComponent();
        //}



        private bool _sorted = false;
        private int[] TheArray;
        Bitmap btm;
        private Graphics g;
        private Graphics SCG;
        private static int MaxHeight;
        private static int MaxWidth;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);


       
   

        Rectangle ball = Rectangle.Empty;

       private static Rectangle Rside ;
        private static Rectangle Lside ;
       private static Label score1 ;
       private static Label score2 ;


        
    

        int ball_speed = 2;
        int ball_speedY = 2;
        int move_speed = 2;

        int LScore = 0;
        int RScore = 0;

        Point moveTo = Point.Empty;
        Point ballMove = Point.Empty;

        public bool drawing = true;

        private static int RyPos = MaxHeight / 2;
        private static int LyPos = MaxHeight / 2;


        public void UpdateMoveMouse(object sender, MouseEventArgs e)
        {
            // moveTo = e.Location;
            Rside.Y = e.Location.Y;
            Lside.Y = e.Location.Y;


        }


        public void DoWork(Panel panel1, int MaxWidth_In ,int MaxHeight_In)
        {

            

           // g = g_In;
            MaxHeight = MaxHeight_In;
            MaxWidth = MaxWidth_In;

            btm = new Bitmap(MaxWidth, MaxHeight);
            g = Graphics.FromImage(btm);
            SCG = panel1.CreateGraphics();

            ball = new Rectangle(MaxWidth/2, MaxHeight/2, 40, 40);

             Rside = new Rectangle(MaxWidth - 50, RyPos, 30, 150);
             Lside = new Rectangle(5, LyPos, 30, 150);





            Thread th = new Thread(draw);
            th.IsBackground = true;

            th.Start();

         

            
        }

        public void draw()
        {

            Form1 f1 = new Form1();
            try
            {

                while(drawing)
                {

                    g.Clear(Color.White);
                    

                    //if (moveTo.Y > Rside.Y + 100) { Rside.Y += move_speed; }
                    //if (moveTo.Y < Rside.Y + 100) { Rside.Y -= move_speed; }

                    //if (ball.Y > Lside.Y + 100) { Lside.Y += move_speed; }
                    //if (ball.Y < Lside.Y + 100) { Lside.Y -= move_speed; }

                    ball.X += ball_speed;



                   if (ballMove.Y > ball.Y) { ball.Y += ball_speedY; }
                    if (ballMove.Y < ball.Y) { ball.Y -= ball_speedY; }

                    if (Rside.IntersectsWith(ball))
                    {
                        ball_speed *= -1;
                    }

                    if (Lside.IntersectsWith(ball))
                    {
                        ball_speed *= -1;
                    }

                    if (ball.Y < 20) { ballMove.Y = Pong.MaxHeight ; }
                    if (ball.Y > Pong.MaxHeight - 80) { ballMove.Y = 0; }

                    if (ball.X < -40) { ball.X = Pong.MaxWidth / 2; RScore++;  f1.updateScore(2, RScore);  }
                    if (ball.X > Pong.MaxWidth) { ball.X = Pong.MaxWidth/2;LScore++; f1.updateScore(1, LScore ); }

                    
                    g.FillRectangle(Brushes.Black, Rside);
                    g.FillRectangle(Brushes.Black, Lside);
                    g.FillEllipse(Brushes.Black, ball);
                  //  score1.Refresh();


                    SCG.DrawImage(btm, 0, 0, MaxWidth, MaxHeight);

                }


            }
            catch
            {
                Console.WriteLine("error");
            }

        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
           // ballMove = e.Location.Y;

                  Rside.Y = e.Location.Y;
        }

   

     

        public void ProcessCmdKey(object sender, KeyEventArgs keyData)
        {
            //capture up arrow key
            if (keyData.KeyCode == Keys.Up)
            {

                Rside.Y += 10;
            }
            if (keyData.KeyCode == Keys.Down)
            {

                Rside.Y -= 10;
            }

        }
   

    }
}

