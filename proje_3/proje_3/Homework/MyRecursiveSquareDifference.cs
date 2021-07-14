using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xint = System.Numerics.BigInteger; //büyük sayılarla bigInteger kütüphanesini kullanıyoruz.


namespace Homework
{
    
    public partial class MyRecursiveSquareDifference : Component
    {
        //bu method uygulamanın başlangıcında çalışacak componentleri oluşturuyor.
        public MyRecursiveSquareDifference()
        {
            InitializeComponent();
        }

        //bu method default olarak geliyor.
        public MyRecursiveSquareDifference(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        //faktöriyeli hesaplayacak metodu oluşturuyoruz.
        public Xint Factorial(int n, int x = 0, Xint y = new Xint(), Xint z = new Xint())
        {
            // 0'dan küçük sayıların faktöriyeli alınamaz.
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Error!");
            }

            // 0 ve 1'in faktöriyeli 1'dir
            if (n < 2)
            {
                return Xint.One;
            }


            // 2'den itibaren diğer pozitif tam sayılar için geçerli metot
            // Factorial Metotu ilk çalıştığında z sayısı default olarak 0'dır. Recursive içerisine girince h ve r değerlerini tekrar hesaplamamak için bu şekilde bir kontrol sağlanıyor.
            if (z == 0)
            {
                long h = n / 2, q = h * h;

                // bitwise operation; n sayısının binary değeri 1'in binary değeri ile AND işlemine giriyor. (Örn: 12 = 0000 1100, 1 = 0000 0001 ) Sonuç 1 değilse : 'dan sonraki kısım gerçekleşiyor, 1 ise önceki kısım.
                long r = (n & 1) == 1 ? 2 * q * n : 2 * q;
                Xint f = new Xint(r);

                // q -= i; işleminin gerçekleşebilmesi için q değerinin 1'den büyük olması gerekiyor. Küçük olduğu taktirde sonuç f'tir.
                if (q < 2)
                {
                    return f;
                }

                // Sayaç görevi gören i değerine ilk aşamada 1 değeri atanıyor.
                int i = 1;
                q -= i;
                f *= q;
                i += 2;
                return Factorial(n, i, q, f);
            }

            // Orijinal algoritmada for döngüsü n - 2'ye kadar sürdüğü için burada bu kontrolü yapıyoruz.
            if (z != 0 && x < n - 2)
            {
                y -= x;
                z *= y;
                x += 2;
                return Factorial(n, x, y, z);
            }

            // x değeri n - 2 değerine eşitlenince veya onu geçince işlem tamamlanıyor, sonuca ulaşıyoruz.
            else
            {
                return z;
            }
        }

    }
}
