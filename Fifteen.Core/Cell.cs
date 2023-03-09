using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.Core
{
    public class Cell
    {
        public bool IsEmpty;
        public int Value;
    
        public Cell(int val) { 
            Value = val;
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
            Value = 0;
        }
    }
}
