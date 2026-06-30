// Responsible to search flight, add and view bookings, and cancel booking
#nullable disable
using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public class Passenger : User
    {
        private List<Booking> _bookings;

        // Starts at 1 and increments each time a new booking is made
        private static int nextId = 1;

        public List<Booking> Bookings
        {
            get { return _bookings;}
            set { _bookings = value;} 
        }

        public Passenger(string name) : base(name)
        {
            _bookings = new List<Booking>();
        }
        
        public void SearchFlight(Admin admin)
        {
            Console.WriteLine("Enter Flight Number to search: ");
            string flightNumber = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                Console.WriteLine("Flight number cannot be empty");
                return;
            }

            Flight foundFlight = admin.SearchFlight(flightNumber);

            if (foundFlight != null)
            {
                Console.WriteLine("\nFlight Found!\n");
                foundFlight.DisplayFlight();
            }
            else
            {
                Console.WriteLine("\nFlight not found.");
            }
        }

        public void ViewBookings()
        {
            if (Bookings.Count == 0)
            {
                Console.WriteLine("\nNo bookings found.");
                return;
            }

            Console.WriteLine("\n===== YOUR BOOKINGS =====");

            foreach (Booking booking in Bookings)
            {
                booking.DisplayBooking();
                Console.WriteLine();
            }
        }

        public void BookFlight(Admin admin)
        {
            Console.WriteLine("\n===== AVAILABLE FLIGHTS =====");
            admin.ViewAllFlights();

            Console.WriteLine("\nEnter Flight Number: ");
            string flightNumber = Console.ReadLine() ?? "";

            Flight selectedFlight = admin.SearchFlight(flightNumber);

            if (selectedFlight == null)
            {
                Console.WriteLine("Flight does not exist.");
                return;
            }

            if (!selectedFlight.HasAvailableSeats())
            {
                Console.WriteLine("Flight is full.");
                return;
            }

            Console.WriteLine("Enter seat number (A1 - F27): ");
            string seatNumber = Console.ReadLine() ?? "";

            seatNumber = seatNumber.ToUpper();

            if (!selectedFlight.IsSeatAvailable(seatNumber))
            {
                Console.WriteLine("Seat already been booked.");
                return;
            }
           
            if (string.IsNullOrWhiteSpace(seatNumber))
            {
                Console.WriteLine("Seat number cannot be empty");
                return;
            }

            int quantity = 1;

            if (selectedFlight.BookedSeats.Count + quantity > selectedFlight.Capacity)
            {
                Console.WriteLine("Not enough seats");
                return;
            }

            Console.WriteLine("\nSelect Ticket Type:");
            Console.WriteLine("1. Economy Class");
            Console.WriteLine("2. Business Class");
            Console.WriteLine("Enter choice of ticket: ");

            string choice = Console.ReadLine() ?? "";

            // Polymorphism implementation
            Ticket ticket;

            if (choice == "1")
            {
                ticket = new EconomyTicket();
            }
            else if (choice == "2")
            {
                ticket = new BusinessTicket();
            }
            else
            {
                Console.WriteLine("Invalid ticket choice.");
                return;
            }

            // Gets passenger name for Booking Receipt
            Console.WriteLine("\nEnter Passenger Name: ");
            string passengerName = Console.ReadLine() ?? "";

            // Creates Passenger object with name input
            Passenger passenger = new Passenger(passengerName);

            if (string.IsNullOrWhiteSpace(passengerName))
            {
                Console.WriteLine("Passenger name cannot be empty.");
                return;
            }

            // Create booking Id
            string status = "Confirmed";

            // BK is prefix, :D3 is 3 digit format (BK001)
            string bookingId = $"BK{nextId:D3}";
            nextId++;

            // Creates booking object
            Booking booking = new Booking(bookingId, passenger, ticket, selectedFlight, seatNumber, quantity, status);
            
            // For the flight the passenger picked, record the seat number in that flight’s BookedSeats list.”
            selectedFlight.BookedSeats.Add(seatNumber);


            // Creates PaymentProcessor object
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            bool PaymentSuccess = paymentProcessor.ProcessPayment(booking);

            // Validation
            if (!PaymentSuccess)
            {
                Console.WriteLine("Booking failed");
                return;
            }

            // Adds to booking object
            Bookings.Add(booking);

            Console.WriteLine("\nBooking successful!\n");
            booking.DisplayBooking();
        }

        // Removes and free seats
        public void CancelBooking()
        {
            if (Bookings.Count == 0)
            {
                Console.WriteLine("No bookings available");
                return;
            }

            Console.WriteLine("\n===== YOUR BOOKINGS =====");

            foreach (Booking booking in Bookings)
            {
                booking.DisplayBooking();
                Console.WriteLine();
            }

            Console.WriteLine("Enter Booking ID to Cancel: ");
            string bookingId = Console.ReadLine() ?? "";

            Booking foundBooking = null;

            foreach (Booking booking in Bookings)
            {
                if (booking.BookingId == bookingId)
                {
                    foundBooking = booking;
                    break;
                }
            }

            if (foundBooking == null)
            {
                Console.WriteLine("Booking was not found.");
                return;
            }

            // Remove the seat from the flight’s BookedSeats list
            foundBooking.Flight.BookedSeats.Remove(foundBooking.SeatNumber);

            // Remove booking from passenger's booking list
            Bookings.Remove(foundBooking);

            
            Console.WriteLine("\nBooking cancelled successfully");

            foundBooking.Status = "Cancelled";
        }
    }
}