
namespace The_CS_Player_Guide
{
    /// <summary>
    /// A class containing members meant for general use throughout this project, hence the name.
    /// </summary>
    public static class General
    {
        /// <summary>
        /// See the "Buying Inventory" Challenge.
        /// </summary>
        public enum Answers : ushort { Y, N };

        /// <summary>
        /// Displays a message before the user exits a menu.
        /// </summary>
        /// <param name="message"></param>
        public static void ExitMessage(string message)
        {
            Console.WriteLine(message);

            WaitForKeyPress();
        }

        /// <summary>
        /// Waits for the user to press any key.
        /// </summary>
        public static void WaitForKeyPress()
        {
            Console.WriteLine("\nPress any key in order to continue.\n");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Asks the user to provide an answer (Yes or No) until he/she does.
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="clearScreen"></param>
        /// <returns></returns>
        public static Answers GetInputAnswer(out Answers answer, bool clearScreen, string question = "Do you like C#?")
        {
            string? input = string.Empty;

            answer = Answers.N;

            while (input != "Y" && input != "N")
            {
                if (clearScreen == true) Console.Clear();

                Console.WriteLine(question);
                Console.Write("Enter the answer (Y/N): ");

                input = Console.ReadLine();

                if (input == "Y")
                {
                    answer = Answers.Y;
                }
                else if (input == "N")
                {
                    answer = Answers.N;
                }
                else
                {
                    Console.WriteLine("Invalid Answer. The answer must be either \"Y\" for \"Yes\" or \"N\" for \"No\".");

                    WaitForKeyPress();
                }
            }
            return answer;
        }

        /// <summary>
        /// Asks the user to input a value of type "int" until he/she does.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static int GetInputInt(out int value, bool clearScreen = false, string message = "Enter a whole number: ", string messageError = "Invalid input. The value must be a whole number.")
        {
            string? input = string.Empty;

            while (int.TryParse(input, out value) == false)
            {
                if (clearScreen == true) Console.Clear();

                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                try
                {
                    value = int.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(messageError);

                    WaitForKeyPress();
                }
            }

            return value;
        }

        /// <summary>
        /// Asks the user to input a value of type "int" within a specified range until he/she does.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        public static void GetInputInt(out int value, int minValue, int maxValue, bool clearScreen = false, string message = "Enter a whole number: ", string messageError = "Invalid input. The value must be a whole number within the specified range.")
        {
            string? input = string.Empty;

            while (int.TryParse(input, out value) == false || value < minValue || value > maxValue)
            {
                if (clearScreen == true) Console.Clear();

                Console.WriteLine("The value must be within the range from " + minValue + " to " + maxValue + ".");
                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                try
                {
                    value = int.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(messageError);

                    WaitForKeyPress();

                    continue;
                }

                if (value < minValue)
                {
                    Console.WriteLine("The value " + value + " is below the specified range.");

                    WaitForKeyPress();
                }
                else if (value > maxValue)
                {
                    Console.WriteLine("The value " + value + " is over the specified range.");

                    WaitForKeyPress();
                }
            }
        }

        /// <summary>
        /// Asks the user to input a value of type "uint" until he/she does.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static uint GetInputUInt(out uint value, bool clearScreen = false, string message = "Enter a positive whole number: ", string messageError = "Invalid input. The value must be a positive whole number.")
        {
            string? input = string.Empty;

            while (uint.TryParse(input, out value) == false)
            {
                if (clearScreen == true) Console.Clear();

                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                try
                {
                    value = uint.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(messageError);

                    WaitForKeyPress();
                }
            }

            return value;
        }

        /// <summary>
        /// Asks the user to input a value of type "ushort" until he/she does.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        public static void GetInputUShort(out ushort value, bool clearScreen = false, string message = "Enter a small positive whole number: ", string messageError = "Invalid input. The value must be a small positive whole number.")
        {
            string? input = string.Empty;

            while (ushort.TryParse(input, out value) == false)
            {
                if (clearScreen == true) Console.Clear();

                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                try
                {
                    value = ushort.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(messageError);

                    WaitForKeyPress();
                }
            }
        }

        /// <summary>
        /// Asks the user to input a value of type "ushort" within a specified range until he/she does.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        public static void GetInputUShort(out ushort value, ushort minValue, ushort maxValue, bool clearScreen = false, string message = "Enter a small positive whole number: ", string messageError = "Invalid input. The value must be a small positive whole number within the specified range.")
        {
            string? input = string.Empty;

            while (ushort.TryParse(input, out value) == false || value < minValue || value > maxValue)
            {
                if (clearScreen == true) Console.Clear();

                Console.WriteLine("The value must be within the range from " + minValue + " to " + maxValue + ".");
                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                try
                {
                    value = ushort.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(messageError);

                    WaitForKeyPress();

                    continue;
                }

                if (value < minValue)
                {
                    Console.WriteLine("The value " + value + " is below the specified range.");

                    WaitForKeyPress();
                }
                else if (value > maxValue)
                {
                    Console.WriteLine("The value " + value + " is over the specified range.");

                    WaitForKeyPress();
                }
            }
        }

        /// <summary>
        /// Asks the user to input a value of type "ushort" that corresponds to one of the options listed on the screen until he/she does.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="options"></param>
        /// <param name="markFinalOptionAsZero"></param>
        /// <param name="clearScreen"></param>
        /// <param name="header"></param>
        public static void GetInputUShort(out ushort option, string[] options, bool markFinalOptionAsZero = false, bool clearScreen = false, string header = "Options")
        {
            string? input = string.Empty;
            bool optionValid = true;

            void OptionsDisplay()
            {
                byte lengthOptions = markFinalOptionAsZero == true ? (byte)(options.Length - 1) : (byte)options.Length;
                byte lengthIndex = (byte)(options.Length + ". ").Length;

                void OptionsSpacing(byte i)
                {
                    byte spacing = (byte)(lengthIndex - ((i + 1) + ". ").Length), k = 0;

                    while (k < spacing)
                    {
                        Console.Write(" ");
                        k++;
                    }
                }

                for (byte i = 0; i < lengthOptions; i++)
                {
                    Console.Write((i + 1) + ". ");
                    OptionsSpacing(i);
                    Console.WriteLine(options[i]);
                }

                if (markFinalOptionAsZero == true)
                {
                    Console.Write("0. ");
                    OptionsSpacing((byte)options.Length);
                    Console.WriteLine(options[options.Length - 1]);
                }

                Console.Write("\n");
            }

            while (ushort.TryParse(input, out option) == false || optionValid == false)
            {
                if (clearScreen == true) Console.Clear();

                Console.WriteLine(header);

                OptionsDisplay();

                Console.Write("Select one option: ");

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                try
                {
                    option = ushort.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Invalid option. The value of the option must be a positive whole number that corresponds to one of the listed options.");

                    WaitForKeyPress();
                }

                if (option > options.Length || (option == 0 && markFinalOptionAsZero == false) || (option >= options.Length && markFinalOptionAsZero == true))
                {
                    Console.WriteLine("Unavailable option. Choose one of the available options.");

                    WaitForKeyPress();

                    optionValid = false;
                }
                else
                {
                    optionValid = true;
                }
            }

            Console.Write("\n");
        }

        /// <summary>
        /// Asks the user to input a value of type "string" until he/she does.
        /// </summary>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static string GetInputString(bool clearScreen = false, string message = "Enter a string: ", string messageError = "Invalid input. The string cannot be null, empty or composed of white spaces.")
        {
            string? input = string.Empty;

            while (string.IsNullOrEmpty(input) == true || string.IsNullOrWhiteSpace(input) == true)
            {
                if (clearScreen == true) Console.Clear();

                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                if (string.IsNullOrEmpty(input) == true || string.IsNullOrWhiteSpace(input) == true)
                {
                    Console.WriteLine(messageError);

                    WaitForKeyPress();
                }
            }

            return input;
        }

        /// <summary>
        /// Asks the user to input a value of type "string" a finite number of times.
        /// </summary>
        /// <param name="messageDefault"></param>
        /// <param name="attempts"></param>
        /// <param name="clearScreen"></param>
        /// <param name="message"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static string GetInputString(string messageDefault, byte attempts = 3, bool clearScreen = false, string message = "Enter a string: ", string messageError = "Invalid input. The string cannot be null, empty or composed of white spaces.")
        {
            string? input = string.Empty;

            while ((string.IsNullOrEmpty(input) == true || string.IsNullOrWhiteSpace(input) == true) && attempts > 0)
            {
                if (clearScreen == true) Console.Clear();

                Console.Write(message);

                input = Console.ReadLine();

                if (input == null) input = string.Empty;

                if (string.IsNullOrEmpty(input) == true || string.IsNullOrWhiteSpace(input) == true)
                {
                    attempts--;

                    Console.WriteLine(messageError);
                    Console.WriteLine("Remaining Attempts: " + attempts);

                    WaitForKeyPress();
                }
            }

            if (attempts == 0)
            {
                Console.WriteLine("No attempts left.");
                return messageDefault;
            }
            else
            {
                return input;
            }
        }
    }
}
