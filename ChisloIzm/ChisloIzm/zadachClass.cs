using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChisloIzm
{
    class zadachClass
    {
        public string TextZad;
        public string TipZad;
        //public string Numb1;
        //public string Numb2;
        //public string Numb3;
        //public string Sum;
        public string Vidp;
        //public int Osn;
        public zadachClass(string TextZad, string TipZad, string Vidp)
        {
            this.TextZad = TextZad;
            this.TipZad = TipZad;
            this.Vidp = Vidp;
        }

        public string Otvet()
        {
            return Vidp;
        }
    }
}

