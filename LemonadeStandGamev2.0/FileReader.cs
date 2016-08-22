using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class FileReader
    {
        public FileReader()
        {
            List<string> loadSave = new List<String>();

            TextReader readSave = new StreamReader(".\\savedGame.txt");

            int lineCount = File.ReadAllLines(".\\savedGame.txt").Length;

            for (int i = 0; i < lineCount; i++)
            {
                loadSave.Add(readSave.ReadLine());
            }
            readSave.Close();
            File.Delete(".\\savedGame.txt");
            Game game = new Game();
            game.ResumeGame(loadSave);
        }
    }
}
