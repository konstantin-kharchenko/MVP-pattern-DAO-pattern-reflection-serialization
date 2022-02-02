using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public enum property {
        NotRead, Read, Awaiting, Nothing
    }

    public class Book:  BusinessObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int PagesRead { get; set; }
        public string Description { get; set; }
        public DateTime TimePublications { get; set; }
        public string Author_ID { get; set; }
        public string Genre_ID { get; set; }
        public bool NotRead { get; set; }
        public bool Awaiting { get; set; }
        public bool Read { get; set; }
        public string ImagePath { get; set; }
        public property Property;

        public Book()
        {
            //Author_ = new Author();
            //Genre_ = new Genre();
        }

    }
}
