using CsvHelper.Configuration;
using CsvHelper;
using ProyectoMerck.Models.Dtos;
using System.Globalization;

namespace ProyectoMerck.Helpers
{
    public static class CsvMethodHelper
    {

        public static List<LocationDto> ReadCsvLocationData(string csvData)
        {

            using (var reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<LocationDto>().ToList();
            }

        }

    }
}
