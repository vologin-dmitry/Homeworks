using System;
using System.Collections.Generic;

namespace H6T2
{
    /// <summary>
    /// The class of the game about the character moving between the walls
    /// </summary>
    public class Game
    {
        private Map map;

        /// <summary>
        /// Constructor, which initializes game field
        /// </summary>
        /// <param name="map">Field, on which you will play</param>
        public Game(List<string> map)
        {
            this.map = new Map(map);
        }

        /// <summary>
        /// Map, on which you play
        /// </summary>
        private class Map
        {
            /// <summary>
            /// Coordinates of player
            /// </summary>
            public (int, int) Coords { get; set; }

            /// <summary>
            /// Game field
            /// </summary>
            public List<string> Field { get; set; }

            /// <summary>
            /// Constructor, which initializes game field
            /// </summary>
            /// <param name="field">Game field</param>
            public Map(List<string> field)
            {
                Field = field;
                Coords = FirstEmpty();
                SetCharacter();
            }

            /// <summary>
            /// Deletes character from map
            /// </summary>
            public void ClearCharacter()
            {
                Field[Coords.Item1] = Field[Coords.Item1].Replace('@', ' ');
            }

            /// <summary>
            /// Sets character to map
            /// </summary>
            public void SetCharacter()
            {
                var temp = Field[Coords.Item1].ToCharArray();
                temp[Coords.Item2] = '@';
                Field[Coords.Item1] = new string(temp);
            }

            private (int, int) FirstEmpty()
            {
                for (int i = 1; i < Field.Count - 1; ++i)
                {
                    for (int j = 1; j < Field[i].Length - 1; ++j)
                    {
                        if (Field[i][j] == ' ')
                        {
                            return (i, j);
                        }
                    }
                }
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// The character goes to the right if there is no wall
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="args">Empty parameters</param>
        public void OnRight(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1, map.Coords.Item2 + 1)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1, map.Coords.Item2 + 1);
                map.SetCharacter();
            }
        }

        /// <summary>
        /// The character goes to the left if there is no wall
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="args">Empty parameters</param>
        public void OnLeft(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1, map.Coords.Item2 - 1)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1, map.Coords.Item2 - 1);
                map.SetCharacter();
            }
        }

        /// <summary>
        /// The character goes to the up if there is no wall
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="args">Empty parameters</param>
        public void OnTop(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1 - 1, map.Coords.Item2)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1 - 1, map.Coords.Item2);
                map.SetCharacter();
            }
        }

        /// <summary>
        /// The character goes to the down if there is no wall
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="args">Empty parameters</param>
        public void OnBottom(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1 + 1, map.Coords.Item2)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1 + 1, map.Coords.Item2);
                map.SetCharacter();
            }
        }

        /// <summary>
        /// Displays the map on the console
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="args">Empty parameters</param>
        public void Draw(object sender, EventArgs args)
        {
            Console.SetCursorPosition(0, 0);
            foreach (var line in map.Field)
            {
                foreach (var ch in line)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
        }

        private bool IsFree((int, int) coords)
            => map.Field[coords.Item1][coords.Item2] != '#';
    }
}