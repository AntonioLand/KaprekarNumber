using System.ComponentModel;
using System.Globalization;

namespace KaprekarNumber
{
    public partial class Form1 : Form
    {
        private int[] Z;// = new int[4];
        int minKey = (int)Keys.NumPad0;
        int maxKey = (int)Keys.NumPad9;
        int BigNummer;
        int SmallNummer;
        int[] newZ;
        public Form1()
        {
            InitializeComponent();
            Z = new int[4];
            LoadArray();
        }
        void LoadArray()
        {
            for (int i = 0; i < 4; i++)
            {
                Z[i] = -1;
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (char.IsDigit((char)e.KeyValue))
            {
                Z[0] = (int)Char.GetNumericValue((char)e.KeyValue);
                textBox2.Focus();
            }
            else if ((int)e.KeyValue >= minKey && (int)e.KeyValue <= maxKey)
            {
                Z[0] = (int)e.KeyCode - minKey;
                textBox2.Focus();
            }
            else
            {
                textBox1.Clear();
            }
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char)e.KeyValue))
            {
                Z[1] = (int)Char.GetNumericValue((char)e.KeyValue);
                textBox3.Select();
            }
            else if ((int)e.KeyValue >= minKey && (int)e.KeyValue <= maxKey)
            {
                Z[1] = (int)e.KeyCode - minKey;
                textBox3.Focus();

            }
            else
            {
                textBox2.Clear();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char)e.KeyValue))
            {
                Z[2] = (int)Char.GetNumericValue((char)e.KeyValue);
                textBox4.Select();
            }
            else if ((int)e.KeyValue >= minKey && (int)e.KeyValue <= maxKey)
            {
                Z[2] = (int)e.KeyCode - minKey;
                textBox4.Focus();

            }
            else
            {
                textBox3.Clear();
            }
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char)e.KeyValue))
            {
                Z[3] = (int)Char.GetNumericValue((char)e.KeyValue);
            }
            else if ((int)e.KeyValue >= minKey && (int)e.KeyValue <= maxKey)
            {
                Z[3] = (int)e.KeyCode - minKey;
                button1.Focus();
            }
            else
            {
                textBox4.Clear();
            }

        }
        bool Kontrol()
        {
            for (int i = 0; i < 4; i++)
                if (Z[i] == -1)
                    return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Kontrol())
                MessageBox.Show("Number not Valid");
            Array.Sort(Z);
            int NewNummer = 0;
            int iter = 0;
            int iterY = 0;
            while (NewNummer != 6174 && iter < 10)
            {
                SmallNummer = ConvertToIntArray(Z);
                BigNummer = ConvertToIntArray(Z, true);
                NewNummer = BigNummer - SmallNummer;
                newZ = ConvertIntToArray(NewNummer);
                
                if(iter <= 5)
                    TowriteInform(150 * iter, 0);
                else
                {
                    TowriteInform(150 * iterY++, 140);

                } 

                iter++;
                newZ.CopyTo(Z, 0);
                Array.Sort(Z);
                Thread.Sleep(1500);
            }
            button2.Focus();
        }

        int[] ConvertIntToArray(int NewNummer)
        {
            string s = NewNummer.ToString();
            if (s.Length == 1)
                s = s.Insert(0, "000");
            else if (s.Length == 2)
                s = s.Insert(0, "00");
            else if (s.Length == 3)
                s = s.Insert(0, "0");
            newZ = new int[4];
            for (int i = 0; i < 4; i++)
                newZ[i] = (int)Char.GetNumericValue((char)s[i]);
            return newZ;

        }
        int ConvertToIntArray(int[] Zarray, bool maxmin = false)
        {
            int value = 0;
            int[] cpZ = new int[4];
            Zarray.CopyTo(cpZ, 0);
            if (maxmin)
            {
                Array.Reverse(cpZ);
            }
            for (int i = 0; i <= 3; i++)
            {
                value += cpZ[i] * Convert.ToInt32(Math.Pow(10, 3 - i));
            }
            return value;
        }
        void TowriteInform(int x, int y)
        {
            Graphics gs = this.CreateGraphics();
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new Point(12 + x, 65 + y);

            for (int j = 3; j >= 0; j--)
            {
                gs.DrawString(Z[j].ToString(), drawFont, drawBrush, drawPoint);
                drawPoint.X = drawPoint.X + 25;

            }
            gs.DrawString("-", drawFont, drawBrush, drawPoint);
            drawPoint.X = 12 + x;
            drawPoint.Y = 85 + y;
            for (int j = 0; j < 4; j++)
            {
                gs.DrawString(Z[j].ToString(), drawFont, drawBrush, drawPoint);
                drawPoint.X = drawPoint.X + 25;
            }
            drawPoint.X = 10 + x;
            drawPoint.Y = 90 + y;
            gs.DrawString("________", drawFont, drawBrush, drawPoint);
            drawPoint.X = 12 + x;
            drawPoint.Y = 115 + y;
            for (int j = 0; j < 4; j++)
            {
                gs.DrawString(newZ[j].ToString(), drawFont, drawBrush, drawPoint);
                drawPoint.X = drawPoint.X + 25;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            this.Refresh();
            textBox1.Focus();
        }
    }
}
