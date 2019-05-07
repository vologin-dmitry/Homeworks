namespace H6T2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var game = new Game(FileReader.MakeList("Map.txt"));
            game.Draw(game, null);
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.TopHandler += game.OnUp;
            eventLoop.BottomHandler += game.OnDown;
            eventLoop.LeftHandler += game.Draw;
            eventLoop.RightHandler += game.Draw;
            eventLoop.TopHandler += game.Draw;
            eventLoop.BottomHandler += game.Draw;
            eventLoop.Run();
        }
    }
}
