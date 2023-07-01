using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    interface IAtmo
    {
        void ChangeZ(Ozone z);
        void ChangeX(Oxygen o);
        void ChangeC(Carbon c);
    }

    class Thunderstrom : IAtmo
    {
        public void ChangeC(Carbon c)
        {
            c.ModifyThickness(0);
        }

        public void ChangeX(Oxygen o)
        {
            o.ModifyThickness(0.5);
        }

        public void ChangeZ(Ozone z)
        {
            z.ModifyThickness(0);
        }


        public Thunderstrom() { }

        private static Thunderstrom instance = null;
        public static Thunderstrom Instance()
        {
            if (instance == null)
            {
                instance = new Thunderstrom();
            }
            return instance;
        }
    }

    class Sunshine : IAtmo
    {
        public void ChangeC(Carbon c)
        {
            c.ModifyThickness(0.05);
        }

        public void ChangeX(Oxygen o)
        {
            o.ModifyThickness(0.05);
        }

        public void ChangeZ(Ozone z)
        {
            z.ModifyThickness(0);
        }

        private Sunshine() { }

        private static Sunshine instance = null;
        public static Sunshine Instance()
        {
            if (instance == null)
            {
                instance = new Sunshine();
            }
            return instance;
        }
    }

    class Other : IAtmo
    {
        public void ChangeC(Carbon c)
        {
            c.ModifyThickness(0);
        }
        public void ChangeX(Oxygen o)
        {
            o.ModifyThickness(0.1);
        }
        public void ChangeZ(Ozone z)
        {
            z.ModifyThickness(0.05);
           
        }

        private Other() { }

        private static Other instance = null;
        public static Other Instance()
        {
            if (instance == null)
            {
                instance = new Other();
            }
            return instance;
        }

    }
}
