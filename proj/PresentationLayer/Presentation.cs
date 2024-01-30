using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public enum menuState
    {
        Initial,
        PlayersAdded,
        Player1ConfiguringShips,
        Player2ConfiguringShips,
        ShipsConfigured,
    }
    public class Presentation
    {

        private Logic logic = new Logic();
        private menuState menuState = menuState.Initial;
        private PlayerManager playerManager;
        public string player1;
        public string player2;

        public Presentation()
        {
            this.playerManager = new PlayerManager(logic);
        }
        public void Start()
        {
            Console.Clear();

            ShowMenu();
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Battleship!");
                Console.WriteLine("Please select an option:");


                if (menuState == menuState.Initial)
                {
                    Console.WriteLine("1. Add Player Details");
                    Console.WriteLine("4. Quit");
                }
                else if (menuState == menuState.PlayersAdded)
                {
                    Console.WriteLine("2. Configure Ships");
                    Console.WriteLine("4. Quit");
                }
                else if (menuState == menuState.ShipsConfigured)
                {
                    Console.WriteLine("3. Launch Attack");
                    Console.WriteLine("4. Quit");
                }

                // Handle user input
                string userInput = Console.ReadLine();

                // Process the selection based on the current gameState
                switch (userInput)
                {
                    case "1":
                        if (menuState == menuState.Initial)
                        {
                            playerManager.addPlayer(player1); // Implement this method according to your game logic
                            playerManager.addPlayer(player2);
                            menuState = menuState.PlayersAdded; // Move to the next state
                        }
                        break;
                    case "2":
                        if (menuState == menuState.PlayersAdded)
                        {
                            //method for configship
                            //ConfigureShips(); // Implement this method according to your game logic
                            menuState = menuState.ShipsConfigured; // Move to the next state
                        }
                        break;
                    case "3":
                        if (menuState == menuState.ShipsConfigured)
                        {
                            //LaunchAttack(); // Implement this method according to your game logic
                                            // GameState might change based on the game outcome
                        }
                        break;
                    case "4":
                        quit(); 
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public void quit()
        {
            Console.WriteLine("Exiting...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public class PlayerManager
        {
            private Logic logic;

            public PlayerManager(Logic logic)
            {
                this.logic = logic;
            }

            public void addPlayer(string playerName)
            {
                Console.Clear();
                Console.WriteLine($"Add {playerName} details:");
                Console.WriteLine("Please enter a username:");
                string username = Console.ReadLine();

                if (logic.checkIfPlayerExists(username))
                {
                    while (true)
                    {
                        Console.WriteLine($"Welcome back {username}, Please enter your password or press Esc to exit:");
                        var keyInfo = Console.ReadKey(); // true to not echo the pressed key
                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("Exiting..."); 
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();


                            // Logic to handle the escape action
                            return;
                        }

                        string password = keyInfo.KeyChar + Console.ReadLine();

                        if (logic.checkPassword(username, password))
                        {
                            Console.WriteLine("Login successful");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Password incorrect. Please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Username not found.");
                    Console.WriteLine("Please enter a password to sign up.");
                    string password = Console.ReadLine();
                    logic.addPlayer(username, password);
                    Console.WriteLine("Player has been successfully added to the database!");
                    Console.ReadKey();
                }
            }
        }

    }
}
