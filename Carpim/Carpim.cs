using Plugin;

namespace Carpim
{
    public class Carpim : IHesap
    {
        public string isim => "*";

        public int hesapla(int a, int b)
        {
            return a * b;
        }
    }
}