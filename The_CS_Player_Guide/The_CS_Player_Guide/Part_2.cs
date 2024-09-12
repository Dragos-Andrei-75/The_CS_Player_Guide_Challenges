
namespace The_CS_Player_Guide
{
    internal class Part_2
    {
        //See the "Simula's Test" Challenge.
        protected enum States : ushort { Open = 1, Closed = 2, Locked = 3, Omitted = 4 };

        //See the "Simula's Soup" Challenge.
        private enum Types : ushort { Soup = 1, Stew = 2, Gumbo = 3 };
        private enum MainIngredients : ushort { Mushrooms = 1, Chicken = 2, Carrots = 3, Patatoes = 4 };
        private enum Seasonings : ushort { Spicy = 1, Salty = 2, Sweet = 3 };

        //See the "SimulasTest" and the "The Locked Door" Challenges.
        protected void Interact(string interactableName, ref States interactableStateCurrent, bool passwordRequired = false, string password = "")
        {
            States interactableStateNext = States.Open;
            string[] actions = { "Open", "Close", "Lock", "Omit" };
            ushort action;

            while (interactableStateNext != States.Omitted)
            {
                Console.Clear();

                General.GetInputUShort(out action, actions, false, false, "The " + interactableName + " is " + interactableStateCurrent + ". What do you want to do?");

                interactableStateNext = (States)action;

                if (interactableStateNext == States.Omitted)
                {
                    continue;
                }
                if (interactableStateNext == interactableStateCurrent)
                {
                    Console.WriteLine("The " + interactableName + " is already " + interactableStateNext + ".");
                }
                else if (interactableStateNext < interactableStateCurrent - 1)
                {
                    Console.WriteLine("In order to do that, the " + interactableName + " must first be " + (interactableStateCurrent - 1) + ".");
                }
                else if (interactableStateNext > interactableStateCurrent + 1)
                {
                    Console.WriteLine("In order to do that, the " + interactableName + " must first be " + (interactableStateCurrent + 1) + ".");
                }
                else
                {
                    if (interactableStateCurrent == States.Locked && interactableStateNext == States.Closed && passwordRequired == true)
                    {
                        if (PasswordCheck(password) == false)
                        {
                            Console.WriteLine("The " + interactableName + "will remain locked until the correct password is provided.");
                            General.WaitForKeyPress();

                            continue;
                        }
                    }

                    interactableStateCurrent = interactableStateNext;
                    Console.WriteLine("The " + interactableName + " is now " + interactableStateCurrent + ".");
                }

                General.WaitForKeyPress();
            }
        }

        //See the "The Locked Door" Challenge.
        private bool PasswordCheck(string passwordCurrent)
        {
            string passwordCheck = General.GetInputString(string.Empty, 5, false, "Enter the current password: ", "The password cannot be null, empty or composed of white spaces.");

            if (passwordCheck == string.Empty || passwordCheck != passwordCurrent)
            {
                Console.WriteLine("Authentication Failed.");
                General.WaitForKeyPress();

                return false;
            }
            else
            {
                Console.WriteLine("Authentication Successful.");
                General.WaitForKeyPress();

                return true;
            }
        }

        //Challenges
        public void SimulasTest() //1
        {
            States chestStateCurrent = States.Open;
            Interact("Chest", ref chestStateCurrent);
        }

        public void SimulasSoup() //2
        {
            (Types Type, MainIngredients MainIngredient, Seasonings Seasoning) food;

            string[] types = { "Soup", "Stew", "Gumbo" },
                     mainIngredients = { "Mushrooms", "Chicken", "Carrots", "Patatoes" },
                     seasonings = { "Spicy", "Salty", "Sweet" };

            Types type;
            MainIngredients mainIngredient;
            Seasonings seasoning;

            General.Answers answer;

            ushort option;

            General.GetInputAnswer(out answer, false, "May I take you order?");

            if (answer == General.Answers.N)
            {
                Console.WriteLine("Alright! Have a good day!");
            }
            else
            {
                General.GetInputUShort(out option, types, false, true, "What type of food would you like?");
                type = (Types)option;

                General.GetInputUShort(out option, mainIngredients, false, true, "What main ingredient would you like?");
                mainIngredient = (MainIngredients)option;

                General.GetInputUShort(out option, seasonings, false, true, "What seasoning would you like?");
                seasoning = (Seasonings)option;

                food = (type, mainIngredient, seasoning);

                Console.Clear();
                Console.WriteLine("Your order: " + food.Seasoning + " " + food.MainIngredient + " " + food.Type);
                Console.ReadKey(true);

            }
        }
    }

    internal class Arrow : InventoryItem //3 //4 //5 //16
    {
        public enum ArrowHeadTypes : ushort { Steel = 10, Wood = 3, Obsidian = 5 };
        public enum FlenchingTypes : ushort { Plastic = 10, TurkeyFeathers = 5, GooseFeathers = 3 };

        //See the "The Properties of Arrows" Challenge.
        public ArrowHeadTypes ArrowHeadType { get => arrowHeadType; }
        public FlenchingTypes FlenchingType { get => flenchingType; }
        public ushort Length { get => length; }

        private static Arrow? arrow;
        private static ushort option;

        private ArrowHeadTypes arrowHeadType;
        private FlenchingTypes flenchingType;
        private ushort length;

        //See the "Packing Inventory" Challenge.
        public Arrow(float weight, float volume) : base(0.1f, 0.05f) { Name = "Arrow"; }

        public Arrow()
        {
            Name = "Arrow";
            Weight = 0.1f;
            Volume = 0.05f;
        }

        private Arrow(ArrowHeadTypes arrowHeadType, FlenchingTypes flenchingType, ushort length)
        {
            this.arrowHeadType = arrowHeadType;
            this.flenchingType = flenchingType;
            this.length = length;
        }

