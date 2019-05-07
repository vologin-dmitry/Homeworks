using System.Collections.Generic;

namespace H6T2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var map = new List<char[]>();
            var game = new Game(FileReader.MakeList("map.txt"));
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
