using System;
using System.Collections.Generic;

namespace EvCihazYonetimi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>
            {
                new Cihaz(1, "Salon Lambası", CihazTuru.Lamba),
                new Cihaz(2, "Oturma Odası Kliması", CihazTuru.Klima),
                new Cihaz(3, "Giriş Güvenlik Sistemi", CihazTuru.GuvenlikSistemi)
            };

            while (true)
            {
                Console.WriteLine("\n--- Ev Cihaz Yönetim Sistemi ---");
                Console.WriteLine("1. Cihazları Listele");
                Console.WriteLine("2. Yeni Cihaz Ekle");
                Console.WriteLine("3. Cihaz Aç");
                Console.WriteLine("4. Cihaz Kapat");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();
                Console.WriteLine();

                switch (secim)
                {
                    case "1":
                        if (cihazlar.Count == 0)
                        {
                            Console.WriteLine("Sistemde kayıtlı cihaz bulunmuyor.");
                        }
                        else
                        {
                            foreach (Cihaz cihaz in cihazlar)
                            {
                                cihaz.BilgileriGoster();
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Cihaz Kimliği (ID): ");
                        if (!int.TryParse(Console.ReadLine(), out int yeniKimlik))
                        {
                            Console.WriteLine("Hata: Geçerli bir sayısal kimlik giriniz.");
                            break;
                        }

                        bool kimlikVarMi = false;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == yeniKimlik)
                            {
                                kimlikVarMi = true;
                                break;
                            }
                        }

                        if (kimlikVarMi)
                        {
                            Console.WriteLine("Hata: Aynı kimliğe sahip bir cihaz zaten mevcut.");
                            break;
                        }

                        Console.Write("Cihaz Adı: ");
                        string yeniAd = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(yeniAd))
                        {
                            Console.WriteLine("Hata: Cihaz adı boş bırakılamaz.");
                            break;
                        }

                        Console.WriteLine("Cihaz Türü Seçiniz (1: Lamba, 2: Klima, 3: Güvenlik Sistemi): ");
                        string turSecim = Console.ReadLine();
                        CihazTuru secilenTur;

                        if (turSecim == "1")
                        {
                            secilenTur = CihazTuru.Lamba;
                        }
                        else if (turSecim == "2")
                        {
                            secilenTur = CihazTuru.Klima;
                        }
                        else if (turSecim == "3")
                        {
                            secilenTur = CihazTuru.GuvenlikSistemi;
                        }
                        else
                        {
                            Console.WriteLine("Hata: Geçersiz cihaz türü seçimi.");
                            break;
                        }

                        cihazlar.Add(new Cihaz(yeniKimlik, yeniAd.Trim(), secilenTur));
                        Console.WriteLine("Cihaz başarıyla eklendi.");
                        break;

                    case "3":
                        Console.Write("Açmak istediğiniz cihazın kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int acilacakKimlik))
                        {
                            Console.WriteLine("Hata: Geçerli bir kimlik giriniz.");
                            break;
                        }

                        Cihaz acilacakCihaz = null;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == acilacakKimlik)
                            {
                                acilacakCihaz = cihaz;
                                break;
                            }
                        }

                        if (acilacakCihaz == null)
                        {
                            Console.WriteLine("Hata: Belirtilen kimliğe sahip cihaz bulunamadı.");
                        }
                        else
                        {
                            acilacakCihaz.Ac();
                            Console.WriteLine($"{acilacakCihaz.Ad} açıldı.");
                        }
                        break;

                    case "4":
                        Console.Write("Kapatmak istediğiniz cihazın kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int kapatilacakKimlik))
                        {
                            Console.WriteLine("Hata: Geçerli bir kimlik giriniz.");
                            break;
                        }

                        Cihaz kapatilacakCihaz = null;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == kapatilacakKimlik)
                            {
                                kapatilacakCihaz = cihaz;
                                break;
                            }
                        }

                        if (kapatilacakCihaz == null)
                        {
                            Console.WriteLine("Hata: Belirtilen kimliğe sahip cihaz bulunamadı.");
                        }
                        else
                        {
                            kapatilacakCihaz.Kapat();
                            Console.WriteLine($"{kapatilacakCihaz.Ad} kapatıldı.");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Hata: Geçersiz bir seçim yaptınız.");
                        break;
                }
            }
        }
    }
}
