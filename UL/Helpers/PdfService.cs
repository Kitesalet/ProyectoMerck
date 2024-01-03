using DinkToPdf.Contracts;
using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common_Layer.Models.Entities;

namespace Utility_Layer.Helpers
{
    public class PdfService
    {

        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdf(List<ClinicConsultation> data)
        {
            var htmlContent = GenerateHtmlFromList(data);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait,
            },
                Objects = {
                new ObjectSettings() {
                    HtmlContent = htmlContent,
                }
            }
            };

            return _converter.Convert(doc);
        }

        private string GenerateHtmlFromList(List<ClinicConsultation> data)
        {
            var stringer = new StringBuilder();

            stringer.Append("<html><body>");

            stringer.Append("<h1 style=" + "text-align: center" +">Consultas Clinicas</h1>");

            foreach (var clinicConsultation in data)
            {

                stringer.Append($"<h3>Id Clínica: {clinicConsultation.Id}</h3>" +
                                $"<br/>" +
                                $"<h4>Motivo Consulta: {clinicConsultation.ConsultMotiveMessage}" +
                                $"<h4>Url: {clinicConsultation.Url}" +
                                $"<h4>Fecha Creación: {clinicConsultation.CreatedTime}" +
                                $"<br/>" +
                                $"<br/>");

            }

            stringer.Append("</body></html>");

            return stringer.ToString();
        }

    }
}
