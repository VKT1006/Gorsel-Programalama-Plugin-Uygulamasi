using Plugin;

namespace Fark
{
    public class fark : IHesap
    {
        public string isim => "-";

        public int hesapla(int a, int b)
        {
            return a - b;
        }
    }
}