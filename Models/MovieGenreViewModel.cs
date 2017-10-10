using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OrangeOrchard.Models
{
    public class MovieGenreViewModel
    {
        public List<Tree> trees;
        public SelectList genres;
        public string movieGenre { get; set; }
    }
}