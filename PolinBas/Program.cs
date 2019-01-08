using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinBas {
    class Program {
        static void Main(string[] args) {
            string a = "11111100101000100001010101101000000000010111010001011010010110101110100011110101011110010011000110101110111011111101101010010100011000011101011000110111110111110110111110011100000110001011011111101001011010001011010101110011111010111";
            string b = "00010111001001101001100111110110000101011100000111111001011011100000000110110110000010001101100010001000011000100111101110000111111100110011001101101000101111001100111110010100111001111100101110000010101110111001101110110110110100000";
            string n = "11000001011101000111100100000010000001011111001011011011000100110101000011001010110001101000111110111010100000101101110000101010111100010000101111001011111111111011001101111000011010000100110100111011011110110100110101111011000010110";


            int[] p1 = new int[1];
            int[] p2 = new int[1];
            int[] p3 = new int[1];


            p1 = StrToByt(a);
            p2 = StrToByt(b);
            p3 = StrToByt(n);


            




            Console.ReadKey();


        }


        public static string BytToStr(int[] a) {
            StringBuilder strl = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; i--) {
                strl.Append(Convert.ToString(a[i], 2));
            }
            return strl.ToString();
        }

        public static int[] StrToByt(string a) {

            var bitlenth = a.Length;
            int[] n = new int[bitlenth];

            for (var i = 0; i < bitlenth; i++) {
                n[i] = Convert.ToByte(a.Substring(a.Length - (i + 1), 1), 2);
            }

            return n;

        }

        public static int[] Del0(int[] a, int b) {
            int ii = 0;
            var i = b - 1;
            while (a[i] == 0) {
                ii++;
                i--;
                if (i == -1) return a;
            }
            int[] res = new int[a.Length - ii];
            for (int k = 0; k < a.Length - ii; k++) {
                res[k] = a[k];
            }
            return res;
        }




        public static int[] Add(int[] a, int[] b) {
            int max;
            if (a.Length < b.Length) { max = b.Length; }
            else { max = a.Length; };
            Array.Resize(ref a, max);
            Array.Resize(ref b, max);
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++) {
                result[i] = (a[i] ^ b[i]);

            }
            return Del0(result, max);
        }

        public static int[] ShiftBits(int[] a, int b) {
            int[] res = new int[a.Length + b];
            for (int i = 0; i < a.Length; i++) {
                res[i + b] = a[i];
            }
            return res;
        }


        public static int[] LenghtControl(int[] a) {
            if (a.Length < 232) {
                Array.Resize(ref a, 233);
            }
            return a;
        }



        public static int[] DivPol(int[] a) {
            string gen = "100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010111";
            int[] genarr = new int[1];
            genarr = StrToByt(gen);
            int[] res = new int[1];
            res = a;


            if (a.Length < genarr.Length) {
                return a;
            }
            else {
                int[] p = new int[1];
                while (res.Length >= genarr.Length) {
                    p = ShiftBits(genarr, res.Length - genarr.Length);
                    res = Add(res, p);
                }
            }
            return LenghtControl(res);
        }

        public static int[] SQ(int[] a) {
            int[] aa = new int[2 * a.Length];
            int[] res = new int[1];
            for (int i = 0; i < a.Length; i++) {
                aa[2 * i] = a[i];
            }
            res = DivPol(aa);
            return res;
        }

        public static int[] Multi(int[] a, int[] b) {
            int max;
            if (a.Length < b.Length) { max = b.Length; }
            else { max = a.Length; };
            Array.Resize(ref a, max);
            Array.Resize(ref b, max);

            int[] p = new int[1];
            int[] res = new int[1];
            for (int i = 0; i < a.Length; i++) {
                if (b[i] == 1) {
                    p = ShiftBits(a, i);
                    res = Add(res, p);
                }
            }
            res = DivPol(res);

            return res;
        }



        public static int[] Tr(int[] a) {
            int[] res = new int[1];
            int[] p = new int[1];
            res = a;
            p = a;
            for (int i = 1; i < 179; i++) {
                p = SQ(p);
                res = Add(res, p);
            }
            res = DivPol(res);
            return res;
        }

        public static int[] BP(int[] a, int[] n) {
            string b = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
            int[] res = new int[a.Length];
            res = StrToByt(b);
            for (int i = 0; i < a.Length; i++) {
                if (n[i] == 1) {
                    res = Multi(res, a);
                }
                a = SQ(a);
            }
            return res;
        }

        public static int[] Inv(int[] a) {
            string b = "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
            int[] inv = new int[a.Length];
            int[] p = new int[a.Length];
            int[] n = new int[a.Length];
            n = StrToByt(b);
            inv = StrToByt(b);
            p = BP(a, n);

            for (int i = 1; i < a.Length; i++) {
                inv = Multi(inv, p);
                p = SQ(p);
            }
            inv = SQ(inv);
            return inv;
        }




        public static int[] Check(int[] a, int[] b, int[] c) {
            int[] one = new int[1];
            one[0] = 1;
            int[] zero = new int[1];
            zero[0] = 1;
            int[] res1 = new int[a.Length];
            int[] res2 = new int[a.Length];
            res1 = Multi(c, Add(a, b));
            res2 = Add(Multi(c, a), Multi(c, b));
            if (res1 == res2) return one;
            else return zero;
        }



    }



}
