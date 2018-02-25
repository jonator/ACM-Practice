using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://open.kattis.com/problems/mancala
/// </summary>
namespace Mancala
{
    class Program
    {
        static void Main(string[] args)
        {
            int setNum = Convert.ToInt32(Console.ReadLine());
            int atSet = 1;
            while (setNum > 0)
            {
                string[] line = Console.ReadLine().Split(' ');
                int ruma = Convert.ToInt32(line[1]);

                List<int> board = new List<int>();
                while (ruma > 0)
                {
                    int hand = 1;
                    ruma--;
                    if (board.Count == 0) board.Add(hand);
                    else
                    {
                        for (int i = 0; i < board.Count; i++)
                        {
                            if (board[i] > 0)
                            {
                                board[i]--;
                                hand++;
                            }
                            else if (board[i] == 0)
                            {
                                board[i] = hand;
                                break;
                            }
                            if (i == board.Count - 1)
                            {
                                board.Add(hand);
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(atSet + " " + board.Count);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < board.Count; i++)
                {
                    sb.Append(board[i] + " ");
                    if ((i + 1) % 10 == 0 && i > 0)
                    {
                        sb.Append("\n");
                    }
                }
                Console.WriteLine(sb.ToString());
                setNum--;
                atSet++;
            }
            Console.ReadLine();
        }
    }
}
