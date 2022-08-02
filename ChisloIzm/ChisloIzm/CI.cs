using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChisloIzm
{
    public static class CI
    {
        // Преобразування символів 16 -> 10
        public static int hex_dex(string s)
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
        public static string dex_hex(int i)
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


        // Перевод числа "x" з с-ми "n" в "m"
        public static string n_to_m(string x, int n, int m)
        {
            var rez1 = n_to_ten(x, n);
            var rez2 = ten_to_n(rez1, m);
            return rez2;
        }

        // Перевод числа "x" з с-ми "n" в "10"
        public static int n_to_ten(string x, int n)
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

        // Перевод числа "x" з с-ми "10" в "n"
        public static string ten_to_n(int x, int n)
        {
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
                while (div >= n)
                {
                    mod = div % n;
                    divn = (int)(div / n);
                    reztmp = reztmp + dex_hex(mod);
                    if (divn < n)
                    {
                        reztmp = reztmp + dex_hex(divn);
                    }
                    div = divn;
                }
                char[] sReverse = reztmp.ToCharArray();
                Array.Reverse(sReverse);
                rez = new string(sReverse);
            }
            return rez;
        }

    }
}
