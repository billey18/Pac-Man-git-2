using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Pac_Man_6
{
    internal class Spaces
    {
        private char value;
        private int x;
        private int y;

        public Spaces(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }


        public char getValue()
        {

            return value;
        }


        public void setValue(char value) 
        { 
        
        this.value = value;
        }

        public int getX() 
        { 
        return x;
        
        }

        public int getY()
        {
            return y;

        }

        public bool playerOnBoard()
        {
            if (value == 'P')
            {
                return true;
            }
            return false;

        }

        public bool ghostOnBoard(char ghostDirection)
        {
            if (value == ghostDirection)
            {
                return true;
            }
            return false;
        }

    }


}