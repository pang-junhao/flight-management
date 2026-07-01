// Responsible for calculation and details for Economy Class Ticket
using System;
namespace CustomProgram
{
    public class EconomyTicket : Ticket
    {
         public override string GetTicketType()
        {
            return "Economy";                           
        }

        public override double GetPrice(Flight flight)
        {
            switch (flight.Region)
            {
                case "Local":
                    return 250.0;
                case "Regional":
                    return 700.0;
                case "International":
                    return 2800.0;
                default:
                    throw new ArgumentException("Unknown region.");
            }
        }
    }
}