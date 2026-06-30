// Responsible for processes and validates booking payments
using System;
namespace CustomProgram
{
    public class PaymentProcessor
    {
        public bool ProcessPayment(Booking booking)
        {
            Console.WriteLine("\n===== PAYMENT PROCESS =====");
            Console.WriteLine($"Total Amount: RM {booking.CalculateTotal()}");

            Console.WriteLine("\nSelect Payment Option:");
            Console.WriteLine("1. Touch 'n Go");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. Credit Card");
            Console.WriteLine("4. Online Banking");
            Console.WriteLine("Choose your payment option: ");

            string option = Console.ReadLine() ?? "";

            if (option != "1" && option != "2" && option != "3" && option != "4")
            {
                Console.WriteLine("Invalid payment option. Payment Failed!");
                return false;
            }

            Console.WriteLine("\nProcessing Payment....");
            Thread.Sleep(5000);

            Console.WriteLine("Payment was successful!");
            return true;
        }
    }
}