using System;

class NumberSystemConverter
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("CHOOSE STARTING SYSTEM:");
            Console.WriteLine("1. Convert from Binary");
            Console.WriteLine("2. Convert from Octal");
            Console.WriteLine("3. Convert from Decimal");
            Console.WriteLine("4. Convert from Hexadecimal");
            Console.WriteLine("5. Exit");
            Console.Write("Enter desired choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. Enter a valid option.");
                continue;
            }

            if (choice == 5)
            {
                Console.WriteLine("Exiting the program.");
                break;
            }
            Console.WriteLine();
            Console.Write("Enter the number: ");
            string input = Console.ReadLine();
            if(input == "")
            {
                Console.WriteLine("Input cannot be empty. Enter a valid input.");
                continue;
            }
            long decimalValue;

            switch (choice)
            {
                case 1:
                    if (!IsValidBinary(input))
                    {
                        Console.WriteLine("Invalid BINARY input.");
                        continue;
                    }
                    decimalValue = BinaryToDecimal(input);
                    break;
                case 2:
                    if (!IsValidOctal(input))
                    {
                        Console.WriteLine("Invalid OCTAL input.");
                        continue;
                    }
                    decimalValue = OctalToDecimal(input);
                    break;
                case 3:
                    if (!IsValidDecimal(input))
                    {
                        Console.WriteLine("Invalid DECIMAL input.");
                        continue;
                    }
                    decimalValue = long.Parse(input);
                    break;
                case 4:
                    if (!IsValidHexadecimal(input))
                    {
                        Console.WriteLine("Invalid HEXADECIMAL input.");
                        continue;
                    }
                    decimalValue = HexadecimalToDecimal(input);
                    break;
                default:
                    decimalValue = 0;
                    break;
            }

            Console.WriteLine();
            Console.WriteLine($"Decimal: {decimalValue}");
            Console.WriteLine($"Binary: {DecimalToBinary(decimalValue)}");
            Console.WriteLine($"Octal: {DecimalToOctal(decimalValue)}");
            Console.WriteLine($"Hexadecimal: {DecimalToHexadecimal(decimalValue)}");
            Console.WriteLine();
        }
    }

    static bool IsValidBinary(string input)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(input, "^[01]+$");
    }

    static bool IsValidOctal(string input)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-7]+$");
    }

    static bool IsValidDecimal(string input)
    {
        return long.TryParse(input, out _);
    }

    static bool IsValidHexadecimal(string input)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-9A-Fa-f]+$");
    }

    static long BinaryToDecimal(string binary)
    {
        long decimalValue = 0;
        int length = binary.Length;
        for (int i = 0; i < length; i++)
        {
            if (binary[i] == '1')
            {
                decimalValue += (long)Math.Pow(2, length - i - 1);
            }
        }
        return decimalValue;
    }

    static long OctalToDecimal(string octal)
    {
        long decimalValue = 0;
        int length = octal.Length;
        for (int i = 0; i < length; i++)
        {
            int digit = octal[i] - '0';
            decimalValue += digit * (long)Math.Pow(8, length - i - 1);
        }
        return decimalValue;
    }

    static long HexadecimalToDecimal(string hexadecimal)
    {
        long decimalValue = 0;
        int length = hexadecimal.Length;
        for (int i = 0; i < length; i++)
        {
            char digit = hexadecimal[i];
            int digitValue;
            if (char.IsDigit(digit))
            {
                digitValue = digit - '0';
            }
            else
            {
                digitValue = char.ToUpper(digit) - 'A' + 10;
            }
            decimalValue += digitValue * (long)Math.Pow(16, length - i - 1);
        }
        return decimalValue;
    }

    static string DecimalToBinary(long decimalValue)
    {
        if (decimalValue == 0)
        {
            return "0";
        }

        string binary = "";
        while (decimalValue > 0)
        {
            long remainder = decimalValue % 2;
            binary = remainder + binary;
            decimalValue /= 2;
        }
        return binary;
    }

    static string DecimalToOctal(long decimalValue)
    {
        if (decimalValue == 0)
        {
            return "0";
        }

        string octal = "";
        while (decimalValue > 0)
        {
            long remainder = decimalValue % 8;
            octal = remainder + octal;
            decimalValue /= 8;
        }
        return octal;
    }
    
    static string DecimalToHexadecimal(long decimalValue)
    {
        if (decimalValue == 0)
        {
            return "0";
        }

        string hexadecimal = "";
        while (decimalValue > 0)
        {
            long remainder = decimalValue % 16;
            if (remainder < 10)
            {
                hexadecimal = remainder + hexadecimal;
            }
            else
            {
                char hexDigit = (char)('A' + (remainder - 10));
                hexadecimal = hexDigit + hexadecimal;
            }
            decimalValue /= 16;
        }
        return hexadecimal;
    }
}
