using ProjectTest.Application.Models.MailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Contracts.MailSender
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
