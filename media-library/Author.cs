using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace media_library
{
    public class Author
    {
        public String Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
