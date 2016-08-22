using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class FileWriter
    {
        public FileWriter(List<string> stuffToSave)
        {
            TextWriter saveGame = new StreamWriter(".\\savedGame.txt");

            foreach(string data in stuffToSave)
            {
                saveGame.WriteLine(data);
            }

            saveGame.Close();
            Environment.Exit(0);
        }
    }
}
