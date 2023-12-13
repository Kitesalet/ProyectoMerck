using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using SendGrid;
using ProyectoMerck.Models.Interfaces;

namespace ProyectoMerck.Helpers

{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_configuration["Email:FromAddress"], _configuration["Email:FromName"]);
            var toAddress = new EmailAddress(to);
            var plainTextContent = body;
            var htmlContent = body;

            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, plainTextContent, htmlContent);

            try
            {
                var response = await client.SendEmailAsync(msg);

                if(response.IsSuccessStatusCode == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex);
                
                return false;

            }

            
        }

    }
}



