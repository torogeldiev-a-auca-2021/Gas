using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace ConsoleApp4
{
    internal class Program
    {
        public  static void Transform(List<Gase> gases, IAtmo atmo)
        {
            int index = 0;
            for (int i = 0; i < gases.Count; i++)
            {
                Gase tmp = gases[i].Traverse(atmo);
                if (tmp != null)
                {
                        index = i;
                        bool b = false;
                        for (int j = 0; j < index; j++)
                        {
                            if (tmp.Type() == gases[j].Type())
                            {
                                gases[j].thickness += tmp.thickness;
                                b = true;
                                 break;
                            }
                        }
                        if (!b && tmp.thickness > 0.5)
                        {
                            gases.Insert(0, tmp);  
                        }

                    if (gases[i].thickness < 0.5)
                    {
                        gases.Remove(gases[i]);
                    }
                }  
            }         
        }

        static void Main()
        {
            TextFileReader r = new("input.txt");
            r.ReadLine(out string line);
            int n = int.Parse(line);
            List<Gase> g = new List<Gase>();
            for (int i = 0; i < n; i++)
            {
                char[] sep = new char[] { ' ', '\t' };
                Gase gase = null;

                if (r.ReadLine(out line))
                {
                    string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    char c = char.Parse(tokens[0]);
                    double d = double.Parse(tokens[1]);

                    switch (c)
                    {
                        case 'Z': gase = new Ozone(d); break;
                        case 'X': gase = new Oxygen(d); break;
                        case 'C': gase = new Carbon(d); break;
                    }
                }
                g.Add(gase);

            }

            string line2 = r.ReadLine();
            List<IAtmo> atmo = new();
            for (int j = 0; j < line2.Length; j++)
            {
                char c = line2[j];
                switch (c)
                {
                    case 'T': atmo.Add(Thunderstrom.Instance()); break;
                    case 'S': atmo.Add(Sunshine.Instance()); break;
                    case 'O': atmo.Add(Other.Instance()); break;
                }
            }
            int day = 1;
            int cnt = 0;

            while (g.Count < n * 3  && g.Count >= 3)
            {
                for (int j = 0; j < atmo.Count; ++j)
                {
                    Transform(g, atmo[j]);
                    if (g.Count <= n * 3 && g.Count >= 2)
                    {
                        
                        if (g.Count == 2)
                        {
                            cnt++;
                        }
                        if (cnt <= 1)
                        {
                            Console.WriteLine($"Day : {day} ");
                            foreach (Gase gs in g)
                            {
                                if (gs.thickness > 0.5)
                                    Console.WriteLine(gs.ToString());
                            }
                            Console.WriteLine();
                            day++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
