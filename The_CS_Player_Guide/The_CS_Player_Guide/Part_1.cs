
namespace The_CS_Player_Guide
{
    internal class Part_1
    {
        //See the "Watchtower" Challenge.
        private enum Poles : ushort { North, South, West, East, Center };

        //Challenges
        public void HelloWorld() //1
        {
            Console.WriteLine("Hello World!");
        }

        public void WhatComesNext() //2
        {
            string? name;

            Console.WriteLine("What is your name?");

            name = Console.ReadLine();

            Console.WriteLine("Hello, " + name + "!");
        }

        public void TheMakingsOfAProgrammer() //3
        {
            Console.WriteLine("I");
            Console.WriteLine("called");
            Console.WriteLine("\"WriteLine\"");
            Console.WriteLine("five");
            Console.WriteLine("times.");
        }

        public void ConsolasAndTelim() //4
        {
            string? name;

            Console.WriteLine("Bread is ready.");
            Console.WriteLine("Who is the bread for?");

            name = Console.ReadLine();

            Console.WriteLine("Noted: " + name + " got bread.");
        }

        public void TheThingNamer3000() //5
        {
            /*predefined cahracteristics of
             *the thing we are talking about*/
            string origin = "of Doom";
            string number = "3000";

            Console.WriteLine("What kind of thing are we talking about?");
            string? thing = Console.ReadLine(); //the name of thing we are talking about

            Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
            string? description = Console.ReadLine(); //the description of the thing we are talking about

            Console.WriteLine("The " + description + " " + thing + " " + origin + " " + number + "!"); //the complete presentation
        }

        public void TheVariableShop() //6
        {
            bool someBool = true;
            byte someByte = 0b00001010;
            sbyte someSByte = -0b00001010;
            short someShort = -25;
            int someInt = -50;
            long someLong = -75L;
            ushort someUShort = 20;
            uint someUInt = 50U;
            ulong someULong = 75UL;
            float someFloat = 2.5f;
            double someDouble = 5.0f;
            decimal someDecimal = 7e25M;
            char someChar = 'c';
            string? someString = "some string";

            void TheVariableList()
            {
                Console.WriteLine("someBool = " + someBool);
                Console.WriteLine("someByte = " + someByte);
                Console.WriteLine("someSByte = " + someSByte);
                Console.WriteLine("someShort = " + someShort);
                Console.WriteLine("someInt = " + someInt);
                Console.WriteLine("someLong = " + someLong);
                Console.WriteLine("someUShort = " + someUShort);
                Console.WriteLine("someUInt = " + someUInt);
                Console.WriteLine("someULong = " + someULong);
                Console.WriteLine("someFloat = " + someFloat);
                Console.WriteLine("someDouble = " + someDouble);
                Console.WriteLine("someDecimal = " + someDecimal);
                Console.WriteLine("someChar = " + someChar);
                Console.WriteLine("someString = " + someString + "\n");
            }

            Console.WriteLine("The Variables and Their Values:");
            TheVariableList();

            Console.WriteLine("Update The Values:");
            Console.Write("someBool = ");
            someBool = Convert.ToBoolean(Console.ReadLine());
            Console.Write("someByte = ");
            someByte = Convert.ToByte(Console.ReadLine());
            Console.Write("someSByte = ");
            someSByte = Convert.ToSByte(Console.ReadLine());
            Console.Write("someShort = ");
            someShort = Convert.ToInt16(Console.ReadLine());
            Console.Write("someInt = ");
            someInt = Convert.ToInt32(Console.ReadLine());
            Console.Write("someLong = ");
            someLong = Convert.ToInt64(Console.ReadLine());
            Console.Write("someUShort = ");
            someUShort = Convert.ToUInt16(Console.ReadLine());
            Console.Write("someUInt = ");
            someUInt = Convert.ToUInt32(Console.ReadLine());
            Console.Write("someULong = ");
            someULong = Convert.ToUInt64(Console.ReadLine());
            Console.Write("someFloat = ");
            someFloat = Convert.ToSingle(Console.ReadLine());
            Console.Write("someDouble = ");
            someDouble = Convert.ToDouble(Console.ReadLine());
            Console.Write("someDecimal = ");
            someDecimal = Convert.ToDecimal(Console.ReadLine());
            Console.Write("someChar = ");
            char.TryParse(Console.ReadLine(), out someChar);
            Console.Write("someString = ");
            someString = Console.ReadLine();
            Console.Write("\n");

            Console.WriteLine("The Variables and Their Updated Values:");
            TheVariableList();
        }

