namespace FinancniMentor.Client.Services
{
    public interface IDataService
    {
        Task<ICollection<YearlyItem>> LoadCurrentYearVydaje();
        Task<ICollection<YearlyItem>> LoadCurrentYearVydelky();
        Task<ThreeMonthsData> LoadLast3MonthsVydaje();
        Task<ThreeMonthsData> LoadLast3MonthsVydelky();
    }

}
