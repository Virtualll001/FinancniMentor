using FinancniMentor.Server.Storage;
using FinancniMentor.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace FinancniMentor.Server
{
    public static class SampleData
    {
        public static void AddVydelkyRepository(this IServiceCollection services)
        {
            var dnes = DateTime.Today;
            var minulyMesic = DateTime.Today.AddMonths(-1);
            var predminulyMesic = DateTime.Today.AddMonths(-2);

            var earningRepository = new MemoryRepository<Vydelek>();

            earningRepository.Add(new Vydelek { Datum = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 25), Castka = 61000, Kategorie = VydelekKategorie.Plat, Subjekt = "Měsíční plat" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 12), Castka = 3440, Kategorie = VydelekKategorie.OSVC, Subjekt = "OSVČ klient A" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 25), Castka = 61000, Kategorie = VydelekKategorie.Plat, Subjekt = "Měsíční plat" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 12), Castka = 3790, Kategorie = VydelekKategorie.OSVC, Subjekt = "OSVČ klient A" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 4), Castka = 1080, Kategorie = VydelekKategorie.KapitalovyZisk, Subjekt = "ETF dividendy" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(dnes.Year, dnes.Month, 25), Castka = 61000, Kategorie = VydelekKategorie.Plat, Subjekt = "Měsíční plat" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(dnes.Year, dnes.Month, 14), Castka = 4680, Kategorie = VydelekKategorie.OSVC, Subjekt = "OSVČ klient A" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(dnes.Year, dnes.Month, 12), Castka = 2500, Kategorie = VydelekKategorie.Flipping, Subjekt = "stará televize" });

            services.AddSingleton<IRepository<Vydelek>>(earningRepository);
        }

        public static void AddVydajeRepository(this IServiceCollection services)
        {
            var dnes = DateTime.Today;
            var minulyMesic = DateTime.Today.AddMonths(-1);
            var predminulyMesic = DateTime.Today.AddMonths(-2);

            var vydajeRepository = new MemoryRepository<Vydaj>();

            vydajeRepository.Add(new Vydaj { Datum = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 8), Castka = 4050, Kategorie = VydajKategorie.Bydleni, Subjekt = "Nájem" });
            vydajeRepository.Add(new Vydaj { Datum = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 18), Castka = 640, Kategorie = VydajKategorie.Vzdelani, Subjekt = "Knihy" });
            vydajeRepository.Add(new Vydaj { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 6), Castka = 4050, Kategorie = VydajKategorie.Bydleni, Subjekt = "Nájem" });
            vydajeRepository.Add(new Vydaj { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 15), Castka = 3200, Kategorie = VydajKategorie.Zdravi, Subjekt = "Zubař" });
            vydajeRepository.Add(new Vydaj { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 27), Castka = 350, Kategorie = VydajKategorie.Zabava, Subjekt = "Harry Potter - kino" });
            vydajeRepository.Add(new Vydaj { Datum = new DateTime(dnes.Year, dnes.Month, 7), Castka = 4050, Kategorie = VydajKategorie.Bydleni, Subjekt = "Nájem" });
            vydajeRepository.Add(new Vydaj { Datum = new DateTime(dnes.Year, dnes.Month, 13), Castka = 6000, Kategorie = VydajKategorie.Zabava, Subjekt = "Nová televize" });

            services.AddSingleton<IRepository<Vydaj>>(vydajeRepository);
        }
    }
}
