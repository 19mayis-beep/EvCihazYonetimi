using System;

namespace EvCihazYonetimi
{
    public class Cihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; private set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            AcikMi = false;
        }

        public void Ac()
        {
            AcikMi = true;
        }

        public void Kapat()
        {
            AcikMi = false;
        }

        public void BilgileriGoster()
        {
            string durum = AcikMi ? "Açık" : "Kapalı";
            Console.WriteLine($"Kimlik: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {durum}");
        }
    }
}
