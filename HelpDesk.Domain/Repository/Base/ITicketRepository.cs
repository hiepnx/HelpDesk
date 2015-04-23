﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Dto;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Utilities.Pagination;

namespace HelpDesk.Domain.Repository.Base
{
    public interface ITicketRepository
    {
        /// <summary>
        /// Occurs when changes are saved.
        /// </summary>
        event EventHandler<TicketEventArgs> Saving;

        /// <summary>
        /// Gets a specific ticket.
        /// </summary>
        /// <param name="ticketId">The ticket id to fetch.</param>
        /// <returns></returns>
        Ticket GetTicket(int ticketId);

        /// <summary>
        /// Get a paged lists of tickets.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortColumns">The sort columns.</param>
        /// <param name="filterColumns">The filter columns.</param>
        /// <returns></returns>
        IPagination<Ticket> ListTickets(int pageIndex, int pageSize, List<TicketListSortColumn> sortColumns, List<TicketListFilterColumn> filterColumns, bool includeComments);

        /// <summary>
        /// Gets a list of tickets from an ordered list of ticket IDs.
        /// </summary>
        /// <param name="orderedTicketList">The ordered ticket list.</param>
        /// <returns>Tickets in the same order as the supplied ticket IDs</returns>
        IEnumerable<Ticket> ListTickets(SortedList<int, int> orderedTicketList, bool includeComments);

        /// <summary>
        /// Creates a new ticket.
        /// </summary>
        /// <param name="newTicket">The new ticket.</param>
        /// <param name="commit">if set to <c>true</c> save new ticket to DB.</param>
        /// <returns>
        /// 	<c>true</c> if the ticket is created successfully.
        /// </returns>
        bool CreateTicket(Ticket newTicket, bool commit);

        /// <summary>
        /// Updates the ticket.
        /// </summary>
        /// <param name="ticket">The ticket to update.</param>
        /// <returns></returns>
        bool UpdateTicket(Ticket ticket);

        /// <summary>
        /// Removes the attachment.
        /// </summary>
        /// <param name="attachment">The attachment to remove.</param>
        /// <param name="commit">if set to <c>true</c> save change to DB.</param>
        /// <returns></returns>
        bool RemoveAttachment(TicketAttachment attachment, bool commit);

        /// <summary>
        /// Adds a pending attachment.
        /// </summary>
        /// <param name="attachment">The attachment to add.</param>
        /// <param name="commit">if set to <c>true</c> save pending attachment to DB.</param>
        /// <returns></returns>
        bool AddPendingAttachment(TicketAttachment attachment, bool commit);

        /// <summary>
        /// Gets the pending attachment.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <returns></returns>
        TicketAttachment GetPendingAttachment(int fileId);

        /// <summary>
        /// Gets the ticket attachment.
        /// </summary>
        /// <param name="fileId">The file id of the attachment.</param>
        /// <returns></returns>
        TicketAttachment GetTicketAttachment(int fileId);

        /// <summary>
        /// Cleans up pending attachments that were not committed to a ticket in a timely manner.
        /// </summary>
        /// <param name="hoursOld">The number of hours old a pending attachment should be before being removed.</param>
        /// <returns></returns>
        bool CleanUpDerelictAttachments(int hoursOld);

        /// <summary>
        /// Gets the list of changes for a ticket.
        /// </summary>
        /// <param name="modifiedTicket">The modified ticket.</param>
        /// <param name="commit">if set to <c>true</c> commit changes to the DB.</param>
        /// <returns>A dictionary containing the fields and values that have been changed.</returns>
        Dictionary<string, object> GetTicketChanges(Ticket modifiedTicket);

        /// <summary>
        /// Clears the tags of a ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="commit">if set to <c>true</c> deletes the tags from the DB.</param>
        /// <returns></returns>
        bool ClearTags(Ticket ticket, bool commit);

        /// <summary>
        /// Gets the distinct tags starting with a specified value.
        /// </summary>
        /// <param name="textToCheck">The starting text from which to locate tags.</param>
        /// <param name="maxTagsToReturn">The max number of possible matches to return.</param>
        /// <returns></returns>
        List<string> GetDistinctTagsStartingWith(string textToCheck, int maxTagsToReturn);

    }
}
