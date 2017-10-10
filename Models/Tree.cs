using System;
using System.ComponentModel.DataAnnotations;
using static System.Math;

namespace OrangeOrchard.Models
{
    public class Tree
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        /*possibly ditch in favour of just age
        [Display(Name = "Year Planted")]
        [DataType(DataType.Year)]
        public DateTime YearPlanted { get; set; }*/

        [Range(1, 150)]
        public int Age { get; set; }
        //uses year planted and ?current year?
        
        /*Create oranges class
        [Display(Name = "Number of Oranges")]
        [Range(1, 100)]
        public int NumOranges { get; set; }*/
        public string Genre {get; set;}
    }
}