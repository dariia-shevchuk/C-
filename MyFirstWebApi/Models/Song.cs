using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebApi.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Album { get; set; }

        public int ReleaseYear { get; set; }
    }
}
