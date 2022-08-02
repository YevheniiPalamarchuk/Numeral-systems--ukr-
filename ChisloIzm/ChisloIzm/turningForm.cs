using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChisloIzm
{
    public partial class turningForm : Form
    {
        mainForm mF;
        //int[,] arZadan;

        public turningForm(mainForm f)
        {
            mF = f;
            InitializeComponent();
        }
        Random rnd = new Random();
        private void turningForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < grBoxFrom.Controls.Count; i++)
            {
                var iAr = Convert.ToInt16(((CheckBox)grBoxFrom.Controls[i]).Name.Substring(6, 2));
                ((CheckBox)grBoxFrom.Controls[i]).Checked = mF.arFrom[iAr - 2];
            }
            for (int i = 0; i < grBoxTo.Controls.Count; i++)
            {
                var iAr = Convert.ToInt16(((CheckBox)grBoxTo.Controls[i]).Name.Substring(4, 2));
                ((CheckBox)grBoxTo.Controls[i]).Checked = mF.arTo[iAr - 2];
            }
            txtMax.Text = mF.chMAX.ToString();
            txtColTest.Text = mF.colTest.ToString();
            chkNoRandom.Checked = true;
            chkNoRandom.Checked = mF.NoRandom;
            if (mF.arZadan != null)
            {
                for (int i = 0; i < mF.arZadan.GetLength(0); i++)
                {
                    gridZadan.Rows.Add();
                    for (int j = 0; j < mF.arZadan.GetLength(1); j++)
                    {
                        gridZadan.Rows[i].Cells[j].Value = (mF.arZadan[i, j] != 0 ? mF.arZadan[i, j].ToString() : null);
                    }
                }
            }
            chkTimer.Checked = true;
            chkTimer.Checked = mF.isTimer;
            txtTimer.Text = mF.colTimer.ToString();
            txtPassword.Text = mF.readPassword();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grBoxFrom.Controls.Count; i++)
            {
                var iAr = Convert.ToInt16(((CheckBox)grBoxFrom.Controls[i]).Name.Substring(6, 2));
                mF.arFrom[iAr - 2] = ((CheckBox)grBoxFrom.Controls[i]).Checked;
            }
            for (int i = 0; i < grBoxTo.Controls.Count; i++)
            {
                var iAr = Convert.ToInt16(((CheckBox)grBoxTo.Controls[i]).Name.Substring(4, 2));
                mF.arTo[iAr - 2] = ((CheckBox)grBoxTo.Controls[i]).Checked;
            }
            mF.chMAX = Convert.ToInt32(txtMax.Text);
            mF.colTest = Convert.ToInt32(txtColTest.Text);
            mF.NoRandom = chkNoRandom.Checked;

            if (mF.NoRandom)
            {
                mF.colTest = gridZadan.RowCount - 1;
                mF.arZadan = new int[gridZadan.RowCount - 1, gridZadan.ColumnCount];
                for (int i = 0; i < gridZadan.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < gridZadan.Columns.Count; j++)
                    {
                        mF.arZadan[i, j] = Convert.ToInt32(gridZadan.Rows[i].Cells[j].Value);
                    }
                }
            }
            mF.isTimer = chkTimer.Checked;
            mF.colTimer = Convert.ToInt32(txtTimer.Text);
            savePassword();
            MessageBox.Show("Налаштування збережені");
            this.Close();
        }

        private void gridZadan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                int val = 0;
                try
                {
                    val = Convert.ToInt32(gridZadan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }
                catch
                {
                    MessageBox.Show("Повинно бути введено ціле число");
                    gridZadan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
        }

        private void chkNoRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoRandom.Checked)
            {
                grBoxFrom.Enabled = false;
                grBoxTo.Enabled = false;
                lbColTest.Enabled = false;
                txtColTest.Enabled = false;
                lbMax.Enabled = false;
                txtMax.Enabled = false;
                gridZadan.Enabled = true;
                btnSave.Enabled = true;
                btnLoad.Enabled = true;
            }
            else
            {
                grBoxFrom.Enabled = true;
                grBoxTo.Enabled = true;
                lbColTest.Enabled = true;
                txtColTest.Enabled = true;
                lbMax.Enabled = true;
                txtMax.Enabled = true;
                gridZadan.Enabled = false;
                btnSave.Enabled = false;
                btnLoad.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //утворення діалогового вікна "Сохранити як..", для збереження зображення
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Зберегти картинку як...";
            //чи отображати зостереження, якщо користувач вказує им'я вже існуючого файлу
            savedialog.OverwritePrompt = true;
            //чи отображати зостереження, якщо користувач вказує неможливий путь
            savedialog.CheckPathExists = true;
            //список форматів файлу, відображаємі в полі "Тип файлу"
            savedialog.Filter = " Text Files(*.TXT)|*.txt";
            //чи отображається ли кнопка "Справка" в диалоговому вікні
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK) //якщо в диалоговому вікне нажата кнопка "ОК"
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(savedialog.FileName))
                    {
                        for (int i = 0; i < gridZadan.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < gridZadan.Columns.Count; j++)
                            {
                                sw.WriteLine(String.Format("{0}|{1}|{2}|", i, j, Convert.ToInt32(gridZadan.Rows[i].Cells[j].Value)));
                            }
                        }
                        sw.Close();
                    }
                    MessageBox.Show("Файл збережено!", "Збереження файлу");
                }
                catch
                {
                    MessageBox.Show("Неможливо зберегти зображення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //утворення діалогового вікна "Сохранити як..", для збереження зображення
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Title = "Загрузити данні";
            //список форматів файлу, відображаємі в полі "Тип файлу"
            opendialog.Filter = " Text Files(*.TXT)|*.txt";
            //чи отображається ли кнопка "Справка" в диалоговому вікні
            opendialog.ShowHelp = true;
            if (opendialog.ShowDialog() == DialogResult.OK) //якщо в диалоговому вікне нажата кнопка "ОК"
            {
                gridZadan.Rows.Clear();
                if (File.Exists(opendialog.FileName))
                {
                    StreamReader sr = File.OpenText(opendialog.FileName);
                    int x, y, z, x_save;
                    try
                    {
                        x_save = -1;
                        while (!sr.EndOfStream)
                        {
                            // зчитуємо строку з файлу
                            string line = sr.ReadLine();
                            // разділяємо на масив зі считанної строки до символа
                            string[] fields = line.Split('|');
                            x = Convert.ToInt32(fields[0]);
                            y = Convert.ToInt32(fields[1]);
                            z = Convert.ToInt32(fields[2]);                    
                            if (x_save != x)
                            {
                                gridZadan.Rows.Add();
                                x_save = x;
                            }
                            if (y == 2)
                                z = rnd.Next(1, 1001);
                            gridZadan.Rows[x].Cells[y].Value = (z != 0 ? z.ToString() : null);
                        }
                        sr.Close();
                        MessageBox.Show("Файл завантажено!", "Збереження файлу");
                    }
                    catch
                    {
                        MessageBox.Show("Неможливо зберегти зображення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void chkTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimer.Checked)
            {
                lbTimer.Enabled = true;
                txtTimer.Enabled = true;
            }
            else
            {
                lbTimer.Enabled = false;
                txtTimer.Enabled = false;
            }
        }

        private void gridZadan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtColTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void savePassword()
        {
            if (File.Exists(".\\password.txt"))
            {
                File.Delete(".\\password.txt");
            }

            StreamWriter sw = File.CreateText(".\\password.txt");
            var password = txtPassword.Text.PadRight(10, '0');
            string spas = "";
            Random rnd = new Random();
            for (int i = 0; i < 200; i++)
            {
                switch (i)
                {
                    case 11:
                        spas = spas + password[0];
                        break;
                    case 21:
                        spas = spas + password[1];
                        break;
                    case 31:
                        spas = spas + password[2];
                        break;
                    case 41:
                        spas = spas + password[3];
                        break;
                    case 51:
                        spas = spas + password[4];
                        break;
                    case 61:
                        spas = spas + password[5];
                        break;
                    case 71:
                        spas = spas + password[6];
                        break;
                    case 81:
                        spas = spas + password[7];
                        break;
                    case 91:
                        spas = spas + password[8];
                        break;
                    case 101:
                        spas = spas + password[9];
                        break;
                    default:
                        spas = spas + rnd.Next(0, 9).ToString();
                        break;
                }
            }
            sw.WriteLine(spas);
            sw.Close();
        }
    }
}
