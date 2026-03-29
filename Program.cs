/*******************************************************************
* Name: Steven McGraw
* Date: 2026-03-29
* Assignment: SDC220 Performance Assessment - Account Balance Calculations
*
* Main application (program) class.
* This application manages a bank account balance. The user enters a
* starting balance, then enters credits or debits until they enter 0
* to quit. A user-defined exception is thrown if a debit would cause
* the balance to go negative. A FormatException is handled if the
* input is not a number.
*/
public class AccountBalance
{
    // Helper method to get and validate a double value from the user
    // Throws FormatException if input is not a number
    public static double GetValue(double balance)
    {
        string? val = Console.ReadLine();
        double amount = Convert.ToDouble(val);

        // Throw user-defined exception if debit would cause negative balance
        if (balance + amount < 0)
        {
            throw new Exception(
                "Amount entered will cause account to be negative.");
        }

        return amount;
    }

    static void Main(string[] args)
    {
        // Print header line
        Console.WriteLine("Steven McGraw - Week 4 PA Account Balance Calculations");

        // Get starting balance
        Console.Write("Please enter the starting balance: ");
        double balance = Convert.ToDouble(Console.ReadLine());

        double amount = 1; // initialize to non-zero to enter loop

        while (amount != 0)
        {
            try
            {
                Console.Write("\nPlease enter a credit or debit amount (0 to quit): ");
                amount = GetValue(balance);

                // Update and display the balance
                balance += amount;
                Console.WriteLine("The updated balance is: {0:F2}", balance);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Please enter a numeric value.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
