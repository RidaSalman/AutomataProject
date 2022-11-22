using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_Project
{
    class Logic
    {
        public static int MAX_CHAR = 256;

        public static int nextState(char[] keyword, int keywordL, int state, int x)
        {
            if (state < keywordL && (char)x == keyword[state])
            {
                return state + 1;
            }
            int nextstate, i;
            for (nextstate = state; nextstate > 0; nextstate--)
            {
                if (keyword[nextstate - 1] == (char)x)
                {
                    for (i = 0; i < nextstate - 1; i++)
                    {
                        if (keyword[i] != keyword[state - nextstate + 1 + i])
                        {
                            break;
                        }
                    }
                    if (i == nextstate - 1)
                    {
                        return nextstate;
                    }
                }
            }
            return 0;
        }

        public static void buildingTransitionTable(char[] keyword, int keywordL, int[][] tranitionframe)
        {
            int state, x;

            for (state = 0; state <= keywordL; ++state)
            {
                for (x = 0; x < MAX_CHAR; ++x)
                {
                    tranitionframe[state][x] = nextState(keyword, keywordL,state, x);
                } 
            }
        }

        public static void findKeywords(char[] keyword, char[] text)
        {
            int keywordL = keyword.Length;
            int textL    = text.Length;
            

            int[][] transitionframe = TransitionTableSize.transitiontablearray(keywordL + 1, MAX_CHAR);
            buildingTransitionTable(keyword, keywordL, transitionframe);

            int[] locations = new int[textL];
            
            int i, state = 0, count = 0;
            for (i = 0; i < textL; i++)
            {
                state = transitionframe[state][text[i]];
                if (state == keywordL)
                {
                    Console.WriteLine("Keyword found at index " + (i - keywordL + 2));
 
                    int k = i - keywordL + 2;
                    locations[count++] = k; 
                }
                else if (count == 0 && i == textL - 1)
                {
                    Console.WriteLine("Not Found !");
                }
            }
            count = 0;


            for (int j = 0; j < textL; j++)
            {
                if (j + 1 == locations[count])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    count++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(text[j]);
            }
        }
    }
}