        /*
        //See the "Vin’s Trouble" Challenge.
        public ArrowHeadTypes GetArrowHeadType() => arrowHeadType;
        public FlenchingTypes GetFlenchingType() => flenchingType;
        public ushort GetLenght() => length;
        */

        private static void CreateEliteArrow() { arrow = new Arrow(ArrowHeadTypes.Steel, FlenchingTypes.Plastic, 95); }

        private static void CreateMarksmanArrow() { arrow = new Arrow(ArrowHeadTypes.Steel, FlenchingTypes.GooseFeathers, 75); }

        private static void CreateBeginnerArrow() { arrow = new Arrow(ArrowHeadTypes.Wood, FlenchingTypes.GooseFeathers, 65); }

        private void CreateCustomArrow()
        {
            string[] arrowHeadTypes = { "Steel", "Wood", "Obsidian" }, flenchingTypes = { "Plastic", "Turkey Feathers", "Goose Feathers" };

            void DeterminePrice(float[] prices)
            {
                if (option > 0 && option <= prices.Length) option = (ushort)prices[option - 1];
                else
                {
                    Console.WriteLine("No price corresponds to the option " + option + ".");
                    Console.ReadKey(true);
                }
            }

            General.GetInputUShort(out option, arrowHeadTypes, false, false, "Choose the arrow head type:");

            DeterminePrice([10, 3, 5]);
            arrowHeadType = (ArrowHeadTypes)option;

            General.GetInputUShort(out option, flenchingTypes, false, false, "Choose the flenching type:");

            DeterminePrice([10, 5, 3]);
            flenchingType = (FlenchingTypes)option;

            General.GetInputUShort(out length, 60, 100, false, "Enter the length of the arrow: ");

            arrow = new Arrow(arrowHeadType, flenchingType, length);
        }

        private void DisplayArrowInformation()
        {
            if (arrow != null)
            {
                float lengthPrice = 0.05f;
                float arrowCost = (float)arrow.arrowHeadType + (float)arrow.flenchingType + ((float)arrow.length * lengthPrice);

                Console.WriteLine("\n");
                Console.WriteLine(arrow.arrowHeadType + " arrow head: " + (ushort)arrow.arrowHeadType + " coins");
                Console.WriteLine(arrow.flenchingType + " flenching: " + (ushort)arrow.flenchingType + " coins");
                Console.WriteLine(arrow.length + "cm length: " + ((ushort)arrow.length * lengthPrice) + " coins");
                Console.WriteLine("\nThe cost of a " + arrow.arrowHeadType + " arrow with flenching of " + arrow.flenchingType + " and a length of " + arrow.length + "cm is " + arrowCost + " coins.");
                General.WaitForKeyPress();

                arrow = null; //set the "arrow" variable to null in order to loose all references to the "Arrow" object that was created in order for the garbage collector to
                              //remove it from memory
            }
        }

        public void ArrowFactories()
        {
            string header = "What type of arrow do you want?";
            string[] options = { "Elite Arrow", "Marksman Arrow", "Beginner Arrow", "Custom Arrow" };

            Console.Clear();

            General.GetInputUShort(out option, options, false, false, header);

            if (option == 1) CreateEliteArrow();
            else if (option == 2) CreateMarksmanArrow();
            else if (option == 3) CreateBeginnerArrow();
            else CreateCustomArrow();

            DisplayArrowInformation();
        }
    }

    public class Point //7
    {
        //Question: Are your X and Y properties immutable? Why did you choose what you did?
        //Answer: The X and Y properties are mutable. I chose to make the properties mutable in order to tackle the possible scenario in which it is more convenient to
        //change the coordinates of an already existing instance of the "Point" class instead of having to create a new object.
        private int x, y;

        private int X { get { return x; } set { x = value; } }

        private int Y { get { return y; } set { y = value; } }

        private Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            x = 0;
            y = 0;
        }

