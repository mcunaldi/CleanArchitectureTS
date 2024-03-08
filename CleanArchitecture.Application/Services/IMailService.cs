using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services;
public interface IMailService
{
    Task<string> SendMailAsync(string email, string subject, string body);
}
