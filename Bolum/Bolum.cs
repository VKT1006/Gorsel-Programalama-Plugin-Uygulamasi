using Plugin;

namespace Bolum
{
    public class Bolum : IHesap
    {
        public string isim => "/";

        public int hesapla(int a, int b)
        {
            return a / b;
        }
    }
}