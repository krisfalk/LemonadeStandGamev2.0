using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer startGame = new SoundPlayer("http://themushroomkingdom.net/sounds/wav/sm3dl/sm3dl_luigi_lets-a_go.wav");
            startGame.Play();

            Game game = new Game();
            game.RunGame(0);
        }
    }
}
