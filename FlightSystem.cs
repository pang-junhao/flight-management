// Responsible for the Admin & Passenger Menu Option
using System;
namespace CustomProgram
{
    public class FlightSystem
    {
        private Admin admin;
        private Passenger passenger;

        public FlightSystem()
        {
            passenger = new Passenger("Guest Passenger");
            admin = new Admin("System Admin");
        }

        // Main Menu
        public void ShowMainMenu()
        {
            Console.WriteLine("\n===== Flight Management System =====");
            Console.WriteLine("1. Admin Menu");
            Console.WriteLine("2. Passenger Menu");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
        }

        // Admin Menu
        public void ShowAdminMenu()
        {
            Console.WriteLine("\n===== Admin Menu =====");
            Console.WriteLine("1. Add Flights");
            Console.WriteLine("2. View Flights");
            Console.WriteLine("3. Remove Flights");
            Console.WriteLine("4. Update Flights");
            Console.WriteLine("5. Search Flights");
            Console.WriteLine("6. Back");
            Console.Write("Enter your choice: ");
        }

        // Passenger Menu
        public void ShowPassengerMenu()
        {
            Console.WriteLine("\n===== Passenger Menu =====");
            Console.WriteLine("1. Search Flights");
            Console.WriteLine("2. Book Flight");
            Console.WriteLine("3. View Bookings");
            Console.WriteLine("4. Cancel Bookings");
            Console.WriteLine("5. Back");
            Console.Write("Enter your choice: ");
        }

        // Main execution loop of the system
        public void Run()
        {
            bool running = true;

            while (running)
            {
                ShowMainMenu();

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        RunAdminMenu();
                        break;
                    case "2":
                        RunPassengerMenu();
                        break;
                    case "3":
                        Console.WriteLine("Exiting system...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }


        public void RunAdminMenu()
        {
            bool adminRunning = true;

            while (adminRunning)
            {
                ShowAdminMenu();

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        admin.AddFlight();
                        break;
                    case "2":
                        admin.ViewAllFlights();
                        break;
                    case "3":
                        admin.RemoveFlight();
                        break;
                    case "4":
                        admin.UpdateFlight();
                        break;
                    case "5":
                        Console.WriteLine("Enter Flight Number: ");
                        string flightNo = Console.ReadLine() ?? "";

                        try
                        {
                            Flight flight = SearchFlight(flightNo);
                            Console.WriteLine("\nFlight Found:");
                            flight.DisplayFlight();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        
                        break;

                    case "6":
                        adminRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public void RunPassengerMenu()
        {
            bool passengerRunning = true;

            while (passengerRunning)
            {
                ShowPassengerMenu();

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        passenger.SearchFlight(admin);
                        break;
                    case "2":
                        passenger.BookFlight(admin);
                        break;
                    case "3":
                        passenger.ViewBookings();
                        break;
                    case "4":
                        passenger.CancelBooking();
                        break;
                    case "5":
                        passengerRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public Flight SearchFlight(string flightNo)
        {
            foreach (Flight flight in admin.ManagedFlights)
            {
                if (flight.FlightNumber == flightNo)
                {
                    return flight;
                }
            }
            throw new InvalidOperationException("Flight was not found");
        }
    }
}
