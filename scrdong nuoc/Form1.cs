using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace DongNuoc
{
    public partial class Form1 : Form
    {
        SoundPlayer sp = new SoundPlayer("tieng nuoc chay.wav");  
        PictureBox Vx = new PictureBox();
        PictureBox Vy = new PictureBox();
        PictureBox Vx_ = new PictureBox();
        PictureBox Vy_ = new PictureBox();
        int HeightY;
        int HeightX;
        int LocationVx_Y;
        int LocationVy_Y;
        int vx=0, vy=0;//the tich binh x va y;
        int x, y;//the tich hien co trong binh x va y;
        int z;//luong nuoc can dong
        int i=1;
        int tam1, tam2;
        int dem = 2;
        public Form1()
        {
            InitializeComponent();
        }
        int ucln(int n, int m)
        {

            while (n != 0 && m != 0)
                if (n > m)
                    n -= m;
                else
                    m -= n;
            if (n == 0)
                return m;
            else
                return n;
        }

        private void PlayMedia()
        {
            sp.PlayLooping();
        }
        private void StopMedia()
        {
            sp.Stop();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Visable_true()
        {
            button1.Visible = true;
            button2.Visible = true;
            button7.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            
        }
        private void Visable_false()
        {
            button1.Visible = false;
            button2.Visible = false;
            button7.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            
        }
        private void Disableds()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button7.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button8.Enabled = false;

        }
        private void Enableds()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button7.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button8.Enabled = true; ;

        }

        private void timer_dovaoVx_Tick(object sender, EventArgs e)
        {
            Disableds();
            pictureBox2.Location = new Point(pictureBox2.Location.X,pictureBox2.Location.Y - 1);   
            if(pictureBox2.Location.Y==Vx.Location.Y)
            {
                timer_dovaoVx.Stop();
                StopMedia();
                if (x == z)
                {
                    timer_autorunb.Stop();
                    MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                    Disableds();
                }
                else if (dem == 1)
                {
                    timer_autorunb.Start();
                }
                if (dem != 1)
                {
                    Enableds();
                }
            }
        }
        private void timer_doVxra_Tick(object sender, EventArgs e)
        {
            Disableds();
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 1);
            if (pictureBox2.Location.Y == 500)
            {
                timer_doVxra.Stop();
                StopMedia();
                if (dem == 1)
                {
                    timer_autorun.Start();
                }
                if (dem != 1)
                {
                    Enableds();
                }
            }
        }
        private void timer_dovaoVy_Tick(object sender, EventArgs e)
        {
            Disableds();
            pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 1);
            if(pictureBox3.Location.Y==Vy.Location.Y)
            {
                timer_dovaoVy.Stop();
                StopMedia();
                if (y == z)
                {
                    timer_autorun.Stop();
                    MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                    Disableds();
                }
                else if (dem == 1)
                {
                    timer_autorun.Start();
                }
                if (dem != 1)
                {
                    Enableds();
                }
            }
        }
        private void timer_doVyra_Tick(object sender, EventArgs e)
        {
            Disableds();
            pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + 1);
            if(pictureBox3.Location.Y==500)
            {
                timer_doVyra.Stop();
                StopMedia();
                if (dem == 1)
                {
                    timer_autorunb.Start();
                }
                if (dem != 1)
                {
                    Enableds();
                }
            }
        }

        private void timer_VxsangVy_Tick(object sender, EventArgs e)
        {
            Disableds();
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 1);
            pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 1);
            if ((pictureBox2.Location.Y == 500) || (pictureBox3.Location.Y == Vy.Location.Y))
            {
                timer_VxsangVy.Stop();
                StopMedia();
                if (dem == 1)
                {
                    timer_autorunb.Start();
                }
                if (pictureBox2.Location.Y == 500)
                {
                    tam2 = x;
                    y = y + x;
                    x = 0;
                    richTextBox2.AppendText(Environment.NewLine);
                    richTextBox2.AppendText(" - Bước " + i + " :  Đã chuyển " + tam2 + " lít nước từ bình " + vx + " lít sang bình " + vy + " lít");
                    richTextBox2.AppendText(Environment.NewLine);
                    richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                    richTextBox2.AppendText(Environment.NewLine);
                    richTextBox2.AppendText("                       " + x + " lít                 |                    " + y + " lít.");
                    richTextBox2.AppendText(Environment.NewLine);
                    i++;
                    if (y == z)
                    {
                        timer_autorunb.Stop();
                        MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                        Disableds();
                    }
                }
                else
                    if (pictureBox3.Location.Y == Vy.Location.Y)
                    {
                        tam2 = vy - y;
                        y = vy;
                        x = x - tam2;
                        richTextBox2.AppendText(Environment.NewLine);
                        richTextBox2.AppendText(" - Bước " + i + " :  Đã chuyển " + tam2 + " lít nước từ bình " + vx + " lít sang bình " + vy + " lít");
                        richTextBox2.AppendText(Environment.NewLine);
                        richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                        richTextBox2.AppendText(Environment.NewLine);
                        richTextBox2.AppendText("                       " + x + " lít                 |                    " + y + " lít.");
                        richTextBox2.AppendText(Environment.NewLine);
                        i++;
                        if (x == z)
                        {
                            timer_autorunb.Stop();
                            MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                            Disableds();
                        }
                    }
                if (dem != 1)
                {
                    Enableds();
                }
            }
        }

        private void timer_VysangVx_Tick(object sender, EventArgs e)
        {
            Disableds();
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 1);
            pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + 1);
            if ((pictureBox3.Location.Y == 500) || (pictureBox2.Location.Y == Vx.Location.Y))
            {
                timer_VysangVx.Stop();
                StopMedia();
                if (dem == 1)
                {
                    timer_autorun.Start();
                }
                if(pictureBox3.Location.Y==500)
                {
                    tam1 = y;
                    x = x + y;
                    y = 0;
                    richTextBox2.AppendText(Environment.NewLine);
                    richTextBox2.AppendText(" - Bước " + i + " :  Đã chuyển " + tam1 + " lít nước từ bình" + vy + "lít sang bình " + vx + " lít");
                    richTextBox2.AppendText(Environment.NewLine);
                    richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                    richTextBox2.AppendText(Environment.NewLine);
                    richTextBox2.AppendText("                       " + x + " lít                 |                    " + y + " lít.");
                    richTextBox2.AppendText(Environment.NewLine);
                    i++;
                    if (x == z)
                    {
                        timer_autorun.Stop();
                        MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                        Disableds();
                    }
                }
                else
                    if (pictureBox2.Location.Y == Vx.Location.Y)
                    {
                        tam1 = vx - x;
                        x = vx;
                        y = y - tam1;
                        richTextBox2.AppendText(Environment.NewLine);
                        richTextBox2.AppendText(" - Bước " + i + " :  Đã chuyển " + tam1 + " lít nước từ bình " + vy + " lít sang bình " + vx + " lít.");
                        richTextBox2.AppendText(Environment.NewLine);
                        richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                        richTextBox2.AppendText(Environment.NewLine);
                        richTextBox2.AppendText("                       " + x + " lít                 |                    " + y + " lít.");
                        richTextBox2.AppendText(Environment.NewLine);
                        i++;
                        if (y == z)
                        {
                            timer_autorun.Stop();
                            MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                            Disableds();
                        }
                    }
                if (dem != 1)
                {
                    Enableds();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == null)
            {
                MessageBox.Show("rong");
            }
            else { 
            if (textBoxX1.Text == "0")
            {
                
            }
            richTextBox2.Text = "0";
            //groupBox2.Visible = false;
            Visable_true();
            Enableds();
            button10.Visible = true;
            i = 1;
            dem = 2;
            vx = Convert.ToInt32(textBoxX1.Text);
            vy = Convert.ToInt32(textBoxX2.Text);
            z = Convert.ToInt32(textBoxX3.Text);
            x = y = 0;
            int tg = ucln(vx, vy);

            if ((z % tg != 0) || (z == 0) )
            {
                    Visable_false();
                    DialogResult kq = MessageBox.Show("Không thể đong được do không thoả mãn điều kiện của bài toán. Vui lòng xem điều kiện.", "Thông báo", MessageBoxButtons.YesNo);
                    if (kq == DialogResult.Yes)
                    {
                       // groupBox2.Visible = true;
                    }

            }
          
            else if (z % tg == 0)
            {
                if ((vx > vy) && (z < vx))
                {
                    LocationVx_Y = 200;
                    HeightY = (Convert.ToInt32(textBoxX2.Text) * 300) / (vx);
                    LocationVy_Y = 500 - HeightY;
                    Vx.Size = new Size(150, 300);
                    Vx.BackColor = Color.Aquamarine;
                    Vx.Location = new Point(500, LocationVx_Y);
                    Controls.Add(Vx);
                    label1.Text = "Bình A: " + textBoxX1.Text + " lít ";
                    label1.Visible = true;

                    Vy.Size = new Size(150, HeightY);
                    Vy.BackColor = Color.Aquamarine;
                    Vy.Location = new Point(800, LocationVy_Y);
                    Controls.Add(Vy);
                    label2.Text = "Bình B: " + textBoxX2.Text + " lít ";
                    label2.Visible = true;
                    pictureBox2.Location = new Point(500, 500);
                    pictureBox2.Size = new Size(150, 300);

                    pictureBox3.Location = new Point(800, 500);
                    pictureBox3.Size = new Size(150, HeightY);
                }
                else if ((vy > vx) && (z < vy))
                {
                    LocationVy_Y = 200;
                    HeightX = (Convert.ToInt32(textBoxX1.Text) * 300) / (vy);
                    LocationVx_Y = 500 - HeightX;
                    Vy.Size = new Size(150, 300);
                    Vy.BackColor = Color.Aquamarine;
                    Vy.Location = new Point(800, LocationVy_Y);
                    Controls.Add(Vy);
                    label2.Text = "Bình B: " + textBoxX2.Text + " lít ";
                    label2.Visible = true;
                    pictureBox3.Location = new Point(800, 500);
                    pictureBox3.Size = new Size(150, 300);
                    label1.Text = "Bình A: " + textBoxX1.Text + " lít ";
                    label1.Visible = true;
                    pictureBox2.Location = new Point(500, 500);
                    pictureBox2.Size = new Size(150, HeightX);


                    Vx.Size = new Size(150, HeightX);
                    Vx.BackColor = Color.Aquamarine;
                    Vx.Location = new Point(500, LocationVx_Y);
                    Controls.Add(Vx);

                }
                else
                {
                    Visable_false();
                    DialogResult kq = MessageBox.Show("Không thể đong được do không thoả mãn điều kiện của bài toán. Vui lòng xem điều kiện.", "Thông báo", MessageBoxButtons.YesNo);
                    if (kq == DialogResult.Yes)
                    {
                        //groupBox2.Visible = true;
                    }

                }

            }
        }
            
  }


        private void button4_Click(object sender, EventArgs e)
        {
            
            if (pictureBox2.Location.Y == Vx.Location.Y)
            {
                MessageBox.Show("Bình " + vx + " lít đã đầy,không thể đổ thêm vào được nữa.");
            }
            else
            {
                PlayMedia();
                tam1 = vx - x;
                x = x + tam1;
                timer_dovaoVx.Start();
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" - Bước " + i + " : Đổ " + tam1 + " lít nước vào bình " + vx + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                i++;
                if (x == z)
                {
                    MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                    Disableds();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (pictureBox2.Location.Y == 500)
            {
                MessageBox.Show("Bình " + vx + " lít đã hết nước. ");
            }
            else
            {
                PlayMedia();
                x = 0;
                timer_doVxra.Start();
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" - Bước " + i + " : đổ hết nước binh " + vx + " lít ra ngoài.");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                i++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (pictureBox3.Location.Y == Vy.Location.Y)
            {
                MessageBox.Show("Bình " + vy + " lít đã đầy,không thể đổ thêm vào được nữa.");
            }
            else
            {
                PlayMedia();
                tam2 = vy - y;
                y = y + tam2;
                timer_dovaoVy.Start();
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" - Bước " + i + " Đổ" + tam2 + " lít nước vào bình " + vy + " lít");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                i++;
                if (y == z)
                {
                    MessageBox.Show("Đã đong được " + z.ToString() + " lít nước.", "Thông báo");
                    Disableds();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (pictureBox3.Location.Y == 500)
            {
                MessageBox.Show("Bình " + vy + " lít đã hết nước.");
            }
            else
            {
                PlayMedia();
                y = 0;
                timer_doVyra.Start();
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" - Bước " + i + " : Đổ hết nước bình " + vy + " lít ra ngoai");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
                richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
                richTextBox2.AppendText(Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (pictureBox2.Location.Y == 500)
            {
                MessageBox.Show("Bình " + vx + " lít đã hết nước,không thể chuyển qua bình " + vy + " lit.");
            }
            else
                if (pictureBox3.Location.Y == Vy.Location.Y)
                {
                    MessageBox.Show("Không thể chuyển nước qua do bình " + vy + " lít đã đầy.");
                }
                else
                {
                    PlayMedia();
                    timer_VxsangVy.Start();
                    
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (pictureBox3.Location.Y == 500)
            {
                MessageBox.Show("Bình " + vy + " lít đã hết nước,không thể chuyển qua bình X.");
            }
            else
                if (pictureBox2.Location.Y == Vx.Location.Y)
                {
                    MessageBox.Show("Không thể chuyển nước qua do bình " + vx + " đã đầy.");
                }
                else
                {
                    PlayMedia();
                    timer_VysangVx.Start();
                }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           // groupBox2.Visible = false;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            button10.Visible = true;
            button8.Visible = true;
          
        }
        //Luat
        #region Cac Luat
        private void luat1a()//Do  Vx ra
        {
            x = 0;
            timer_autorun.Stop();
            timer_doVxra.Start();
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" - Bước " + i + " : Đổ hết nước bình " + vx + " ra ngoài.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            i++;
        }
        private void luat1b()//Do Vy ra
        {
            y = 0;
            timer_autorunb.Stop();
            timer_doVyra.Start();
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" - Bước " + i + " : Đổ hết nước bình " + vy + " ra ngoài.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            i++;

        }
        private void luat2a()//Vx->Vy
        {
            tam2 = vy - y;
            y = vy;
            timer_autorun.Stop();
            timer_dovaoVy.Start();
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" - Bước " + i + " : Đổ " + tam2 + " lít nước vào bình " + vy + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText("                       " + x +  " lít                  |                    " + y + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            i++;
        }
        private void luat2b()//Vy->Vx
        {
            tam1 = vx - x;
            x = vx;
            timer_autorunb.Stop();
            timer_dovaoVx.Start();
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" - Bước " + i + " : Đổ " + tam1 + " lít nước vào bình " + vx + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText(" Lượng nước trong bình " + vx + " lít   | Lượng nước trong bình " + vy + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            richTextBox2.AppendText("                       " + x + " lít                  |                    " + y + " lít.");
            richTextBox2.AppendText(Environment.NewLine);
            i++;

        }
        #endregion
        private void button8_Click_1(object sender, EventArgs e)
        {
            button10.Enabled = true;
            if (vx > vy)
            {
                dem = 1;
                timer_autorun.Start();
                Disableds();
            }
            else if (vx < vy)
            {
                dem = 1;
                timer_autorunb.Start();
                Disableds();
            }
        }

        private void timer_autorun_Tick(object sender, EventArgs e)
        {
            PlayMedia();
                if (x == vx)
                {
                    luat1a();
                }

                else if (y == 0)
                {
                    luat2a();
                }

                else if ((x != vx) && (y != 0))
                {
                    timer_autorun.Stop();
                    timer_VysangVx.Start();
                }
            
        }

        private void timer_autorunb_Tick(object sender, EventArgs e)
        {
            PlayMedia();
            if (y == vy)
            {
                luat1b();
            }
            else if (x == 0)
            {
                luat2b();
            }
            else if((y!=vy)&&(x!=0))
            {
                timer_autorunb.Stop();
                timer_VxsangVy.Start();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer_autorun.Stop();
            timer_autorunb.Stop();
            button10.Enabled = false;
            dem = 2;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
