using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApi.Viewmodel
{
    public class PostBookViewModel
    {
        [Required]
        public string TitleOfSource { get; set; }
        public string TitleOfContainer { get; set; }
        public string AuthorLastName { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        public string VolumeNo { get; set; }
        public string PageRange { get; set; }
        public string Url { get; set; }
        [Required]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal Price { get; set; }
    }
}
