// Responsible for calculation and details for Business Class Ticket
using System;
namespace CustomProgram
{
    public class BusinessTicket : Ticket
    {
        public override string GetTicketType()
        {
            return "Business";
        }

        public override double GetPrice(Flight flight)
        {
            if (flight.Region != "Local" && flight.Region != "Regional" && flight.Region != "International")
            {
                throw new ArgumentException("Unknown region.");
            }

            switch (flight.Region)
            {
                case "Local":
                    return 900.00;
                case "Regional":
                    return 2200.00;
                case "International":
                    return 7500.00;
                default:
                    return 0.0;
            }
        }
    }
}