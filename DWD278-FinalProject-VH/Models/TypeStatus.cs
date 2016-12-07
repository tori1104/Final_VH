using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DWD278_FinalProject_VH.Models
{
    public class TypeStatus
    {
        public int ID { get; set; }

        [DisplayName("TypeStatus")]
        public string Description { get; set; }
    }
}