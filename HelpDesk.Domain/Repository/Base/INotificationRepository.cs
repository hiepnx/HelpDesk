﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Models;

namespace HelpDesk.Domain.Repository.Base
{
    public interface INotificationRepository
    {
        IOrderedQueryable<TicketEventNotification> GetQueuedNotifications();

        bool UpdateNotifications(IEnumerable<TicketEventNotification> notifications);

        /// <summary>
        /// Ensures a valid next delivery date for any newly queud notifications when a notification has been rescheduled.
        /// </summary>
        /// <param name="ticketId">The ticket id.</param>
        /// <param name="notifyUser">The notify user.</param>
        /// <param name="lastSentCommentId">The last sent comment id.</param>
        /// <param name="nextDeliveryAttemptDate">The next delivery attempt date.</param>
        /// <remarks>
        /// While the system is processing ticket emails, new notifications could get queued up.
        /// This method should be called if the sending process has to re-schedule a notifiaciton 
        /// for a later re-try attempt. This will keep the notification that was being processed from
        /// having it's next delivery date kicked out further than newer comments that have queued up.
        /// It should look for any new notifications that are queued for the same user and ticket, 
        /// and ensure that their next-delivery date remains greater than the last one that was processed 
        /// and rescheduled.
        /// </remarks>
        void EnsureValidNextDeliveryDateForNewlyQueudNotifications(int ticketId, string notifyUser, int lastSentCommentId, DateTime nextDeliveryAttemptDate);
    }
}