        public void TheTriangleFarmer() //7
        {
            float triangleBase;
            float triangleHeight;
            float area;

            Console.Write("Enter the size of the triangle base: ");
            triangleBase = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter the size of the triangle height: ");
            triangleHeight = Convert.ToSingle(Console.ReadLine());

            area = (triangleBase * triangleHeight) / 2;

            Console.WriteLine("The area of the triangle: " + area);
        }

        public void TheFourSistersAndTheDuckbear() //8
        {
            int chocolateEggs;
            int chocolateEggsPerSister;
            int chocolateEggsForDuckBear;

            Console.Write("Enter the number of chocolate eggs that were gathered today: ");
            chocolateEggs = Convert.ToInt32(Console.ReadLine());

            chocolateEggsPerSister = chocolateEggs / 4; //divide by 4 because there are four sisters
            chocolateEggsForDuckBear = chocolateEggs % 4; //the duckbear receives the remainder of the chocolate eggs after they were divided evenly among the fout sisters

            Console.WriteLine("Each sister receives " + chocolateEggsPerSister + " chocolate egg(s).");
            Console.WriteLine("The Duckbear receives the remaining " + chocolateEggsForDuckBear + " chocolate egg(s).");
        }

        public void TheDominionOfKings() //9
        {
            int provinces, duchies, estates, provincesScore, duchiesScore, finalScore = 0;

            Console.Write("Enter the number of provinces you own: ");
            provinces = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of duchies you own: ");
            duchies = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of estates you own: ");
            estates = Convert.ToInt32(Console.ReadLine());

            provincesScore = provinces * 6;
            duchiesScore = duchies * 3;

            finalScore += estates + duchiesScore + provincesScore;

            Console.WriteLine("\nScoring System");
            Console.WriteLine("Each estate is worth 1 point.");
            Console.WriteLine("Each duchy is worth 3 points.");
            Console.WriteLine("Each province is worth 6 points.");

            Console.WriteLine("\nCalculating Score:");
            Console.WriteLine(provinces + " provinces " + " * 6 = " + provincesScore);
            Console.WriteLine(duchies + " duchies " + " * 3  = " + duchiesScore);
            Console.WriteLine(estates + " estates " + " * 1 = " + estates);

            Console.WriteLine(provincesScore + " + " + duchiesScore + " + " + estates + " = " + finalScore);
            Console.WriteLine("\nFinal Score: " + finalScore);
        }

        public void TheDefenseOfConsolas() //10
        {
            ushort[] positionsX, positionsY;
            ushort row, column;

            void DetermineCoordinates(ushort value, out ushort[] positions)
            {
                //Address the scenario in which the position that is under attack is located at the edge of the grid.
                if (value == ushort.MinValue || value == ushort.MaxValue) positions = new ushort[1];
                else positions = new ushort[2];

                if (positions.Length == 1)
                {
                    if (value == ushort.MinValue) positions[0] = (ushort)(value + 1);
                    else positions[0] = (ushort)(value - 1);
                }
                else
                {
                    positions[0] = (ushort)(value - 1);
                    positions[1] = (ushort)(value + 1);
                }
            }

            void Deploy()
            {
                Console.WriteLine("Deploy to:");

                Console.WriteLine($"({row}, {positionsX[0]})");
                Console.WriteLine($"({positionsY[0]}, {column})");

                if (positionsX.Length != ushort.MinValue && positionsX.Length != ushort.MaxValue) Console.WriteLine($"({row}, {positionsX[1]})");
                if (positionsY.Length != ushort.MinValue && positionsY.Length != ushort.MaxValue) Console.WriteLine($"({positionsY[1]}, {column})");

                //A "for" loop is not viable option for completing this task as it is too expensive.
                //for (int i = 0; i < positionsY.Length; i++) Console.WriteLine($"({row}, {positionsX[i]})");
                //for (int i = 0; i < positionsX.Length; i++) Console.WriteLine($"({positionsY[i]}, {column})");

                Console.Beep();
            }

            Console.Clear();

            General.GetInputUShort(out row, true, "Enter the row value: ");
            General.GetInputUShort(out column, true, "Enter the column value: ");

            DetermineCoordinates(row, out positionsY);
            DetermineCoordinates(column, out positionsX);

            Deploy();
        }

