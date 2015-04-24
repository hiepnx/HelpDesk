using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Services.Base
{
    public interface INotificationSendingService
    {
        void ProcessWaitingTicketEventNotifications();
    }
}
