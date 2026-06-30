// Responsible for managing flights (adding, removing, updating, seaching, and viewing flights)
#nullable disable
using System;
namespace CustomProgram
{
    public class Admin : User 
    {
        private List<Flight> managedFlights;

        public List<Flight> ManagedFlights
        {
            get { return managedFlights;}
            set { managedFlights = value;}
        }

        public Admin(string name) : base(name)
        {
            managedFlights = new List<Flight>();
            managedFlights.Add(new Flight("MH001", "Penang", "Local", 162));
            managedFlights.Add(new Flight("MH002", "Singapore", "Regional", 162));
            managedFlights.Add(new Flight("MH003", "Kuala Lumpur", "Local", 162));
            managedFlights.Add(new Flight("MH004", "Jakarta", "Regional", 162));
            managedFlights.Add(new Flight("MH005", "Korea", "International", 162));
        }

        public void AddFlight()
        {   
            Console.WriteLine("Enter Flight Number: ");
            string FlightNumber = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Destination: ");
            string Destination = Console.ReadLine() ?? "";

            string Region = "";
            while (true)
            {
                Console.WriteLine("Enter Region (Local/Regional/International): ");
                Region = Console.ReadLine() ?? "";

                if (Region == "Local" || Region == "Regional" || Region == "International")
                {
                    break;
                }

                Console.WriteLine("Invalid region. Please try again");
            }
                
            if (string.IsNullOrWhiteSpace(FlightNumber) || string.IsNullOrWhiteSpace(Destination) || string.IsNullOrWhiteSpace(Region))
            {
                Console.WriteLine("Invalid input. Fields must not be empty.");
                return;
            }

            foreach (Flight flight in managedFlights)
            {
                if (flight.FlightNumber == FlightNumber)
                {
                    Console.WriteLine("Flight number already exists.");
                    return;
                }
            }

            managedFlights.Add(new Flight(FlightNumber, Destination, Region, 162));
            Console.WriteLine($"Flight {FlightNumber} to {Destination} ({Region}) added successfully!");
        }   

        public void RemoveFlight()
        {
            Console.WriteLine("Enter Flight Number to remove: ");
            string NumInput = Console.ReadLine() ?? "";

            // Flight Number Error Validation
            if (string.IsNullOrWhiteSpace(NumInput))
            {
                Console.WriteLine("Flight number cannot be empty.");
                return;
            }

            bool found = false;
            for (int i = 0; i < managedFlights.Count; i++)
            {
                if (managedFlights[i].FlightNumber == NumInput)
                {
                    managedFlights.RemoveAt(i);
                    Console.WriteLine($"Flight {NumInput} was successfully deleted.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Flight {NumInput} was not found.");
            }
        }

        public void UpdateFlight()
        {
            Console.WriteLine("Enter Flight Number to update: ");
            string NumInput = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(NumInput))
            {
                Console.WriteLine("Flight number cannot be empty");
                return;
            }

            bool found = false;

            for (int i = 0; i < managedFlights.Count; i++)
            {
                if (managedFlights[i].FlightNumber == NumInput)
                {
            
                    Console.WriteLine("Enter Destination: ");
                    string Destination = Console.ReadLine() ?? "";

                    // Validation
                    if (string.IsNullOrWhiteSpace(Destination))
                    {
                        Console.WriteLine("Destination cannot be empty.");
                        return;
                    }

                    string Region = "";
                    while (true)
                    {
                        Console.WriteLine("Enter Region (Local/Regional/International): ");
                        Region = Console.ReadLine() ?? "";
                        
                        if (Region == "Local" || Region == "Regional" || Region == "International")
                        {
                            break;
                        }

                        Console.WriteLine("Invalid region. Please try again.");
                    }

                    managedFlights[i].Destination = Destination;
                    managedFlights[i].Region = Region;

                    Console.WriteLine("Flight update successfully!");

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Flight not found");
            }
        }

        public Flight SearchFlight(string flightNumber)
        {
            foreach (Flight flight in managedFlights)
            {
                if (flight.FlightNumber == flightNumber)
                {
                    return flight;
                }
            }
            return null;
        }

        public void ViewAllFlights()
        {
            Console.WriteLine("\n===== Flights managed by Admin =====");

            if (managedFlights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            foreach (Flight flight in managedFlights)
            {
                Console.WriteLine($"{flight.FlightNumber} - {flight.Destination} ({flight.Region})");
            } 
        }
    }
}