        public void RepairingTheClocktower() //11
        {
            string? input = "";
            string message;
            int number;

            while (int.TryParse(input, out number) == false)
            {
                Console.Clear();

                Console.Write("Enter a number: ");
                input = Console.ReadLine();

                if (input == null) input = "";

                try
                {
                    number = int.Parse(input);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Invalid input. The value must be a whole number. Press any key in order to try again.");

                    Console.ReadKey(true);
                }
            }

            message = number % 2 == 0 ? "Tick" : "Tock";

            Console.WriteLine(message);
        }

        public void Watchtower() //12
        {
            Poles poleX, poleY;
            int directionX, directionY;

            Poles DeterminePole(int value, bool vertical)
            {
                Poles pole = Poles.Center;

                if (vertical == true) pole = value > 0 ? Poles.North : Poles.South;
                else pole = value > 0 ? Poles.East : Poles.West;

                return pole;
            }

            directionX = General.GetInputInt(out directionX, true);
            directionY = General.GetInputInt(out directionY, true);

            poleX = DeterminePole(directionX, false);
            poleY = DeterminePole(directionY, true);

            if (poleX == Poles.Center && poleY == Poles.Center) Console.WriteLine("The enemy is here!");
            else if (poleX == Poles.Center && poleY != Poles.Center) Console.WriteLine("The enemy is to the " + poleY + "!");
            else if (poleX != Poles.Center && poleY == Poles.Center) Console.WriteLine("The enemy is to the " + poleX + "!");
            else Console.WriteLine("The enemy is to the " + poleY + poleX + "!");
        }

