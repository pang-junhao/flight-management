// Parent class for Business/EconomyTicket
using System;
namespace CustomProgram
{
    public abstract class Ticket
    {
        public abstract double GetPrice(Flight flight);
        public abstract string GetTicketType();
    }
}