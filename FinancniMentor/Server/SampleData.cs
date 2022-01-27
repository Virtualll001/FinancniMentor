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

            earningRepository.Add(new Vydelek { Datum = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 25), Castka = 2480, Kategorie = VydelekKategorie.Plat, Subjekt = "Měsíční plat" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 12), Castka = 440, Kategorie = VydelekKategorie.OSVC, Subjekt = "OSVČ klient A" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 25), Castka = 2480, Kategorie = VydelekKategorie.Plat, Subjekt = "Měsíční plat" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 12), Castka = 790, Kategorie = VydelekKategorie.OSVC, Subjekt = "OSVČ klient A" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(minulyMesic.Year, minulyMesic.Month, 4), Castka = 387, Kategorie = VydelekKategorie.KapitalovyZisk, Subjekt = "ETF dividendy" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(dnes.Year, dnes.Month, 25), Castka = 2480, Kategorie = VydelekKategorie.Plat, Subjekt = "Měsíční plat" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(dnes.Year, dnes.Month, 14), Castka = 680, Kategorie = VydelekKategorie.OSVC, Subjekt = "OSVČ klient A" });
            earningRepository.Add(new Vydelek { Datum = new DateTime(dnes.Year, dnes.Month, 12), Castka = 245, Kategorie = VydelekKategorie.Flipping, Subjekt = "stará televize" });

            services.AddSingleton<IRepository<Vydelek>>(earningRepository);
        }

        //public static void AddNakladyRepository(this IServiceCollection services)
        //{
        //    var dnes = DateTime.Today;
        //    var minulyMesic = DateTime.Today.AddMonths(-1);
        //    var predminulyMesic = DateTime.Today.AddMonths(-2);

        //    var expensesRepository = new MemoryRepository<Expense>();

        //    expensesRepository.Add(new Expense { Date = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 8), Castka = 1050, Kategorie = ExpenseKategorie.Housing, Subjekt = "Rent" });
        //    expensesRepository.Add(new Expense { Date = new DateTime(predminulyMesic.Year, predminulyMesic.Month, 18), Castka = 140, Kategorie = ExpenseKategorie.Education, Subjekt = "Books" });
        //    expensesRepository.Add(new Expense { Date = new DateTime(minulyMesic.Year, minulyMesic.Month, 6), Castka = 1050, Kategorie = ExpenseKategorie.Housing, Subjekt = "Rent" });
        //    expensesRepository.Add(new Expense { Date = new DateTime(minulyMesic.Year, minulyMesic.Month, 15), Castka = 415, Kategorie = ExpenseKategorie.Healthcare, Subjekt = "H-Care" });
        //    expensesRepository.Add(new Expense { Date = new DateTime(minulyMesic.Year, minulyMesic.Month, 27), Castka = 76, Kategorie = ExpenseKategorie.Entertainment, Subjekt = "Harry Potter Series" });
        //    expensesRepository.Add(new Expense { Date = new DateTime(dnes.Year, dnes.Month, 7), Castka = 1050, Kategorie = ExpenseKategorie.Housing, Subjekt = "Rent" });
        //    expensesRepository.Add(new Expense { Date = new DateTime(dnes.Year, dnes.Month, 13), Castka = 870, Kategorie = ExpenseKategorie.Entertainment, Subjekt = "New TV" });

        //    services.AddSingleton<IRepository<Expense>>(expensesRepository);
        //}
    }
}
