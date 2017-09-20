using System;
using System.ComponentModel.DataAnnotations;

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
        
        [Range(1, 100)]
        public int Height { 
            get;
            set
            {
                //use of magic number 15 for max height(m) of orange tree
                if (Tree.Age <= 15)
                {
                this.Height = Tree.Age * 1;
                }
                else if (Tree.Age >=16)
                {
                    //magic number
                    this.Height = 15;
                }
                else
                {
                    throw new Exception("Invalid Age to process Height");
                }
            };
        }
        //requires age to process
        
        //possibly create own model for this and only show on inspection
        [Display(Name = "Number of Oranges")]
        [Range(1, 100)]
        public int NumOranges { get; set; }
    }
}