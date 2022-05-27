namespace sortingVisualizer
{
    public partial class Form1 : Form
    {
        int[] TheArray;
        Graphics g;

        string selection;

       
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            int numEntries = panel1.Width;
            int MaxVal = panel1.Height;

            
      
           

            TheArray = new int[numEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black),0,0,numEntries,MaxVal);
            Random rand = new Random();
            for(int i=0;i<numEntries;i++)
            {
                TheArray[i] = rand.Next(0,MaxVal);
            }
            for(int i = 0;i<numEntries;i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - TheArray[i], 1, MaxVal);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

         //   g.Clear(Color.White);
            if (selection == "Bubble Sort")
            {
                button1_Click(sender, e);
                ISortEngine se = new SortEngineBubble();
                se.DoWork(TheArray, g, panel1.Height);
            }

            if (selection == "Merge Sort")
            {
                button1_Click(sender, e);
                ISortEngine se = new SortEngineMerge();
                se.DoWork(TheArray, g, panel1.Height);
            }

            if (selection == "Pong")
            {
                IPongEngine pe = new Pong();
                g = panel1.CreateGraphics();
                pe.DoWork( panel1,panel1.Width, panel1.Height);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != null)
            {
                selection = comboBox1.SelectedItem.ToString();
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Pong pe = new Pong();
            pe.UpdateMoveMouse(sender, e);
           

        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            Pong pe = new Pong();
            pe.ProcessCmdKey(sender, e)
;
        }

        public void updateScore(int side,int score)
        {
            if (side == 1)
            {
                label2.Text = score.ToString();
                label2.Update();
                label2.Refresh();
               Application.DoEvents();



            }
            if (side == 2)
            {
                label3.Text = score.ToString();
                label3.Update();
                label3.Refresh();
          


            }
        }


    

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.label2.Refresh();
            this.label3.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.label2.Text = "2";
            this.label3.Refresh();
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
          
           // this.label3.Text = sender.ToString();
            this.label2.Text = sender.ToString();

        }
    }
}