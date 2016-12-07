using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DWD278_FinalProject_VH.Models
{
    public class Genre
    {
        public int ID { get; set; }

        [DisplayName("Genre")]
        public string Description { get; set; }
    }
}