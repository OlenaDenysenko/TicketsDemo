﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketsDemo.Data.Entities;
using TicketsDemo.Domain.Interfaces;

namespace TicketsDemo.App_Start
{
    public class TicketServiceLoggingDecorator : ITicketService
    {
        private ITicketService _decoratedObject;
        private ILogger _logger;

        public TicketServiceLoggingDecorator(ITicketService DecoratedObject, ILogger logger)
        {
            _decoratedObject = DecoratedObject;
            _logger = logger;
        }
        public Ticket CreateTicket(int reservationId, string firstName, string lastName)
        {

            string message = string.Format("Attempt to buy a ticket: Id {0}, firstName {1}, lastName {2}", reservationId, firstName, lastName);
            _logger.Log(message, LogSeverity.Info);
            return _decoratedObject.CreateTicket(reservationId, firstName, lastName);
        }

    }
}