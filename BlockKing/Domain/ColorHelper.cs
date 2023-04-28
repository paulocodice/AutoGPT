using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wacton.Unicolour;

namespace BlockKing.Data.Domain
{
    //Colorhelper functions for the domain
    public static class ColorHelper
    {
        public static Unicolour RandomColor()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            return Unicolour.FromHsl(random.Next(0, 255), 1.0, 0.5);  //bright color
        }
    }
}
