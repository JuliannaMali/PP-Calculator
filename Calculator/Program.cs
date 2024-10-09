//class Calculator odpowiada za same obliczenia, class Program za interakcję z użytkownikiem

using System.Text.RegularExpressions;

class Calculator
{
    public static double DoOperation(double number1, double number2, string op)
        //public - każdy ma dostęp, np. double/int/string oznacza że funkcja zwraca rezultat określonego typu
    {
        double result = double.NaN;
        //domyślna opcja jeśli rezultat nie jest numerem

        switch(op)
        {
            case "a":
                result = number1 + number2;
                break;

            case "s":
                result = number1 - number2;
                break;

            case "m":
                result = number1 * number2;
                break;

            case "d":
                if (number2 != 0)
                {
                    result = number1 / number2;
                }
                break;

            default:
                break;
            //^^ jeśli żaden z caseów nie może być wykonany bo inputy nie są numerami program zwróci ustaloną opcję domyślną
        }
        return result;
    }
}


class Program
{
    static void Main(string[] args)
        //void oznacza że funkcja coś robi, nie zwraca
    {
        bool endApp = false;

        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("========================\n");
        // \n-new line, \r- carriage return (przenosi kursor na początek linii)

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.WriteLine("Type in the first number and press Enter: ");
            //user input
            numInput1 = Console.ReadLine();

            double finNum1 = 0;
            while (!double.TryParse(numInput1, out finNum1))
                //tryParse próbuje konwertować numInput1 ze striga na double, jeśli się uda to out zwraca przekonwertowaną wartość do finNum1
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }


            Console.Write("Type in the second number and press Enter: ");
            numInput2 = Console.ReadLine();

            double finNum2 = 0;
            while (!double.TryParse(numInput2, out finNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("Please choose the operation from the list: \n\ta - add\n\ts- subtract\n\tm - multiply\n\td - divide");
            // \t - tab
            Console.Write("What will you choose? ");

            string? op = Console.ReadLine();


            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
                //^^sprawdza czy wpisana wartość pasuje do któregoś casea, jeśli nie to zwraca błąd
            }
            else
            {
                try
                {
                    result = Calculator.DoOperation(finNum1, finNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This will result in a mathematical error.\n");
                        //jeśli wynikiem operacji nie będzie liczba (is Not a Number) to zwróci błąd
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred.\n - Details: " + e.Message);
                }
            }

            Console.WriteLine("========================\n");

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            //^podwójne żeby ładnie było
        }
        return;
    }
}