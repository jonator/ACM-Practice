using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://open.kattis.com/problems/classy
/// </summary>
namespace A_Classy_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int cases = Convert.ToInt32(Console.ReadLine());
            while (cases > 0)
            {
                int familymemcount = Convert.ToInt32(Console.ReadLine());
                CasteNode familyRoot = new CasteNode();
                while (familymemcount > 0)
                {
                    string[] line = Console.ReadLine().Split(' ');
                    string name = line[0].Trim(':');
                    string[] heirarchy = line[1].Split('-');
                    familyRoot.AddNode(name, heirarchy);
                    familymemcount--;
                }
                StringBuilder sb = new StringBuilder();
                familyRoot.InorderPrint(sb);
                Console.Write(sb.ToString());
                Console.WriteLine("==============================");
                cases--;
            }
            Console.ReadLine();
        }

        class CasteNode
        {
            List<string> names = new List<string>();
            CasteNode Upper = null;
            CasteNode Middle = null;
            CasteNode Lower = null;
            public void AddNode(string name, string[] isclass)
            {
                if (isclass.Length == 0)
                {
                    names.Add(name);
                    names.Sort();
                }
                else
                {
                    string[] newclasses = new string[isclass.Length - 1];
                    Array.ConstrainedCopy(isclass, 1, newclasses, 0, isclass.Length - 1);
                    switch (isclass[0])
                    {
                        case "upper":
                            if (Upper == null) Upper = new CasteNode();
                            Upper.AddNode(name, newclasses);
                            break;
                        case "middle":
                            if (Middle == null) Middle = new CasteNode();
                            Middle.AddNode(name, newclasses);
                            break;
                        case "lower":
                            if (Lower == null) Lower = new CasteNode();
                            Lower.AddNode(name, newclasses);
                            break;
                    }
                }
            }
            public void InorderPrint(StringBuilder sb)
            {
                foreach (string name in names)
                {
                    sb.AppendLine(name);
                }
                if (Upper != null) Upper.InorderPrint(sb);
                if (Middle != null) Middle.InorderPrint(sb);
                if (Lower != null) Lower.InorderPrint(sb);
            }
        }
    }
}
