using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.DTOs
{
    public class MovieDto : BaseModelDto
    {
        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

    }
}