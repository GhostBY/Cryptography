using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fiat_Shamir
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            FiatShamir fs = new FiatShamir();

            Console.WriteLine(" ----------- Генерация ключей ----------- ");
            Console.WriteLine("Генерация простых ключей  p и q и их произведения n = p * q");
            Console.WriteLine("n: {0} (открытый)", fs.n);
            Console.WriteLine("p: {0} (закрытый)", fs.p);
            Console.WriteLine("q: {0} (закрытый)", fs.q);

            Console.WriteLine("ВЫбираем s (s<n и ggt(s,n)=1) и образует v = s^2 mod n");
            BigInteger s = fs.GetCoPrime(fs.n);
            Console.WriteLine("s: {0}  (закрытый 1-го)", s);
            BigInteger v = (s * s) % fs.n;
            Console.WriteLine("v: {0}  (открытый)", v);



            Console.WriteLine(" ---------------- Применение ---------------- ");
            Console.WriteLine("ВЫбираем случайным образом r (r<n и ggt(r,n)=1) и образует x = r^2 mod n");
            BigInteger r = fs.GetCoPrime(fs.n);
            Console.WriteLine("r: {0}  (закрытый 1-го для этого раунда)", s);
            BigInteger x = (r * r) % fs.n;
            Console.WriteLine("x: {0} (открытый)", x);

            Console.WriteLine("Послаем  x другому пользователю");
            Console.WriteLine();


            Console.WriteLine("2-ой пользователь случайным образом выбирает одит Bit b и посылае 1-ому b");
            int b = random.Next(0, 2);
            Console.WriteLine("b: {0}", b);

            BigInteger y = 0;
            if (b == 1) y = (r * s) % fs.n;
            if (b == 0) y = r % fs.n;
            Console.WriteLine("1-ый посылает y");
            Console.WriteLine("y: {0} ", y);
            Console.WriteLine("2-ой принимает");
            BigInteger yn = (y * y) % fs.n;

            BigInteger test = 0;
            if (b == 1) test = (x * v) % fs.n;
            if (b == 0) test = x % fs.n;

            if (yn == test)
            {
                Console.WriteLine("Проверка пройдена");
            }
            else
            {
                Console.WriteLine("Проверка не пройдена");
            }
            Console.ReadLine();
        }
    }
}
