using System;

namespace H6T2
{
    /// <summary>
    /// Supports game work
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<EventArgs> TopHandler = (sender, args) => { };
        public event EventHandler<EventArgs> BottomHandler = (sender, args) => { };
        public event EventHandler<EventArgs> ExitHandler = (sender, args) => { };

        /// <summary>
        /// Reads actions and allows the game to respond to them
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        TopHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        BottomHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
