using Plugin;

namespace Topla
{
    public class Topla : IHesap
    {
        public string isim => "+";

        public int hesapla(int a, int b)
        {
            return a + b;
        }
    }
}