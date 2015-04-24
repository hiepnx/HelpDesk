using HelpDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Services.Base
{
    public interface INotificationQueuingService
    {
        void AddTicketEventNotifications(TicketComment comment, bool isNewOrGiveUpTicket, string[] subscribers);
    }
}
