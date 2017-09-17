using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        // for some locales the data format has to be set eg. below
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        // changing column title and removing time
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        //requires globalization to allow chars other than '.'
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Required]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}