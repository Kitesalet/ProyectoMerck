using CsvHelper.Configuration;
using CsvHelper;
using ProyectoMerck.Models.Dtos;
using System.Globalization;

namespace ProyectoMerck.Helpers
{
    public static class CsvMethodHelper<T>
    {

        public static List<T> ReadCsvLocationData(string csvData)
        {

            using (var reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<T>().ToList();
            }

        }

    }
}
