using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace media_library
{
    public class Song
    {
        public String Title { get; set;  }

        public String Directory { get; set; }

        public Author SongAuthor { get; set; }

        public override string ToString()
        {
            return "Title: " + Title + ", Directory: " + SongAuthor.ToString();
        }
    }
}
