using System;
using System.Collections.Generic;

namespace H2T2
{
    public class Game
    {
        private Map map;

        public Game(List<char[]> map)
        {
            this.map = new Map(map);
        }

        private class Map
        {
            public (int, int) Coords { get; set; }
            public List<char[]> Field { get; set; }

            public Map(List<char[]> field)
            {
                Field = field;
                Coords = FirstEmpty();
                SetCharacter();
            }

            public void ClearCharacter()
            {
                Field[Coords.Item1][Coords.Item2] = ' ';
            }

            public void SetCharacter()
            {
                Field[Coords.Item1][Coords.Item2] = '@';
            }

            private (int, int) FirstEmpty()
            {
                for (int i = 0; i < Field.Count; ++i)
                {
                    for (int j = 0; j < Field[i].Length; ++j)
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

        public void OnRight(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1, map.Coords.Item2 + 1)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1, map.Coords.Item2 + 1);
                map.SetCharacter();
            }
        }

        public void OnLeft(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1, map.Coords.Item2 - 1)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1, map.Coords.Item2 - 1);
                map.SetCharacter();
            }
        }

        public void OnTop(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1 - 1, map.Coords.Item2)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1 - 1, map.Coords.Item2);
                map.SetCharacter();
            }
        }

        public void OnBottom(object sender, EventArgs args)
        {
            if (IsFree((map.Coords.Item1 + 1, map.Coords.Item2)))
            {
                map.ClearCharacter();
                map.Coords = (map.Coords.Item1 + 1, map.Coords.Item2);
                map.SetCharacter();
            }
        }

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