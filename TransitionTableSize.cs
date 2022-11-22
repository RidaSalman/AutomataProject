using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_Project
{
    public static class TransitionTableSize
    {
        public static int[][] transitiontablearray(int rows,int colums)
        {
            int[][] array = new int[rows][];
            for(int i = 0;i < rows; i++)
            {
                array[i] = new int[colums];
            }

            return array;
        }
    }
}
