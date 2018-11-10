using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    class LINQBasedFieldsAreClunky
    {
        private static string[] currentVideogames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
        private IEnumerable<string> subset = from q in currentVideogames where q.Contains(" ") orderby q select q;
        public void PrintGames()
        {
            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Car
    {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }
    }


    public struct Square
    {
        public int Length { get; set; }

        public Square( int l ) : this()
        {
            Length = l;
        }
        
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        { return string.Format("[Length = {0}]", Length); }

        #region Conversion operations
        // Rectangles can be explicitly converted
        // into Squares.
        public static explicit operator Square( Rectangle r )
        {
            Square s = new Square();
            s.Length = r.Height;
            return s;
        }

        public static explicit operator Square( int sideLength )
        {
            Square newSq = new Square();
            newSq.Length = sideLength;
            return newSq;
        }

        public static explicit operator int( Square s )
        { return s.Length; }
        #endregion
    }

}
