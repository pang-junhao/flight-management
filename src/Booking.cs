// Responsible for record booking details
using System;
using CustomProgram;
namespace CustomProgram
{
    public class Booking 
    {
        private string _bookingId;
        private Passenger Passenger;
        private Ticket Ticket;
        private Flight _flight;
        private string _seatNumber;
        private int _quantity;
        private string _status;

        public Booking(string bookingId, Passenger passenger, Ticket ticket, Flight flight, string seatNumber, int quantity, string status)
        {
            _bookingId = bookingId;
            Passenger = passenger;
            Ticket = ticket;
            _flight = flight;
            _seatNumber = seatNumber;
            _quantity = quantity;
            _status = status;
        }

        public string BookingId
        {
            get { return _bookingId;}
        }

        public Flight Flight
        {
            get { return _flight;}
        }

        public string SeatNumber
        {
            get { return _seatNumber;}
        }

        public int Quantity
        {
            get { return _quantity;}
        }

        public string Status
        {
            get { return _status;}
            set { _status = value;}
        }
        
        public double CalculateTotal()
        {
            return Ticket.GetPrice(Flight) * Quantity;
        }
        
        public void DisplayBooking()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("     Booking Receipt     ");
            Console.WriteLine("=========================");

            Console.WriteLine($"Booking ID: {BookingId}");
            Console.WriteLine($"Passenger Name: {Passenger.Name}");
            Console.WriteLine($"Flight Number: {_flight.FlightNumber}");
            Console.WriteLine($"Destination: {_flight.Destination}");
            Console.WriteLine($"Region: {Flight.Region}");
            Console.WriteLine($"Seat Number: {_seatNumber}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Ticket Type: {Ticket.GetTicketType()}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Total Price: RM {CalculateTotal()}");
            Console.WriteLine($"=========================");
        }
    }
}