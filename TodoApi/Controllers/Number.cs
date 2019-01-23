using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    // Extends INumber Interface
    public class Number : INumber
    {
        private int Num;
        
        // Interface methods
        public void SetNum(int num)
        {
            Num = num;
        }

        public int GetNum()
        {
            return Num;
        }
    }
}
