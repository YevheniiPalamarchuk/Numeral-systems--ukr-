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
    public partial class zadachiForm : Form
    {
        mainForm mF;
        int iCol = 0;
        int iOK = 0;
        int procOK = 0;
        int procALL = 0;
        Graphics gr;
        Bitmap myBitmap;
        int iGr = 0;
        int iTime = 0;
        Graphics grTimer;
        Graphics grQuest;
        string strQuest;

        int kolTest = 10;

        zadachClass[] zadachi;

        string[,] textZad;

        public zadachiForm(mainForm f)
        {
            InitializeComponent();
            mF = f;
        }

        private void zadachiForm_Load(object sender, EventArgs e)
        {

            /* Типы задач 
            1 - 1+2=3 Определить основание
            2 - 3=1+x Определить x
            */
            zadachi = new zadachClass[kolTest];
            textZad = new string[kolTest,2];

            textZad[0, 0] = "Набір олівців коштує {0} гривень,\r\n а ручок - {1} гривень.\r\n Загальна вартість наборів - {2} гривень.\r\n Визначте основу цих чисел?";
            textZad[0, 1] = "1";
            textZad[1, 0] = "На уроці Оленка вирізала {0} фігурок,\r\n а Тетянка - {1} фігурок.\r\n Разом дівчатка вирізали {2} фігурок.\r\n Визначте основу цих чисел?";
            textZad[1, 1] = "1";
            textZad[2, 0] = "У першій коробці {0} зошитів,\r\n а у другій - {1} зошитів.\r\n Загалом у двох коробках {2} зошитів.\r\n Визначте основу цих чисел?";
            textZad[2, 1] = "1";
            textZad[3, 0] = "У першому будинку {0} квартир,\r\n а у другому - {1} квартир.\r\n Загальна кількість квартир - {2} .\r\n Визначте основу цих чисел?";
            textZad[3, 1] = "1";
            textZad[4, 0] = "В парку дівчата посадили {0} дерев,\r\n а хлопці - {1} дерев.\r\n Загалом вони посадили {2} дерев.\r\n Визначте основу цих чисел?";
            textZad[4, 1] = "1";
            textZad[5, 0] = "Для приготування святкового столу купили {0} кг фруктів\r\n та {1} кг овочів.\r\n Загалом купили {2} кг.\r\n Визначте основу цих чисел?";
            textZad[5, 1] = "1";
            textZad[6, 0] = "Місткість бензобака автомобіля - {0} літрів пального.\r\n Зараз у бензобаці {1} літрів.\r\n Скільки треба долити літрів пального,\r\n якщо основа цих чисел {2} ?";
            textZad[6, 1] = "2";
            textZad[7, 0] = "Річ, яку Сергій хоче купити коштує {0} гривень,\r\n але Сергій має при собі лише {1} гривень.\r\n Скільки Сергієві потрібно попросити гривень у мами, аби купити ці річ,\r\n якщо основа цих чисел {2} ?";
            textZad[7, 1] = "2";
            textZad[8, 0] = "На приготування до концерту музиканти мають {0} днів,\r\n а пройшло вже {1} днів.\r\n Скільки у музикантів залишилось днів на підготовку до концерту,\r\n якщо основа цих чисел {2} ?";
            textZad[8, 1] = "2";
            textZad[9, 0] = "Прохідний бал на змаганнях з баскетболу - {0} балів.\r\n Збірна України вже має - {1} балів.\r\n Скільки ще потрібно отримати балів, аби пройти у наступний етап змагання,\r\n якщо основа цих чисел {2}?";
            textZad[9, 1] = "2";
            Random rnd = new Random();

            for (int i = 0; i < kolTest; i++)
            {
                link1:
                var Num1 = rnd.Next(5, 101);
                var Num2 = rnd.Next(5, 101);
                var Num3 = Num1 + Num2;
                var Osn = rnd.Next(4, 9);

                if (int.Parse(CI.ten_to_n(Num1, Osn)) + int.Parse(CI.ten_to_n(Num2, Osn)) == int.Parse(CI.ten_to_n(Num3, Osn)))
                {
                    goto link1;
                }
                if (textZad[i,1] == "1")
                {
                    zadachi[i] = new zadachClass(string.Format(textZad[i,0], CI.ten_to_n(Num1, Osn), CI.ten_to_n(Num2, Osn), CI.ten_to_n(Num3, Osn)), textZad[i,1], Osn.ToString());
                }
                if (textZad[i,1] == "2")
                {
                    zadachi[i] = new zadachClass(string.Format(textZad[i,0], CI.ten_to_n(Num3, Osn), CI.ten_to_n(Num1, Osn), Osn.ToString()), textZad[i,1], CI.ten_to_n(Num2, Osn));
                }

            };

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

            procALL = kolTest;

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

        private string sec_to_string(int sec)
        {
            var colHour = (int)((mF.colTimer - iTime) / 3600);
            var colMinut = (int)((mF.colTimer - iTime) / 60);
            var colSecond = (int)((mF.colTimer - iTime));
            TimeSpan interval = new TimeSpan(colHour, colMinut, colSecond);
            return interval.ToString();
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
                grQuest.DrawImage(newImage, 450, 55);
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

            strQuest = zadachi[iCol].TextZad;
            drawQuest(true);


            gr.DrawString(String.Format(@"Завдання {0} ", (iCol+1).ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
            iGr = iGr + 15;
            gr.DrawString(String.Format(@"{0}", strQuest), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
            iGr = iGr + 85;
            //gr.DrawString(String.Format(@"{0}", zadachi[iCol].Vidp), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
            //iGr = iGr + 15;

            pb.Image = myBitmap;

            btnQuest.Enabled = false;
            btnQuest.Text = "Питання " + (iCol+1).ToString();
            btnAnswer.Enabled = true;
            txtAnswer.Enabled = true;
            txtAnswer.Text = "";

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

        private void printSmile(int x, int y, bool prOK, ref Graphics g)
        {
            if (prOK)
            {
                Image newImage = Image.FromFile(".\\testOK.png");
                g.DrawImage(newImage, x, y);
            }
            else
            {
                Image newImage = Image.FromFile(".\\testNoOK.png");
                g.DrawImage(newImage, x, y);
            }
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
            var ch_OK = zadachi[iCol].Otvet();
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
                    //procOK = procOK + mF.arZadan[iCol - 1, 3];
                    procOK = procOK + 1;
                }
                else
                {
                    procOK = procOK + 1;
                }
                grQuest.DrawString(String.Format(@"ВІДПОВІДЬ ПРАВИЛЬНА"), new Font(new FontFamily("Calibri"), 14, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Green), 0, 100);
                printSmile(460, 60, true, ref grQuest);
            }
            else
            {
                grQuest.DrawString(String.Format(@"ВІДПОВІДЬ НЕПРАВИЛЬНА"), new Font(new FontFamily("Calibri"), 14, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Red), 0, 100);
                printSmile(460, 60, false, ref grQuest);
            }

            btnAnswer.Enabled = false;
            txtAnswer.Enabled = false;

            iCol++;

            if (iCol < kolTest)
            {
                btnQuest.Enabled = true;
                btnQuest.Text = "Питання " + (iCol + 1).ToString();
            }
            else
            {
                gr.DrawString(String.Format(@"ТЕСТ ЗАКІНЧЕНО"), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
                iGr = iGr + 15;
                gr.DrawString(String.Format(@"Правильних відповідей {0} из {1}", iOK.ToString(), iCol.ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
                iGr = iGr + 15;
                gr.DrawString(String.Format(@"Результат {0}%", (Math.Round((decimal)100 * procOK / procALL)).ToString()), new Font(new FontFamily("Calibri"), 12, FontStyle.Bold, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, iGr);
                btnQuest.Text = "Тест закінчено";
            }

        }

        private void zadachiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timeTXT.Stop();
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
    }
    
}
