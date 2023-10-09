using BookstoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApi.Viewmodel
{
    public class BookViewmodel
    {
        public BookDetails BookDetails { get; set; }
        public string MLACitation { get; set; }
        public string ChicagoCitation { get; set; }
    }
}
