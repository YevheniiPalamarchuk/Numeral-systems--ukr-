using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ChisloIzm
{
    public partial class testForm : Form
    {
        Graphics gr;
        int ix, iy;

        public testForm()
        {
            InitializeComponent();
        }

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

        // Перевод числа "x" з с-ми "n" в "m"
        public string n_to_m(string x, int n, int m)
        {
            var rez1 = n_to_ten(x, n, false);
            var rez2 = ten_to_n(rez1, m, false);
            return rez2;
        }

        // Перевод числа "x" з с-ми "n" в "10"
        public int n_to_ten(string x, int n, bool prPaint)
        {
            var rez = 0;
            int ln = n.ToString().Length;
            char[] sN = x.ToCharArray();
            var p = sN.Length - 1;
            for (int i = 0; i < sN.Length; i++)
            {
                rez = rez + hex_dex(sN[i].ToString()) * (int)Math.Pow(n, p);
                // графіка
                if (prPaint == true)
                {
                    gr.DrawString(sN[i].ToString() + "*" + n.ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
                    gr.DrawString(p.ToString(), new Font(new FontFamily("Calibri"), 8, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix + 15 + ln * 5, iy - 2);
                    if (p > 0)
                    {
                        gr.DrawString("+", new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix + 25 + ln * 5, iy);
                    }
                    else
                    {
                        gr.DrawString("=", new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix + 20 + ln * 5, iy);
                        gr.DrawString(rez.ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), ix + 30 + ln * 5, iy);
                    }
                    ix = ix + 30 + ln * 5;
                }
                //
                p--;
            }
            return rez;
        }

        // Перевод числа "x" з с-ми "10" в "n"
        public string ten_to_n(int x, int n, bool prPaint)
        {
            int div = x;
            int divn = div;
            int mod = 0;
            string rez = "";
            string reztmp = "";
            if (div < n)
            {
                rez = rez + div.ToString();
                if (prPaint == true)
                {
                    gr.DrawString(div.ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
                }
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
                    // графіка
                    if (prPaint == true)
                    {
                        ix1 = ix;
                        iy1 = iy;
                        if (i == 1)
                        {
                            gr.DrawString(" " + div.ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix1, iy1);
                        }
                        ix2 = ix1 + div.ToString().Length * 10 + 5;
                        iy2 = iy1;
                        gr.DrawString(n.ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix2, iy2);
                        ix3 = ix2;
                        iy3 = iy2 + 15;
                        if (divn < n)
                        {
                            gr.DrawString(" " + dex_hex(divn), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), ix3, iy3);
                        }
                        else
                        {
                            gr.DrawString(" " + divn.ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix3, iy3);
                        }
                        ix4 = ix1;
                        iy4 = iy3;
                        gr.DrawString((-divn * n).ToString(), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix4, iy4);
                        ix5 = ix1;
                        iy5 = iy4 + 15;
                        gr.DrawString(dex_hex(mod), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), ix5, iy5);
                        ixn = ix3 + divn.ToString().Length * 10 + 5;
                        gr.DrawLine(new Pen(Color.Black, 2), ix3, iy3, ixn, iy3);
                        gr.DrawLine(new Pen(Color.Black, 2), ix1, iy5, ix2, iy5);
                        gr.DrawLine(new Pen(Color.Black, 2), ix2, iy1, ix2, iy5);

                        ix = ix3;
                        iy = iy3;
                    }
                    //
                    div = divn;
                }
                char[] sReverse = reztmp.ToCharArray();
                Array.Reverse(sReverse);
                rez = new string(sReverse);
            }
            return rez;
        }


        private void Form1_When(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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


        private void grBoxFrom_Enter_1(object sender, EventArgs e)
        {
            txtZapros.Text = "";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
             Bitmap myBitmap = new Bitmap(2000, 2000);
            gr = Graphics.FromImage(myBitmap);
            gr.Clear(Color.Wheat);
            for (int i = 0; i < 200; i++)
            {
                gr.DrawLine(Pens.LightGray, i * 15, 0, i * 15, 2000);
                gr.DrawLine(Pens.LightGray, 0, i * 15, 2000, i * 15);
            }

            ix = 0;
            iy = 0;
            var n = 0;
            var m = 0;
            nm(out n, out m);
            var ch_n = txtZapros.Text;
            if (chkTriad.Checked)
            {
                checkTRIAD(n, m, ch_n);
            }
            else
            {
                checkDEX(n, m, ch_n);
            }
            pb.Image = myBitmap;
            btnGenValue.PerformClick();
            ch_n = txtZapros.Text;
            iy = iy + 25;
            ix = 0;
            gr.DrawString(String.Format(@"Нове завдання: перевести число '{0}' з с-ми '{1}' в с-му '{2}'", ch_n, n.ToString(), m.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
        }

        private void btnGenValue_Click(object sender, EventArgs e)
        {
            var max_rnd = Convert.ToInt32(txtRandom.Text);
            Random rnd = new Random();
            var ch_ten = rnd.Next(0, max_rnd);
            var n = 0;
            var m = 0;
            nm(out n, out m);
            var ch_n = ten_to_n(ch_ten, n, false);
            txtZapros.Text = ch_n;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pb.Image != null)
            {
                //утворення діалогового вікна "Сохранити як..", для збереження зображення
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Зберегти картинку як...";
                //чи отображати зостереження, якщо користувач вказує им'я вже існуючого файлу
                savedialog.OverwritePrompt = true;
                //чи отображати зостереження, якщо користувач вказує неможливий путь
                savedialog.CheckPathExists = true;
                //список форматів файлу, відображаємі в полі "Тип файлу"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //чи отображається ли кнопка "Справка" в диалоговому вікні
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //якщо в диалоговому вікне нажата кнопка "ОК"
                {
                    try
                    {
                        pb.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Файл збережено!", "Збереження файлу");
                    }
                    catch
                    {
                        MessageBox.Show("Неможливо зберегти зображення", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void checkDEX(int n, int m, string ch_n)
        {
            gr.DrawString(String.Format(@"Завдання: перевести число '{0}' з с-ми '{1}' в с-му '{2}'", ch_n, n.ToString(), m.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            iy = iy + 30;
            var ch_user = txtOtvet.Text;
            gr.DrawString(String.Format(@"Ви відповіли: '{0}'", ch_user), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Blue), ix, iy);
            iy = iy + 30;
            var ch_OK = n_to_m(ch_n, n, m);
            Color color_ok;
            if (ch_OK == ch_user)
            {
                color_ok = Color.Green;
            }
            else
            {
                color_ok = Color.Red;
            }
            gr.DrawString(String.Format(@"Правильна відповідь: '{0}'", ch_OK), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(color_ok), ix, iy);
            iy = iy + 50;
            gr.DrawString(String.Format(@"Послідовність рішення:"), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            iy = iy + 25;
            gr.DrawString(String.Format(@"1.Переведемо число '{0}' з с-ми '{1}' в с-му '10'", ch_n, n.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            iy = iy + 25;
            var ch_ten = n_to_ten(ch_n, n, true);
            ix = 0;
            iy = iy + 30;
            gr.DrawString(String.Format(@"2.Переведемо число '{0}' з с-ми '10' в с-му '{1}'", ch_ten.ToString(), m.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            iy = iy + 25;
            ten_to_n(ch_ten, m, true);
            // Стрілка
            iy = iy + 50;
            Pen pen = new Pen(Color.Red, 6);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.RoundAnchor;
            gr.DrawLine(pen, 0, iy, ix + 5, iy);
            

        }

        private void checkTRIAD(int n, int m, string ch_n)
        {
            gr.DrawString(String.Format(@"Завдання: перевести число '{0}' з с-ми '{1}' в с-му '{2}'", ch_n, n.ToString(), m.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            iy = iy + 30;
            var ch_user = txtOtvet.Text;
            gr.DrawString(String.Format(@"Ви відповіли: '{0}'", ch_user), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Blue), ix, iy);
            iy = iy + 30;
            var ch_OK = "";
            if (n == 2)
            {
                ch_OK = two_to_m(ch_n, m, false);
            }
            else if (m == 2)
            {
                ch_OK = n_to_two(ch_n, n, false);
            }

            Color color_ok;
            if (ch_OK == ch_user)
            {
                color_ok = Color.Green;
            }
            else
            {
                color_ok = Color.Red;
            }
            gr.DrawString(String.Format(@"Правильна відповідь: '{0}'", ch_OK), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(color_ok), ix, iy);
            iy = iy + 50;
            gr.DrawString(String.Format(@"Послідовність рішення:"), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), ix, iy);
            iy = iy + 25;
            if (n == 2)
            {
                two_to_m(ch_n, m, true);
            }
            else if (m == 2)
            {
                n_to_two(ch_n, n, true);
            }
        }

        private void rbFrom2_CheckedChanged(object sender, EventArgs e)
        {
            chkTriadEnable();
        }

        private void rbTo8_CheckedChanged(object sender, EventArgs e)
        {
            chkTriadEnable();
        }

        private void rbTo16_CheckedChanged(object sender, EventArgs e)
        {
            chkTriadEnable();
        }

        private void rbFrom8_CheckedChanged(object sender, EventArgs e)
        {
            chkTriadEnable();
        }

        private void rbFrom16_CheckedChanged(object sender, EventArgs e)
        {
            chkTriadEnable();
        }

        private void rbTo2_CheckedChanged(object sender, EventArgs e)
        {
            chkTriadEnable();
        }

        protected void nm(out int n, out int m)
        {
            n = 0;
            m = 0;
            for (int i = 0; i < grBoxFrom.Controls.Count; i++)
            {
                if (((RadioButton)grBoxFrom.Controls[i]).Checked)
                {
                    n = Convert.ToInt32(((RadioButton)grBoxFrom.Controls[i]).Text);
                }
            }
            for (int i = 0; i < grBoxTo.Controls.Count; i++)
            {
                if (((RadioButton)grBoxTo.Controls[i]).Checked)
                {
                    m = Convert.ToInt32(((RadioButton)grBoxTo.Controls[i]).Text);
                }
            }
        }

        private void txtRandom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        protected void chkTriadEnable()
        {
            int n = 0;
            int m = 0;
            nm(out n, out m);
            if (((n == 2) && (m == 2 || m == 8 || m == 16)) || ((m == 2) && (n == 2 || n == 8 || n == 16)))
            {
                chkTriad.Enabled = true;
            }
            else
            {
                chkTriad.Enabled = false;
                chkTriad.Checked = false;
            }
        }

        private void txtZapros_KeyPress(object sender, KeyPressEventArgs e)
        {
            int n = 0;
            int m = 0;
            nm(out n, out m);
            switch (n)
            {
                case 2:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1  && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 3:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 4:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.D3 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 5:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.D3 && e.KeyChar != (char)Keys.D4 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 6:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.D3 && e.KeyChar != (char)Keys.D4 && e.KeyChar != (char)Keys.D5 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 7:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.D3 && e.KeyChar != (char)Keys.D4 && e.KeyChar != (char)Keys.D5 && e.KeyChar != (char)Keys.D6 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 8:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.D3 && e.KeyChar != (char)Keys.D4 && e.KeyChar != (char)Keys.D5 && e.KeyChar != (char)Keys.D6 && e.KeyChar != (char)Keys.D7 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 9:
                    if (e.KeyChar != (char)Keys.D0 && e.KeyChar != (char)Keys.D1 && e.KeyChar != (char)Keys.D2 && e.KeyChar != (char)Keys.D3 && e.KeyChar != (char)Keys.D4 && e.KeyChar != (char)Keys.D5 && e.KeyChar != (char)Keys.D6 && e.KeyChar != (char)Keys.D7 && e.KeyChar != (char)Keys.D8 && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 10:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                case 11:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.A)
                    {
                        e.Handled = true;
                    }
                    break;
                case 12:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.A && e.KeyChar != (char)Keys.B)
                    {
                        e.Handled = true;
                    }
                    break;
                case 13:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.A && e.KeyChar != (char)Keys.B && e.KeyChar != (char)Keys.C)
                    {
                        e.Handled = true;
                    }
                    break;
                case 14:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.A && e.KeyChar != (char)Keys.B && e.KeyChar != (char)Keys.C && e.KeyChar != (char)Keys.D)
                    {
                        e.Handled = true;
                    }
                    break;
                case 15:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.A && e.KeyChar != (char)Keys.B && e.KeyChar != (char)Keys.C && e.KeyChar != (char)Keys.D && e.KeyChar != (char)Keys.E)
                    {
                        e.Handled = true;
                    }
                    break;
                case 16:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.A && e.KeyChar != (char)Keys.B && e.KeyChar != (char)Keys.C && e.KeyChar != (char)Keys.D && e.KeyChar != (char)Keys.E && e.KeyChar != (char)Keys.F)
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

    }
}
