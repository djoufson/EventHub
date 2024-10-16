using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Services.EmailService;

namespace Event.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}