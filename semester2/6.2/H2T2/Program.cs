using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2T2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var map = new List<char[]>();
            var fir = new char[] { '#', '#', '#', '#', '#' };
            var sec = new char[] { '#', ' ', '#', ' ', '#' };
            var thi = new char[] { '#', ' ', '#', ' ', '#' };
            var forth = new char[] { '#', ' ', ' ', ' ', '#' };
            var fif = new char[] { '#', '#', '#', '#', '#' };
            map.Add(fir); map.Add(sec); map.Add(thi); map.Add(forth); map.Add(fif);
            var game = new Game(map);
            game.Draw(game, null);
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.TopHandler += game.OnTop;
            eventLoop.BottomHandler += game.OnBottom;
            eventLoop.LeftHandler += game.Draw;
            eventLoop.RightHandler += game.Draw;
            eventLoop.TopHandler += game.Draw;
            eventLoop.BottomHandler += game.Draw;
            eventLoop.Run();
        }
    }
}
