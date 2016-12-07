using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWD278_FinalProject_VH.Models
{
    public class ToWatchList
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int GenreID { get; set; }

        public int RatingID { get; set; }

        public string Description { get; set; }

        public int TypeStatusID { get; set; }



        [ForeignKey("GenreID")]
        public virtual Genre Genre { get; set; }

        [ForeignKey("RatingID")]
        public virtual Rating Rating { get; set; }

        [ForeignKey("TypeStatusID")]
        public virtual TypeStatus TypeStatus { get; set; }
    }
}