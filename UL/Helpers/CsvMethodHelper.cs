using CsvHelper.Configuration;
using CsvHelper;
using ProyectoMerck.Models.Dtos;
using System.Globalization;
using Common_Layer.Models.Entities;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common_Layer.Models.Dtos;

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

        public static string WriteCsvData(IEnumerable<ClinicConsultationDto> data)
        {
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(data);
                return writer.ToString();
            }
        }

        public static FileContentResult DownloadCsvFile(string data, string fileName)
        {

            var byteArray = Encoding.UTF8.GetBytes(data);

            return new FileContentResult(byteArray, "text/csv")
            {
                FileDownloadName = fileName
            };
        }

    }
}
