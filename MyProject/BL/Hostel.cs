using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BL
{
    class Hostel
    {
        public int capacity;
        public int floornumber;

        public Hostel(int floornumber, int capacity)
        {
            this.floornumber = floornumber;
            this.capacity = capacity;

        }
    }
}
