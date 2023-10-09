using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookstoreApi.Models
{
    public partial class BookDetails
    {
        public int BookId { get; set; }
        public string TitleOfSource { get; set; }
        public string TitleOfContainer { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string VolumeNo { get; set; }
        public string PageRange { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
    }
}
