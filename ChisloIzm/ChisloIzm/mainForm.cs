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
    public partial class mainForm : Form
    {
        public bool[] arFrom = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] arTo = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        public int chMAX = 100;
        public int colTest = 5;
        public bool NoRandom = false;
        public int[,] arZadan;
        public bool isTimer = true;
        public int colTimer = 30;
        public string user_pass = "";

        private void testLoad()
        {
            string pathLoad = ".\\default.txt";
            if (File.Exists(pathLoad))
            {
                StreamReader sr_rzm = File.OpenText(pathLoad);
                int x = 0, y = 0, z = 0;
                try
                {
                    while (!sr_rzm.EndOfStream)
                    {
                        string line = sr_rzm.ReadLine();
                        string[] fields = line.Split('|');
                        x = Convert.ToInt32(fields[0]);
                        y = Convert.ToInt32(fields[1]);
                    }
                    arZadan = new int[x+1, y+1];
                    colTest = x + 1;
                    NoRandom = true;
                    sr_rzm.Close();
                    StreamReader sr = File.OpenText(pathLoad);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = line.Split('|');
                        x = Convert.ToInt32(fields[0]);
                        y = Convert.ToInt32(fields[1]);
                        z = Convert.ToInt32(fields[2]);
                        arZadan[x, y] = z;
                    }
                    sr.Close();
                    //MessageBox.Show("Файл загружен!", "Загрузка файла");
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.testLoad();
        }

        private void lbTeor_MouseEnter(object sender, EventArgs e)
        {
            lbTeor.ForeColor = Color.Blue;
        }

        private void lbTeor_MouseLeave(object sender, EventArgs e)
        {
            lbTeor.ForeColor = Color.Red;
        }

        private void lbTest_MouseEnter(object sender, EventArgs e)
        {
            lbTest.ForeColor = Color.Blue;
        }

        private void lbTest_MouseLeave(object sender, EventArgs e)
        {
            lbTest.ForeColor = Color.Red;
        }

        private void lbTurning_MouseEnter(object sender, EventArgs e)
        {
            lbTurning.ForeColor = Color.Blue;
        }

        private void lbTurning_MouseLeave(object sender, EventArgs e)
        {
            lbTurning.ForeColor = Color.Red;
        }

        private void lbExam_MouseEnter(object sender, EventArgs e)
        {
            lbExam.ForeColor = Color.Blue;
        }

        private void lbExam_MouseLeave(object sender, EventArgs e)
        {
            lbExam.ForeColor = Color.Red;
        }

        private void lbTest_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            testForm testF = new testForm();
            this.Visible = false;
            testF.ShowDialog();
            this.Visible = true;
        }

        private void lbTurning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            passwordForm passF = new passwordForm(this);
            this.Visible = false;
            passF.ShowDialog();
            this.Visible = true;
            if (user_pass == readPassword())
            {
                turningForm turningF = new turningForm(this);
                this.Visible = false;
                turningF.ShowDialog();
                this.Visible = true;
            }
        }

        private void lbExam_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //passwordForm passF = new passwordForm(this);
            //this.Visible = false;
            //passF.ShowDialog();
            //this.Visible = true;
            //if (user_pass == readPassword())
            //{
                examForm examF = new examForm(this);
                this.Visible = false;
                examF.ShowDialog();
                this.Visible = true;
            //}
        }

        private void lbTeor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(".\\Help.chm");
        }

        private void lbTeor_Click(object sender, EventArgs e)
        {

        }

        public string readPassword()
        {
            string password = "qwerty";
            if (File.Exists(".\\password.txt"))
            {
                StreamReader sr = File.OpenText(".\\password.txt");
                string spas = sr.ReadLine();
                password = spas[11].ToString() + spas[21] + spas[31] + spas[41] + spas[51] + spas[61] + spas[71] + spas[81] + spas[91] + spas[101];
                sr.Close();
            }
            password = password.PadRight(10, '0');
            return password;
        }

        private void lbArifmetic_MouseEnter(object sender, EventArgs e)
        {
            lbArifmetic.ForeColor = Color.Blue;
        }

        private void lbArifmetic_MouseLeave(object sender, EventArgs e)
        {
            lbArifmetic.ForeColor = Color.Red;
        }

        private void lbArifmetic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ArifmeticForm arifmeticF = new ArifmeticForm();
            this.Visible = false;
            arifmeticF.ShowDialog();
            this.Visible = true;
        }

        private void lbArifmetic_Click(object sender, EventArgs e)
        {

        }

        private void lbZadachi_MouseEnter(object sender, EventArgs e)
        {
            lbZadachi.ForeColor = Color.Blue;
        }

        private void lbZadachi_MouseLeave(object sender, EventArgs e)
        {
            lbZadachi.ForeColor = Color.Red;
        }

        private void lbZadachi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            passwordForm passF = new passwordForm(this);
            this.Visible = false;
            passF.ShowDialog();
            this.Visible = true;
            if (user_pass == readPassword())
            {
            */
           
                zadachiForm zadachF = new zadachiForm(this);
                this.Visible = false;
                zadachF.ShowDialog();
                this.Visible = true;
            /*
            }
            */
        }
    }
}
