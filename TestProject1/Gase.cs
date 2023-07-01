using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    abstract class Gase
    {
        public double thickness;
        public Gase(double thickness)
        {
            this.thickness = thickness;
        }
        public Gase() { }
        public bool Exist() { return thickness > 0.5; }
        public void ModifyThickness(double thick) {
            thickness -= thickness * thick; 
        }
        
        public double GetThickness() { return  thickness; }

        public void Print(List<Gase> g)
        {
            for (int i = 0; i < g.Count; ++i)
            {
                Console.WriteLine(g[i]);
            }
        }
        public abstract char Type();
        public abstract Gase Traverse(IAtmo atmo);
        public abstract string ToString();

        public double tChange(double th)
        {
            return thickness - th;
        }
    }

    class Ozone : Gase
    {
        public Ozone(double thickness) : base(thickness){}
       
        public override Gase Traverse(IAtmo atmo)
        {
            atmo.ChangeZ(this);
            double a = 0;
            switch (atmo)
            {
                case Other : a = this.thickness / 0.95;
                    return new Oxygen(a - this.thickness);
                default: return null;
            }
        }

        public override string ToString()
        {
            return "Ozone " + String.Format("{0:0.00}", thickness);
        }

        public override char Type()
        {
            return 'Z';    
        }
    }

    class Oxygen : Gase
    {
        public Oxygen(double thickness) : base(thickness) { }
        public override Gase Traverse(IAtmo atmo)
        {
            atmo.ChangeX(this);
            double a = 0;
            switch (atmo)
            {
                case Thunderstrom: return new Ozone(this.thickness); break;
                case Sunshine: a = this.thickness / 0.95;
                    return new Ozone(a - this.thickness); break;
                case Other : a =  this.thickness / 0.9;
                    return new Carbon(a - this.thickness); break;
                default: return null;
            }
        }

        public override string ToString()
        {
            return "Oxygen " + String.Format("{0:0.00}", thickness);
        }

        public override char Type()
        {
            return 'O';
        }
    }

    class Carbon : Gase
    {
        public Carbon (double thickness) : base(thickness) { }
        public override Gase Traverse(IAtmo atmo)
        {
           atmo.ChangeC(this);
            double a = 0;
           switch (atmo)
           {
               case Sunshine: a = this.thickness / 0.95;
                    return new Oxygen(a - this.thickness);
               default: return null;
           }
        }
        public override string ToString()
        {
            return "Carbon " + String.Format("{0:0.00}", thickness);
        }

        public override char Type()
        {
            return 'C';
        }
    }
}
