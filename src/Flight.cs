// Responsible for storing flight details
using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public class Flight
    {
        private string _flightNumber;
        private string _destination;
        private string _region;
        private List<string> _bookedSeats;
        private int _capacity;

        public Flight(string flightnumber, string destination, string region, int capacity)
        {
            _flightNumber = flightnumber;
            _destination = destination;
            _region = region;
            _bookedSeats = new List<string>();
            _capacity = capacity;
        }

        public string FlightNumber
        {
            get { return _flightNumber;}
            set { _flightNumber = value;}
        }

        public string Destination
        {
            get { return _destination;}
            set { _destination = value;}
        }

        public string Region
        {
            get { return _region;}
            set { _region = value;}
        }

        public List<string> BookedSeats
        {
            get { return _bookedSeats;}
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }

        // Shows how many seats available
        public int AvailableSeats
        {
            get { return Capacity - BookedSeats.Count;}
        }

        
        // checks whether the particular seat is available or not
        public bool IsSeatAvailable(string seatNumber) 
        {
            return !BookedSeats.Contains(seatNumber);
        }

        // Checks for available seats for bookings
        public bool HasAvailableSeats()
        {
            return BookedSeats.Count < Capacity;
        }

        public void DisplayFlight()
        {
            Console.WriteLine($"Flight: {FlightNumber}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"Region: {Region}");
            Console.WriteLine($"Capacity: {Capacity}");
            Console.WriteLine($"Booked Seats: {BookedSeats.Count}");
            Console.WriteLine($"Available Seats: {AvailableSeats}");
        }
    }
}