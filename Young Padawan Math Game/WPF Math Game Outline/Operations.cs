using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Learned from: https://stackoverflow.com/questions/2844899/how-to-get-global-access-to-enum-types-in-c

namespace WPF_Math_Game_Outline
{
    public static class Operations
    {
        /// <summary>
        /// Enum so the whole program can access them
        /// </summary>
        public enum MathType
        {
            Add, Subtract, Multiply, Divide
        }
    }
}
