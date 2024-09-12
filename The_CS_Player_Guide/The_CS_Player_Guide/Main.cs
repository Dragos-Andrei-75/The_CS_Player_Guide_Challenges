// See https://aka.ms/new-console-template for more information

using The_CS_Player_Guide;

Part_1 part1 = new Part_1();
Part_2 part2 = new Part_2();
Part_3 part3 = new Part_3();
Part_4 part4 = new Part_4();
Part_5 part5 = new Part_5();

string[] parts = {
                  "The Basics",
                  "Object-Oriented Programming",
                  "Advanced Topics",
                  "The Endgame",
                  "Bonus Levels",
                  "Exit",
                 },

         part1Challenges = {
                            "Hello World",
                            "What Comes Next",
                            "The Makings of a programmer",
                            "Consolas and Telim",
                            "The Thing Namer 3000",
                            "The Variable Shop",
                            "The Triangle Farmer",
                            "The Four Sisters and the Duckbear",
                            "The Dominion of Kings",
                            "The Defense of Consolas",
                            "Repairing the Clocktower",
                            "Watchtower",
                            "Buying Inventory",
                            "Discounted Inventory",
                            "The Prototype",
                            "The Magic Cannon",
                            "The Replicator of D’To",
                            "The Laws of Freach",
                            "Taking a Number",
                            "Countdown",
                            "Hunting the Manticore",
                            "Return to Main Menu"
                           },

         part2Challenges = {
                            "Simula's Test",
                            "Simula’s Soup",
                            "Vin Fletcher’s Arrows",
                            "Vin’s Trouble",
                            "The Properties of Arrows",
                            "Arrow Factories",
                            "The Point",
                            "The Color",
                            "The Card",
                            "The Locked Door",
                            "The Password Validator",
                            "Rock-Paper-Scissors",
                            "15-Puzzle",
                            "Hangman",
                            "Tic-Tac-Toe",
                            "Packing Inventory",
                            "Labeling Inventory",
                            "The Old Robot",
                            "Return to Main Menu"
                           },

         part3Challenges = {
                            "Return to Main Menu"
                           },

         part4Challenges = {
                            "Return to Main Menu"
                           },

         part5Challenges = {
                            "Return to Main Menu"
                           };

string partsHeader = "The C# Player's Guide",
       part1Header = "Part 1 - The Basics",
       part2Header = "Part 2 - Object-Oriented Programming",
       part3Header = "Part 3 - Advanced Topics",
       part4Header = "Part 4 - The Endgame",
       part5Header = "Part 5 - Bonus Levels";

ushort option = ushort.MaxValue;

void Menu(Action Options, string[] options, string header)
{
    while (option != 0)
    {
        General.GetInputUShort(out option, options, true, true, header);

        Options();

        Console.ReadKey(true);
    }

    option = ushort.MaxValue;
}

void OptionsParts()
{
    switch (option)
    {
        case 1:
            Menu(OptionsPart1, part1Challenges, part1Header);
            break;

        case 2:
            Menu(OptionsPart2, part2Challenges, part2Header);
            break;

        case 3:
            Menu(OptionsPart3, part3Challenges, part3Header);
            break;

        case 4:
            Menu(OptionsPart4, part4Challenges, part4Header);
            break;

        case 5:
            Menu(OptionsPart5, part5Challenges, part5Header);
            break;

        case 0:
            General.ExitMessage("Program stopped.");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Unavailable option. Choose one of the available options.");
            break;
    }
}

void OptionsPart1()
{
    switch (option)
    {
        case 1:
            part1.HelloWorld();
            break;

        case 2:
            part1.WhatComesNext();
            break;

        case 3:
            part1.TheMakingsOfAProgrammer();
            break;

        case 4:
            part1.ConsolasAndTelim();
            break;

        case 5:
            part1.TheThingNamer3000();
            break;

        case 6:
            part1.TheVariableShop();
            break;

        case 7:
            part1.TheTriangleFarmer();
            break;

        case 8:
            part1.TheFourSistersAndTheDuckbear();
            break;

        case 9:
            part1.TheDominionOfKings();
            break;

        case 10:
            part1.TheDefenseOfConsolas();
            break;

        case 11:
            part1.RepairingTheClocktower();
            break;

        case 12:
            part1.Watchtower();
            break;

        case 13:
        case 14:
            part1.BuyingInventoryAndDiscountedInventory();
            break;

        case 15:
            part1.ThePrototype();
            break;

        case 16:
            part1.TheMagicCannon();
            break;

        case 17:
            part1.TheReplicatorOfDTo();
            break;

        case 18:
            part1.TheLawsOfFreach();
            break;

        case 19:
            part1.TakingANumber();
            break;

        case 20:
            part1.Countdown(10);
            break;

        case 21:
            part1.HuntingTheManticore();
            break;

        case 0:
            General.ExitMessage("Returning to the main menu.");
            break;

        default:
            Console.WriteLine("Unavailable option. Choose one of the available options.");
            break;
    }
}

void OptionsPart2()
{
    switch (option)
    {
        case 1:
            part2.SimulasTest();
            break;

        case 2:
            part2.SimulasSoup();
            break;

        case 3:
        case 4:
        case 5:
        case 6:
            Arrow arrowFactories = new Arrow();
            arrowFactories.ArrowFactories();
            break;

        case 7:
            Point thePoint = new Point();
            thePoint.ThePoint();
            break;

        case 8:
            Color theColor = new Color();
            theColor.TheColor();
            break;

        case 9:
            Card theCard = new Card();
            theCard.TheCard();
            break;

        case 10:
            Door door = new Door();
            door.TheLockedDoor();
            break;

        case 11:
            PasswordValidator passwordValidator = new PasswordValidator();
            passwordValidator.ThePasswordValidator();
            break;

        case 12:
            RockPaperScissors rockPaperScissors = new RockPaperScissors();
            rockPaperScissors.RockPaperScissorsGame();
            break;

        case 13:
            Puzzle15 puzzle15 = new Puzzle15();
            puzzle15.Puzzle15Game();
            break;

        case 14:
            HangMan hangMan = new HangMan();
            hangMan.HangManGame();
            break;

        case 15:
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.TicTacToeGame();
            break;

        case 16:
        case 17:
            Pack pack = new Pack();
            pack.PackingInventory();
            break;

        case 18:
            Robot robot = new Robot();
            robot.TheOldRobot();
            break;

        case 0:
            General.ExitMessage("Returning to the main menu.");
            break;

        default:
            Console.WriteLine("Unavailable option. Choose one of the available options.");
            break;
    }
}

void OptionsPart3()
{
    switch (option)
    {
        case 0:
            General.ExitMessage("Returning to the main menu.");
            break;

        default:
            Console.WriteLine("Unavailable option. Choose one of the available options.");
            break;
    }
}

void OptionsPart4()
{
    switch (option)
    {
        case 0:
            General.ExitMessage("Returning to the main menu.");
            break;

        default:
            Console.WriteLine("Unavailable option. Choose one of the available options.");
            break;
    }
}

void OptionsPart5()
{
    switch (option)
    {
        case 0:
            General.ExitMessage("Returning to the main menu.");
            break;

        default:
            Console.WriteLine("Unavailable option. Choose one of the available options.");
            break;
    }
}

Console.Title = "The C# Player's Guide";
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Green;

Menu(OptionsParts, parts, partsHeader);
