using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Game
    {
        Player[] players;
        Customer[] customers;
        Store store;
        Day day;
        public Game()
        {
            store = new Store();
            day = new Day();
        }
        public void RunGame(int load)
        {
            CheckLoadSaveGame(load);
            SetupGame(load);
            while(day.GetDayNumber() <= day.GetTotalDays())
            {
                CheckSaveOrContinue();
                TakeTurns();
                day.AdvanceDay();
            }
            EndGame();
        }
        public void SetupGame(int load)
        {
            if (load == 0)
            {
                Console.WriteLine("Welcome to Kris' Lemonade Stand Game!\nHow many players for this game?");
                players = new Player[Convert.ToInt32(Console.ReadLine())];
                SetupEachPlayer();
                day.AskNumberDays();
            }
        }
        public void SetupEachPlayer()
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("Enter name for player {0}:", i + 1);
                players[i] = new Player(Console.ReadLine());
            }
        }
        public void TakeTurns()
        {
            for (int i = 0; i < players.Length; i++)
            {
                store.SellEachIngredients(players[i]);
                day.PrintDay();
                players[i].recipe.SetRecipe(players[i].GetName());
                FillCustomerBase(i);
                day.RunPlayerDay(players[i], customers);
                players[i].inventory.SpoilIce(players[i].inventory.CountIce());
            }
        }
        public void FillCustomerBase(int index)
        {
            customers = new Customer[players[index].popularity.BonusCustomers()];
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = new Customer(i + 1);
            }
        }
        public void EndGame()
        {
            Console.Clear();
            for (int i = 0; i < players.Length; i++)
            {
                players[i].PrintPlayerBankFinal(players[i]);
            }
            Console.WriteLine("\nPress enter to exit game.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public void CheckSaveOrContinue()
        {
            Console.WriteLine("Would you like to save and exit game?\nType 'yes' to save and exit or press enter to continue.");
            if (Console.ReadLine() == "yes")
            {
                List<string> stuffToSave = new List<string>();
                stuffToSave = FillList();
                FileWriter saveGame = new FileWriter(stuffToSave);
            }
        }
        public List<string> FillList()
        {
            List<string> saving = new List<string>();
            saving.Add(Convert.ToString(players.Length));
            saving.Add(Convert.ToString(day.GetDayNumber()));
            saving.Add(Convert.ToString(day.GetTotalDays()));
            saving.Add(day.today.GetWeatherType());
            saving.Add(Convert.ToString(day.today.GetTemperature()));
            saving.Add(day.tomorrow.GetWeatherType());
            saving.Add(Convert.ToString(day.tomorrow.GetTemperature()));
            for (int i = 0; i < players.Length; i++)
            {
                saving.Add(players[i].GetName());
                saving.Add(Convert.ToString(players[i].inventory.CountCups()));
                saving.Add(Convert.ToString(players[i].inventory.CountLemons()));
                saving.Add(Convert.ToString(players[i].inventory.CountSugar()));
                saving.Add(Convert.ToString(players[i].popularity.GetPopularityLevel()));
                saving.Add(Convert.ToString(players[i].bank.GetMoney()));
                saving.Add(Convert.ToString(players[i].bank.GetIncome()));
                saving.Add(Convert.ToString(players[i].bank.GetSpent()));
            }
            return saving;
        }
        public void CheckLoadSaveGame(int load)
        {
            FileReader loadGame;
            if (load == 0)
            {
                Console.WriteLine("Would you like to load last saved game?");
                if(Console.ReadLine() == "yes")
                {
                    loadGame = new FileReader();
                }
            }
        }
        public void ResumeGame(List<string> loadSave)
        {
            int numberOfPlayers;
            int dayNumber;
            int totalDays;
            int temperature1;
            int temperature2;

            int.TryParse(loadSave[0], out numberOfPlayers);
            int.TryParse(loadSave[1], out dayNumber);
            day.LoadDayNumber(dayNumber);
            int.TryParse(loadSave[2], out totalDays);
            day.LoadTotalDays(totalDays);
            day.today.LoadType(loadSave[3]);
            int.TryParse(loadSave[4], out temperature1);
            day.today.LoadTemperature(temperature1);
            day.tomorrow.LoadType(loadSave[5]);
            int.TryParse(loadSave[6], out temperature2);
            day.tomorrow.LoadTemperature(temperature2);


            players = new Player[numberOfPlayers];
            for (int i = 0; i < players.Length; i++)
            {
                int cups;
                int lemons;
                int sugar;
                int popularity;
                double money;
                double income;
                double spent;

                players[i] = new Player(loadSave[7 + (8 * i)]);

                int.TryParse(loadSave[8 + (8 * i)], out cups);
                players[i].inventory.LoadCups(cups);
                int.TryParse(loadSave[9 + (8 * i)], out lemons);
                players[i].inventory.LoadLemons(lemons);
                int.TryParse(loadSave[10 + (8 * i)], out sugar);
                players[i].inventory.LoadSugar(sugar);
                int.TryParse(loadSave[11 + (8 * i)], out popularity);
                players[i].popularity.LoadPopularity(popularity);
                double.TryParse(loadSave[12 + (8 * i)], out money);
                players[i].bank.AddMoney(money);
                double.TryParse(loadSave[13 + (8 * i)], out income);
                players[i].bank.AddIncome(income);
                double.TryParse(loadSave[14 + (8 * i)], out spent);
                players[i].bank.AddSpent(spent);
            }
            RunGame(1);
        }
    }
}
