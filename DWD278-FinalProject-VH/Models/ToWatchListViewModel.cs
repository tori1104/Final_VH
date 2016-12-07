using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWD278_FinalProject_VH.Models
{
    public class ToWatchListViewModel
    {
        public List<ToWatchList> Movie { get; internal set; }
        public List<ToWatchList> Show { get; internal set; }
        public List<ToWatchList> ToWatchList { get; set; }
    }
}