        public void BuyingInventoryAndDiscountedInventory() //13 //14
        {
            (string Name, uint Price) detailsRope = ("Rope", 25),
                                      detailsTorch = ("Torch", 15),
                                      detailsClimbingEquipment = ("Climbing Equipment", 50),
                                      detailsCleanWater = ("Clean Water", 1),
                                      detailsMachete = ("Machete", 17),
                                      detailsCanoe = ("Canoe", 100),
                                      detailsFoodSupplies = ("Food Supplies", 5);

            string shopOwnerName = "Napoleon";
            string? shopperName;
            uint coins;
            int item = -1;

            Console.WriteLine("What is your name?");
            shopperName = Console.ReadLine();

            if (shopperName == shopOwnerName)
            {
                Console.WriteLine("That's my name, too! You can have anything in this shop at half the price. " + shopOwnerName + "s must look out for one another.");

                detailsRope.Price /= 2;
                detailsTorch.Price /= 2;
                detailsClimbingEquipment.Price /= 2;
                detailsCleanWater.Price /= 2;
                detailsMachete.Price /= 2;
                detailsCanoe.Price /= 2;
                detailsFoodSupplies.Price /= 2;
            }
            else
            {
                Console.WriteLine("Haven't seen you around these parts. Anyway, care to buy something?");
            }

            void ListItems()
            {
                Console.WriteLine("The following items are available:");
                Console.WriteLine("1 – Rope");
                Console.WriteLine("2 – Torch");
                Console.WriteLine("3 – Climbing Equipment");
                Console.WriteLine("4 – Clean Water");
                Console.WriteLine("5 – Machete");
                Console.WriteLine("6 – Canoe");
                Console.WriteLine("7 – Food Supplies");
                Console.WriteLine("0 - Checkout");

                Console.WriteLine("\nCoins: " + coins);
            }

            void SellItem((string Name, uint Price) details)
            {
                General.Answers answer;

                Console.WriteLine("The " + details.Name + " costs " + details.Price + " coin(s).");

                General.GetInputAnswer(out answer, false, "Do you want to purchase the " + details.Name + "?");

                if (answer == General.Answers.N)
                {
                    Console.WriteLine("Alright! Do you want anything else?");
                }
                else
                {
                    if (coins < details.Price)
                    {
                        Console.WriteLine("Insufficient coins.");
                    }
                    else
                    {
                        uint moneyLeft = coins - details.Price;

                        Console.WriteLine(details.Name + " bought.");
                        Console.WriteLine(coins + "coin(s) - " + details.Price + "coin(s)= " + moneyLeft + " coin(s)");
                        Console.WriteLine("Remaining Coin(s): " + moneyLeft);

                        coins = moneyLeft;
                    }
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }

            Console.WriteLine("Press any key in order to enter the ammount of coins you have.");
            Console.ReadKey(true);

            General.GetInputUInt(out coins, false);

            while(item != 0)
            {
                Console.Clear();

                ListItems();

                Console.WriteLine("Press any key in order to specify the item you want to check out.");
                Console.ReadKey(true);

                General.GetInputInt(out item, false);

                switch (item)
                {
                    case 1:
                        SellItem(detailsRope);
                        break;

                    case 2:
                        SellItem(detailsTorch);
                        break;

                    case 3:
                        SellItem(detailsClimbingEquipment);
                        break;

                    case 4:
                        SellItem(detailsCleanWater);
                        break;

                    case 5:
                        SellItem(detailsMachete);
                        break;

                    case 6:
                        SellItem(detailsCanoe);
                        break;

                    case 7:
                        SellItem(detailsFoodSupplies);
                        break;

                    case 0:
                        Console.WriteLine("Have a good day!");
                        Console.WriteLine("Press any key in order to exit the shop.");
                        Console.ReadKey(true);
                        break;

                    default:
                        Console.WriteLine("Unavailable Option. Press any key in order to try again.");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        public void ThePrototype() //15
        {
            int numberToGuess = -1;
            uint guess = 101;

            while (numberToGuess < 0 || numberToGuess > 100)
            {
                Console.Clear();
                Console.WriteLine("User 1, enter a number between 0 and 100: ");

                General.GetInputInt(out numberToGuess, false);

                if (numberToGuess < 0 || numberToGuess > 100) Console.WriteLine("That number must be greater than 0 and lower than 100. Enter another number.");
            }

            while (guess != numberToGuess)
            {
                Console.Clear();
                Console.WriteLine("User 2, guess the number that User 1 entered.");

                General.GetInputUInt(out guess, false);

                if (guess < numberToGuess) Console.WriteLine(guess + " is too low.");
                else if (guess > numberToGuess) Console.WriteLine(guess + " is too high.");
                else Console.WriteLine("You guessed the number!");

                Console.WriteLine("Press any key in order to guess another number.");
                Console.ReadKey(true);
            }
        }

        public void TheMagicCannon() //16
        {
            ushort fire = 0;

            while (fire < 100)
            {
                fire++;

                Console.Write(fire + ": ");

                if (fire % 3 == 0 && fire % 5 == 0) Console.WriteLine("Electric Fire");
                else if (fire % 3 == 0) Console.WriteLine("Fire");
                else if (fire % 5 == 0) Console.WriteLine("Electric");
                else Console.WriteLine("Normal");
            }
        }

        public void TheReplicatorOfDTo() //17
        {
            int[] array = new int[5];
            int[] arrayCopy;

            arrayCopy = new int[array.Length];

            Console.WriteLine("Enter 5 values.\n");

            for (int i = 0; i < array.Length; i++)
            {
                General.GetInputInt(out array[i], false, "array[" + i + "] = ");
                arrayCopy[i] = array[i];
            }

            Console.WriteLine("\nArray                    Copy\n");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
                Console.WriteLine($"{arrayCopy[i], 25}");
            }
        }

        public void TheLawsOfFreach() //18
        {
            int[] numbers = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int currentSmallest = int.MaxValue; // Start higher than anything in the array.
            int total = 0;

            foreach (int number in numbers)
            {
                if (number < currentSmallest)
                    currentSmallest = number;
            }

            Console.WriteLine("The smalles number in the array is " + currentSmallest + ".");

            foreach (int number in numbers)
                total += number;

            float average = (float)total / numbers.Length;

            Console.WriteLine("The average of the values inside the array is " + average + ".");
        }

        public void TakingANumber() //19
        {
            int resultAskForNumber;
            int resultAskForNumberInRange;

            int AskForNumber(string text)
            {
                int number = int.MaxValue;
                int numberDesired = 1729;

                while (number != numberDesired)
                {
                    Console.Clear();
                    Console.WriteLine(text);

                    General.GetInputInt(out number, false);

                    if (number != numberDesired)
                    {
                        Console.WriteLine("That is not the correct number. Press any key in order to try again.");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        Console.WriteLine(number + " is the correct answer.");
                        Console.ReadKey(true);
                    }
                }

                return number;
            }

            resultAskForNumber = AskForNumber("What is the Ramanujan number?");

            General.GetInputInt(out resultAskForNumberInRange, 0, 100, false, "Enter a number between 0 and 100.", "Invalid input. The value must be a whole number between 0 and 100.");
            Console.WriteLine(resultAskForNumberInRange + " is the correct number.");
        }

        public void Countdown(int number) //20
        {
            Console.WriteLine(number);
            if (number != 1) Countdown(number - 1); //Bottom case, the alternative to a base case. :)
        }

        public void HuntingTheManticore() //21
        {
            ushort round = 1,
                   healthManticore = 10,
                   healthCity = 15,
                   rangeManticore = 101,
                   rangeTarget,
                   cannonDamage;

            void DiplayRoundInformation()
            {
                Console.WriteLine($"Round {round}");
                Console.WriteLine($"Manticore Health: {healthManticore}");
                Console.WriteLine($"City Health: {healthCity}");
            }

            void DetermineCannonDamage()
            {
                if (round % 3 == 0 && round % 5 == 0) cannonDamage = 10;
                else if ((round % 3 == 0 && round % 5 != 0) || (round % 3 != 0 && round % 5 == 0)) cannonDamage = 3;
                else cannonDamage = 1;
            }

            void InputPlayer1()
            {
                while (rangeManticore > 100)
                {
                    General.GetInputUShort(out rangeManticore, true, "Enter the range of the Manticore (0 to 100): ", "The range of the Manticore must be a positive whole number.");

                    if (rangeManticore > 100) Console.WriteLine("The range of the Manticore must be a positive whole number between 0 and 100.");
                }

                Console.Clear();
            }

            void InputPlayer2()
            {
                General.GetInputUShort(out rangeTarget, false, "Enter the position of the Manticore (0 to 100): ", "The range of the Manticore is a positive whole number between 0 and 100.");

                if (rangeTarget < rangeManticore) Console.WriteLine("The cannon undershot the Manticore.");
                else if (rangeTarget > rangeManticore) Console.WriteLine("The cannon overshot the Manticore.");
                if (rangeTarget == rangeManticore)
                {
                    Console.WriteLine("The cannon hit the Manticore!");
                    healthManticore = (ushort)(healthManticore - cannonDamage) < 0 ? (ushort)0 : (ushort)(healthManticore - cannonDamage);
                }

                Console.WriteLine("\nPress any key in order to advance to the next round.");
                Console.ReadKey(true);
            }

            void GameOver()
            {
                Console.WriteLine("Game Over!");

                if (healthManticore > 0) Console.WriteLine($"\nThe Manticore destroyed the city.\nManticore Health: {healthManticore}");
                else Console.WriteLine($"\nThe City is saved.\nCity Health: {healthCity}");

                Console.WriteLine("\nThe game lasted " + round + " rounds.\nPress any key in order to continue.");
            }

            while (healthManticore > 0 && healthCity > 0)
            {
                InputPlayer1();

                DiplayRoundInformation();
                DetermineCannonDamage();

                InputPlayer2();

                rangeManticore = 101;
                healthCity--;
                round++;
            }

            GameOver();
        }
    }
}
