using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChisloIzm
{
    public partial class ArifmeticForm : Form
    {
        Graphics gr;
        int ix, iy;
        // Преобразовання символів 16 -> 10
        public int hex_dex(string s)
        {
            switch (s)
            {
                case "A":
                    return 10;
                case "B":
                    return 11;
                case "C":
                    return 12;
                case "D":
                    return 13;
                case "E":
                    return 14;
                case "F":
                    return 15;
                default:
                    return Convert.ToInt32(s);
            }
        }
        // Преобразовання символів 10 -> 16
        public string dex_hex(int i)
        {
            switch (i)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return i.ToString();
            }
        }
        public string two_to_m(string x, int m, bool prPaint)
        {
            string rez = "";
            var m_kol = 0;
            if (m == 8)
            {
                m_kol = 3;
            }
            if (m == 16)
            {
                m_kol = 4;
            }
            if (m_kol == 0)
            {
                return "";
            }
            char[] sN = x.ToCharArray();
            string x_0 = "";
            if (sN.Length % m_kol != 0)
            {
                x_0 = x_0.PadLeft(m_kol - (sN.Length % m_kol), '0');
            }
            x_0 = x_0 + x;
            var x_new = "";
            char[] sN_0 = x_0.ToCharArray();
            for (int i = 0; i < sN_0.Length; i++)
            {
                x_new = x_new + x_0[i];
                if ((i + 1) % m_kol == 0 && i != sN_0.Length - 1)
                {
                    x_new = x_new + ";";
                }
            }
            string[] x_triad = x_new.Split(';');
            for (int i = 0; i < x_triad.Length; i++)
            {
                var smb = dex_hex(Convert.ToInt32(n_to_m(x_triad[i], 2, m)));
                rez = rez + smb;
                // графіка
                if (prPaint == true)
                {
                    gr.DrawString(x_triad[i], new Font(new FontFamily("Calibri"), 14, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix + i * 50, iy);
                    gr.DrawArc(new Pen(Color.Red, 3), ix + i * 50, iy + 15, m_kol * 10, 10, 0, 180);
                    gr.DrawString(smb, new Font(new FontFamily("Calibri"), 14, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), ix + i * 50 + m_kol * 4, iy + 25);
                }
            }
            return rez;
        }
        public string n_to_m(string x, int n, int m)
        {
            var rez1 = n_to_ten(x, n);
            var rez2 = ten_to_n(rez1, m);
            return rez2;
        }

        public string n_to_two(string x, int n, bool prPaint)
        {
            string rez = "";
            var n_kol = 0;
            if (n == 8)
            {
                n_kol = 3;
            }
            if (n == 16)
            {
                n_kol = 4;
            }
            if (n_kol == 0)
            {
                return "";
            }
            char[] sN = x.ToCharArray();
            string x_0 = "";
            for (int i = 0; i < sN.Length; i++)
            {
                var s_dbl_tmp = n_to_m(sN[i].ToString(), n, 2);
                var s_dbl = s_dbl_tmp.PadLeft(n_kol, '0');
                // графіка
                if (prPaint == true)
                {
                    gr.DrawString(sN[i].ToString(), new Font(new FontFamily("Calibri"), 14, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix + i * 50 + n_kol * 4, iy);
                    gr.DrawArc(new Pen(Color.Red, 3), ix + i * 50, iy + 25, n_kol * 10, 10, 0, -180);
                    gr.DrawString(s_dbl, new Font(new FontFamily("Calibri"), 14, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), ix + i * 50, iy + 35);
                }
                if (i == 0)
                {
                    x_0 = x_0 + s_dbl_tmp;
                }
                else
                {
                    x_0 = x_0 + s_dbl;
                }
            }
            rez = x_0;
            return rez;
        }
        public string ten_to_n(int x, int n )
        {
            //char znak = ' ';
            //if (x < 0)
            //{
            //    x = x * (-1);
            //    znak = '-';
            //}               
            int div = x;
            int divn = div;
            int mod = 0;
            string rez = "";
            string reztmp = "";
            if (div < n)
            {
                rez = rez + div.ToString();
                
            }
            else
            {
                var i = 0;
                var ix1 = ix;
                var iy1 = iy;
                var ix2 = ix;
                var iy2 = iy;
                var ix3 = ix;
                var iy3 = iy;
                var ix4 = ix;
                var iy4 = iy;
                var ix5 = ix;
                var iy5 = iy;
                var ixn = ix;

                while (div >= n)
                {
                    i++;
                    mod = div % n;
                    divn = (int)(div / n);
                    reztmp = reztmp + dex_hex(mod);
                    if (divn < n)
                    {
                        reztmp = reztmp + dex_hex(divn);
                    }
                    //графіка
                    

                    div = divn;
                }
                char[] sReverse = reztmp.ToCharArray();
                Array.Reverse(sReverse);
                rez = new string(sReverse);
                //rez = znak + rez;
            }
            return rez;

        }
        public int n_to_ten(string x, int n)
        {
            var rez = 0;
            int ln = n.ToString().Length;
            char[] sN = x.ToCharArray();
            var p = sN.Length - 1;
            for (int i = 0; i < sN.Length; i++)
            {
                rez = rez + hex_dex(sN[i].ToString()) * (int)Math.Pow(n, p);
                p--;
            }
            return rez;
        }

        public ArifmeticForm()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int rand1max, rand2max;
        int numb1, numb2;
        int osnova = 1;
        int vidp;

        

        private void btnGenValue1_Click(object sender, EventArgs e)
        {
            rand1max = int.Parse(txtRandom1.Text);
            rand2max = int.Parse(txtRandom2.Text);
            numb1 = rnd.Next(0, rand1max + 1);  //генерація рандомного числа          
            numb2 = rnd.Next(0, rand2max + 1);  //генерація рандомного числа 
            osnova = 0;
            if (rbSys2.Checked == true)
                osnova = 2;
            if (rbSys8.Checked == true)
                osnova = 8;
            if (rbSys16.Checked == true)
                osnova = 16;           
            string numb1osn = ten_to_n(numb1, osnova);
            txtValue1.Text = numb1osn.ToString();
            string numb2osn = ten_to_n(numb2, osnova);
            txtValue2.Text = numb2osn.ToString();

        }
        private void checkDEX(int n, string ch_n1, string ch_n2, string oper)
        {
            iy = 0;
            ix = 0;
            if (oper == "+ Додавання")
            gr.DrawString(String.Format(@"Завдання: додати число '{0}' та число '{1}'", ch_n1, ch_n2), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            if (oper == "- Віднімання")
                gr.DrawString(String.Format(@"Завдання: відняти число '{0}' та число '{1}'", ch_n1, ch_n2), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            //if (oper == "* Множення")
            //    gr.DrawString(String.Format(@"Завдання: помножити число '{0}' на число '{1}'", ch_n1, ch_n2), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);            
            iy = iy + 30;
            var ch_user = txtOtvet.Text;
            gr.DrawString(String.Format(@"Ви відповіли: '{0}'", ch_user), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Blue), ix, iy);
            iy = iy + 30;
            int ch_OK = 0;
            //var ch_OK = n_to_m(ch_n1, n, m);
            if (oper == "+ Додавання")
            {
                //MessageBox.Show(n_to_ten(ch_n1, n).ToString());
                ch_OK = n_to_ten(ch_n1, n) + n_to_ten(ch_n2, n);
            }
            //MessageBox.Show(ch_OK.ToString());
            if (oper == "- Віднімання")
            {
                //MessageBox.Show(n_to_ten(ch_n1, n).ToString());
                //MessageBox.Show(n_to_ten(ch_n2, n).ToString());
                ch_OK = n_to_ten(ch_n1, n) - n_to_ten(ch_n2, n);
            }
            //MessageBox.Show(ch_OK.ToString());
            //if (oper == "* Множення")
            //{
            //    ch_OK = n_to_ten(ch_n1, n) * n_to_ten(ch_n2, n);
            //}
            //MessageBox.Show(ch_OK.ToString());  
            Color color_ok;
            if (ch_OK.ToString() == ch_user)
            {
                color_ok = Color.Green;
            }
            else
            {
                color_ok = Color.Red;
            }
            var znak = ' ';
            if (ch_OK < 0)
            {
                znak = '-';
            }
            gr.DrawString(String.Format(@"Правильна відповідь: '{0}'", znak + ten_to_n(Math.Abs(ch_OK), n)), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(color_ok), ix, iy);
            iy = iy + 50;
            //gr.DrawString(String.Format(@"Послідовність рішення:"), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            //iy = iy + 25;
            //gr.DrawString(String.Format(@"1.Переведемо число '{0}' з с-ми '{1}' в с-му '10'", ch_n, n.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            //iy = iy + 25;
            //var ch_ten = n_to_ten(ch_n, n, true);
            //ix = 0;
            //iy = iy + 30;
            //gr.DrawString(String.Format(@"2.Переведемо число '{0}' з с-ми '10' в с-му '{1}'", ch_ten.ToString(), m.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            //iy = iy + 25;
            //ten_to_n(ch_ten, m, true);
            //// Стрілка
            //iy = iy + 50;
            //Pen pen = new Pen(Color.Red, 6);
            //pen.StartCap = LineCap.ArrowAnchor;
            //pen.EndCap = LineCap.RoundAnchor;
            //gr.DrawLine(pen, 0, iy, ix + 5, iy);
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            int n = 2;
            Bitmap myBitmap = new Bitmap(2000, 2000);
            gr = Graphics.FromImage(myBitmap);
            gr.Clear(Color.Wheat);
            for (int i = 0; i < 200; i++)
            {
                gr.DrawLine(Pens.LightGray, i * 15, 0, i * 15, 2000);
                gr.DrawLine(Pens.LightGray, 0, i * 15, 2000, i * 15);
            }
            if (cmbOper.Text == "+ Додавання")
            {
                vidp = numb1 + numb2;
            }
            if (cmbOper.Text == "- Віднімання")
            {
                vidp = numb1 - numb2;
            }
            //if (cmbOper.Text == "* Множення")
            //{
            //    vidp = numb1 * numb2;
            //}
            string vidpOsn = ten_to_n(vidp, osnova);
            if(rbSys2.Checked == true)
                n = 2;
            if (rbSys8.Checked == true)
                n = 8;
            if (rbSys16.Checked == true)
                n = 16;
            checkDEX(n, txtValue1.Text, txtValue2.Text, cmbOper.Text);
            pb.Image = myBitmap;


        }

        private void btnGenValue2_Click(object sender, EventArgs e)
        {
            
        }
        private void ArifmeticForm_Load(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(2000, 2000);
            gr = Graphics.FromImage(myBitmap);
            gr.Clear(Color.Wheat);
            for (int i = 0; i < 200; i++)
            {
                gr.DrawLine(Pens.LightGray, i * 15, 0, i * 15, 2000);
                gr.DrawLine(Pens.LightGray, 0, i * 15, 2000, i * 15);
            }
            pb.Image = myBitmap;
        }
        
    }
}
