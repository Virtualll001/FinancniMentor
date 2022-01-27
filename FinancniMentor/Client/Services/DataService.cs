using FinancniMentor.Shared;
using System.Net.Http.Json;

namespace FinancniMentor.Client.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private readonly int _currentYear = DateTime.Today.Year;

        public DataService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<ICollection<YearlyItem>> LoadCurrentYearEarnings()
        {
            var data = await _httpClient.GetFromJsonAsync<Vydelek[]>("api/Vydelky");
            return data.Where(vydelek => vydelek.Datum >= new DateTime(_currentYear, 1, 1)
                && vydelek.Datum <= new DateTime(_currentYear, 12, 31))
                .GroupBy(vydelek => vydelek.Datum.Month)
                .OrderBy(vydelek => vydelek.Key)
                .Select(vydelek => new YearlyItem
                {
                    Month = GetMonthAsText(vydelek.Key, _currentYear),
                    Amount = vydelek.Sum(item => item.Castka)
                })
                .ToList();
        }

        public async Task<ICollection<YearlyItem>> LoadCurrentYearExpenses()
        {
            var data = await _httpClient.GetFromJsonAsync<Vydaj[]>("api/Vydaje");
            return data.Where(vydaj => vydaj.Datum >= new DateTime(_currentYear, 1, 1)
                && vydaj.Datum <= new DateTime(_currentYear, 12, 31))
                .GroupBy(vydaj => vydaj.Datum.Month)
                .OrderBy(vydaj => vydaj.Key)
                .Select(vydaj => new YearlyItem
                {
                    Month = GetMonthAsText(vydaj.Key, _currentYear),
                    Amount = vydaj.Sum(item => item.Castka)
                })
                .ToList();
        }

        public async Task<ThreeMonthsData> LoadLast3MonthsEarnings()
        {
            var currentMonth = DateTime.Today.Month;
            var lastMonth = DateTime.Today.AddMonths(-1);
            var previousMonth = DateTime.Today.AddMonths(-2);

            return new ThreeMonthsData
            {
                CurrentMonth = new MonthlyData
                {
                    Data = await GetMonthlyEarnings(currentMonth, _currentYear),
                    Label = GetMonthAsText(currentMonth, _currentYear)
                },
                LastMonth = new MonthlyData
                {
                    Data = await GetMonthlyEarnings(lastMonth.Month, lastMonth.Year),
                    Label = GetMonthAsText(lastMonth.Month, lastMonth.Year)
                },
                PreviousMonth = new MonthlyData
                {
                    Data = await GetMonthlyEarnings(previousMonth.Month, previousMonth.Year),
                    Label = GetMonthAsText(previousMonth.Month, previousMonth.Year)
                }
            };
        }

        private async Task<ICollection<MonthlyItem>> GetMonthlyEarnings(int month, int year)
        {
            var data = await _httpClient.GetFromJsonAsync<Vydelek[]>("api/Vydelky");
            return data.Where(vydelek => vydelek.Datum >= new DateTime(year, month, 1)
                && vydelek.Datum <= new DateTime(year, month, LastDayOfMonth(month, year)))
                .GroupBy(vydelek => vydelek.Kategorie)
                .Select(vydelek => new MonthlyItem
                {
                    Amount = vydelek.Sum(item => item.Castka),
                    Category = vydelek.Key.ToString()
                })
                .ToList();
        }

        public async Task<ThreeMonthsData> LoadLast3MonthsExpenses()
        {
            var currentMonth = DateTime.Today.Month;
            var lastMonth = DateTime.Today.AddMonths(-1);
            var previousMonth = DateTime.Today.AddMonths(-2);

            return new ThreeMonthsData
            {
                CurrentMonth = new MonthlyData
                {
                    Data = await GetMonthlyExpenses(currentMonth, _currentYear),
                    Label = GetMonthAsText(currentMonth, _currentYear)
                },
                LastMonth = new MonthlyData
                {
                    Data = await GetMonthlyExpenses(lastMonth.Month, lastMonth.Year),
                    Label = GetMonthAsText(lastMonth.Month, lastMonth.Year)
                },
                PreviousMonth = new MonthlyData
                {
                    Data = await GetMonthlyExpenses(previousMonth.Month, previousMonth.Year),
                    Label = GetMonthAsText(previousMonth.Month, previousMonth.Year)
                }
            };
        }

        private async Task<ICollection<MonthlyItem>> GetMonthlyExpenses(int month, int year)
        {
            var data = await _httpClient.GetFromJsonAsync<Vydaj[]>("api/Vydaje");
            return data.Where(vydaj => vydaj.Datum >= new DateTime(year, month, 1)
                && vydaj.Datum <= new DateTime(year, month, LastDayOfMonth(month, year)))
                .GroupBy(vydaj => vydaj.Kategorie)
                .Select(vydaj => new MonthlyItem
                {
                    Amount = vydaj.Sum(item => item.Castka),
                    Category = vydaj.Key.ToString()
                })
                .ToList();
        }

        private static int LastDayOfMonth(int month, int year)
        {
            return DateTime.DaysInMonth(year, month);
        }

        private static string GetMonthAsText(int month, int year)
        {
            return month switch
            {
                1 => $"Leden {year}",
                2 => $"Únor {year}",
                3 => $"Březen {year}",
                4 => $"Duben {year}",
                5 => $"Květen {year}",
                6 => $"Červen {year}",
                7 => $"Červenec {year}",
                8 => $"Srpen {year}",
                9 => $"Září {year}",
                10 => $"Říjen {year}",
                11 => $"Listopad {year}",
                12 => $"Prosinec {year}",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
