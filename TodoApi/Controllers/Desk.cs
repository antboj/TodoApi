using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    // Extends abstract class Item
    public class Desk : Item
    {
        private string Name;

        public void SetDesk(string name)
        {
            Name = name;
        }

    }
    
}