        public void ThePoint()
        {
            Point point1 = new Point(2, 3);
            Point point2 = new Point(-4, 0);

            Console.WriteLine("Instantiating Objects of type \"Point\".");
            Console.WriteLine("(" + point1.X + "," + point1.Y + ")");
            Console.WriteLine("(" + point2.X + "," + point2.Y + ")");
        }
    }

    public class Color //8
    {
        byte red, green, blue;

        private byte Red { get => red; set => red = value; }

        private byte Green { get => green; set => green = value; }

        private byte Blue { get => blue; set => blue = value; }

        private static Color CreateWhite { get => new Color(255, 255, 255); } //White(255, 255, 255)
        private static Color CreateBlack { get => new Color(0, 0, 0); } //Black(0, 0, 0)
        private static Color CreateRed { get => new Color(255, 0, 0); } //Red(255, 0, 0)
        private static Color CreateOrange { get => new Color(255, 165, 0); } //Orange(255,165, 0)
        private static Color CreateYellow { get => new Color(255, 255, 0); } //Yellow(255, 255, 0)
        private static Color CreateGreen { get => new Color(0, 128, 0); } //Green(0, 128, 0)
        private static Color CreateBlue { get => new Color(0, 0, 255); } //Blue(0, 0, 255)
        private static Color CreatePurple { get => new Color(128, 0, 128); } //Purple(128, 0, 128)

        private Color(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public Color() { }

        public void TheColor()
        {
            ConsoleColor consoleInitialColor = Console.ForegroundColor;
            Color colorCustom, colorRed;

            colorCustom = new Color(0, 255, 255); //Cyan(0, 255, 255)
            colorRed = CreateRed;

            Console.WriteLine("Instantiating objects of type \"Color\".");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Console.ForegroundColor + " R: " + colorCustom.red + " G: " + colorCustom.green + " B: " + colorCustom.blue);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Console.ForegroundColor + " R: " + colorRed.red + " G: " + colorRed.green + " B: " + colorRed.blue);

            Console.ForegroundColor = consoleInitialColor;
        }
    }

    public class Card //9
    {
        private enum Colors : ushort { Red, Green, Blue, Yellow };

        private enum Symbols : ushort { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Modulo, Circumflex, Ampersand };

        private Colors color;
        private Symbols symbol;

        private Colors Color { get => color; }

        private Symbols Symbol { get => symbol; }

        private Card(Colors color, Symbols symbol)
        {
            this.color = color;
            this.symbol = symbol;
        }

        public Card() { }

        public void TheCard()
        {
            ConsoleColor initialColor = Console.ForegroundColor;
            ushort colorIndex = 0, symbolIndex;
            ushort colorsLength = (ushort)(Colors.Yellow + 1), symbolLength = (ushort)(Symbols.Ampersand + 1);

            Console.WriteLine("The Full Deck\n");

            while (colorIndex < colorsLength)
            {
                symbolIndex = 0;

                while (symbolIndex < symbolLength)
                {
                    Card card = new Card((Colors)colorIndex, (Symbols)symbolIndex);

                    if (card.Color == Colors.Red) Console.ForegroundColor = ConsoleColor.Red;
                    else if (card.Color == Colors.Green) Console.ForegroundColor = ConsoleColor.Green;
                    else if (card.Color == Colors.Blue) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.Yellow;

                    if ((ushort)card.Symbol < 10) Console.WriteLine("The " + card.Color + " of " + card.Symbol);
                    else Console.WriteLine("The " + card.Color + " " + card.Symbol);

                    symbolIndex = (ushort)(symbolIndex + 1);
                }

                colorIndex = (ushort)(colorIndex + 1);
            }

            Console.ForegroundColor = initialColor;
        }
    }

    internal class Door : Part_2 //10
    {
        private States doorState = States.Locked;
        private string doorPassword;

        private string[] options = { "Interact with Door", "Change Door Password", "Leave" };
        private ushort option;

        public Door() { doorPassword = General.GetInputString(false, "Enter a password for the door: ", "The password cannot be null, empty or composed of white spaces."); }

        private string PasswordChange(string passwordOld)
        {
            string input = General.GetInputString(string.Empty, 5, false, "Enter the old password: ", "The password cannot be null, empty or composed of white spaces.");

            if (input != passwordOld)
            {
                Console.WriteLine("Authentication Failed.");
                General.WaitForKeyPress();
            }
            else
            {
                input = General.GetInputString(false, "Enter the new password: ", "The new password cannot be null, empty or composed of white spaces.");

                General.WaitForKeyPress();

                return input;
            }

            return passwordOld;
        }

        public void TheLockedDoor()
        {
            Console.Clear();

            while (option != options.Length)
            {
                General.GetInputUShort(out option, options);

                if (option == 1) Interact("Door", ref doorState, true, doorPassword);
                else if (option == 2) doorPassword = PasswordChange(doorPassword);
            }

            General.WaitForKeyPress();
        }
    }

    internal class PasswordValidator //11
    {
        private string password = string.Empty;

        private PasswordValidator(string password) { this.password = password; }

        public PasswordValidator() { }

        public void ThePasswordValidator()
        {
            General.Answers answer = General.Answers.Y;

            while (answer != General.Answers.N)
            {
                PasswordValidator passwordValidator;
                bool containsLowerCaseCharacter, containssUpperCaseCharacter, containssNumber, validLength, validCharacters;

                containsLowerCaseCharacter = containssUpperCaseCharacter = containssNumber = validLength = validCharacters = false;

                password = General.GetInputString(true, "Enter a password: ", "The password cannot be null, empty or composed of white spaces.");

                passwordValidator = new PasswordValidator(password);

                foreach (char character in password)
                {
                    if (containsLowerCaseCharacter = true && containssUpperCaseCharacter == true && containssNumber == true)
                    {
                        break;
                    }
                    else
                    {
                        if (containsLowerCaseCharacter == false && char.IsLower(character) == true) containsLowerCaseCharacter = true;
                        else if (containssUpperCaseCharacter == false && char.IsUpper(character) == true) containssUpperCaseCharacter = true;
                        else if (containssNumber == false && char.IsNumber(character) == true) containssNumber = true;
                    }
                }

                if (password.Length >= 6 && password.Length <= 13) validLength = true;

                if (password.Contains("T") == false && password.Contains("&") == false) validCharacters = true;

                if (containsLowerCaseCharacter = true && containssUpperCaseCharacter == true && containssNumber == true && validLength == true && validCharacters == true)
                {
                    Console.WriteLine("The password \"" + password + "\" is valid.");
                    General.WaitForKeyPress();
                }
                else
                {
                    if (validLength == false) Console.WriteLine("The password must contain a minimun of 6 characters and a maximum of 13 characters. \"" + password + "\" is " + password.Length + " characters long.");
                    if (containsLowerCaseCharacter == false || containssUpperCaseCharacter == false || containssNumber == false) Console.WriteLine("The password must contain at least 1 lower case character, 1 upper case character and 1 number.");
                    if (validCharacters == false) Console.WriteLine("The password cannot contain the characters \"T\" or \"&\" because Ingelmar in IT has decreed it.");

                    General.WaitForKeyPress();
                }

                General.GetInputAnswer(out answer, true, "Do you want to check if another password is valid?");
            }
        }
    }

    internal class RockPaperScissors //12
    {
        private enum RPS : ushort {Rock = 1, Paper = 2, Scissors = 3}

        public void RockPaperScissorsGame()
        {
            string[] options = { "Rock", "Paper", "Scissors" };
            ushort player1Option, player2Option, player1Score = 0, player2Score = 0, round = 0;
            RPS player1Choice, player2Choice;
            General.Answers answer = General.Answers.Y;

            void Result(string Winner, ref ushort scoreWinner, RPS choiceWinner, RPS choiceLoser)
            {
                Console.WriteLine(choiceWinner + " beats " + choiceLoser + " -> " + Winner + " Wins!");
                scoreWinner++;
            }

            while (answer == General.Answers.Y)
            {
                round++;

                Console.Clear();

                General.GetInputUShort(out player1Option, options, false, true, "Make a choice, Player 1: ");
                player1Choice = (RPS)player1Option;

                General.GetInputUShort(out player2Option, options, false, true, "Make a choice, Player 2: ");
                player2Choice = (RPS)player2Option;

                Console.WriteLine("P1: " + player1Choice + " | " + "P2: " + player2Choice);

                if ((player1Option == 1 && player2Option == 3) ^ ((player1Option != 3 || player2Option != 1) && player1Option > player2Option)) Result("Player 1", ref player1Score, player1Choice, player2Choice);
                else if ((player1Option == 3 && player2Option == 1) ^ ((player1Option != 1 || player2Option != 3) && player1Option < player2Option)) Result("Player 2", ref player2Score, player2Choice, player1Choice);

                General.WaitForKeyPress();

                Console.WriteLine("Round: " + round);
                Console.WriteLine("Player 1 Score: " + player1Score + " | " + "Player 2 Score: " + player2Score);

                General.WaitForKeyPress();

                General.GetInputAnswer(out answer, false, "Play another round?");
            }
        }
    }

    internal class Puzzle15 //13
    {
        private enum Directions : byte { UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3, NONE = 4 }

        public void Puzzle15Game()
        {
            Random random = new Random();
            General.Answers answer = General.Answers.Y;
            byte[,] puzzle = new byte[4, 4];
            byte[] puzzleValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, puzzleCompleted = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            (byte row, byte column) emptyPiece;
            ushort moves;

            //In order to make sure every game is different from the previous ones, the puzzle will be pseudo-randomly generated every time.
            void PuzzleGenerate()
            {
                //The empty space inside a puzzle is pseudo-randomly chosen.
                emptyPiece = ((byte)random.Next(0, 4), (byte)random.Next(0, 4));
                /*The empty space inside the puzzle is the only position within the array which will not be assigned a value from 1 to 15.
                 *The value 0 will be assigned to the empty space in order to identify it during the puzzle generation process to mark it with the "_" symbol.*/
                puzzle[emptyPiece.row, emptyPiece.column] = 0;

                /*Store a copy of the array "puzzleValues" inside the "values" array. The copy is needed because it will slowly loose its values but they must still be stored
                 *somewhere else in case the player wants to play again and the puzzle must be regenerated.*/
                byte[] values = puzzleValues;

                /*Meant to exclude values that were already used during the puzzle generation process in order to make sure it is not used again since each value must appear
                 *only once.*/
                byte[] ArrayModify(byte[] array, byte valueToExclude)
                {
                    byte[] arrayCopy = array; //Store a copy of the array within another array.
                    byte k = 0;

                    array = new byte[arrayCopy.Length - 1]; //Reduce the length of the array. This deletes all existing values inside the array.

                    for (byte i = 0; i < arrayCopy.Length; i++)
                    {
                        if (arrayCopy[i] != valueToExclude) //Only add this value inside the new array if it is not the value that is meant to be excluded.
                        {
                            array[k] = arrayCopy[i]; //Fill the new array with values, one iteration at a time.
                            k++;
                        }
                    }

                    return array; //Return the new array.
                }

                //Generates the puzzle.
                for (byte i = 0; i < puzzle.GetLength(0); i++)
                {
                    for (byte j = 0; j < puzzle.GetLength(1); j++)
                    {
                        if (i == emptyPiece.row && j == emptyPiece.column) continue; //In case this position in the array is meant to serve as the empty space, it will be skipped.

                        puzzle[i, j] = values[random.Next(0, values.Length)]; //A pseudo-random value is assigned to every other position.
                        values = ArrayModify(values, puzzle[i, j]); /*After every assignment, the value that was previously assigned is removed from the array of available values
                                                                     *in order to make sure there are no duplicates.*/
                    }
                }
            }

            //Displays the puzzle inside the console application.
            void PuzzleDisplay()
            {
                Console.Clear();

                Console.WriteLine("  15-Puzzle\n"); //Display the name of the game.

                //Display the column indices.
                Console.Write(" ");
                for (byte i = 0; i < puzzle.GetLength(0); i++) Console.Write("  " + i);
                Console.Write("\n\n");

                for (byte i = 0; i < puzzle.GetLength(0); i++)
                {
                    Console.Write(i + " "); //Display the row indices.

                    for (byte j = 0; j < puzzle.GetLength(1); j++)
                    {
                        if (puzzle[i, j] == 0) //In case this position in the array is meant to serve as the empty space which allows the player to move the other "pieces".
                        {
                            Console.Write(" _ "); //The empty space will be marked with an underscore.
                            continue;
                        }
                        else if(puzzle[i, j] < 10) //In case the number is less than 10, an extra space must be added in order to keep the "pieces" properly alligned.
                        {
                            Console.Write(" ");
                        }

                        Console.Write(puzzle[i, j] + " ");
                    }

                    Console.WriteLine("\n");
                }

                Console.WriteLine("\nMoves: " + moves + "\n"); //Display the number or moves made by the player.
            }

            (byte, byte, Directions)[] FindEmptyPieceNeighbours()
            {
                (byte, byte, Directions)[] coordinates = new (byte, byte, Directions)[4];
                byte k = 0;

                while (k < coordinates.Length)
                {
                    coordinates[k].Item3 = Directions.NONE;
                    k++;
                }

                //Adds the neighbours positions to the "coordinates" array, accompanied by the directions in which they can be moved.
                void AddNeighbour(int length, int offsetRow, int offsetColumn)
                {
                    Directions direction;

                    if (offsetRow > 0) direction = Directions.UP; //The neighbour below the empty "piece" can be moved UP.
                    else if (offsetRow < 0) direction = Directions.DOWN; //The neighbour above the empty "piece" can be moved DOWN.
                    else if (offsetColumn > 0) direction = Directions.LEFT; //The neighbour on the RIGHT of the empty "piece" can be moved LEFT.
                    else direction = Directions.RIGHT; //The neighbour on the LEFT of the empty "piece" can be moved RIGHT.

                    coordinates[(byte)direction] = ((byte)(emptyPiece.row + offsetRow), (byte)(emptyPiece.column + offsetColumn), direction);
                }

                //If the empty "piece" is not situated on the last row, that means it has a neighbour below.
                if (emptyPiece.row < puzzle.GetLength(0) - 1) AddNeighbour(coordinates.Length, 1, 0);
                //If the empty "piece" is not situated on the first row, that means it has a neighbour above.
                if (emptyPiece.row > 0) AddNeighbour(coordinates.Length, -1, 0);
                //If the empty "piece" is not situated on the first column, that means it has a neighbour on its left.
                if (emptyPiece.column > 0) AddNeighbour(coordinates.Length, 0, -1);
                //If the empty "piece" is not situated on the last column, that means it has a neighbour on its right.
                if (emptyPiece.column < puzzle.GetLength(1) - 1) AddNeighbour(coordinates.Length, 0, 1);

                return coordinates;
            }

            void MoveEmptyPieceNeighbours((byte row, byte column, Directions direction)[] coordinates)
            {
                ConsoleKeyInfo input;
                Directions chosenDirection = Directions.NONE;
                byte k = 0, temp;

                Console.Write("\n");

                while (k < coordinates.Length)
                {
                    if (coordinates[k].direction != Directions.NONE) //Only display the information in case it corresponds to a move that the player can make.
                    {
                        Console.Write("| Move " + coordinates[k].direction + ": " + puzzle[coordinates[k].row, coordinates[k].column] + " |");
                    }

                    k++;
                }

                while (chosenDirection == Directions.NONE) //The loop repeats until a direction is assigned to "chosenDirection".
                {
                    input = Console.ReadKey(true); //Take input from the player.

                    if (input.KeyChar == 'w') chosenDirection = Directions.UP;
                    else if (input.KeyChar == 's') chosenDirection = Directions.DOWN;
                    else if (input.KeyChar == 'a') chosenDirection = Directions.LEFT;
                    else if (input.KeyChar == 'd') chosenDirection = Directions.RIGHT;
                    else continue; //In case the player input does not correspond to any of the available options, skip to the next iteration.

                    //In case the chosen option does not correspond to any move the player can make.
                    if (coordinates[(byte)chosenDirection].direction == Directions.NONE) chosenDirection = Directions.NONE;
                }

                //Classic interchange of values.
                temp = puzzle[coordinates[(byte)chosenDirection].row, coordinates[(byte)chosenDirection].column];
                puzzle[coordinates[(byte)chosenDirection].row, coordinates[(byte)chosenDirection].column] = puzzle[emptyPiece.row, emptyPiece.column];
                puzzle[emptyPiece.row, emptyPiece.column] = temp;

                //Update the position of the empty "piece".
                emptyPiece = (coordinates[(byte)chosenDirection].row, coordinates[(byte)chosenDirection].column);
            }

            bool PuzzleCheck()
            {
                byte[] puzzleCopy = new byte[puzzle.Length];

                Buffer.BlockCopy(puzzle, 0, puzzleCopy, 0, puzzle.Length);

                return puzzleCopy.SequenceEqual(puzzleCompleted);
            }

            void GameLoop()
            {
                (byte, byte, Directions)[] coordinatesNeighbours;

                while (answer != General.Answers.N)
                {
                    PuzzleGenerate();
                    moves = 0;

                    while (PuzzleCheck() == false)
                    {
                        PuzzleDisplay();
                        coordinatesNeighbours = FindEmptyPieceNeighbours();
                        MoveEmptyPieceNeighbours(coordinatesNeighbours);

                        moves++;
                    }

                    PuzzleDisplay();

                    Console.WriteLine("\nGame Over! Puzzle Completed in " + moves + " moves.");

                    General.WaitForKeyPress();
                    General.GetInputAnswer(out answer, false, "Play Again?");
                }
            }

            GameLoop();
        }
    }

    internal class HangMan //14
    {
        public void HangManGame()
        {
            Random random = new Random();

            string[] words = { "Airplane", "Biology", "Centrifuge", "Dinosaur", "Elephant", "Forbidden", "Immutable" };
            char[] guessesRight = new char[0], guessesWrong = new char[0];
            string word = words[random.Next(0, words.Length)].ToLower();
            char guess = char.MinValue;
            byte guesses = 10;
            bool complete = false;

            void AddToArray(ref char[] array, char element)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = element;
            }

            Console.Clear();

            void GameLoop()
            {
                General.Answers answer = General.Answers.Y;

                while (answer != General.Answers.N)
                {
                    while (guesses != 0 && complete == false)
                    {
                        byte k = 0;

                        Console.Write("Word: ");
                        for (byte i = 0; i < word.Length; i++)
                        {
                            if (guessesRight.Contains(word[i]))
                            {
                                Console.Write(word[i]);
                                k++;
                            }
                            else
                            {
                                Console.Write("_");
                            }

                            Console.Write(" ");
                        }

                        Console.Write(" | Remaining: " + guesses);

                        Console.Write(" | Incorrect: ");
                        for (byte i = 0; i < guessesWrong.Length; i++) Console.Write(guessesWrong[i]);

                        if (k != word.Length)
                        {
                            Console.Write(" | Guess: ");
                            while (char.IsLetter(guess) == false) guess = (char)Console.Read();

                            Console.Write("\n");

                            if (word.Contains(guess) == true)
                            {
                                AddToArray(ref guessesRight, guess);
                            }
                            else
                            {
                                AddToArray(ref guessesWrong, guess);
                                guesses--;
                            }

                            guess = char.MinValue;
                        }
                        else
                        {
                            complete = true;
                        }
                    }

                    if (guesses == 0 && complete == false) Console.WriteLine(" | You Lost!");
                    else Console.WriteLine(" | You Win!");

                    General.GetInputAnswer(out answer, false, "Play Again?");
                }

            }

            GameLoop();
        }
    }

    internal class TicTacToe //15
    {
        private enum Positions : byte { UpperLeft = 1, UpperMiddle = 2, UpperRight = 3, CenterLeft = 4, CenterMiddle = 5, CenterRight = 6, LowerLeft = 7, LowerMiddle = 8, LowerRight = 9 };

        public void TicTacToeGame()
        {
            char[,] grid;
            byte[] positionsPlayer1, positionsPlayer2;
            int round;

            void GridGenerate()
            {
                string gridPieces = "-+|";
                byte i = 0, j = 0;

                while (i < grid.GetLength(0))
                {
                    while (j < grid.GetLength(1))
                    {
                        if (j == 3 || j == 7)
                        {
                            if (i % 2 == 0) grid[i, j] = gridPieces[2];
                            else grid[i, j] = gridPieces[1];
                        }
                        else if (i % 2 != 0)
                        {
                            grid[i, j] = gridPieces[0];
                        }

                        j++;
                    }

                    j = 0;

                    i++;
                }
            }

            void GridDisplay()
            {
                Console.Clear();

                Console.WriteLine("\nTIC-TAC-TOE\n");

                for (byte i = 0; i < grid.GetLength(0); i++)
                {
                    for (byte j = 0; j < grid.GetLength(1); j++)
                    {
                        if (grid[i, j] == 0) Console.Write(" ");
                        else Console.Write(grid[i, j]);
                    }

                    Console.Write("\n");
                }

                Console.WriteLine("\nRound: " + round);
            }

            void GridPickPosition((byte Index, Positions Position)[] options, out byte option)
            {
                string? input = string.Empty;
                bool available = false;

                while (byte.TryParse(input, out option) == false || available == false)
                {
                    byte counter = 0;

                    GridDisplay();

                    Console.WriteLine("\nAvailable Positions:");

                    for (byte i = 0; i < options.Length; i++) Console.WriteLine(options[i].Position + " - " + options[i].Index);

                    if (round % 2 != 0) Console.WriteLine("\nPlayer 1's Turn");
                    else Console.WriteLine("\nPlayer 2's Turn");

                    Console.Write("\nSelect one option: ");
                    input = Console.ReadLine();

                    if (input == null) input = string.Empty;

                    try
                    {
                        option = byte.Parse(input);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.WriteLine("Invalid option. The value of the option must be a positive whole number that corresponds to one of the listed options.");

                        General.WaitForKeyPress();
                    }

                    while (counter < options.Length)
                    {
                        if (option == options[counter].Index)
                        {
                            available = true;
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }

                    if (byte.TryParse(input, out option) == true && available == false)
                    {
                        Console.WriteLine("Unavailable option. Choose one of the available options.");
                        General.WaitForKeyPress();
                    }
                }
            }

            void GridUpdate(ref (byte Index, Positions Position)[] options, int option)
            {
                (byte Row, byte Column, char Symbol) position;
                (byte Index, Positions Position)[] optionsCopy = options;
                byte k = 0;

                void SavePlayerPositions(ref byte[] positionsPlayer)
                {
                    Array.Resize(ref positionsPlayer, positionsPlayer.Length + 1);
                    positionsPlayer[positionsPlayer.Length - 1] = (byte)option;
                    Array.Sort(positionsPlayer);
                }

                //Determine Row
                if (option <= 3) position.Row = 0;
                else if (option <= 6) position.Row = 2;
                else position.Row = 4;

                //Determine Column
                if (option % 3 == 1) position.Column = 1;
                else if (option % 3 == 2) position.Column = 5;
                else position.Column = 9;

                //Eliminate the grid positions that were filled from the array of available positions.
                options = new (byte Index, Positions Position)[optionsCopy.Length - 1];

                for (byte i = 0; i < optionsCopy.Length; i++)
                {
                    if (optionsCopy[i].Index != option)
                    {
                        options[k] = optionsCopy[i];
                        k++;
                    }
                }

                //Pick a symbol based on the player whose turn it is and update the respective player's array.
                if (round % 2 != 0)
                {
                    position.Symbol = 'X';
                    SavePlayerPositions(ref positionsPlayer1);
                }
                else
                {
                    position.Symbol = '0';
                    SavePlayerPositions(ref positionsPlayer2);
                }

                grid[position.Row, position.Column] = position.Symbol;
            }

            bool GameCheck()
            {
                bool gameOver = false;

                void CheckWinState(byte[] playerPositions)
                {
                    for (byte i = 0; i < playerPositions.Length; i++)
                    {
                        //Forgive me, Lord, for I have sinned...
                        if ((playerPositions[i] % 3 == 1 && playerPositions.Contains((byte)(playerPositions[i] + 1)) && playerPositions.Contains((byte)(playerPositions[i] + 2)))
                            || (playerPositions[i] <= 3 && playerPositions.Contains((byte)(playerPositions[i] + 3)) && playerPositions.Contains((byte)(playerPositions[i] + 6)))
                            || (playerPositions[i] == 3 && playerPositions.Contains((byte)(playerPositions[i] + 2)) && playerPositions.Contains((byte)(playerPositions[i] + 4)))
                            || (playerPositions[i] == 1 && playerPositions.Contains((byte)(playerPositions[i] + 4)) && playerPositions.Contains((byte)(playerPositions[i] + 8))))
                        {
                            gameOver = true;
                            break;
                        }
                    }
                }

                CheckWinState(positionsPlayer1);
                CheckWinState(positionsPlayer2);

                if (gameOver == false && round < 10)
                {
                    round++;

                    return true;
                }
                else
                {
                    GridDisplay();

                    Console.WriteLine("Game Over!");

                    if (round < 10)
                    {
                        if (round % 2 != 0) Console.WriteLine("Player 1 Wins!");
                        else Console.WriteLine("Player 2 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                    }

                    return false;
                }
            }

            void GameLoop()
            {
                General.Answers answer = General.Answers.Y;

                while (answer != General.Answers.N)
                {
                    (byte Index, Positions Position)[] options = { (1, (Positions)1), (2, (Positions)2), (3, (Positions)3), (4, (Positions)4), (5, (Positions)5), (6, (Positions)6), (7, (Positions)7), (8, (Positions)8), (9, (Positions)9) };
                    byte option;

                    positionsPlayer1 = positionsPlayer2 = new byte[0];
                    grid = new char[5, 11];
                    round = 0;

                    GridGenerate();

                    while (GameCheck() == true)
                    {
                        GridPickPosition(options, out option);
                        GridUpdate(ref options, option);
                    }

                    General.WaitForKeyPress();
                    General.GetInputAnswer(out answer, false, "Play Again?");
                }
            }

            GameLoop();
        }
    }

    internal class Pack //16
    {
        private InventoryItem[] items;
        private float currentWeight = 0;
        private float currentVolume = 0;
        private float limitWeight = 25;
        private float limitVolume = 25;
        private byte countItems = 0;
        private int limitItems = 10;

        private string[] options = { "Add Item", "Begin Journey" };
        private string optionConditional = "Discard Item";

        private delegate void AddFirstItem();
        private event AddFirstItem? OnAddFirstItem;

        public float CurrentWeight { get => currentWeight; }
        public float CurrentVolume { get => currentVolume; }
        public float LimitWeight { get => limitWeight; }
        public float LimitVolume { get => limitVolume; }
        public byte CountItems { get => countItems; }
        public int LimitItems { get => limitItems; }

        public Pack() => items = new InventoryItem[limitItems];

        public override string ToString()
        {
            string message = "Pack Containing: \n";

            for (byte i = 0; i < items.Length; i++) message += items[i].ToString() + "\n";

            return message;
        }

        //Adds or removes the "Remove Item" option from the list of available options by checking if there is at least one item to remove.
        private void UpdateOptions()
        {
            if (items[0] != null) //If there is at least one item inside the inventory, the "Remove Item" option is added.
            {
                Array.Resize(ref options, options.Length + 1);

                options[2] = options[1];
                options[1] = optionConditional;

                Console.WriteLine("I'm here!");
            }
            else if (options.Length == 3) //The "Remove Item" option is removed only if it is present on the list.
            {
                options[1] = options[2];

                Array.Resize(ref options, options.Length - 1);

                Console.WriteLine("No, I'm here!");
            }
        }

        private void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("Inventory:");

            if (items[0] == null)
            {
                Console.WriteLine("No items were added to the inventory yet.");

                if (OnAddFirstItem == null)
                {
                    OnAddFirstItem += UpdateOptions;
                    OnAddFirstItem();
                }
            }
            else
            {
                for (byte i = 0; i < items.Length; i++)
                {
                    if (items[i] == null) break;

                    Console.WriteLine(i + ". " + items[i].ToString() + " | Weight: " + items[i].Weight + " | Volume: " + items[i].Volume);
                }
            }

            Console.Write("\n");

            Console.WriteLine("Weight Limit: " + limitWeight + " | Current Weight: " + currentWeight);
            Console.WriteLine("Volume Limit: " + limitVolume + " | Volume Weight: " + currentVolume);
            Console.WriteLine("Items Count: " + countItems + "\\" + limitItems + "\n");
        }

        private void DisplayItems()
        {
            ushort option;

            Console.WriteLine("1. Water");
            Console.WriteLine("2. Food");
            Console.WriteLine("3. Rope");
            Console.WriteLine("4. Sword");
            Console.WriteLine("5. Bow");
            Console.WriteLine("6. Arrow");
            Console.WriteLine("0. Leave");

            General.GetInputUShort(out option, 0, 6, false, "Choose an Item: ");

            switch (option)
            {
                case 1:
                    AddInventoryItem(new Water());
                    break;

                case 2:
                    AddInventoryItem(new Food());
                    break;

                case 3:
                    AddInventoryItem(new Rope());
                    break;

                case 4:
                    AddInventoryItem(new Sword());
                    break;

                case 5:
                    AddInventoryItem(new Bow());
                    break;

                case 6:
                    AddInventoryItem(new Arrow());
                    break;

                case 0:
                    Console.WriteLine("Have a good day!");
                    General.WaitForKeyPress();
                    break;
            }
        }

        private bool AddInventoryItem(InventoryItem item)
        {
            float totalWeight = currentWeight + item.Weight;
            float totalVolume = currentVolume + item.Volume;

            if (totalWeight > limitWeight || totalVolume > limitVolume || (countItems == limitItems))
            {
                if (totalWeight > limitWeight) Console.WriteLine("Weight limit reached! Item Weight: " + item.Weight + " | Current Weight + Item Weight: " + totalWeight + "| Weight Limit: " + limitWeight);
                else if (totalVolume > limitVolume) Console.WriteLine("Volume limit reacehd! Item Volume: " + item.Volume + " | Current Volume + Item Volume: " + totalVolume + "| Volume Limit: " + limitVolume);
                else if (countItems == limitItems) Console.WriteLine("Item limit reached!");

                General.WaitForKeyPress();

                return false;
            }
            else
            {
                items[countItems] = item;

                currentWeight += item.Weight;
                currentVolume += item.Volume;

                countItems++;

                if (OnAddFirstItem != null)
                {
                    OnAddFirstItem();
                    OnAddFirstItem = null;
                }

                return true;
            }
        }

        private void RemoveInventoryItem()
        {
            ushort itemIndex;

            if (countItems == 1) itemIndex = 0;
            else General.GetInputUShort(out itemIndex, 0, (ushort)(countItems - 1), false, "Enter a number corresponding to the index of the item you wish to remove: ");

            currentWeight -= items[itemIndex].Weight;
            currentVolume -= items[itemIndex].Volume;

            countItems--;

            items = items.Where((val, index) => index != itemIndex).ToArray();
        }

        public void PackingInventory()
        {
            ushort option = 1;

            while (option != 0)
            {
                DisplayInventory();

                General.GetInputUShort(out option, options, true, false, "Inventory Options:");

                switch (option)
                {
                    case 1:
                        DisplayItems();
                        break;

                    case 2:
                        RemoveInventoryItem();
                        break;

                    case 0:
                        Console.WriteLine("Good luck, adventurer!");
                        General.WaitForKeyPress();
                        break;
                }
            }
        }
    }

    internal class InventoryItem
    {
        private string name = "Item";
        private float weight;
        private float volume;

        public string Name { get => name; protected set { name = value; } }
        public float Weight { get => weight; protected set { weight = value; } }
        public float Volume { get => volume; protected set { volume = value; } }

        protected InventoryItem(float weight, float volume)
        {
            this.weight = weight;
            this.volume = volume;
        }

        protected InventoryItem() { }

        public override string ToString() { return name; }
    }

    internal class Water : InventoryItem
    {
        public Water(float weight, float volume) : base(2, 3) { Name = "Water"; }

        public Water()
        {
            Name = "Water";
            Weight = 2;
            Volume = 3;
        }
    }

    internal class Food : InventoryItem
    {
        public Food(float weight, float volume) : base(1, 0.5f) { Name = "Food"; }

        public Food()
        {
            Name = "Food";
            Weight = 1;
            Volume = 0.5f;
        }
    }

    internal class Rope : InventoryItem
    {
        public Rope(float weight, float volume) : base(1, 1.5f) { Name = "Rope"; }

        public Rope()
        {
            Name = "Rope";
            Weight = 1;
            Volume = 1.5f;
        }
    }

    internal class Sword : InventoryItem
    {
        public Sword(float weight, float volume) : base(5, 3) { Name = "Sword"; }

        public Sword()
        {
            Name = "Sword";
            Weight = 5;
            Volume = 3;
        }
    }

    internal class Bow : InventoryItem
    {
        public Bow(float weight, float volume) : base(1, 4) { Name = "Bow"; }

        public Bow()
        {
            Name = "Bow";
            Weight = 1;
            Volume = 4;
        }
    }

    public class Robot
    {
        private int positionX = 0;
        private int positionY = 0;
        private bool isPowered = false;

        public int X { get { return positionX; } set { positionX = value; } }
        public int Y { get { return positionY; } set { positionY = value; } }
        public bool IsPowered { get { return isPowered; } set { isPowered = value; } }

        public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

        public void Run()
        {
            foreach (RobotCommand? command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }

        public void TheOldRobot()
        {
            string[] commandsValid = { "on", "off", "north", "south", "west", "east" };
            string[] commandsChosen = new string[3];
            int commandsCount = 0;
            bool operational = false;

            while (commandsCount < Commands.Length)
            {
                string command;
                byte k = 0;

                Console.Clear();
                Console.WriteLine("Available Commands: on | off | north | south | west| east");

                command = General.GetInputString(false, "Enter command " + (commandsCount + 1) + ": ");
                command = command.ToLower();

                while (k < commandsValid.Length)
                {
                    if (command == commandsValid[k])
                    {
                        commandsChosen[commandsCount] = command;
                        break;
                    }
                    else
                    {
                        k++;
                    }
                }

                if (k >= commandsValid.Length || (operational == false && k > 1))
                {
                    Console.WriteLine("Unavailable Command. Choose one of the available commands.");
                    Console.WriteLine("Remember that the robot must be powered on before it can move.");
                    General.WaitForKeyPress();

                    continue;
                }
                else
                {
                    switch (k)
                    {
                        case 0:
                            Commands[commandsCount] = new OnCommand();
                            operational = true;
                            break;

                        case 1:
                            Commands[commandsCount] = new OffCommand();
                            operational = false;
                            break;

                        case 2:
                            Commands[commandsCount] = new NorthCommand();
                            break;

                        case 3:
                            Commands[commandsCount] = new SouthCommand();
                            break;

                        case 4:
                            Commands[commandsCount] = new WestCommand();
                            break;

                        case 5:
                            Commands[commandsCount] = new EastCommand();
                            break;
                    }

                    commandsCount++;
                }
            }

            Console.Clear();

            Console.WriteLine(commandsChosen[0]);
            Console.WriteLine(commandsChosen[1]);
            Console.WriteLine(commandsChosen[2]);

            Console.Write("\n");

            Run();
        }
    }

    public abstract class RobotCommand
    {
        public abstract void Run(Robot robot);
    }

    internal class OnCommand() : RobotCommand
    {
        public override void Run(Robot robot) { robot.IsPowered = true; }
    }

    internal class OffCommand() : RobotCommand
    {
        public override void Run(Robot robot) { robot.IsPowered = false; }
    }

    internal class NorthCommand() : RobotCommand
    {
        public override void Run(Robot robot) { robot.Y += 1; }
    }

    internal class SouthCommand() : RobotCommand
    {
        public override void Run(Robot robot) { robot.Y -= 1; }
    }

    internal class EastCommand() : RobotCommand
    {
        public override void Run(Robot robot) { robot.X += 1; }
    }

    internal class WestCommand() : RobotCommand
    {
        public override void Run(Robot robot) { robot.X -= 1; }
    }
}
