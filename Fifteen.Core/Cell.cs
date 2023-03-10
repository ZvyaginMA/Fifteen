using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.Core
{
    public class Cell
    {
        public bool IsEmpty;
        public int Val;
        
        
        public Cell(int val) { 
            Val = val;
            IsEmpty = false;
        }

        public Cell(bool isEmpty)
        {
            if (isEmpty)
            {
                IsEmpty = true;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void MakeEmpty()
        {
            IsEmpty = true;
            Val = 0;
        }
    }
}
