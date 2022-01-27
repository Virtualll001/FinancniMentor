using System.Collections.Generic;

namespace FinancniMentor.Client.Services
{
    public class MonthlyData
    {
        public ICollection<MonthlyItem> Data { get; set; }
        public string Label { get; set; }
    }
}
