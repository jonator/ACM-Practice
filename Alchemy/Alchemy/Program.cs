using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://open.kattis.com/problems/alchemy
/// </summary>
namespace Alchemy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCircles = Convert.ToInt32(Console.ReadLine());
            List<Circle> circles = new List<Circle>();
            int circleiditerator = 0;
            while (numOfCircles > 0)
            {
                circleiditerator++;
                string[] line = Console.ReadLine().Split(' ');
                int id = circleiditerator;
                int x = Convert.ToInt32(line[0]);
                int y = Convert.ToInt32(line[1]);
                int r = Convert.ToInt32(line[2]);
                int f2w = Convert.ToInt32(line[3]);
                int w2f = Convert.ToInt32(line[4]);
                circles.Add(new Circle(id, x, y, r, f2w, w2f));
                numOfCircles--;
            }
        }

        static List<List<Circle>> ArrangeIntoPilesOnXY(List<Circle> circles)
        {
            Dictionary<Tuple<int, int>, List<Circle>> dictionary = new Dictionary<Tuple<int, int>, List<Circle>>();
            foreach (Circle c in circles)
            {
                if (dictionary.TryGetValue(c.Center, out List<Circle> foundList))
                {
                    foundList.Add(c);
                }
                else
                {
                    List<Circle> newListOfCircles = new List<Circle>();
                    newListOfCircles.Add(c);
                    dictionary.Add(c.Center, newListOfCircles);
                }
            }
        }

        // returns max E val of pile
        static int OrderPileByEnergy(List<Circle> circles)
        {

        }
    }

    class Circle
    {
        int Id;
        public Tuple<int, int> Center;
        public int Radius;
        public int EReleasedFire2Wat;
        public int EReleasedWat2Fire;
        public Circle(int id, int x, int y, int r, int f2w, int w2f)
        {
            Center = new Tuple<int, int>(x, y);
            Radius = r;
            EReleasedFire2Wat = f2w;
            EReleasedWat2Fire = w2f;
        }
    }
}
