using CleanArchitecture.Application.Services;
using GenericEmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services;
public sealed class MailService : IMailService
{
    public async Task<string> SendMailAsync(string email, string subject, string body)
    {
        EmailConfigurations configurations = new(
                                        Smtp: "smtp.gmail.com",
                                        Password: "sjya zmqg xmau mcgm",
                                        Port: 587,
                                        SSL: false,
                                        Html: true);

        EmailModel<Stream> model = new(
                          Configurations: configurations,
                          FromEmail: "mehmetcanunaldi@gmail.com",
                          ToEmails: new List<string> { email },
                          Subject: subject,
                          Body: body,
                          Attachments: null);


        string emailSendResponse = await EmailService.SendEmailWithMailKitAsync(model);

        return emailSendResponse;

    }
}
