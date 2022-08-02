using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChisloIzm
{
    public partial class examForm : Form
    {

        mainForm mF;
        int iCol = 0;
        int iOK = 0;
        int procOK = 0;
        int procALL = 0;
        Graphics gr;
        Bitmap myBitmap;
        int iGr = 0;
        int n = 0;
        int m = 0;
        string ch_n = "";
        int iTime = 0;
        Graphics grTimer;
        Graphics grQuest;
        string strQuest;

        private void printSmile(int x, int y, bool prOK, ref Graphics g)
        {
            if (prOK)
            {
                Image newImage = Image.FromFile(".\\testOK.png");
                g.DrawImage(newImage, x, y);
                //g.DrawEllipse(new Pen(Color.GreenYellow, 5), x, y, 40, 40);
                //g.FillEllipse(new SolidBrush(Color.GreenYellow), x, y, 40, 40);
                //g.FillEllipse(new SolidBrush(Color.Yellow), x + 5, y + 10, 12, 12);
                //g.FillEllipse(new SolidBrush(Color.Yellow), x + 25, y + 10, 12, 12);
                //g.DrawArc(new Pen(Color.Yellow, 3), x + 10, y + 25, 20, 10, 0, 180);
            }
            else
            {
                Image newImage = Image.FromFile(".\\testNoOK.png");
                g.DrawImage(newImage, x, y);
                //g.DrawEllipse(new Pen(Color.Red, 5), x, y, 40, 40);
                //g.FillEllipse(new SolidBrush(Color.Red), x, y, 40, 40);
                //g.FillEllipse(new SolidBrush(Color.Yellow), x + 5, y + 10, 12, 6);
                //g.FillEllipse(new SolidBrush(Color.Yellow), x + 25, y + 10, 12, 6);
                //g.DrawArc(new Pen(Color.Yellow, 3), x + 10, y + 30, 20, 10, 0, -180);
            }
        }

        public examForm(mainForm f)
        {
            InitializeComponent();
            mF = f;
        }

        private void examForm_Load(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(2000, 2000);
            gr = Graphics.FromImage(myBitmap);
            gr.Clear(Color.Wheat);
            for (int i = 0; i < 200; i++)
            {
                gr.DrawLine(Pens.LightGray, i * 15, 0, i * 15, 2000);
                gr.DrawLine(Pens.LightGray, 0, i * 15, 2000, i * 15);
            }
            pb.Image = myBitmap;

            btnQuest.Enabled = true;
            btnAnswer.Enabled = false;
            txtAnswer.Enabled = false;
            if (mF.NoRandom)
            {
                for (int i = 0; i < mF.arZadan.GetLength(0); i++)
                {
                    procALL = procALL + mF.arZadan[i, 3];
                }
            }
            else
            {
                procALL = mF.colTest;
            }
            if (mF.isTimer)
            {
                pbTimer.Visible = true;
            }
            else
            {
                pbTimer.Visible = false;
            }
            grTimer = pbTimer.CreateGraphics();
            grTimer.Clear(Color.Red);
            grQuest = pbQuest.CreateGraphics();
            grQuest.Clear(Color.Wheat);
            for (int i = 0; i < 200; i++)
            {
                grQuest.DrawLine(Pens.LightGray, i * 15, 0, i * 15, 2000);
                grQuest.DrawLine(Pens.LightGray, 0, i * 15, 2000, i * 15);
            }

        }

        private void drawQuest(bool pr_smile)
        {
            grQuest.Clear(Color.Wheat);
            for (int i = 0; i < 200; i++)
            {
                grQuest.DrawLine(Pens.LightGray, i * 15, 0, i * 15, 2000);
                grQuest.DrawLine(Pens.LightGray, 0, i * 15, 2000, i * 15);
            }
            grQuest.DrawString(strQuest, new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, 0);
            if (pr_smile)
            {
                Image newImage = Image.FromFile(".\\testQuest.png");
                grQuest.DrawImage(newImage, 50, 45);
            }
        }


        private void btnQuest_Click(object sender, EventArgs e)
        {
            if (mF.isTimer)
            {
                iTime = 0;
                grTimer.Clear(Color.Red);
                grTimer.DrawString(sec_to_string((mF.colTimer - iTime)), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Yellow), 0, 0);
                timeTXT.Start();
            }
            Random rnd = new Random();
            var ch_ten = 0;
            if (mF.NoRandom)
            {
                n = mF.arZadan[iCol, 0];
                if (n == 0)
                {
                    n = rnd.Next(2, 16);
                }
                m = mF.arZadan[iCol, 1];
                if (m == 0)
                {
                    m = rnd.Next(2, 16);
                }
                ch_ten = mF.arZadan[iCol, 2];
                if (ch_ten == 0)
                {
                    ch_ten = rnd.Next(1, mF.chMAX);
                }
            }
            else
            {
                n = rnd.Next(2, 16);
                while (mF.arFrom[n - 2] == false)
                {
                    n = rnd.Next(2, 16);
                }
                m = n;
                while (m == n || mF.arTo[n - 2] == false)
                {
                    m = rnd.Next(2, 16);
                }
                ch_ten = rnd.Next(1, mF.chMAX);
            }

            ch_n = CI.ten_to_n(ch_ten, n);
            iCol++;
            strQuest = String.Format(@"Завдання {0} 
Переведіть число '{1}' з с-ми '{2}' в с-му '{3}'",
                                       iCol.ToString(), ch_n, n.ToString(), m.ToString());
            drawQuest(true);

            gr.DrawString(String.Format(@"Завдання {0}: перевести число '{1}' з с-ми '{2}' в с-му '{3}'", iCol.ToString(), ch_n, n.ToString(), m.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
            iGr = iGr + 15;

            pb.Image = myBitmap;

            btnQuest.Enabled = false;
            btnQuest.Text = "Питання " + (iCol).ToString();
            btnAnswer.Enabled = true;
            txtAnswer.Enabled = true;
            txtAnswer.Text = "";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (mF.isTimer)
            {
                timeTXT.Stop();
            }
            var ch_user = txtAnswer.Text;
            gr.DrawString(String.Format(@"Ви відповіли: '{0}'", ch_user), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Blue), 0, iGr);
            iGr = iGr + 15;
            var ch_OK = CI.n_to_m(ch_n, n, m);
            Color color_ok;
            if (ch_OK == ch_user)
            {
                color_ok = Color.Green;
            }
            else
            {
                color_ok = Color.Red;
            }
            gr.DrawString(String.Format(@"Правильна відповідь: '{0}'", ch_OK), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(color_ok), 0, iGr);
            if (mF.isTimer)
            {
                iGr = iGr + 15;
                gr.DrawString(String.Format(@"Час на відповідь {0} с", iTime.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Coral), 0, iGr);
            }
            iGr = iGr + 30;

            pb.Image = myBitmap;

            drawQuest(false);

            if (ch_OK == ch_user)
            {
                iOK++;
                if (mF.NoRandom)
                {
                    procOK = procOK + mF.arZadan[iCol - 1, 3];
                }
                else
                {
                    procOK = procOK + 1;
                }
                grQuest.DrawString(String.Format(@"ВІДПОВІДЬ ПРАВИЛЬНА"), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Green), 0, 50);
                printSmile(160, 40, true, ref grQuest);
            }
            else
            {
                grQuest.DrawString(String.Format(@"ВІДПОВІДЬ НЕПРАВИЛЬНА"), new Font(new FontFamily("Calibri"), 10, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), 0, 50);
                printSmile(140, 40, false, ref grQuest);
            }

            btnAnswer.Enabled = false;
            txtAnswer.Enabled = false;
            if (iCol < mF.colTest)
            {
                btnQuest.Enabled = true;
                btnQuest.Text = "Питання "+(iCol+1).ToString();
            }
            else
            {
                gr.DrawString(String.Format(@"ТЕСТ ЗАКІНЧЕНО"), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
                iGr = iGr + 15;
                gr.DrawString(String.Format(@"Правильних відповідей {0} из {1}", iOK.ToString(), mF.colTest.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
                iGr = iGr + 15;
                gr.DrawString(String.Format(@"Результат {0}%", (Math.Round((decimal)100 * procOK / procALL)).ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
                btnQuest.Text = "Тест закінчено";
            }

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

        private void timeTXT_Tick(object sender, EventArgs e)
        {
            iTime++;
            if ((mF.colTimer - iTime) < 10)
            {
                grTimer.Clear(Color.Red);
                grTimer.DrawString(sec_to_string((mF.colTimer - iTime)), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Yellow), 0, 0);
                //SystemSounds.Beep.Play();
            }
            else
            {
                grTimer.Clear(Color.Green);
                grTimer.DrawString(sec_to_string((mF.colTimer - iTime)), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Yellow), 0, 0);
            }
            if (iTime < mF.colTimer)
            {
                timeTXT.Start();
            }
            else
            {
                btnAnswer.PerformClick();
            }
        }

        private string sec_to_string(int sec)
        {
            var colHour = (int)((mF.colTimer - iTime) / 3600);
            var colMinut = (int)((mF.colTimer - iTime) / 60);
            var colSecond = (int)((mF.colTimer - iTime));
            TimeSpan interval = new TimeSpan(colHour, colMinut, colSecond);
            return interval.ToString();
        }

        private void examForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timeTXT.Stop();
        }

        private void pn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
