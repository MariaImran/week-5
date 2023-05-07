using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week_5_PD.bl
{
    class angle
    {
        public int degrees;
        public float minutes;
        public char direction;
        
        public angle(int deg, float min, char dir)
        {
            degrees = deg;
            minutes = min;
            direction = dir;
        }
        public override string ToString()
        {
            return string.Format("{0}*,{1}',{2}''", degrees, minutes, direction);
        }
    }