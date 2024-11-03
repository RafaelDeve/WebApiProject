using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Book
    {
        public int Id {get;set;}
        public string Title {get; set;} = string.Empty;
        public string Genre {get; set;} = string.Empty;
        public string Author {get;set;} = string.Empty;
        public int Year {get;set;}

    }
}