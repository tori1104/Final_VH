using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DWD278_FinalProject_VH.Models
{
    public class Rating
    {
        public int ID { get; set; }

        [DisplayName("Rating")]
        public string Description { get; set; }
    }
}