using System;

namespace Digital_Signature_Algorithm_DSA_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------Шифрование--------------------------------");
            Console.WriteLine("Введите сообщение");
            var M = Console.ReadLine();
            int q;
            q = 23;
            var p = q + 1;

            while (true)
            {
                var f = false;
                for (var i = 2; i < p - 1; i++)
                    if (p % i == 0)
                    {
                        f = true;
                        break;
                    }
                if (!f && (p - 1) % q == 0)
                    break;
                p++;
            }

            double g = 0;
            var rand = new Random();

            while (g < 1)
                g = Math.Pow(rand.Next(1, p - 1), (p - 1) / q);

            var x = rand.Next(0, q);

            var y = fast(Convert.ToInt32(g), x, p);

            Console.WriteLine("{0},{1}", x, y);
            var s = 0;
            var r = 0;

            while (true)
            {
                var k = rand.Next(0, q);
                r = fast(Convert.ToInt32(g), k, p) % q;
                var k1 = 0;
                while (k1 * k % q != 1)
                    k1++;

                s = Convert.ToInt32(k1 * (hash(M, q) + x * r)) % q;
                if (r != 0 || s != 0)
                {
                    Console.WriteLine("Сообщение с подписью: [{0}, {1}, {2}]", M, r, s);
                    break;
                }
            }
            Console.WriteLine("---------------------------------Проверка---------------------------------");
            Console.WriteLine("Введите первый ключ");
            var key1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второй ключ");
            var key2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите собщение для проверки:");
            M = Console.ReadLine();
            if (key1 == r && key2 == s)
            {
                var s1 = 0;
                while (s1 * s % q != 1)
                    s1++;

                var w = s1 % q;

                var u1 = hash(M, q) * w % q;

                var u2 = r * w % q;

                double mp1 = fast(Convert.ToInt32(g), u1, p);

                double mp2 = fast(y, u2, p);

                var res = mp1 * mp2;

                res %= p;
                res %= q;
                var v = Convert.ToInt32(res);
                Console.WriteLine("v = {0}", v);
                if (v == r)
                    Console.WriteLine("Значения совпадают, ЭЦП верна: {0} = {1}", v, r);
                else
                    Console.WriteLine("Значения не совпадают, ЭЦП не верна: {0} != {1}", v, r);
            }
            else
            {
                Console.WriteLine("Ключи не совпадают");
            }

            Console.ReadLine();
        }

        public static int NOD(int a, int b)
        {
            if (a == b)
                return a;
            if (a > b)
                return NOD(a - b, b);
            return NOD(b - a, a);
        }

        public static int fast(int a, int r, int n)
        {
            var a1 = a;
            var z1 = r;
            var x = 1;
            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 /= 2;
                    a1 = a1 * a1 % n;
                }
                z1 -= 1;
                x = x * a1 % n;
            }

            return x;
        }

        public static int hash(string s, int n)
        {
            var b = new char[33];
            b[0] = 'а';
            b[1] = 'б';
            b[2] = 'в';
            b[3] = 'г';
            b[4] = 'д';
            b[5] = 'е';
            b[6] = 'ё';
            b[7] = 'ж';
            b[8] = 'з';
            b[9] = 'и';
            b[10] = 'й';
            b[11] = 'к';
            b[12] = 'л';
            b[13] = 'м';
            b[14] = 'н';
            b[15] = 'о';
            b[16] = 'п';
            b[17] = 'р';
            b[18] = 'с';
            b[19] = 'т';
            b[20] = 'у';
            b[21] = 'ф';
            b[22] = 'х';
            b[23] = 'ц';
            b[24] = 'ч';
            b[25] = 'ш';
            b[26] = 'щ';
            b[27] = 'ъ';
            b[28] = 'ы';
            b[29] = 'ь';
            b[30] = 'э';
            b[31] = 'ю';
            b[32] = 'я';
            var k = 150;
            //n = 391;
            var f = 0;
            s = s.ToLower();
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = 0; j < 33; j++)
                    if (b[j] == s[i])
                        f = j + 1;
                k = Convert.ToInt32(Math.Pow(k + f, 2) % n);
            }

            return k;
        }
    }
}